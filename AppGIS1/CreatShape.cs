using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;


namespace AppGIS1
{
    public partial class CreatShape : Form
    {
        public IMap Map;
        public String type;
        public CreatShape(IHookHelper hookHelper)
        {
            InitializeComponent();
            Map = hookHelper.FocusMap;
        }

        private void CreatShape_Load(object sender, EventArgs e)
        {
            cbotype.Items.Add("点");
            cbotype.Items.Add("线");
            cbotype.Items.Add("面");
            cbotype.SelectedIndex = 0;
        }

        private void cbotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbotype.SelectedIndex == 0)
            {
                type = "point";
            }
            else if(cbotype.SelectedIndex == 1)
            {
                type = "Polyline";
            }
            else if (cbotype.SelectedIndex == 2)
            {
                type = "Polygon";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建shape文件，将其以要素类形式获取，并判断是否成功。若失败，消息框提示，返回空
            DataOperator dataOperator = new DataOperator(Map);
            IFeatureClass featureClass = dataOperator.CreatShapefile("D:\\ArcGIS\\AppGIS", "ShapefileWorkspace", "ShapefileSample", type);
            
            if (featureClass == null)
            {
                MessageBox.Show("创建shape文件失败！");
                return;
            }

            //将要素类添加到地图中，其图层名"ObservationStation",并记录其结果。若为ture,将"创建shapefile"按钮禁用，消息框提示，返回空
            bool bRes = dataOperator.AddFeatureClassToMap(featureClass, "ObservationStation");
            if (bRes)
            {
                return;
            }
            else
            {
                MessageBox.Show("将新建shape文件加入地图失败！");
                return;
            }
        }
    }
}
