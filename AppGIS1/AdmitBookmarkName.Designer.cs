
namespace AppGIS1
{
    partial class AdmitBookmarkName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdmitBookmarkName));
            this.tbBookmarkName = new System.Windows.Forms.TextBox();
            this.btnAdmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbBookmarkName
            // 
            this.tbBookmarkName.Location = new System.Drawing.Point(41, 63);
            this.tbBookmarkName.Name = "tbBookmarkName";
            this.tbBookmarkName.Size = new System.Drawing.Size(100, 28);
            this.tbBookmarkName.TabIndex = 0;
            // 
            // btnAdmit
            // 
            this.btnAdmit.Location = new System.Drawing.Point(165, 58);
            this.btnAdmit.Name = "btnAdmit";
            this.btnAdmit.Size = new System.Drawing.Size(83, 35);
            this.btnAdmit.TabIndex = 1;
            this.btnAdmit.Text = "确认";
            this.btnAdmit.UseVisualStyleBackColor = true;
            this.btnAdmit.Click += new System.EventHandler(this.btnAdmit_Click);
            // 
            // AdmitBookmarkName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 156);
            this.Controls.Add(this.btnAdmit);
            this.Controls.Add(this.tbBookmarkName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdmitBookmarkName";
            this.Text = "书签名称设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBookmarkName;
        private System.Windows.Forms.Button btnAdmit;
    }
}