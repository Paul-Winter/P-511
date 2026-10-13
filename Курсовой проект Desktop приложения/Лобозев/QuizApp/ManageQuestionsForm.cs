using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class ManageQuestionsForm : Form
    {
        private ListBox lstQuestions;
        private Button btnDelete, btnClearAll, btnClose;
        private Label lblCount;

        private List<Question> questions;
        private string questionsFile;

        public bool Changed { get; private set; }

        public List<Question> UpdatedQuestions { get; private set; }

        public ManageQuestionsForm(List<Question> questions, string questionsFile)
        {
            InitializeComponent();

            this.questions = new List<Question>();
            foreach (Question q in questions)
            {
                Question copy = new Question();
                copy.Text = q.Text;
                copy.Answers = new List<string>(q.Answers);
                copy.CorrectIndex = q.CorrectIndex;
                this.questions.Add(copy);
            }
            this.questionsFile = questionsFile;

            BuildUI();
            RefreshList();
        }

        // ============================================================
        //                    ИНТЕРФЕЙС
        // ============================================================
        private void BuildUI()
        {
            Text = "Управление вопросами";
            ClientSize = new Size(700, 460);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10f);

            Label lblTitle = new Label();
            lblTitle.Text = "Все вопросы:";
            lblTitle.Location = new Point(15, 12);
            lblTitle.Size = new Size(200, 22);
            lblTitle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            Controls.Add(lblTitle);

            lblCount = new Label();
            lblCount.Location = new Point(500, 12);
            lblCount.Size = new Size(185, 22);
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            lblCount.ForeColor = Color.DimGray;
            Controls.Add(lblCount);

            lstQuestions = new ListBox();
            lstQuestions.Location = new Point(15, 38);
            lstQuestions.Size = new Size(670, 340);
            lstQuestions.Font = new Font("Segoe UI", 10f);
            lstQuestions.IntegralHeight = false;
            lstQuestions.DoubleClick += (s, e) => ShowSelectedQuestion();
            Controls.Add(lstQuestions);

            btnDelete = new Button();
            btnDelete.Text = "🗑 Удалить выбранный";
            btnDelete.Location = new Point(15, 392);
            btnDelete.Size = new Size(210, 45);
            btnDelete.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnDelete.BackColor = Color.MistyRose;
            btnDelete.Click += btnDelete_Click;
            Controls.Add(btnDelete);

            btnClearAll = new Button();
            btnClearAll.Text = "🗑 Очистить всё";
            btnClearAll.Location = new Point(235, 392);
            btnClearAll.Size = new Size(160, 45);
            btnClearAll.Font = new Font("Segoe UI", 10f);
            btnClearAll.BackColor = Color.LightCoral;
            btnClearAll.Click += btnClearAll_Click;
            Controls.Add(btnClearAll);

            btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Location = new Point(555, 392);
            btnClose.Size = new Size(130, 45);
            btnClose.Font = new Font("Segoe UI", 10f);
            btnClose.Click += (s, e) => { SaveIfChanged(); Close(); };
            Controls.Add(btnClose);

            CancelButton = btnClose;
        }

        // ============================================================
        //                    СПИСОК
        // ============================================================
        private void RefreshList()
        {
            lstQuestions.Items.Clear();

            for (int i = 0; i < questions.Count; i++)
            {
                Question q = questions[i];

                string text = q.Text;
                if (text.Length > 80) text = text.Substring(0, 77) + "...";

                lstQuestions.Items.Add((i + 1) + ". " + text);
            }

            lblCount.Text = "Всего: " + questions.Count;
        }

        private int GetSelectedIndex()
        {
            if (lstQuestions.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите вопрос из списка.");
                return -1;
            }
            return lstQuestions.SelectedIndex;
        }

        private void ShowSelectedQuestion()
        {
            int i = GetSelectedIndex();
            if (i < 0) return;

            Question q = questions[i];
            string msg = "Вопрос:\n" + q.Text + "\n\nВарианты:\n";
            for (int k = 0; k < q.Answers.Count; k++)
            {
                string mark = (k == q.CorrectIndex) ? "  ✅ " : "     ";
                msg += mark + (k + 1) + ") " + q.Answers[k] + "\n";
            }
            MessageBox.Show(msg, "Просмотр вопроса");
        }

        // ============================================================
        //                    УДАЛЕНИЕ
        // ============================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = GetSelectedIndex();
            if (i < 0) return;

            Question q = questions[i];
            string shortText = q.Text.Length > 60
                ? q.Text.Substring(0, 57) + "..."
                : q.Text;

            DialogResult res = MessageBox.Show(
                "Удалить вопрос?\n\n" + shortText,
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (res != DialogResult.Yes) return;

            questions.RemoveAt(i);
            Changed = true;
            RefreshList();

            if (lstQuestions.Items.Count > 0)
                lstQuestions.SelectedIndex = Math.Min(i, lstQuestions.Items.Count - 1);

            SaveToFile();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (questions.Count == 0)
            {
                MessageBox.Show("Список пуст.");
                return;
            }

            DialogResult res = MessageBox.Show(
                "Удалить ВСЕ " + questions.Count + " вопросов?\n" +
                "Это действие нельзя отменить.",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop);

            if (res != DialogResult.Yes) return;

            questions.Clear();
            Changed = true;
            RefreshList();
            SaveToFile();
        }

        // ============================================================
        //                    СОХРАНЕНИЕ
        // ============================================================
        private void SaveToFile()
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(questions);
                File.WriteAllText(questionsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить: " + ex.Message);
            }
        }

        private void SaveIfChanged()
        {
            if (Changed)
            {
                UpdatedQuestions = questions;
            }
        }
    }
}