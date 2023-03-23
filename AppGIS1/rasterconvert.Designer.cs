
namespace AppGIS1
{
    partial class rasterconvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rasterconvert));
            this.label1 = new System.Windows.Forms.Label();
            this.fileGDB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inputname = new System.Windows.Forms.TextBox();
            this.outputname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入栅格所在数据库：";
            // 
            // fileGDB
            // 
            this.fileGDB.Location = new System.Drawing.Point(37, 51);
            this.fileGDB.Name = "fileGDB";
            this.fileGDB.Size = new System.Drawing.Size(316, 28);
            this.fileGDB.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入栅格名称：";
            // 
            // inputname
            // 
            this.inputname.Location = new System.Drawing.Point(37, 121);
            this.inputname.Name = "inputname";
            this.inputname.Size = new System.Drawing.Size(370, 28);
            this.inputname.TabIndex = 4;
            // 
            // outputname
            // 
            this.outputname.Location = new System.Drawing.Point(37, 263);
            this.outputname.Name = "outputname";
            this.outputname.Size = new System.Drawing.Size(370, 28);
            this.outputname.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "输出栅格名称：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(37, 193);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(316, 28);
            this.filePath.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "输出栅格位置：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(332, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 34);
            this.button3.TabIndex = 10;
            this.button3.Text = "确认";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rasterconvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 397);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.outputname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileGDB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rasterconvert";
            this.Text = "栅格格式转换";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileGDB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputname;
        private System.Windows.Forms.TextBox outputname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
    }
}