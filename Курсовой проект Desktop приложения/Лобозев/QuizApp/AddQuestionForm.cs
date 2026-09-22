using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class AddQuestionForm : Form
    {
        private TextBox txtQuestion;
        private TextBox[] txtAnswers;
        private RadioButton[] rbCorrect;
        private Button btnSave, btnCancel;
        private Label lblInfo;

        public Question NewQuestion { get; private set; }

        public AddQuestionForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Новый вопрос";
            ClientSize = new Size(560, 400);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10f);

            Label lblQ = new Label();
            lblQ.Text = "Вопрос:";
            lblQ.Location = new Point(15, 15);
            lblQ.Size = new Size(100, 22);
            Controls.Add(lblQ);

            txtQuestion = new TextBox();
            txtQuestion.Location = new Point(15, 40);
            txtQuestion.Size = new Size(530, 60);
            txtQuestion.Multiline = true;
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            txtQuestion.Font = new Font("Segoe UI", 11f);
            Controls.Add(txtQuestion);

            Label lblA = new Label();
            lblA.Text = "Варианты ответа (отметьте правильный):";
            lblA.Location = new Point(15, 110);
            lblA.Size = new Size(400, 22);
            lblA.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            Controls.Add(lblA);

            txtAnswers = new TextBox[4];
            rbCorrect = new RadioButton[4];

            for (int i = 0; i < 4; i++)
            {
                int y = 140 + i * 40;

                rbCorrect[i] = new RadioButton();
                rbCorrect[i].Location = new Point(15, y + 5);
                rbCorrect[i].Size = new Size(50, 25);
                rbCorrect[i].Text = "№" + (i + 1);
                rbCorrect[i].Checked = (i == 0);
                Controls.Add(rbCorrect[i]);

                txtAnswers[i] = new TextBox();
                txtAnswers[i].Location = new Point(70, y);
                txtAnswers[i].Size = new Size(475, 28);
                txtAnswers[i].Font = new Font("Segoe UI", 11f);
                Controls.Add(txtAnswers[i]);
            }

            lblInfo = new Label();
            lblInfo.Location = new Point(15, 305);
            lblInfo.Size = new Size(530, 22);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Text = "Заполните вопрос и все 4 варианта. Отметьте правильный.";
            Controls.Add(lblInfo);

            btnSave = new Button();
            btnSave.Text = "💾 Сохранить";
            btnSave.Location = new Point(380, 340);
            btnSave.Size = new Size(165, 40);
            btnSave.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btnSave.BackColor = Color.LightGreen;
            btnSave.Click += btnSave_Click;
            Controls.Add(btnSave);

            btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.Location = new Point(240, 340);
            btnCancel.Size = new Size(130, 40);
            btnCancel.Font = new Font("Segoe UI", 10f);
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            Controls.Add(btnCancel);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQuestion.Text.Trim() == "")
            {
                MessageBox.Show("Введите текст вопроса!");
                txtQuestion.Focus();
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                if (txtAnswers[i].Text.Trim() == "")
                {
                    MessageBox.Show("Заполните вариант ответа №" + (i + 1));
                    txtAnswers[i].Focus();
                    return;
                }
            }

            int correctIndex = 0;
            for (int i = 0; i < 4; i++)
                if (rbCorrect[i].Checked) correctIndex = i;

            Question q = new Question();
            q.Text = txtQuestion.Text.Trim();
            q.Answers = new System.Collections.Generic.List<string>();
            for (int i = 0; i < 4; i++)
                q.Answers.Add(txtAnswers[i].Text.Trim());
            q.CorrectIndex = correctIndex;

            NewQuestion = q;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}