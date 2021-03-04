namespace Serialize
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFname = new System.Windows.Forms.TextBox();
            this.textBoxLname = new System.Windows.Forms.TextBox();
            this.numericUpDownAge = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerBornDate = new System.Windows.Forms.DateTimePicker();
            this.buttonsave = new System.Windows.Forms.Button();
            this.buttonload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Возраст";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата рождения";
            // 
            // textBoxFname
            // 
            this.textBoxFname.Location = new System.Drawing.Point(116, 20);
            this.textBoxFname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFname.Name = "textBoxFname";
            this.textBoxFname.Size = new System.Drawing.Size(254, 20);
            this.textBoxFname.TabIndex = 4;
            // 
            // textBoxLname
            // 
            this.textBoxLname.Location = new System.Drawing.Point(116, 67);
            this.textBoxLname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxLname.Name = "textBoxLname";
            this.textBoxLname.Size = new System.Drawing.Size(254, 20);
            this.textBoxLname.TabIndex = 5;
            // 
            // numericUpDownAge
            // 
            this.numericUpDownAge.Enabled = false;
            this.numericUpDownAge.Location = new System.Drawing.Point(116, 119);
            this.numericUpDownAge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownAge.Name = "numericUpDownAge";
            this.numericUpDownAge.Size = new System.Drawing.Size(253, 20);
            this.numericUpDownAge.TabIndex = 6;
            this.numericUpDownAge.ValueChanged += new System.EventHandler(this.numericUpDownAge_ValueChanged);
            // 
            // dateTimePickerBornDate
            // 
            this.dateTimePickerBornDate.Location = new System.Drawing.Point(116, 172);
            this.dateTimePickerBornDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerBornDate.Name = "dateTimePickerBornDate";
            this.dateTimePickerBornDate.Size = new System.Drawing.Size(254, 20);
            this.dateTimePickerBornDate.TabIndex = 7;
            this.dateTimePickerBornDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_DateChanged);
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(14, 227);
            this.buttonsave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(137, 24);
            this.buttonsave.TabIndex = 8;
            this.buttonsave.Text = "Сохранить";
            this.buttonsave.UseVisualStyleBackColor = true;
            this.buttonsave.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonload
            // 
            this.buttonload.Location = new System.Drawing.Point(232, 227);
            this.buttonload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonload.Name = "buttonload";
            this.buttonload.Size = new System.Drawing.Size(137, 24);
            this.buttonload.TabIndex = 9;
            this.buttonload.Text = "Загрузить";
            this.buttonload.UseVisualStyleBackColor = true;
            this.buttonload.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 264);
            this.Controls.Add(this.buttonload);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.dateTimePickerBornDate);
            this.Controls.Add(this.numericUpDownAge);
            this.Controls.Add(this.textBoxLname);
            this.Controls.Add(this.textBoxFname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Binary Serialize";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFname;
        private System.Windows.Forms.TextBox textBoxLname;
        private System.Windows.Forms.NumericUpDown numericUpDownAge;
        private System.Windows.Forms.DateTimePicker dateTimePickerBornDate;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Button buttonload;
    }
}

