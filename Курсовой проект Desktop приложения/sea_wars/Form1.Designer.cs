namespace sea_wars
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            buttonautoyes = new Button();
            buttonautono = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            buttonregister = new Button();
            buttonautorize = new Button();
            label5 = new Label();
            openFileDialog1 = new OpenFileDialog();
            buttonopen = new Button();
            buttonsave = new Button();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // buttonautoyes
            // 
            resources.ApplyResources(buttonautoyes, "buttonautoyes");
            buttonautoyes.Name = "buttonautoyes";
            buttonautoyes.UseVisualStyleBackColor = true;
            buttonautoyes.Click += buttonautoyes_Click;
            // 
            // buttonautono
            // 
            resources.ApplyResources(buttonautono, "buttonautono");
            buttonautono.Name = "buttonautono";
            buttonautono.UseVisualStyleBackColor = true;
            buttonautono.Click += buttonautono_Click;
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.Name = "textBox1";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // textBox2
            // 
            resources.ApplyResources(textBox2, "textBox2");
            textBox2.Name = "textBox2";
            // 
            // buttonregister
            // 
            resources.ApplyResources(buttonregister, "buttonregister");
            buttonregister.Name = "buttonregister";
            buttonregister.UseVisualStyleBackColor = true;
            buttonregister.Click += buttonregister_Click;
            // 
            // buttonautorize
            // 
            resources.ApplyResources(buttonautorize, "buttonautorize");
            buttonautorize.Name = "buttonautorize";
            buttonautorize.UseVisualStyleBackColor = true;
            buttonautorize.Click += buttonautorize_Click;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "profiles.txt";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            // 
            // buttonopen
            // 
            resources.ApplyResources(buttonopen, "buttonopen");
            buttonopen.Name = "buttonopen";
            buttonopen.UseVisualStyleBackColor = true;
            buttonopen.Click += buttonopen_Click;
            // 
            // buttonsave
            // 
            resources.ApplyResources(buttonsave, "buttonsave");
            buttonsave.Name = "buttonsave";
            buttonsave.UseVisualStyleBackColor = true;
            buttonsave.Click += buttonsave_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileName = "profiles.txt";
            saveFileDialog1.Tag = "";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonsave);
            Controls.Add(buttonopen);
            Controls.Add(label5);
            Controls.Add(buttonautorize);
            Controls.Add(buttonregister);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(buttonautono);
            Controls.Add(buttonautoyes);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button buttonautoyes;
        private Button buttonautono;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Button buttonregister;
        private Button buttonautorize;
        private Label label5;
        private OpenFileDialog openFileDialog1;
        private Button buttonopen;
        private Button buttonsave;
        private SaveFileDialog saveFileDialog1;
    }
}
