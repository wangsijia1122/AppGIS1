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
    public partial class DataBoard : Form
    {
        public DataBoard(String sDataName,DataTable dataTable)
        {
            //初始化窗体控件
            InitializeComponent();
            //设置文本框中的文本和数据网络视图的数据源
            tbDataName.Text = sDataName;
            dataGridView1.DataSource = dataTable;
        }

    }
}
