using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        // ============== КОНТРОЛЫ ==============
        private Label lblScore, lblTimer;
        private TextBox txtQuestion;
        private ProgressBar progressBar1;
        private GroupBox grpAnswers;
        private RadioButton rbAnswer1, rbAnswer2, rbAnswer3, rbAnswer4;
        private Button btnNext, btnRestart, btnRecords, btnAdd, btnManage;
        private Timer timerQuestion;

        // ================== ДАННЫЕ ==================
        private List<Question> questions = new List<Question>();
        private int currentIndex = 0;
        private int score = 0;
        private int timeLeft = 15;
        private const int QuestionTime = 15;
        private bool answerLocked = false;

        private const string QuestionsFile = "questions.json";
        private const string ScoresFile = "scores.json";

        public Form1()
        {
            InitializeComponent();
            BuildUI();
            LoadQuestionsFromJson();
            StartQuiz();
        }

        private RadioButton MakeRadio(Point location) => new RadioButton
        {
            Location = location,
            Size = new Size(620, 30),
            Font = new Font("Segoe UI", 12f),
            Text = ""
        };

        private Button MakeButton(string text, Point location, Size size) => new Button()
        {
            Text = text,
            Location = location,
            Size = size,
            Font = new Font("Segoe UI", 10f),
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = true
        };

        // ============================================================
        //                     ИНТЕРФЕЙС
        // ============================================================
        private void BuildUI()
        {
            Text = "Викторина";
            ClientSize = new Size(720, 480);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10f);

            lblScore = new Label();
            lblScore.Text = "Счёт: 0 / 0";
            lblScore.Location = new Point(20, 15);
            lblScore.Size = new Size(300, 25);
            lblScore.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblScore.ForeColor = Color.DarkBlue;
            Controls.Add(lblScore);

            lblTimer = new Label();
            lblTimer.Text = "⏱ 15 сек";
            lblTimer.Location = new Point(520, 15);
            lblTimer.Size = new Size(180, 25);
            lblTimer.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblTimer.ForeColor = Color.DarkRed;
            lblTimer.TextAlign = ContentAlignment.MiddleRight;
            Controls.Add(lblTimer);

            progressBar1 = new ProgressBar();
            progressBar1.Location = new Point(20, 50);
            progressBar1.Size = new Size(680, 18);
            Controls.Add(progressBar1);

            txtQuestion = new TextBox();
            txtQuestion.Location = new Point(20, 85);
            txtQuestion.Size = new Size(680, 70);
            txtQuestion.Font = new Font("Segoe UI", 13f);
            txtQuestion.BackColor = Color.AliceBlue;
            txtQuestion.BorderStyle = BorderStyle.FixedSingle;
            txtQuestion.ReadOnly = true;
            txtQuestion.Multiline = true;
            txtQuestion.WordWrap = true;
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            txtQuestion.TabStop = false;
            Controls.Add(txtQuestion);

            grpAnswers = new GroupBox();
            grpAnswers.Text = "Варианты ответа";
            grpAnswers.Location = new Point(20, 170);
            grpAnswers.Size = new Size(680, 200);
            grpAnswers.Font = new Font("Segoe UI", 10f);
            Controls.Add(grpAnswers);

            rbAnswer1 = MakeRadio(new Point(30, 35));
            rbAnswer2 = MakeRadio(new Point(30, 75));
            rbAnswer3 = MakeRadio(new Point(30, 115));
            rbAnswer4 = MakeRadio(new Point(30, 155));
            grpAnswers.Controls.Add(rbAnswer1);
            grpAnswers.Controls.Add(rbAnswer2);
            grpAnswers.Controls.Add(rbAnswer3);
            grpAnswers.Controls.Add(rbAnswer4);

            btnRestart = MakeButton("🔄 Заново", new Point(20, 390), new Size(140, 45));
            btnRestart.Click += btnRestart_Click;
            Controls.Add(btnRestart);

            btnRecords = MakeButton("🏆 Рекорды", new Point(180, 390), new Size(140, 45));
            btnRecords.Click += btnRecords_Click;
            Controls.Add(btnRecords);

            btnAdd = MakeButton("➕ Добавить вопрос", new Point(340, 390), new Size(210, 45));
            btnAdd.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnAdd.BackColor = Color.LightYellow;
            btnAdd.Click += btnAdd_Click;
            Controls.Add(btnAdd);

            btnManage = MakeButton("📋 Список вопросов", new Point(20, 440), new Size(210, 40));
            btnManage.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnManage.BackColor = Color.LightBlue;
            btnManage.Click += btnManage_Click;
            Controls.Add(btnManage);

            btnNext = MakeButton("Далее ▶", new Point(560, 390), new Size(140, 45));
            btnNext.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btnNext.BackColor = Color.LightGreen;
            btnNext.Click += btnNext_Click;
            Controls.Add(btnNext);

            timerQuestion = new Timer();
            timerQuestion.Interval = 1000;
            timerQuestion.Tick += timerQuestion_Tick;
        }


        // ============================================================
        //                       ЛОГИКА ВИКТОРИНЫ
        // ============================================================

        private void LoadQuestionsFromJson()
        {
            try
            {
                if (!File.Exists(QuestionsFile))
                {
                    questions = GetDefaultQuestions();
                    return;
                }

                var json = File.ReadAllText(QuestionsFile);
                questions = JsonSerializer.Deserialize<List<Question>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? GetDefaultQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки вопросов: {ex.Message}");
                questions = GetDefaultQuestions();
            }
        }

        private List<Question> GetDefaultQuestions() => new List<Question>
        {
        new Question("Столица Франции?",
            new List<string> { "Лондон", "Париж", "Берлин", "Мадрид" }, 1),
        new Question("Сколько будет 7 * 8?",
            new List<string> { "54", "56", "64", "48" }, 1),
        new Question("Какой язык используется в .NET?",
            new List<string> { "Python", "Java", "C#", "Ruby" }, 2),
        new Question("Кто написал 'Войну и мир'?",
            new List<string> { "Толстой", "Достоевский", "Пушкин", "Чехов" }, 0),
        new Question("Самая длинная река в мире?",
            new List<string> { "Нил", "Амазонка", "Янцзы", "Миссисипи" }, 1),
        };

        private void StartQuiz()
        {
            questions = questions.OrderBy(_ => Guid.NewGuid()).ToList();
            foreach (var q in questions) ShuffleAnswers(q);

            currentIndex = 0;
            score = 0;
            btnNext.Enabled = true;
            btnNext.Text = "Далее ▶";
            ShowQuestion();
        }

        private void ShuffleAnswers(Question q)
        {
            var correct = q.Answers[q.CorrectIndex];
            q.Answers = q.Answers.OrderBy(_ => Guid.NewGuid()).ToList();
            q.CorrectIndex = q.Answers.IndexOf(correct);
        }

        private void ShowQuestion()
        {
            if (currentIndex >= questions.Count) { EndQuiz(); return; }

            answerLocked = false;
            timeLeft = QuestionTime;

            var q = questions[currentIndex];
            txtQuestion.Text = $"Вопрос {currentIndex + 1}/{questions.Count}: {q.Text}";

            var radios = new[] { rbAnswer1, rbAnswer2, rbAnswer3, rbAnswer4 };
            for (int i = 0; i < radios.Length; i++)
            {
                radios[i].Text = i < q.Answers.Count ? q.Answers[i] : "";
                radios[i].Checked = false;
                radios[i].ForeColor = Color.Black;
                radios[i].Enabled = true;
            }

            lblScore.Text = $"Счёт: {score} / {questions.Count}";
            lblTimer.Text = $"⏱ {timeLeft} сек";
            lblTimer.ForeColor = Color.DarkRed;

            progressBar1.Maximum = questions.Count;
            progressBar1.Value = currentIndex;

            btnNext.Enabled = true;
            btnNext.Text = (currentIndex == questions.Count - 1) ? "Завершить" : "Далее ▶";

            timerQuestion.Start();
        }

        private void timerQuestion_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = $"⏱ {timeLeft} сек";

            if (timeLeft <= 5) lblTimer.ForeColor = Color.Red;

            if (timeLeft <= 0)
            {
                timerQuestion.Stop();
                CheckAnswer(timeUp: true);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (answerLocked)
            {
                currentIndex++;
                ShowQuestion();
                return;
            }

            var radios = new[] { rbAnswer1, rbAnswer2, rbAnswer3, rbAnswer4 };
            int selected = -1;
            for (int i = 0; i < radios.Length; i++)
                if (radios[i].Checked) selected = i;

            if (selected == -1)
            {
                MessageBox.Show("Выберите ответ!");
                return;
            }

            CheckAnswer(timeUp: false, selectedIndex: selected);
        }

        private void CheckAnswer(bool timeUp, int selectedIndex = -1)
        {
            timerQuestion.Stop();
            answerLocked = true;

            var q = questions[currentIndex];
            var radios = new[] { rbAnswer1, rbAnswer2, rbAnswer3, rbAnswer4 };

            foreach (var rb in radios) rb.Enabled = false;
            radios[q.CorrectIndex].ForeColor = Color.Green;

            if (!timeUp && selectedIndex == q.CorrectIndex)
            {
                score++;
                lblScore.Text = $"Счёт: {score} / {questions.Count}";
            }
            else if (!timeUp && selectedIndex >= 0)
            {
                radios[selectedIndex].ForeColor = Color.Red;
            }
            else if (timeUp)
            {
                lblTimer.Text = "⏱ Время вышло!";
            }
        }

        private void EndQuiz()
        {
            timerQuestion.Stop();
            btnNext.Enabled = false;

            string name = Prompt.ShowDialog("Введите ваше имя:", "Результат");
            if (!string.IsNullOrWhiteSpace(name))
            {
                SaveScore(new ScoreRecord
                {
                    PlayerName = name,
                    Score = score,
                    Total = questions.Count,
                    Date = DateTime.Now
                });
            }

            MessageBox.Show(
                $"Викторина окончена!\nВаш результат: {score} из {questions.Count}",
                "Результат");
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            timerQuestion.Stop();
            StartQuiz();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            var records = LoadScores()
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.Date)
                .Take(10)
                .ToList();

            if (records.Count == 0)
            {
                MessageBox.Show("Рекордов пока нет.");
                return;
            }

            string text = "🏆 Топ-10 рекордов:\n\n";
            int place = 1;
            foreach (var r in records)
                text += $"{place++}. {r.PlayerName} — {r.Score}/{r.Total} ({r.Date:dd.MM.yyyy HH:mm})\n";

            MessageBox.Show(text, "Рекорды");
        }

        private List<ScoreRecord> LoadScores()
        {
            try
            {
                if (!File.Exists(ScoresFile)) return new List<ScoreRecord>();
                var json = File.ReadAllText(ScoresFile);
                return JsonSerializer.Deserialize<List<ScoreRecord>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<ScoreRecord>();
            }
            catch { return new List<ScoreRecord>(); }
        }

        private void SaveScore(ScoreRecord record)
        {
            try
            {
                var all = LoadScores();
                all.Add(record);
                File.WriteAllText(ScoresFile,
                    JsonSerializer.Serialize(all,
                        new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить рекорд: {ex.Message}");
            }
        }
        // ============================================================
        //                  ДОБАВЛЕНИЕ ВОПРОСА
        // ============================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddQuestionForm dlg = new AddQuestionForm();

            if (dlg.ShowDialog(this) != DialogResult.OK) return;
            if (dlg.NewQuestion == null) return;

            questions.Add(dlg.NewQuestion);

            SaveQuestionsToJson();

            MessageBox.Show("Вопрос добавлен!\nВсего вопросов: " + questions.Count);
        }

        private void SaveQuestionsToJson()
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer
                    = new System.Web.Script.Serialization.JavaScriptSerializer();

                string json = serializer.Serialize(questions);
                File.WriteAllText(QuestionsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить вопрос: " + ex.Message);
            }
        }

        // ============================================================
        //              УПРАВЛЕНИЕ ВОПРОСАМИ
        // ============================================================
        private void btnManage_Click(object sender, EventArgs e)
        {
            timerQuestion.Stop();

            ManageQuestionsForm dlg = new ManageQuestionsForm(questions, QuestionsFile);

            dlg.ShowDialog(this);

            if (dlg.Changed && dlg.UpdatedQuestions != null)
            {
                questions = dlg.UpdatedQuestions;

                if (questions.Count == 0)
                {
                    MessageBox.Show("Список вопросов пуст.\n" +
                        "Добавьте новые через «➕ Добавить вопрос».",
                        "Внимание");
                    return;
                }

                StartQuiz();
            }
            else
            {
                timerQuestion.Start();
            }
        }
    }
}
