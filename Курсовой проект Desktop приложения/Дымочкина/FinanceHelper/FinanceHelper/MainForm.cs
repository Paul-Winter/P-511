using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace FinanceHelper
{
    public partial class MainForm : Form
    {        
        public MainForm()
        {
            InitializeComponent();

            dgvRecords.Columns.Add("colDate", "Дата");
            dgvRecords.Columns.Add("colIncome", "Доход");
            dgvRecords.Columns.Add("colExpense", "Расход");
            dgvRecords.Columns.Add("colCategory", "Категория");

            printDocument1.PrintPage += PrintDocument1_PrintPage;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите категорию.");
                return;
            }

            decimal income = 0;
            if (!string.IsNullOrWhiteSpace(txtIncome.Text))
            {
                if (!decimal.TryParse(txtIncome.Text, out income))
                {
                    MessageBox.Show("Доход должен быть числом.");
                    return;
                }
            }

            decimal expense = 0;
            if (!string.IsNullOrWhiteSpace(txtExpense.Text))
            {
                if (!decimal.TryParse(txtExpense.Text, out expense))
                {
                    MessageBox.Show("Расход должен быть числом.");
                    return;
                }
            }

            if (income == 0 && expense == 0)
            {
                MessageBox.Show("Введите доход или расход.");
                return;
            }

            dgvRecords.Rows.Add(
                dtpDate.Value.ToShortDateString(),
                income > 0 ? income.ToString("0.00") : "-",
                expense > 0 ? expense.ToString("0.00") : "-",
                cmbCategory.Text
            );

            txtIncome.Clear();
            txtExpense.Clear();
            cmbCategory.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить все записи?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgvRecords.Rows.Clear();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvRecords.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для печати.");
                return;
            }

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 11, FontStyle.Bold);
            Font textFont = new Font("Arial", 10);

            int y = 60;
            int left = 50;

            e.Graphics.DrawString("Финансовый отчёт", titleFont, Brushes.Black, left, y);
            y += 40;
            e.Graphics.DrawString("Дата: " + DateTime.Now.ToShortDateString(), textFont, Brushes.Black, left, y);
            y += 30;

            e.Graphics.DrawString("Дата", headerFont, Brushes.Black, left, y);
            e.Graphics.DrawString("Доход", headerFont, Brushes.Black, left + 150, y);
            e.Graphics.DrawString("Расход", headerFont, Brushes.Black, left + 280, y);
            e.Graphics.DrawString("Категория", headerFont, Brushes.Black, left + 410, y);
            y += 25;
            e.Graphics.DrawLine(Pens.Black, left, y, left + 600, y);
            y += 10;

            decimal totalIncome = 0;
            decimal totalExpense = 0;

            foreach (DataGridViewRow row in dgvRecords.Rows)
            {
                if (row.IsNewRow) continue;

                string date = row.Cells[0].Value?.ToString() ?? "";
                string income = row.Cells[1].Value?.ToString() ?? "";
                string expense = row.Cells[2].Value?.ToString() ?? "";
                string category = row.Cells[3].Value?.ToString() ?? "";

                e.Graphics.DrawString(date, textFont, Brushes.Black, left, y);
                e.Graphics.DrawString(income, textFont, Brushes.Black, left + 150, y);
                e.Graphics.DrawString(expense, textFont, Brushes.Black, left + 280, y);
                e.Graphics.DrawString(category, textFont, Brushes.Black, left + 410, y);
                y += 22;

                decimal inc, exp;
                if (decimal.TryParse(income, out inc)) totalIncome += inc;
                if (decimal.TryParse(expense, out exp)) totalExpense += exp;
            }

            y += 20;
            e.Graphics.DrawLine(Pens.Black, left, y, left + 600, y);
            y += 10;
            e.Graphics.DrawString("Итого доход: " + totalIncome.ToString("0.00"), headerFont, Brushes.Black, left, y);
            y += 25;
            e.Graphics.DrawString("Итого расход: " + totalExpense.ToString("0.00"), headerFont, Brushes.Black, left, y);
            y += 25;
            e.Graphics.DrawString("Остаток: " + (totalIncome - totalExpense).ToString("0.00"), headerFont, Brushes.Black, left, y);
        }
    }
}
