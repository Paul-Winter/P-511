using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        // ---------- Настройки ----------
        const int CellSize = 30;   

        int rows = 9;
        int cols = 9;
        int mineCount = 10;
        int difficulty = 0;        

        string[] levelNames = { "Новичок", "Любитель", "Профессионал" };

        string resultsFile = Path.Combine(Application.StartupPath, "results.txt");
        string saveFile = Path.Combine(Application.StartupPath, "save.txt");

        // ---------- Состояние игры ----------
        Button[,] buttons;   
        bool[,] mines;       
        bool[,] opened;      
        bool[,] flags;      

        bool gameOver = false;
        int openedCount = 0;      
        int seconds = 0;          
        bool timerStarted = false;
        bool minesPlaced = false; 

        Random random = new Random();

        // ---------- Элементы интерфейса (создаём в коде) ----------
        MenuStrip menuStrip;
        ToolStripMenuItem[] difficultyItems;
        Label labelTime;
        Panel panelField;
        System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Сапёр";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            CreateMenu();

            labelTime = new Label();
            labelTime.Text = "Время: 0";
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(labelTime);

            panelField = new Panel();
            this.Controls.Add(panelField);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            SetDifficulty(0);
        }

        // ---------- Меню ----------
        void CreateMenu()
        {
            menuStrip = new MenuStrip();

            // Меню "Игра"
            ToolStripMenuItem gameMenu = new ToolStripMenuItem("Игра");

            ToolStripMenuItem itemNew = new ToolStripMenuItem("Новая игра");
            itemNew.Click += NewGame_Click;

            ToolStripMenuItem itemSave = new ToolStripMenuItem("Сохранить игру");
            itemSave.Click += SaveGame;

            ToolStripMenuItem itemLoad = new ToolStripMenuItem("Загрузить игру");
            itemLoad.Click += LoadGame;

            ToolStripMenuItem itemResults = new ToolStripMenuItem("Результаты");
            itemResults.Click += ShowResults;

            ToolStripMenuItem itemExit = new ToolStripMenuItem("Выход");
            itemExit.Click += Exit_Click;

            gameMenu.DropDownItems.Add(itemNew);
            gameMenu.DropDownItems.Add(itemSave);
            gameMenu.DropDownItems.Add(itemLoad);
            gameMenu.DropDownItems.Add(itemResults);
            gameMenu.DropDownItems.Add(itemExit);

            ToolStripMenuItem levelMenu = new ToolStripMenuItem("Сложность");
            string[] titles = { "Новичок (9x9, 10 мин)", "Любитель (12x12, 25 мин)", "Профессионал (16x16, 40 мин)" };

            difficultyItems = new ToolStripMenuItem[3];
            for (int i = 0; i < 3; i++)
            {
                difficultyItems[i] = new ToolStripMenuItem(titles[i]);
                difficultyItems[i].Tag = i;   
                difficultyItems[i].Click += Difficulty_Click;
                levelMenu.DropDownItems.Add(difficultyItems[i]);
            }

            menuStrip.Items.Add(gameMenu);
            menuStrip.Items.Add(levelMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        void NewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Difficulty_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            SetDifficulty((int)item.Tag);
        }

        // ---------- Сложность и создание поля ----------
        void SetDifficulty(int level)
        {
            difficulty = level;

            if (level == 1)
            {
                cols = 12;
                rows = 12;
                mineCount = 25;
            }
            else if (level == 2)
            {
                cols = 16;
                rows = 16;
                mineCount = 40;
            }
            else
            {
                difficulty = 0;
                cols = 9;
                rows = 9;
                mineCount = 10;
            }

            // Ставим галочку у выбранной сложности
            for (int i = 0; i < 3; i++)
            {
                difficultyItems[i].Checked = (i == difficulty);
            }

            BuildField();
            NewGame();
        }

        void BuildField()
        {
            panelField.Controls.Clear();

            buttons = new Button[cols, rows];
            mines = new bool[cols, rows];
            opened = new bool[cols, rows];
            flags = new bool[cols, rows];

            int top = menuStrip.Height + 35;

            labelTime.Location = new Point(5, menuStrip.Height + 5);
            panelField.Location = new Point(0, top);
            panelField.Size = new Size(cols * CellSize, rows * CellSize);
            this.ClientSize = new Size(cols * CellSize, top + rows * CellSize);

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Button b = new Button();
                    b.Size = new Size(CellSize, CellSize);
                    b.Location = new Point(x * CellSize, y * CellSize);
                    b.Font = new Font("Segoe UI Emoji", 10, FontStyle.Bold);
                    b.Tag = new Point(x, y);       
                    b.MouseUp += Button_MouseUp;

                    buttons[x, y] = b;
                    panelField.Controls.Add(b);
                }
            }
        }

        // ---------- Новая игра ----------
        void NewGame()
        {
            gameOver = false;
            openedCount = 0;

            timer.Stop();
            timerStarted = false;
            minesPlaced = false;
            seconds = 0;
            UpdateTimeLabel();

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    mines[x, y] = false;
                    opened[x, y] = false;
                    flags[x, y] = false;
                    buttons[x, y].Text = "";
                    buttons[x, y].BackColor = SystemColors.Control;
                }
            }

            
        }

        void PlaceMines(int safeX, int safeY)
        {
            int placed = 0;
            while (placed < mineCount)
            {
                int x = random.Next(cols);
                int y = random.Next(rows);

                
                bool nearClick = Math.Abs(x - safeX) <= 1 && Math.Abs(y - safeY) <= 1;

                if (mines[x, y] == false && nearClick == false)
                {
                    mines[x, y] = true;
                    placed++;
                }
            }

            minesPlaced = true;
        }

        // ---------- Секундомер ----------
        void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            UpdateTimeLabel();
        }

        void UpdateTimeLabel()
        {
            labelTime.Text = "Время: " + seconds;
        }

        // ---------- Нажатие на клетку ----------
        void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            Button b = (Button)sender;
            Point p = (Point)b.Tag;
            int x = p.X;
            int y = p.Y;

            if (e.Button == MouseButtons.Right)
            {
                if (opened[x, y] == false)
                {
                    flags[x, y] = !flags[x, y];
                    if (flags[x, y])
                    {
                        b.Text = "F";
                    }
                    else
                    {
                        b.Text = "";
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (flags[x, y] || opened[x, y])
                {
                    return;
                }

                if (timerStarted == false)
                {
                    timerStarted = true;
                    timer.Start();
                }

                if (minesPlaced == false)
                {
                    PlaceMines(x, y);
                }

                if (mines[x, y])
                {
                    Lose();
                }
                else
                {
                    OpenCell(x, y);
                    if (openedCount == cols * rows - mineCount)
                    {
                        Win();
                    }
                }
            }
        }

        int CountMinesAround(int x, int y)
        {
            int count = 0;

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx >= 0 && nx < cols && ny >= 0 && ny < rows)
                    {
                        if (mines[nx, ny])
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        void OpenCell(int x, int y)
        {
            if (x < 0 || x >= cols || y < 0 || y >= rows)
            {
                return;
            }
            if (opened[x, y] || flags[x, y])
            {
                return;
            }

            opened[x, y] = true;
            openedCount++;
            buttons[x, y].BackColor = Color.DarkGray;

            int around = CountMinesAround(x, y);

            if (around > 0)
            {
                buttons[x, y].Text = around.ToString();
            }
            else
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        OpenCell(x + dx, y + dy);
                    }
                }
            }
        }

        // ---------- Проигрыш и победа ----------
        void Lose()
        {
            gameOver = true;
            timer.Stop();

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (mines[x, y])
                    {
                        buttons[x, y].Text = "💣";
                        buttons[x, y].BackColor = Color.Red;
                    }
                }
            }

            MessageBox.Show("Вы проиграли!");
            NewGame();
        }

        void Win()
        {
            gameOver = true;
            timer.Stop();

            SaveResult();

            MessageBox.Show("Вы выиграли! Ваше время: " + seconds + " сек.");
            NewGame();
        }

        // ---------- Запись результатов ----------
        void SaveResult()
        {
            string line = difficulty + ";" + seconds + ";" + Environment.UserName + ";" + DateTime.Now.ToString("dd.MM.yyyy");

            try
            {
                File.AppendAllText(resultsFile, line + Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("Не удалось записать результат в файл.");
            }
        }

        void ShowResults(object sender, EventArgs e)
        {
            if (File.Exists(resultsFile) == false)
            {
                MessageBox.Show("Результатов пока нет.");
                return;
            }

            string[] lines = File.ReadAllLines(resultsFile);
            string text = "";

            for (int level = 0; level < 3; level++)
            {

                List<string[]> records = new List<string[]>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    int time;

                    if (parts.Length == 4 && parts[0] == level.ToString() && int.TryParse(parts[1], out time))
                    {
                        records.Add(parts);
                    }
                }


                records.Sort((a, b) => int.Parse(a[1]).CompareTo(int.Parse(b[1])));

                text += levelNames[level] + ":\n";

                if (records.Count == 0)
                {
                    text += "   пока нет результатов\n";
                }

                for (int i = 0; i < records.Count && i < 5; i++)
                {
                    text += "   " + (i + 1) + ". " + records[i][1] + " сек. - " + records[i][2] + " (" + records[i][3] + ")\n";
                }

                text += "\n";
            }

            MessageBox.Show(text, "Лучшие результаты");
        }

        // ---------- Сохранение и загрузка игры ----------
        void SaveGame(object sender, EventArgs e)
        {
            string[] lines = new string[rows + 2];
            lines[0] = difficulty.ToString();
            lines[1] = seconds.ToString();

            for (int y = 0; y < rows; y++)
            {
                string row = "";

                for (int x = 0; x < cols; x++)
                {
                    int code = 0;
                    if (mines[x, y]) code += 1;
                    if (opened[x, y]) code += 2;
                    if (flags[x, y]) code += 4;

                    row += code;
                }

                lines[y + 2] = row;
            }

            try
            {
                File.WriteAllLines(saveFile, lines);
                MessageBox.Show("Игра сохранена.");
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить игру.");
            }
        }

        void LoadGame(object sender, EventArgs e)
        {
            if (File.Exists(saveFile) == false)
            {
                MessageBox.Show("Сохранённой игры нет.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(saveFile);
                int level = int.Parse(lines[0]);
                int savedSeconds = int.Parse(lines[1]);

                SetDifficulty(level);

                bool hasMines = false;

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        int code = lines[y + 2][x] - '0';

                        mines[x, y] = (code & 1) != 0;
                        if (mines[x, y])
                        {
                            hasMines = true;
                        }
                        opened[x, y] = (code & 2) != 0;
                        flags[x, y] = (code & 4) != 0;
                    }
                }


                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        if (flags[x, y])
                        {
                            buttons[x, y].Text = "F";
                        }

                        if (opened[x, y])
                        {
                            openedCount++;
                            buttons[x, y].BackColor = Color.DarkGray;

                            int around = CountMinesAround(x, y);
                            if (around > 0)
                            {
                                buttons[x, y].Text = around.ToString();
                            }
                        }
                    }
                }


                minesPlaced = hasMines;

                seconds = savedSeconds;
                UpdateTimeLabel();

                if (openedCount > 0)
                {
                    timerStarted = true;
                    timer.Start();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить игру: файл сохранения повреждён.");
                NewGame();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}