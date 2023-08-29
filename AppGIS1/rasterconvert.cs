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
    public partial class rasterconvert : Form
    {
        
        public rasterconvert()
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
            
            RasterUtil rastUtil = new RasterUtil();
            rastUtil.RasterConvert(fileGDB.Text, inputname.Text, filePath.Text, outputname.Text);
            MessageBox.Show("转换完成！");
        }
    }
}
