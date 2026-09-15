using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btnA1 = new Button();
            //btnA1.Location = new Point(50, 50);
            //btnA1.Size = new Size(10, 10);
            btnA1.Click += new System.EventHandler(btnA1_Click);

            Button btnA2 = new Button();
            Button btnA3 = new Button();

            Button btnB1 = new Button();
            Button btnB2 = new Button();
            Button btnB3 = new Button();
            btnB2.Click += new System.EventHandler(btnB2_Click);

            Button btnC1 = new Button();
            Button btnC2 = new Button();
            Button btnC3 = new Button();
            btnC3.Click += new System.EventHandler(btnC3_Click);

            this.Controls.Add(btnA1);
            this.Controls.Add(btnA2);
            this.Controls.Add(btnA3);

            this.Controls.Add(btnB1);
            this.Controls.Add(btnB2);
            this.Controls.Add(btnB3);

            this.Controls.Add(btnC1);
            this.Controls.Add(btnC2);
            this.Controls.Add(btnC3);

            Button[] buttonsA = { btnA1, btnA2, btnA3 };
            Button[] buttonsB = { btnB1, btnB2, btnB3 };
            Button[] buttonsC = { btnC1, btnC2, btnC3 };

            for (int i = 0; i < buttonsA.Length; i++)
            {
                buttonsA[i].Size = new Size(60, 60);
                buttonsB[i].Size = new Size(60, 60);
                buttonsC[i].Size = new Size(60, 60);

                buttonsA[i].Location = new Point((i + 1) * 60, 10);
                buttonsB[i].Location = new Point((i + 1) * 60, 70);
                buttonsC[i].Location = new Point((i + 1) * 60, 130);
            }
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
        private void btnB2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }
        private void btnC3_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }
    }
}
