
namespace AppGIS1
{
    partial class RasterCalculate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RasterCalculate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.expression = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.cboinput1 = new System.Windows.Forms.ComboBox();
            this.cboinput2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbomath = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入图层1：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入图层2：";
            // 
            // expression
            // 
            this.expression.Location = new System.Drawing.Point(49, 196);
            this.expression.Multiline = true;
            this.expression.Name = "expression";
            this.expression.Size = new System.Drawing.Size(437, 80);
            this.expression.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "表达式：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(408, 369);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 36);
            this.button3.TabIndex = 13;
            this.button3.Text = "确认";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cboinput1
            // 
            this.cboinput1.FormattingEnabled = true;
            this.cboinput1.Location = new System.Drawing.Point(151, 38);
            this.cboinput1.Name = "cboinput1";
            this.cboinput1.Size = new System.Drawing.Size(338, 26);
            this.cboinput1.TabIndex = 18;
            this.cboinput1.SelectedIndexChanged += new System.EventHandler(this.cboinput1_SelectedIndexChanged);
            // 
            // cboinput2
            // 
            this.cboinput2.FormattingEnabled = true;
            this.cboinput2.Location = new System.Drawing.Point(151, 87);
            this.cboinput2.Name = "cboinput2";
            this.cboinput2.Size = new System.Drawing.Size(338, 26);
            this.cboinput2.TabIndex = 19;
            this.cboinput2.SelectedIndexChanged += new System.EventHandler(this.cboinput2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "输出位置：";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(52, 316);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(379, 28);
            this.output.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 28);
            this.button1.TabIndex = 22;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbomath
            // 
            this.cbomath.FormattingEnabled = true;
            this.cbomath.Location = new System.Drawing.Point(151, 134);
            this.cbomath.Name = "cbomath";
            this.cbomath.Size = new System.Drawing.Size(132, 26);
            this.cbomath.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "运算：";
            // 
            // RasterCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbomath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboinput2);
            this.Controls.Add(this.cboinput1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expression);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RasterCalculate";
            this.Text = "栅格计算器";
            this.Load += new System.EventHandler(this.RasterCalculate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox expression;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cboinput1;
        private System.Windows.Forms.ComboBox cboinput2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbomath;
        private System.Windows.Forms.Label label5;
    }
}