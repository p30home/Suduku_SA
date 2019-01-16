namespace AI_PROJECT
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
            if(disposing && (components != null))
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
            this.pnlSuduku = new System.Windows.Forms.Panel();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSALimit = new System.Windows.Forms.TextBox();
            this.btnSA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSusukuType = new System.Windows.Forms.ComboBox();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtMemoryUsage = new System.Windows.Forms.TextBox();
            this.txtCurrentDepth = new System.Windows.Forms.TextBox();
            this.txtEllapsedTime = new System.Windows.Forms.TextBox();
            this.txtProcessedStates = new System.Windows.Forms.TextBox();
            this.lblCurrentDepth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProcessedStates = new System.Windows.Forms.Label();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLastStates = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuduku
            // 
            this.pnlSuduku.Location = new System.Drawing.Point(12, 12);
            this.pnlSuduku.Name = "pnlSuduku";
            this.pnlSuduku.Size = new System.Drawing.Size(350, 282);
            this.pnlSuduku.TabIndex = 0;
            // 
            // pnlSetting
            // 
            this.pnlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSetting.Controls.Add(this.groupBox2);
            this.pnlSetting.Controls.Add(this.label1);
            this.pnlSetting.Controls.Add(this.cboSusukuType);
            this.pnlSetting.Location = new System.Drawing.Point(426, 12);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(227, 483);
            this.pnlSetting.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSALimit);
            this.groupBox2.Controls.Add(this.btnSA);
            this.groupBox2.Location = new System.Drawing.Point(3, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 59);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtSALimit
            // 
            this.txtSALimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSALimit.Location = new System.Drawing.Point(157, 21);
            this.txtSALimit.Name = "txtSALimit";
            this.txtSALimit.Size = new System.Drawing.Size(51, 20);
            this.txtSALimit.TabIndex = 2;
            this.txtSALimit.Text = "1 min";
            this.txtSALimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSA
            // 
            this.btnSA.Location = new System.Drawing.Point(7, 19);
            this.btnSA.Name = "btnSA";
            this.btnSA.Size = new System.Drawing.Size(144, 23);
            this.btnSA.TabIndex = 0;
            this.btnSA.Text = "Simulated Annealing";
            this.btnSA.UseVisualStyleBackColor = true;
            this.btnSA.Click += new System.EventHandler(this.btnSA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Suduku Type";            
            // 
            // cboSusukuType
            // 
            this.cboSusukuType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSusukuType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSusukuType.FormattingEnabled = true;
            this.cboSusukuType.Location = new System.Drawing.Point(80, 20);
            this.cboSusukuType.Name = "cboSusukuType";
            this.cboSusukuType.Size = new System.Drawing.Size(135, 21);
            this.cboSusukuType.TabIndex = 0;
            this.cboSusukuType.SelectedIndexChanged += new System.EventHandler(this.cboSusukuType_SelectedIndexChanged);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.txtMemoryUsage);
            this.pnlInfo.Controls.Add(this.txtCurrentDepth);
            this.pnlInfo.Controls.Add(this.txtEllapsedTime);
            this.pnlInfo.Controls.Add(this.txtProcessedStates);
            this.pnlInfo.Controls.Add(this.lblCurrentDepth);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.lblProcessedStates);
            this.pnlInfo.Controls.Add(this.picLoading);
            this.pnlInfo.Location = new System.Drawing.Point(12, 300);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(408, 195);
            this.pnlInfo.TabIndex = 2;
            // 
            // txtMemoryUsage
            // 
            this.txtMemoryUsage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemoryUsage.Location = new System.Drawing.Point(119, 93);
            this.txtMemoryUsage.Name = "txtMemoryUsage";
            this.txtMemoryUsage.ReadOnly = true;
            this.txtMemoryUsage.Size = new System.Drawing.Size(169, 20);
            this.txtMemoryUsage.TabIndex = 4;
            this.txtMemoryUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentDepth
            // 
            this.txtCurrentDepth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentDepth.Location = new System.Drawing.Point(119, 41);
            this.txtCurrentDepth.Name = "txtCurrentDepth";
            this.txtCurrentDepth.ReadOnly = true;
            this.txtCurrentDepth.Size = new System.Drawing.Size(169, 20);
            this.txtCurrentDepth.TabIndex = 4;
            this.txtCurrentDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEllapsedTime
            // 
            this.txtEllapsedTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEllapsedTime.Location = new System.Drawing.Point(119, 67);
            this.txtEllapsedTime.Name = "txtEllapsedTime";
            this.txtEllapsedTime.ReadOnly = true;
            this.txtEllapsedTime.Size = new System.Drawing.Size(169, 20);
            this.txtEllapsedTime.TabIndex = 4;
            this.txtEllapsedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProcessedStates
            // 
            this.txtProcessedStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessedStates.Location = new System.Drawing.Point(119, 15);
            this.txtProcessedStates.Name = "txtProcessedStates";
            this.txtProcessedStates.ReadOnly = true;
            this.txtProcessedStates.Size = new System.Drawing.Size(169, 20);
            this.txtProcessedStates.TabIndex = 4;
            this.txtProcessedStates.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCurrentDepth
            // 
            this.lblCurrentDepth.AutoSize = true;
            this.lblCurrentDepth.Location = new System.Drawing.Point(14, 44);
            this.lblCurrentDepth.Name = "lblCurrentDepth";
            this.lblCurrentDepth.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentDepth.TabIndex = 3;
            this.lblCurrentDepth.Text = "Current Depth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Memory Usage (MB) ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ellapsed Time ";
            // 
            // lblProcessedStates
            // 
            this.lblProcessedStates.AutoSize = true;
            this.lblProcessedStates.Location = new System.Drawing.Point(14, 18);
            this.lblProcessedStates.Name = "lblProcessedStates";
            this.lblProcessedStates.Size = new System.Drawing.Size(93, 13);
            this.lblProcessedStates.TabIndex = 3;
            this.lblProcessedStates.Text = "Processed States ";
            // 
            // picLoading
            // 
            this.picLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Image = global::AI_PROJECT.Properties.Resources._477__1_;
            this.picLoading.Location = new System.Drawing.Point(304, 15);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(99, 83);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 3;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // btnLastStates
            // 
            this.btnLastStates.Location = new System.Drawing.Point(368, 70);
            this.btnLastStates.Name = "btnLastStates";
            this.btnLastStates.Size = new System.Drawing.Size(52, 23);
            this.btnLastStates.TabIndex = 3;
            this.btnLastStates.Text = "ALL";
            this.btnLastStates.UseVisualStyleBackColor = true;
            this.btnLastStates.Click += new System.EventHandler(this.btnLastStates_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(368, 41);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(52, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 507);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLastStates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlSetting);
            this.Controls.Add(this.pnlSuduku);
            this.MinimumSize = new System.Drawing.Size(681, 546);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuduku;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSusukuType;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.TextBox txtMemoryUsage;
        private System.Windows.Forms.TextBox txtEllapsedTime;
        private System.Windows.Forms.TextBox txtProcessedStates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProcessedStates;
        private System.Windows.Forms.TextBox txtCurrentDepth;
        private System.Windows.Forms.Label lblCurrentDepth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLastStates;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSA;
        private System.Windows.Forms.TextBox txtSALimit;
    }
}

