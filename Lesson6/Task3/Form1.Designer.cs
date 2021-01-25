namespace Task3
{
    partial class fmMain
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
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btOpen = new System.Windows.Forms.Button();
            this.gbTypes = new System.Windows.Forms.GroupBox();
            this.lbTypes = new System.Windows.Forms.ListBox();
            this.gbMethods = new System.Windows.Forms.GroupBox();
            this.lbMethods = new System.Windows.Forms.ListBox();
            this.gbMethodInfo = new System.Windows.Forms.GroupBox();
            this.tbMethodInfo = new System.Windows.Forms.RichTextBox();
            this.gbInfo.SuspendLayout();
            this.gbTypes.SuspendLayout();
            this.gbMethods.SuspendLayout();
            this.gbMethodInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.gbMethodInfo);
            this.gbInfo.Controls.Add(this.gbMethods);
            this.gbInfo.Controls.Add(this.gbTypes);
            this.gbInfo.Location = new System.Drawing.Point(12, 50);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.gbInfo.Size = new System.Drawing.Size(776, 388);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация о сборке: ";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(12, 12);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 23);
            this.btOpen.TabIndex = 1;
            this.btOpen.Text = "Open DLL";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // gbTypes
            // 
            this.gbTypes.Controls.Add(this.lbTypes);
            this.gbTypes.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbTypes.Location = new System.Drawing.Point(3, 23);
            this.gbTypes.Name = "gbTypes";
            this.gbTypes.Size = new System.Drawing.Size(250, 362);
            this.gbTypes.TabIndex = 0;
            this.gbTypes.TabStop = false;
            this.gbTypes.Text = "Типы";
            // 
            // lbTypes
            // 
            this.lbTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTypes.FormattingEnabled = true;
            this.lbTypes.HorizontalScrollbar = true;
            this.lbTypes.Location = new System.Drawing.Point(3, 16);
            this.lbTypes.Name = "lbTypes";
            this.lbTypes.Size = new System.Drawing.Size(244, 343);
            this.lbTypes.TabIndex = 0;
            this.lbTypes.SelectedIndexChanged += new System.EventHandler(this.lbTypes_SelectedIndexChanged);
            // 
            // gbMethods
            // 
            this.gbMethods.Controls.Add(this.lbMethods);
            this.gbMethods.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbMethods.Location = new System.Drawing.Point(253, 23);
            this.gbMethods.Name = "gbMethods";
            this.gbMethods.Size = new System.Drawing.Size(250, 362);
            this.gbMethods.TabIndex = 1;
            this.gbMethods.TabStop = false;
            this.gbMethods.Text = "Методы";
            // 
            // lbMethods
            // 
            this.lbMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMethods.FormattingEnabled = true;
            this.lbMethods.HorizontalScrollbar = true;
            this.lbMethods.Location = new System.Drawing.Point(3, 16);
            this.lbMethods.Name = "lbMethods";
            this.lbMethods.Size = new System.Drawing.Size(244, 343);
            this.lbMethods.TabIndex = 0;
            this.lbMethods.SelectedIndexChanged += new System.EventHandler(this.lbMethods_SelectedIndexChanged);
            // 
            // gbMethodInfo
            // 
            this.gbMethodInfo.Controls.Add(this.tbMethodInfo);
            this.gbMethodInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMethodInfo.Location = new System.Drawing.Point(503, 23);
            this.gbMethodInfo.Name = "gbMethodInfo";
            this.gbMethodInfo.Size = new System.Drawing.Size(270, 362);
            this.gbMethodInfo.TabIndex = 2;
            this.gbMethodInfo.TabStop = false;
            this.gbMethodInfo.Text = "Инфромация о методе";
            // 
            // tbMethodInfo
            // 
            this.tbMethodInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMethodInfo.Location = new System.Drawing.Point(3, 16);
            this.tbMethodInfo.Name = "tbMethodInfo";
            this.tbMethodInfo.ReadOnly = true;
            this.tbMethodInfo.Size = new System.Drawing.Size(264, 343);
            this.tbMethodInfo.TabIndex = 0;
            this.tbMethodInfo.Text = "";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.gbInfo);
            this.Name = "fmMain";
            this.Text = "Reflector";
            this.gbInfo.ResumeLayout(false);
            this.gbTypes.ResumeLayout(false);
            this.gbMethods.ResumeLayout(false);
            this.gbMethodInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.GroupBox gbTypes;
        private System.Windows.Forms.ListBox lbTypes;
        private System.Windows.Forms.GroupBox gbMethods;
        private System.Windows.Forms.ListBox lbMethods;
        private System.Windows.Forms.GroupBox gbMethodInfo;
        private System.Windows.Forms.RichTextBox tbMethodInfo;
    }
}

