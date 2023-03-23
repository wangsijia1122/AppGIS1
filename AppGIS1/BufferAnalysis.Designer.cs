
namespace AppGIS1
{
    partial class BufferAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BufferAnalysis));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBufferDistance = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cboLayers = new System.Windows.Forms.ComboBox();
            this.cboUnits = new System.Windows.Forms.ComboBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "距离：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出图层：";
            // 
            // txtBufferDistance
            // 
            this.txtBufferDistance.Location = new System.Drawing.Point(28, 104);
            this.txtBufferDistance.Name = "txtBufferDistance";
            this.txtBufferDistance.Size = new System.Drawing.Size(288, 28);
            this.txtBufferDistance.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(28, 169);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(383, 28);
            this.textBox3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(417, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(389, 209);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 8;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cboLayers
            // 
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.Location = new System.Drawing.Point(28, 41);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(436, 26);
            this.cboLayers.TabIndex = 9;
            // 
            // cboUnits
            // 
            this.cboUnits.FormattingEnabled = true;
            this.cboUnits.Items.AddRange(new object[] {
            "Unknown",
            "Inches",
            "Points",
            "Feet",
            "Yards",
            "Miles",
            "NauticalMiles",
            "Millimeters",
            "Centimeters",
            "Meters",
            "Kilometers",
            "DecimalDegrees",
            "Decimeters"});
            this.cboUnits.Location = new System.Drawing.Point(322, 106);
            this.cboUnits.Name = "cboUnits";
            this.cboUnits.Size = new System.Drawing.Size(142, 26);
            this.cboUnits.TabIndex = 10;
            // 
            // txtMessages
            // 
            this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessages.Location = new System.Drawing.Point(0, 24);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(436, 158);
            this.txtMessages.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMessages);
            this.groupBox1.Location = new System.Drawing.Point(28, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 182);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理过程";
            // 
            // BufferAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 465);
            this.Controls.Add(this.cboUnits);
            this.Controls.Add(this.cboLayers);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtBufferDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BufferAnalysis";
            this.Text = "缓冲区分析";
            this.Load += new System.EventHandler(this.BufferAnalysis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBufferDistance;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cboLayers;
        private System.Windows.Forms.ComboBox cboUnits;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}