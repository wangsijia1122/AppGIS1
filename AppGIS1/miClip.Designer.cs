
namespace AppGIS1
{
    partial class miClip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(miClip));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnIutputPath = new System.Windows.Forms.Button();
            this.btnClipPath = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.geo_Clip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入要素：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "裁剪要素：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出要素：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 28);
            this.textBox1.TabIndex = 3;
            // 
            // btnIutputPath
            // 
            this.btnIutputPath.Location = new System.Drawing.Point(380, 53);
            this.btnIutputPath.Name = "btnIutputPath";
            this.btnIutputPath.Size = new System.Drawing.Size(45, 28);
            this.btnIutputPath.TabIndex = 4;
            this.btnIutputPath.Text = "...";
            this.btnIutputPath.UseVisualStyleBackColor = true;
            this.btnIutputPath.Click += new System.EventHandler(this.btnIutputPath_Click);
            // 
            // btnClipPath
            // 
            this.btnClipPath.Location = new System.Drawing.Point(380, 126);
            this.btnClipPath.Name = "btnClipPath";
            this.btnClipPath.Size = new System.Drawing.Size(45, 28);
            this.btnClipPath.TabIndex = 6;
            this.btnClipPath.Text = "...";
            this.btnClipPath.UseVisualStyleBackColor = true;
            this.btnClipPath.Click += new System.EventHandler(this.btnClipPath_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 126);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(330, 28);
            this.textBox2.TabIndex = 5;
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Location = new System.Drawing.Point(380, 201);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(45, 28);
            this.btnOutputPath.TabIndex = 8;
            this.btnOutputPath.Text = "...";
            this.btnOutputPath.UseVisualStyleBackColor = true;
            this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(43, 201);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(330, 28);
            this.txtOutputPath.TabIndex = 7;
            // 
            // geo_Clip
            // 
            this.geo_Clip.Location = new System.Drawing.Point(351, 252);
            this.geo_Clip.Name = "geo_Clip";
            this.geo_Clip.Size = new System.Drawing.Size(74, 33);
            this.geo_Clip.TabIndex = 9;
            this.geo_Clip.Text = "确定";
            this.geo_Clip.UseVisualStyleBackColor = true;
            this.geo_Clip.Click += new System.EventHandler(this.geo_Clip_Click);
            // 
            // miClip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 324);
            this.Controls.Add(this.geo_Clip);
            this.Controls.Add(this.btnOutputPath);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.btnClipPath);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnIutputPath);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "miClip";
            this.Text = "裁剪";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnIutputPath;
        private System.Windows.Forms.Button btnClipPath;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOutputPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button geo_Clip;
    }
}