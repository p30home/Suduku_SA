namespace AI_PROJECT
{
    partial class DiagramForm
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
            this.picDiag = new System.Windows.Forms.PictureBox();
            this.picContainer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDiag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // picDiag
            // 
            this.picDiag.BackColor = System.Drawing.Color.Transparent;
            this.picDiag.Location = new System.Drawing.Point(33, 12);
            this.picDiag.Name = "picDiag";
            this.picDiag.Size = new System.Drawing.Size(377, 378);
            this.picDiag.TabIndex = 1;
            this.picDiag.TabStop = false;
            // 
            // picContainer
            // 
            this.picContainer.Image = global::AI_PROJECT.Properties.Resources.dBackGround;
            this.picContainer.Location = new System.Drawing.Point(12, 12);
            this.picContainer.Name = "picContainer";
            this.picContainer.Size = new System.Drawing.Size(400, 400);
            this.picContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picContainer.TabIndex = 0;
            this.picContainer.TabStop = false;
            this.picContainer.Click += new System.EventHandler(this.picDiag_Click);
            // 
            // DiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 418);
            this.Controls.Add(this.picDiag);
            this.Controls.Add(this.picContainer);
            this.MinimumSize = new System.Drawing.Size(346, 367);
            this.Name = "DiagramForm";
            this.Text = "DiagramForm";
            this.Load += new System.EventHandler(this.DiagramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDiag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picContainer;
        private System.Windows.Forms.PictureBox picDiag;
    }
}