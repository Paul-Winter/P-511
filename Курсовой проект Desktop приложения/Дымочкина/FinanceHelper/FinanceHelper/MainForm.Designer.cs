namespace FinanceHelper
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.txtIncome = new System.Windows.Forms.TextBox();
            this.txtExpense = new System.Windows.Forms.TextBox();
            this.lblExpense = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            //((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(20, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDate.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(21, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 20);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Дата:";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(230, 5);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(61, 20);
            this.lblIncome.TabIndex = 2;
            this.lblIncome.Text = "Доход:";
            // 
            // txtIncome
            // 
            this.txtIncome.Location = new System.Drawing.Point(230, 30);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(100, 26);
            this.txtIncome.TabIndex = 3;
            // 
            // txtExpense
            // 
            this.txtExpense.Location = new System.Drawing.Point(358, 32);
            this.txtExpense.Name = "txtExpense";
            this.txtExpense.Size = new System.Drawing.Size(100, 26);
            this.txtExpense.TabIndex = 4;
            // 
            // lblExpense
            // 
            this.lblExpense.AutoSize = true;
            this.lblExpense.Location = new System.Drawing.Point(354, 5);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.Size = new System.Drawing.Size(78, 20);
            this.lblExpense.TabIndex = 5;
            this.lblExpense.Text = "Расходы:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(477, 5);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(93, 20);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Зарплата",
            "Еда",
            "Транспорт",
            "Развлечения",
            "Коммунальные",
            "Прочее"});
            this.cmbCategory.Location = new System.Drawing.Point(481, 28);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 28);
            this.cmbCategory.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 87);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 46);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(120, 87);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 46);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(230, 87);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 46);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Очистить все";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Location = new System.Drawing.Point(20, 171);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowHeadersWidth = 62;
            this.dgvRecords.RowTemplate.Height = 28;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(700, 300);
            this.dgvRecords.TabIndex = 11;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 483);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblExpense);
            this.Controls.Add(this.txtExpense);
            this.Controls.Add(this.txtIncome);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.TextBox txtIncome;
        private System.Windows.Forms.TextBox txtExpense;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}

