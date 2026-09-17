namespace sea_wars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonautono_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            buttonautorize.Visible = true;
            buttonautorize.Enabled = false;
            buttonregister.Visible = true;
            buttonregister.Enabled = true;
        }

        private void buttonautoyes_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            buttonautorize.Visible = true;
            buttonautorize.Enabled = true;
            buttonregister.Visible = true;
            buttonregister.Enabled = false;
        }

        private void buttonopen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Datas.filePath = openFileDialog1.FileName;
            if (Datas.profile.LoadDatabase(Datas.filePath) == 1)
                MessageBox.Show("Ваш файл не подходит, поврежден или пустой.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Datas.profile.LoadDatabase(Datas.filePath) == 2)
                MessageBox.Show("База данных в файле пуста или повреждена и не подходит для игры.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                buttonopen.Enabled = false;
                buttonsave.Enabled = false;
                label2.Visible = true;
                buttonautoyes.Visible = true;
                buttonautono.Visible = true;
                MessageBox.Show("База данных успешно подгружена.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName == null || !saveFileDialog1.CheckWriteAccess)
            {
                MessageBox.Show("Путь не указан.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Datas.filePath = saveFileDialog1.FileName;
            if (Datas.profile.CreateDatabaseFile(Datas.filePath) == 1)
                MessageBox.Show("Создаваемый файл написан не на латинице или не имеет формата .txt.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Datas.profile.LoadDatabase(Datas.filePath) == 2)
                MessageBox.Show("Ошибка файловой системы.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                buttonopen.Enabled = false;
                buttonsave.Enabled = false;
                label2.Visible = true;
                buttonautoyes.Visible = true;
                buttonautoyes.Enabled = false;
                buttonautono.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                buttonautorize.Visible = true;
                buttonautorize.Enabled = false;
                buttonregister.Visible = true;
                buttonregister.Enabled = true;
                MessageBox.Show("База данных успешно создана.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonregister_Click(object sender, EventArgs e)
        {
            if (textBox1 == null || textBox2 == null)
            {
                MessageBox.Show("Логин или пароль пустые.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!Datas.profile.RegisterUser(textBox1.Text, textBox2.Text, Datas.filePath))
            {
                MessageBox.Show("Логин уже существует.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Datas.profile.RegisterUser(textBox1.Text, textBox2.Text, Datas.filePath);
            textBox1.Text = null;
            textBox2.Text = null;
            buttonautono.Enabled = false;
            buttonautoyes.Enabled = true;
            buttonautorize.Enabled = true;
            buttonregister.Enabled = false;
            MessageBox.Show("Вы успешно зарегистрировались", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonautorize_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Логин или пароль пустые.", "Упс...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Datas.profile.AuthorizeUser1(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Вы успешно авторизовались", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            if (Datas.profile.tryautorize1 == 0)
                this.Close();
        }
    }
}
