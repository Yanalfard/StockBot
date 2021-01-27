
namespace Frame03
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdIr = new System.Windows.Forms.RadioButton();
            this.RdEu = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdNorm = new System.Windows.Forms.RadioButton();
            this.RdReg = new System.Windows.Forms.RadioButton();
            this.Rich = new System.Windows.Forms.RichTextBox();
            this.GpCalculateSettings = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtInspect = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.BtnLastPoint = new System.Windows.Forms.Button();
            this.BtnHeader = new System.Windows.Forms.Button();
            this.BtnInspect = new System.Windows.Forms.Button();
            this.BtnEndPoint = new System.Windows.Forms.Button();
            this.BtnStartPoint = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LblTime = new System.Windows.Forms.Label();
            this.DtTimeToHit = new System.Windows.Forms.DateTimePicker();
            this.NumConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.PnlPassword = new System.Windows.Forms.Panel();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.PnlMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GpCalculateSettings.SuspendLayout();
            this.PnlPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.groupBox2);
            this.PnlMain.Controls.Add(this.groupBox1);
            this.PnlMain.Controls.Add(this.Rich);
            this.PnlMain.Controls.Add(this.GpCalculateSettings);
            this.PnlMain.Controls.Add(this.button3);
            this.PnlMain.Controls.Add(this.button2);
            this.PnlMain.Controls.Add(this.LblTime);
            this.PnlMain.Controls.Add(this.DtTimeToHit);
            this.PnlMain.Controls.Add(this.NumConfig);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(12, 12);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1259, 654);
            this.PnlMain.TabIndex = 0;
            this.PnlMain.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RdIr);
            this.groupBox2.Controls.Add(this.RdEu);
            this.groupBox2.Location = new System.Drawing.Point(4, 452);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 100);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.Tip.SetToolTip(this.groupBox2, "بعد از تغییر دادن این گزینه باید برنامه ریستارت شود.");
            // 
            // RdIr
            // 
            this.RdIr.AutoSize = true;
            this.RdIr.Checked = true;
            this.RdIr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdIr.Location = new System.Drawing.Point(260, 37);
            this.RdIr.Name = "RdIr";
            this.RdIr.Size = new System.Drawing.Size(79, 36);
            this.RdIr.TabIndex = 0;
            this.RdIr.TabStop = true;
            this.RdIr.Text = "IR";
            this.RdIr.UseVisualStyleBackColor = true;
            this.RdIr.CheckedChanged += new System.EventHandler(this.RdIr_CheckedChanged);
            // 
            // RdEu
            // 
            this.RdEu.AutoSize = true;
            this.RdEu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F);
            this.RdEu.Location = new System.Drawing.Point(25, 37);
            this.RdEu.Name = "RdEu";
            this.RdEu.Size = new System.Drawing.Size(91, 36);
            this.RdEu.TabIndex = 0;
            this.RdEu.Text = "EU";
            this.RdEu.UseVisualStyleBackColor = true;
            this.RdEu.CheckedChanged += new System.EventHandler(this.RdEu_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RdNorm);
            this.groupBox1.Controls.Add(this.RdReg);
            this.groupBox1.Location = new System.Drawing.Point(4, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 100);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // RdNorm
            // 
            this.RdNorm.AutoSize = true;
            this.RdNorm.Checked = true;
            this.RdNorm.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.RdNorm.Location = new System.Drawing.Point(260, 37);
            this.RdNorm.Name = "RdNorm";
            this.RdNorm.Size = new System.Drawing.Size(103, 48);
            this.RdNorm.TabIndex = 0;
            this.RdNorm.TabStop = true;
            this.RdNorm.Text = "ساده";
            this.RdNorm.UseVisualStyleBackColor = true;
            this.RdNorm.CheckedChanged += new System.EventHandler(this.RdNorm_CheckedChanged);
            // 
            // RdReg
            // 
            this.RdReg.AutoSize = true;
            this.RdReg.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.RdReg.Location = new System.Drawing.Point(25, 37);
            this.RdReg.Name = "RdReg";
            this.RdReg.Size = new System.Drawing.Size(136, 48);
            this.RdReg.TabIndex = 0;
            this.RdReg.Text = "میانگین";
            this.RdReg.UseVisualStyleBackColor = true;
            this.RdReg.CheckedChanged += new System.EventHandler(this.RdReg_CheckedChanged);
            // 
            // Rich
            // 
            this.Rich.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.Rich.Location = new System.Drawing.Point(555, 3);
            this.Rich.Name = "Rich";
            this.Rich.Size = new System.Drawing.Size(699, 330);
            this.Rich.TabIndex = 73;
            this.Rich.Text = "";
            // 
            // GpCalculateSettings
            // 
            this.GpCalculateSettings.Controls.Add(this.button1);
            this.GpCalculateSettings.Controls.Add(this.TxtInspect);
            this.GpCalculateSettings.Controls.Add(this.BtnSend);
            this.GpCalculateSettings.Controls.Add(this.BtnLastPoint);
            this.GpCalculateSettings.Controls.Add(this.BtnHeader);
            this.GpCalculateSettings.Controls.Add(this.BtnInspect);
            this.GpCalculateSettings.Controls.Add(this.BtnEndPoint);
            this.GpCalculateSettings.Controls.Add(this.BtnStartPoint);
            this.GpCalculateSettings.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.GpCalculateSettings.Location = new System.Drawing.Point(555, 328);
            this.GpCalculateSettings.Name = "GpCalculateSettings";
            this.GpCalculateSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GpCalculateSettings.Size = new System.Drawing.Size(699, 323);
            this.GpCalculateSettings.TabIndex = 72;
            this.GpCalculateSettings.TabStop = false;
            this.GpCalculateSettings.Text = "تنظیمات محاسبه";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(140, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 57);
            this.button1.TabIndex = 66;
            this.button1.Text = "تنظیم کلیک";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtInspect
            // 
            this.TxtInspect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TxtInspect.Location = new System.Drawing.Point(40, 120);
            this.TxtInspect.Name = "TxtInspect";
            this.TxtInspect.Size = new System.Drawing.Size(94, 41);
            this.TxtInspect.TabIndex = 64;
            this.TxtInspect.Text = "157";
            this.TxtInspect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtInspect.TextChanged += new System.EventHandler(this.TxtInspect_TextChanged);
            // 
            // BtnSend
            // 
            this.BtnSend.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.BtnSend.Location = new System.Drawing.Point(40, 51);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(256, 57);
            this.BtnSend.TabIndex = 63;
            this.BtnSend.Text = "نقطه ی ارسال";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // BtnLastPoint
            // 
            this.BtnLastPoint.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.BtnLastPoint.Location = new System.Drawing.Point(420, 240);
            this.BtnLastPoint.Name = "BtnLastPoint";
            this.BtnLastPoint.Size = new System.Drawing.Size(273, 57);
            this.BtnLastPoint.TabIndex = 32;
            this.BtnLastPoint.Text = "نقطه ی آخرین";
            this.BtnLastPoint.UseVisualStyleBackColor = true;
            this.BtnLastPoint.Click += new System.EventHandler(this.BtnLastPoint_Click);
            // 
            // BtnHeader
            // 
            this.BtnHeader.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.BtnHeader.Location = new System.Drawing.Point(420, 177);
            this.BtnHeader.Name = "BtnHeader";
            this.BtnHeader.Size = new System.Drawing.Size(273, 57);
            this.BtnHeader.TabIndex = 32;
            this.BtnHeader.Text = "نقطه ی جستجو";
            this.BtnHeader.UseVisualStyleBackColor = true;
            this.BtnHeader.Click += new System.EventHandler(this.BtnHeader_Click);
            // 
            // BtnInspect
            // 
            this.BtnInspect.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.BtnInspect.Location = new System.Drawing.Point(40, 177);
            this.BtnInspect.Name = "BtnInspect";
            this.BtnInspect.Size = new System.Drawing.Size(256, 57);
            this.BtnInspect.TabIndex = 32;
            this.BtnInspect.Text = "نقطه ی راست کلیک";
            this.BtnInspect.UseVisualStyleBackColor = true;
            this.BtnInspect.Click += new System.EventHandler(this.BtnInspect_Click);
            // 
            // BtnEndPoint
            // 
            this.BtnEndPoint.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.BtnEndPoint.Location = new System.Drawing.Point(420, 114);
            this.BtnEndPoint.Name = "BtnEndPoint";
            this.BtnEndPoint.Size = new System.Drawing.Size(273, 57);
            this.BtnEndPoint.TabIndex = 32;
            this.BtnEndPoint.Text = "نقطه ی پایان";
            this.BtnEndPoint.UseVisualStyleBackColor = true;
            this.BtnEndPoint.Click += new System.EventHandler(this.BtnEndPoint_Click);
            // 
            // BtnStartPoint
            // 
            this.BtnStartPoint.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.BtnStartPoint.Location = new System.Drawing.Point(420, 51);
            this.BtnStartPoint.Name = "BtnStartPoint";
            this.BtnStartPoint.Size = new System.Drawing.Size(273, 57);
            this.BtnStartPoint.TabIndex = 32;
            this.BtnStartPoint.Text = "نقطه ی شروع";
            this.BtnStartPoint.UseVisualStyleBackColor = true;
            this.BtnStartPoint.Click += new System.EventHandler(this.BtnStartPoint_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("B Nazanin", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.Location = new System.Drawing.Point(11, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(247, 85);
            this.button2.TabIndex = 70;
            this.button2.Text = "ارسال خودکار";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LblTime.Location = new System.Drawing.Point(4, 3);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(0, 42);
            this.LblTime.TabIndex = 69;
            // 
            // DtTimeToHit
            // 
            this.DtTimeToHit.CustomFormat = "hh:mm:ss";
            this.DtTimeToHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.DtTimeToHit.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtTimeToHit.Location = new System.Drawing.Point(4, 291);
            this.DtTimeToHit.Name = "DtTimeToHit";
            this.DtTimeToHit.Size = new System.Drawing.Size(247, 42);
            this.DtTimeToHit.TabIndex = 68;
            // 
            // NumConfig
            // 
            this.NumConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F);
            this.NumConfig.Location = new System.Drawing.Point(273, 291);
            this.NumConfig.Name = "NumConfig";
            this.NumConfig.Size = new System.Drawing.Size(100, 42);
            this.NumConfig.TabIndex = 67;
            this.NumConfig.Text = "0";
            this.NumConfig.TextChanged += new System.EventHandler(this.NumConfig_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(379, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 44);
            this.label1.TabIndex = 77;
            this.label1.Text = "جبران خطا";
            // 
            // Time
            // 
            this.Time.Enabled = true;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // PnlPassword
            // 
            this.PnlPassword.Controls.Add(this.TxtPass);
            this.PnlPassword.Controls.Add(this.label2);
            this.PnlPassword.Location = new System.Drawing.Point(399, 2);
            this.PnlPassword.Name = "PnlPassword";
            this.PnlPassword.Size = new System.Drawing.Size(464, 701);
            this.PnlPassword.TabIndex = 1;
            // 
            // TxtPass
            // 
            this.TxtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TxtPass.Location = new System.Drawing.Point(79, 333);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(256, 45);
            this.TxtPass.TabIndex = 78;
            this.TxtPass.UseSystemPasswordChar = true;
            this.TxtPass.TextChanged += new System.EventHandler(this.TxtPass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(354, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 50);
            this.label2.TabIndex = 79;
            this.label2.Text = "رمز";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("B Nazanin", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.Location = new System.Drawing.Point(11, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(247, 85);
            this.button3.TabIndex = 70;
            this.button3.Text = "ارسال دستی";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1283, 678);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlPassword);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GpCalculateSettings.ResumeLayout(false);
            this.GpCalculateSettings.PerformLayout();
            this.PnlPassword.ResumeLayout(false);
            this.PnlPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RdIr;
        private System.Windows.Forms.RadioButton RdEu;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdNorm;
        private System.Windows.Forms.RadioButton RdReg;
        private System.Windows.Forms.RichTextBox Rich;
        private System.Windows.Forms.GroupBox GpCalculateSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtInspect;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Button BtnLastPoint;
        private System.Windows.Forms.Button BtnHeader;
        private System.Windows.Forms.Button BtnInspect;
        private System.Windows.Forms.Button BtnEndPoint;
        private System.Windows.Forms.Button BtnStartPoint;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.DateTimePicker DtTimeToHit;
        private System.Windows.Forms.TextBox NumConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.Panel PnlPassword;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}

