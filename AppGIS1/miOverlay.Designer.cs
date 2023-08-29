
namespace AppGIS1
{
    partial class miOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(miOverlay));
            this.button2 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.buttonoutput = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonInput = new System.Windows.Forms.Button();
            this.buttoninput1 = new System.Windows.Forms.Button();
            this.textBoxinput1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOverLay = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 16;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(0, 27);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(435, 129);
            this.txtMessage.TabIndex = 15;
            // 
            // buttonoutput
            // 
            this.buttonoutput.Location = new System.Drawing.Point(419, 219);
            this.buttonoutput.Name = "buttonoutput";
            this.buttonoutput.Size = new System.Drawing.Size(56, 28);
            this.buttonoutput.TabIndex = 14;
            this.buttonoutput.Text = "...";
            this.buttonoutput.UseVisualStyleBackColor = true;
            this.buttonoutput.Click += new System.EventHandler(this.buttonoutput_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(40, 219);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(373, 28);
            this.txtOutputPath.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "输出图层：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "输入要素：";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(40, 40);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(373, 28);
            this.textBoxInput.TabIndex = 18;
            // 
            // buttonInput
            // 
            this.buttonInput.Location = new System.Drawing.Point(420, 40);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(56, 28);
            this.buttonInput.TabIndex = 19;
            this.buttonInput.Text = "...";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // buttoninput1
            // 
            this.buttoninput1.Location = new System.Drawing.Point(420, 107);
            this.buttoninput1.Name = "buttoninput1";
            this.buttoninput1.Size = new System.Drawing.Size(56, 28);
            this.buttoninput1.TabIndex = 22;
            this.buttoninput1.Text = "...";
            this.buttoninput1.UseVisualStyleBackColor = true;
            this.buttoninput1.Click += new System.EventHandler(this.buttoninput1_Click);
            // 
            // textBoxinput1
            // 
            this.textBoxinput1.Location = new System.Drawing.Point(40, 107);
            this.textBoxinput1.Name = "textBoxinput1";
            this.textBoxinput1.Size = new System.Drawing.Size(373, 28);
            this.textBoxinput1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "叠置要素：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "叠置方式：";
            // 
            // cboOverLay
            // 
            this.cboOverLay.FormattingEnabled = true;
            this.cboOverLay.Location = new System.Drawing.Point(132, 154);
            this.cboOverLay.Name = "cboOverLay";
            this.cboOverLay.Size = new System.Drawing.Size(281, 26);
            this.cboOverLay.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Location = new System.Drawing.Point(40, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 147);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理过程";
            // 
            // miOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 475);
            this.Controls.Add(this.cboOverLay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttoninput1);
            this.Controls.Add(this.textBoxinput1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonInput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonoutput);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "miOverlay";
            this.Text = "叠置分析";
            this.Load += new System.EventHandler(this.miOverlay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button buttonoutput;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Button buttoninput1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOverLay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxinput1;
    }
}