using System;
using System.Drawing;
using System.Windows.Forms;

namespace DailyPlanner
{
    public class TaskEditForm : Form
    {
        public PlannerTask Task { get; private set; }
        private TextBox txtTitle, txtDesc;
        private DateTimePicker timePicker;

        public TaskEditForm(PlannerTask task)
        {
            Task = task;
            this.Text = "Настройки задачи";
            this.Size = new Size(300, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var lblTitle = new Label { Text = "Название:", Top = 10, Left = 10 };
            txtTitle = new TextBox { Top = 30, Left = 10, Width = 260, Text = task.Title };

            var lblDesc = new Label { Text = "Описание:", Top = 60, Left = 10 };
            txtDesc = new TextBox { Top = 80, Left = 10, Width = 260, Height = 80, Multiline = true, Text = task.Description };

            var lblTime = new Label { Text = "Время:", Top = 170, Left = 10 };
            timePicker = new DateTimePicker
            {
                Top = 190,
                Left = 10,
                Width = 100,
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true,
                Value = task.Date
            };

            var btnSave = new Button { Text = "Сохранить", Top = 230, Left = 100, Width = 100, DialogResult = DialogResult.OK };
            btnSave.Click += (s, e) =>
            {
                Task.Title = txtTitle.Text;
                Task.Description = txtDesc.Text;
                Task.Date = new DateTime(Task.Date.Year, Task.Date.Month, Task.Date.Day, timePicker.Value.Hour, timePicker.Value.Minute, 0);
            };

            this.Controls.AddRange(new Control[] { lblTitle, txtTitle, lblDesc, txtDesc, lblTime, timePicker, btnSave });
        }
    }
}