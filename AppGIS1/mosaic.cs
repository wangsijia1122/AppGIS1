using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGIS1
{
    public partial class mosaic : Form
    {
        public string strOutputPath;
        public mosaic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择输入数据位置";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                fileGDB.Text = folderBrowserDialog.SelectedPath;
            }
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择输入数据位置";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            strOutputPath = filePath.Text + output.Text;
            RasterUtil rastUtil = new RasterUtil();
            rastUtil.Mosaic(fileGDB.Text, catalog.Text, filePath.Text, output.Text);
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("镶嵌完成！");
        }

        private void mosaic_Load(object sender, EventArgs e)
        {
            
            string tempDir = @"D:\ArcGIS\AppGIS";
            filePath.Text = tempDir;
            fileGDB.Text = tempDir;
        }
    }
}
