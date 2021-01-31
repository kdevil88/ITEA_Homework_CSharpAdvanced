namespace Task4
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
            this.label = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.menuFontColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(582, 321);
            this.label.TabIndex = 0;
            this.label.Text = "Отакої!";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings,
            this.menuBackColor,
            this.menuFont,
            this.menuFontColor});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(582, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuSettings
            // 
            this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuRegistry});
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(79, 20);
            this.menuSettings.Text = "Настройки";
            // 
            // menuFile
            // 
            this.menuFile.Checked = true;
            this.menuFile.CheckOnClick = true;
            this.menuFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(180, 22);
            this.menuFile.Text = "В файле";
            this.menuFile.CheckStateChanged += new System.EventHandler(this.menuFile_CheckStateChanged);
            // 
            // menuRegistry
            // 
            this.menuRegistry.CheckOnClick = true;
            this.menuRegistry.Name = "menuRegistry";
            this.menuRegistry.Size = new System.Drawing.Size(180, 22);
            this.menuRegistry.Text = "В реестре";
            this.menuRegistry.CheckStateChanged += new System.EventHandler(this.menuRegistry_CheckStateChanged);
            // 
            // menuBackColor
            // 
            this.menuBackColor.Name = "menuBackColor";
            this.menuBackColor.Size = new System.Drawing.Size(77, 20);
            this.menuBackColor.Text = "Цвет фона";
            this.menuBackColor.Click += new System.EventHandler(this.menuBackColor_Click);
            // 
            // menuFont
            // 
            this.menuFont.Name = "menuFont";
            this.menuFont.Size = new System.Drawing.Size(58, 20);
            this.menuFont.Text = "Шрифт";
            this.menuFont.Click += new System.EventHandler(this.menuFont_Click);
            // 
            // menuFontColor
            // 
            this.menuFontColor.Name = "menuFontColor";
            this.menuFontColor.Size = new System.Drawing.Size(93, 20);
            this.menuFontColor.Text = "Цвет шрифта";
            this.menuFontColor.Click += new System.EventHandler(this.menuFontColor_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 345);
            this.Controls.Add(this.label);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "fmMain";
            this.Text = "Text";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuRegistry;
        private System.Windows.Forms.ToolStripMenuItem menuBackColor;
        private System.Windows.Forms.ToolStripMenuItem menuFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem menuFontColor;
    }
}

