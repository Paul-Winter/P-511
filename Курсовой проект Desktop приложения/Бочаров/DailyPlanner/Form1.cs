using System;
using System.Drawing;
using System.Windows.Forms;

namespace DailyPlanner
{
    public partial class Form1 : Form
    {
        private TaskManager manager;
        private DateTime selectedDate;

        public Form1()
        {
            InitializeComponent();

            manager = new TaskManager();
            selectedDate = DateTime.Today;
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            gridTasks.DataSource = null;
            gridTasks.DataSource = manager.GetTasksByDate(selectedDate);
        }

        private void AddTaskLogic()
        {
            var form = new TaskEditForm(new PlannerTask { Date = selectedDate, Title = "Новая задача" });
            if (form.ShowDialog() == DialogResult.OK)
            {
                manager.AddTask(form.Task);
                UpdateGrid();
            }
        }

        private void EditTaskLogic()
        {
            if (gridTasks.CurrentRow?.DataBoundItem is PlannerTask task)
            {
                var form = new TaskEditForm(task);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    manager.UpdateTask();
                    UpdateGrid();
                }
            }
        }

        private void DeleteTaskLogic()
        {
            if (gridTasks.CurrentRow?.DataBoundItem is PlannerTask task)
            {
                if (MessageBox.Show("Точно удалить?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    manager.DeleteTask(task.Id);
                    UpdateGrid();
                }
            }
        }

        private void RescheduleTaskLogic()
        {
            if (gridTasks.CurrentRow?.DataBoundItem is PlannerTask task)
            {
                using (var form = new Form { Text = "Перенос записи", Size = new Size(220, 240), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog })
                {
                    var cal = new MonthCalendar { Dock = DockStyle.Top, MaxSelectionCount = 1, SelectionStart = task.Date };
                    var btnOk = new Button { Text = "Перенести", Dock = DockStyle.Bottom };
                    btnOk.Click += (s, ev) => { form.DialogResult = DialogResult.OK; };

                    form.Controls.Add(cal);
                    form.Controls.Add(btnOk);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        task.Date = new DateTime(cal.SelectionStart.Year, cal.SelectionStart.Month, cal.SelectionStart.Day, task.Date.Hour, task.Date.Minute, 0);
                        manager.UpdateTask();
                        UpdateGrid();
                        MessageBox.Show("Запись успешно перенесена!");
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTaskLogic();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditTaskLogic();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTaskLogic();
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            RescheduleTaskLogic();
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = calendar.SelectionStart;
            UpdateGrid();
        }
    }
}