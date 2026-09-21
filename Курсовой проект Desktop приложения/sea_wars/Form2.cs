using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sea_wars
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            string login = Datas.profile.login1;
            labellogin.Text = login; labellogin.Visible = true;
            labelrating.Text = Convert.ToString(Datas.profile.GetRating(login)); labelrating.Visible = true;
            labelwinrate.Text = Datas.profile.GetWinRate(login); labelwinrate.Visible = true;
            if (Datas.profile.GetGameOpponent(login, 1) != "-1") { labelgame1.Text = Datas.profile.GetGameResult(login, 1); labelopp1.Text = Datas.profile.GetGameOpponent(login, 1); labelg1.Visible = true; labelgame1.Visible = true; labelopp1.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 2) != "-1") { labelgame2.Text = Datas.profile.GetGameResult(login, 2); labelopp2.Text = Datas.profile.GetGameOpponent(login, 2); labelg2.Visible = true; labelgame2.Visible = true; labelopp2.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 3) != "-1") { labelgame3.Text = Datas.profile.GetGameResult(login, 3); labelopp3.Text = Datas.profile.GetGameOpponent(login, 3); labelg3.Visible = true; labelgame3.Visible = true; labelopp3.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 4) != "-1") { labelgame4.Text = Datas.profile.GetGameResult(login, 4); labelopp4.Text = Datas.profile.GetGameOpponent(login, 4); labelg4.Visible = true; labelgame4.Visible = true; labelopp4.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 5) != "-1") { labelgame5.Text = Datas.profile.GetGameResult(login, 5); labelopp5.Text = Datas.profile.GetGameOpponent(login, 5); labelg5.Visible = true; labelgame5.Visible = true; labelopp5.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 6) != "-1") { labelgame6.Text = Datas.profile.GetGameResult(login, 6); labelopp6.Text = Datas.profile.GetGameOpponent(login, 6); labelg6.Visible = true; labelgame6.Visible = true; labelopp6.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 7) != "-1") { labelgame7.Text = Datas.profile.GetGameResult(login, 7); labelopp7.Text = Datas.profile.GetGameOpponent(login, 7); labelg7.Visible = true; labelgame7.Visible = true; labelopp7.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 8) != "-1") { labelgame8.Text = Datas.profile.GetGameResult(login, 8); labelopp8.Text = Datas.profile.GetGameOpponent(login, 8); labelg8.Visible = true; labelgame8.Visible = true; labelopp8.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 9) != "-1") { labelgame9.Text = Datas.profile.GetGameResult(login, 9); labelopp9.Text = Datas.profile.GetGameOpponent(login, 9); labelg9.Visible = true; labelgame9.Visible = true; labelopp9.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 10) != "-1") { labelgame10.Text = Datas.profile.GetGameResult(login, 10); labelopp10.Text = Datas.profile.GetGameOpponent(login, 10); labelg10.Visible = true; labelgame10.Visible = true; labelopp10.Visible = true; }
            //Datas.profile.GetTop10(); labeltop1.Text = Datas.profile.result[0]; labeltop2.Text = Datas.profile.result[1]; labeltop3.Text = Datas.profile.result[2]; labeltop4.Text = Datas.profile.result[3]; labeltop5.Text = Datas.profile.result[4]; labeltop6.Text = Datas.profile.result[5]; labeltop7.Text = Datas.profile.result[6]; labeltop8.Text = Datas.profile.result[7]; labeltop9.Text = Datas.profile.result[8]; labeltop10.Text = Datas.profile.result[9];
            //richTextBox1.Lines = Datas.profile.GetTop10Array();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonquit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form2_Load(object sender, EventArgs e)
        {


        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void buttonprofile_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++) Controls.Find($"labelg{i}", true)[0].Visible = false;
            for (int i = 1; i <= 10; i++) Controls.Find($"labelgame{i}", true)[0].Visible = false;
            for (int i = 1; i <= 10; i++) Controls.Find($"labelopp{i}", true)[0].Visible = false;
            string login = Datas.profile.login1;
            labellogin.Text = login; labellogin.Visible = true;
            labelrating.Text = Convert.ToString(Datas.profile.GetRating(login)); labelrating.Visible = true;
            labelwinrate.Text = Datas.profile.GetWinRate(login); labelwinrate.Visible = true;
            if (Datas.profile.GetGameOpponent(login, 1) != "-1") { labelgame1.Text = Datas.profile.GetGameResult(login, 1); labelopp1.Text = Datas.profile.GetGameOpponent(login, 1); labelg1.Visible = true; labelgame1.Visible = true; labelopp1.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 2) != "-1") { labelgame2.Text = Datas.profile.GetGameResult(login, 2); labelopp2.Text = Datas.profile.GetGameOpponent(login, 2); labelg2.Visible = true; labelgame2.Visible = true; labelopp2.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 3) != "-1") { labelgame3.Text = Datas.profile.GetGameResult(login, 3); labelopp3.Text = Datas.profile.GetGameOpponent(login, 3); labelg3.Visible = true; labelgame3.Visible = true; labelopp3.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 4) != "-1") { labelgame4.Text = Datas.profile.GetGameResult(login, 4); labelopp4.Text = Datas.profile.GetGameOpponent(login, 4); labelg4.Visible = true; labelgame4.Visible = true; labelopp4.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 5) != "-1") { labelgame5.Text = Datas.profile.GetGameResult(login, 5); labelopp5.Text = Datas.profile.GetGameOpponent(login, 5); labelg5.Visible = true; labelgame5.Visible = true; labelopp5.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 6) != "-1") { labelgame6.Text = Datas.profile.GetGameResult(login, 6); labelopp6.Text = Datas.profile.GetGameOpponent(login, 6); labelg6.Visible = true; labelgame6.Visible = true; labelopp6.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 7) != "-1") { labelgame7.Text = Datas.profile.GetGameResult(login, 7); labelopp7.Text = Datas.profile.GetGameOpponent(login, 7); labelg7.Visible = true; labelgame7.Visible = true; labelopp7.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 8) != "-1") { labelgame8.Text = Datas.profile.GetGameResult(login, 8); labelopp8.Text = Datas.profile.GetGameOpponent(login, 8); labelg8.Visible = true; labelgame8.Visible = true; labelopp8.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 9) != "-1") { labelgame9.Text = Datas.profile.GetGameResult(login, 9); labelopp9.Text = Datas.profile.GetGameOpponent(login, 9); labelg9.Visible = true; labelgame9.Visible = true; labelopp9.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 10) != "-1") { labelgame10.Text = Datas.profile.GetGameResult(login, 10); labelopp10.Text = Datas.profile.GetGameOpponent(login, 10); labelg10.Visible = true; labelgame10.Visible = true; labelopp10.Visible = true; }
        }

        private void buttonshowstat_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите имя игрока.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 1; i <= 10; i++) Controls.Find($"labelg{i}", true)[0].Visible = false;
            for (int i = 1; i <= 10; i++) Controls.Find($"labelgame{i}", true)[0].Visible = false;
            for (int i = 1; i <= 10; i++) Controls.Find($"labelopp{i}", true)[0].Visible = false;
            string login = textBox1.Text;
            labellogin.Text = login; labellogin.Visible = true;
            labelrating.Text = Convert.ToString(Datas.profile.GetRating(login)); labelrating.Visible = true;
            labelwinrate.Text = Datas.profile.GetWinRate(login); labelwinrate.Visible = true;
            if (Datas.profile.GetGameOpponent(login, 1) != "-1") { labelgame1.Text = Datas.profile.GetGameResult(login, 1); labelopp1.Text = Datas.profile.GetGameOpponent(login, 1); labelg1.Visible = true; labelgame1.Visible = true; labelopp1.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 2) != "-1") { labelgame2.Text = Datas.profile.GetGameResult(login, 2); labelopp2.Text = Datas.profile.GetGameOpponent(login, 2); labelg2.Visible = true; labelgame2.Visible = true; labelopp2.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 3) != "-1") { labelgame3.Text = Datas.profile.GetGameResult(login, 3); labelopp3.Text = Datas.profile.GetGameOpponent(login, 3); labelg3.Visible = true; labelgame3.Visible = true; labelopp3.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 4) != "-1") { labelgame4.Text = Datas.profile.GetGameResult(login, 4); labelopp4.Text = Datas.profile.GetGameOpponent(login, 4); labelg4.Visible = true; labelgame4.Visible = true; labelopp4.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 5) != "-1") { labelgame5.Text = Datas.profile.GetGameResult(login, 5); labelopp5.Text = Datas.profile.GetGameOpponent(login, 5); labelg5.Visible = true; labelgame5.Visible = true; labelopp5.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 6) != "-1") { labelgame6.Text = Datas.profile.GetGameResult(login, 6); labelopp6.Text = Datas.profile.GetGameOpponent(login, 6); labelg6.Visible = true; labelgame6.Visible = true; labelopp6.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 7) != "-1") { labelgame7.Text = Datas.profile.GetGameResult(login, 7); labelopp7.Text = Datas.profile.GetGameOpponent(login, 7); labelg7.Visible = true; labelgame7.Visible = true; labelopp7.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 8) != "-1") { labelgame8.Text = Datas.profile.GetGameResult(login, 8); labelopp8.Text = Datas.profile.GetGameOpponent(login, 8); labelg8.Visible = true; labelgame8.Visible = true; labelopp8.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 9) != "-1") { labelgame9.Text = Datas.profile.GetGameResult(login, 9); labelopp9.Text = Datas.profile.GetGameOpponent(login, 9); labelg9.Visible = true; labelgame9.Visible = true; labelopp9.Visible = true; }
            if (Datas.profile.GetGameOpponent(login, 10) != "-1") { labelgame10.Text = Datas.profile.GetGameResult(login, 10); labelopp10.Text = Datas.profile.GetGameOpponent(login, 10); labelg10.Visible = true; labelgame10.Visible = true; labelopp10.Visible = true; }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonsolo_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void buttonduo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Еще не построил :(", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
