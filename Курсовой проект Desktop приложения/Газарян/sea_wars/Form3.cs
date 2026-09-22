using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace sea_wars
{
    public partial class Form3 : Form
    {
        public Button[,] playerButtons = new Button[12, 12];
        public Button[,] botButtons = new Button[12, 12];
        public Form3()
        {
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    playerButtons[i, j] = new Button();
                    botButtons[i, j] = new Button();
                }
            }
            InitBoards();
            Datas.botplay.Cleardecks();
            Datas.botplay.Setdeck1auto();
            Datas.botplay.Setdeck2auto();
            UpdateBoards();
            Datas.profile.AuthorizeUser2("Робот", "ImRobotAndImNotHaveAPassword!");
            labellogin.Text = Datas.profile.login2; labellogin.Visible = true;
            labelrating.Text = Convert.ToString(Datas.profile.GetRating(Datas.profile.login2)); labelrating.Visible = true;
            labelwinrate.Text = Datas.profile.GetWinRate(Datas.profile.login2); labelwinrate.Visible = true;
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 1) != "-1") { labelgame1.Text = Datas.profile.GetGameResult(Datas.profile.login2, 1); labelopp1.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 1); labelg1.Visible = true; labelgame1.Visible = true; labelopp1.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 2) != "-1") { labelgame2.Text = Datas.profile.GetGameResult(Datas.profile.login2, 2); labelopp2.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 2); labelg2.Visible = true; labelgame2.Visible = true; labelopp2.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 3) != "-1") { labelgame3.Text = Datas.profile.GetGameResult(Datas.profile.login2, 3); labelopp3.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 3); labelg3.Visible = true; labelgame3.Visible = true; labelopp3.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 4) != "-1") { labelgame4.Text = Datas.profile.GetGameResult(Datas.profile.login2, 4); labelopp4.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 4); labelg4.Visible = true; labelgame4.Visible = true; labelopp4.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 5) != "-1") { labelgame5.Text = Datas.profile.GetGameResult(Datas.profile.login2, 5); labelopp5.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 5); labelg5.Visible = true; labelgame5.Visible = true; labelopp5.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 6) != "-1") { labelgame6.Text = Datas.profile.GetGameResult(Datas.profile.login2, 6); labelopp6.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 6); labelg6.Visible = true; labelgame6.Visible = true; labelopp6.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 7) != "-1") { labelgame7.Text = Datas.profile.GetGameResult(Datas.profile.login2, 7); labelopp7.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 7); labelg7.Visible = true; labelgame7.Visible = true; labelopp7.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 8) != "-1") { labelgame8.Text = Datas.profile.GetGameResult(Datas.profile.login2, 8); labelopp8.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 8); labelg8.Visible = true; labelgame8.Visible = true; labelopp8.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 9) != "-1") { labelgame9.Text = Datas.profile.GetGameResult(Datas.profile.login2, 9); labelopp9.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 9); labelg9.Visible = true; labelgame9.Visible = true; labelopp9.Visible = true; }
            if (Datas.profile.GetGameOpponent(Datas.profile.login2, 10) != "-1") { labelgame10.Text = Datas.profile.GetGameResult(Datas.profile.login2, 10); labelopp10.Text = Datas.profile.GetGameOpponent(Datas.profile.login2, 10); labelg10.Visible = true; labelgame10.Visible = true; labelopp10.Visible = true; }
            Datas.profile.rating1 -= 10;
            Datas.profile.rating2 += 10;
            for (int i = 0; i < 9; i++)
            {
                Datas.profile.wins1[i] = Datas.profile.wins1[i + 1];
                Datas.profile.winsperson1[i] = Datas.profile.winsperson1[i + 1];
                Datas.profile.wins2[i] = Datas.profile.wins2[i + 1];
                Datas.profile.winsperson2[i] = Datas.profile.winsperson2[i + 1];
            }
            Datas.profile.wins1[9] = false;
            Datas.profile.winsperson1[9] = Datas.profile.login2;
            Datas.profile.wins2[9] = true;
            Datas.profile.winsperson2[9] = Datas.profile.login1;
            Datas.profile.UpdateMainArraysFromActivePlayers();
            Datas.profile.SaveToFile(Datas.filePath);
        }
        private void InitBoards()
        {
            int buttonSize = 23;
            int playerX = 26;
            int playerY = 67;
            int botX = 569;
            int buttonStep = 29;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btnPlayer = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(playerX + j * buttonStep, playerY + i * buttonStep),
                        Visible = true,
                        Enabled = false
                    };
                    playerButtons[i + 1, j + 1] = btnPlayer;
                    this.Controls.Add(btnPlayer);
                    Button btnBot = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(botX + j * buttonStep, playerY + i * buttonStep),
                        Visible = true,
                        Tag = new Point(i + 1, j + 1)
                    };
                    botButtons[i + 1, j + 1] = btnBot;
                    btnBot.Click += BotButton_Click;
                    this.Controls.Add(btnBot);
                }
            }
        }
        private void UpdateButtonState(Button btn, int state, bool isEnemy)
        {
            switch (state)
            {
                case 0:
                    btn.Text = "";
                    btn.Enabled = !isEnemy ? false : true;
                    break;
                case 1:
                    btn.Text = "";
                    btn.Enabled = !isEnemy ? false : true;
                    break;
                case 2:
                    if (isEnemy)
                    {
                        btn.Text = "";
                        btn.Enabled = true;
                    }
                    else
                    {
                        btn.Text = "x";
                        btn.Enabled = false;
                    }
                    break;
                case 3:
                    btn.Text = "O";
                    btn.Enabled = false;
                    break;
                case 4:
                    btn.Text = "X";
                    btn.Enabled = false;
                    break;
                case 5:
                    btn.Text = "O";
                    btn.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        public void UpdateBoards()
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    UpdateButtonState(playerButtons[i, j], Datas.botplay.deck1[i, j], false);
                    UpdateButtonState(botButtons[i, j], Datas.botplay.deck2[i, j], true);
                }
            }
        }
        public void DisableBot()
        {
            buttonrobot.Enabled = true;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    botButtons[i, j].Enabled = false;
                }
            }
        }
        public void EnableBot()
        {
            buttonrobot.Enabled = false;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (Datas.botplay.deck2[i, j] == 3 || Datas.botplay.deck2[i, j] == 4 || Datas.botplay.deck2[i, j] == 5)
                        botButtons[i, j].Enabled = false;
                    else
                        botButtons[i, j].Enabled = true;
                }
            }
        }
        private void BotButton_Click(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point pos = (Point)clickedButton.Tag;
            int row = pos.X;
            int col = pos.Y;
            Datas.botplay.status1 = 1; Datas.botplay.status2 = 0;
            int temp = Datas.botplay.Step(row, col);
            if (temp == 0)
            {
                label6.Text = "Промазал, ход робота";
                UpdateBoards();
                DisableBot();
            }
            else if (temp == 1)
            {
                label6.Text = "Ранил, но не убил. Ход игрока";
                UpdateBoards();
                EnableBot();
            }
            else if (temp == 2)
            {
                label6.Text = "Убил! Ход игрока";
                UpdateBoards();
                EnableBot();
                if (Datas.botplay.Checkwin() == 1)
                {
                    Datas.profile.rating1 += 20;
                    Datas.profile.wins1[9] = true;
                    Datas.profile.rating2 -= 20;
                    Datas.profile.wins2[9] = false;
                    buttondemoute.Enabled = false;
                    buttondemoutequit.Enabled = false;
                    buttonexit.Visible = true;
                    DisableBot();
                    buttonrobot.Enabled = false;
                    label6.Text = ("Вы победили.");
                    Datas.profile.UpdateMainArraysFromActivePlayers();
                    Datas.profile.SaveToFile(Datas.filePath);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void buttondemoutequit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите выйти? После выхода вам автоматически зачтется техническое поражение", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void buttondemoute_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите выйти? После выхода вам автоматически зачтется техническое поражение", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
        }

        private void buttonrobot_Click(object sender, EventArgs e)
        {
            Datas.botplay.status1 = 0; Datas.botplay.status2 = 1;
            int temp = Datas.botplay.Step(-1, -1);
            if (temp == 0)
            {
                label6.Text = $"Робот промазал по точке {Datas.lastPoint.X}{(char)(Datas.lastPoint.Y + 64)}, ход игрока";
                UpdateBoards();
                EnableBot();
            }
            else if (temp == 1)
            {
                label6.Text = $"Ранил, но не убил в точке {Datas.lastPoint.X}{(char)(Datas.lastPoint.Y + 64)}. Ход робота";
                UpdateBoards();
                DisableBot();
            }
            else if (temp == 2)
            {
                label6.Text = $"Убил в точке {Datas.lastPoint.X}{(char)(Datas.lastPoint.Y + 64)}! Ход игрока";
                UpdateBoards();
                DisableBot();
                if (Datas.botplay.Checkwin() == 2)
                {
                    buttondemoute.Enabled = false;
                    buttondemoutequit.Enabled = false;
                    buttonexit.Enabled = true;
                    buttonexit.Visible = true;
                    DisableBot();
                    buttonrobot.Enabled = false;
                    label6.Text = ("Робот победил.");
                }
            }
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
