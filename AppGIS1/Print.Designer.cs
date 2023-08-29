
namespace AppGIS1
{
    partial class Print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.optPortrait = new System.Windows.Forms.RadioButton();
            this.optLandscape = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.label3 = new System.Windows.Forms.Label();
            this.cboscale = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "纸张大小:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "纸张方向:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(597, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboPageSize
            // 
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Location = new System.Drawing.Point(474, 52);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(210, 26);
            this.cboPageSize.TabIndex = 9;
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged_1);
            // 
            // optPortrait
            // 
            this.optPortrait.AutoSize = true;
            this.optPortrait.Location = new System.Drawing.Point(567, 114);
            this.optPortrait.Name = "optPortrait";
            this.optPortrait.Size = new System.Drawing.Size(69, 22);
            this.optPortrait.TabIndex = 10;
            this.optPortrait.TabStop = true;
            this.optPortrait.Text = "横向";
            this.optPortrait.UseVisualStyleBackColor = true;
            this.optPortrait.Click += new System.EventHandler(this.optPortrait_Click);
            // 
            // optLandscape
            // 
            this.optLandscape.AutoSize = true;
            this.optLandscape.Location = new System.Drawing.Point(567, 143);
            this.optLandscape.Name = "optLandscape";
            this.optLandscape.Size = new System.Drawing.Size(69, 22);
            this.optLandscape.TabIndex = 11;
            this.optLandscape.TabStop = true;
            this.optLandscape.Text = "纵向";
            this.optLandscape.UseVisualStyleBackColor = true;
            this.optLandscape.Click += new System.EventHandler(this.optLandscape_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axPageLayoutControl1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 517);
            this.panel1.TabIndex = 12;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(415, 517);
            this.axPageLayoutControl1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "比例尺类型：";
            // 
            // cboscale
            // 
            this.cboscale.FormattingEnabled = true;
            this.cboscale.Location = new System.Drawing.Point(474, 213);
            this.cboscale.Name = "cboscale";
            this.cboscale.Size = new System.Drawing.Size(210, 26);
            this.cboscale.TabIndex = 15;
            this.cboscale.SelectedIndexChanged += new System.EventHandler(this.cboscale_SelectedIndexChanged);
            // 
            // Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 544);
            this.Controls.Add(this.cboscale);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.optLandscape);
            this.Controls.Add(this.optPortrait);
            this.Controls.Add(this.cboPageSize);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Print";
            this.Text = "打印";
            this.Load += new System.EventHandler(this.Print_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.RadioButton optPortrait;
        private System.Windows.Forms.RadioButton optLandscape;
        private System.Windows.Forms.Panel panel1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboscale;
    }
}