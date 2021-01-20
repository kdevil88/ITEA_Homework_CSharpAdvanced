namespace Task2
{
    partial class fmInput
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LessonNum = new System.Windows.Forms.NumericUpDown();
            this.numMark = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.LessonNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMark)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Урок №";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Оценка";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LessonNum
            // 
            this.LessonNum.Location = new System.Drawing.Point(83, 11);
            this.LessonNum.Name = "LessonNum";
            this.LessonNum.Size = new System.Drawing.Size(120, 20);
            this.LessonNum.TabIndex = 6;
            this.LessonNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMark
            // 
            this.numMark.DecimalPlaces = 2;
            this.numMark.Location = new System.Drawing.Point(83, 42);
            this.numMark.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMark.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMark.Name = "numMark";
            this.numMark.Size = new System.Drawing.Size(120, 20);
            this.numMark.TabIndex = 7;
            this.numMark.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // fmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 140);
            this.Controls.Add(this.numMark);
            this.Controls.Add(this.LessonNum);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "fmInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Данные";
            ((System.ComponentModel.ISupportInitialize)(this.LessonNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.NumericUpDown LessonNum;
        public System.Windows.Forms.NumericUpDown numMark;
    }
}