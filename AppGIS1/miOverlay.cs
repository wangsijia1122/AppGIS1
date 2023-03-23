using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;

namespace AppGIS1
{
    public partial class miOverlay : Form
    {
        public string strOutputPath;
        public miOverlay()
        {
            InitializeComponent();
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileOpen = new OpenFileDialog();
            FileOpen.Filter = "shp文件(*.shp)|*.shp";
            FileOpen.Title = "打开shp文件";
            //FileOpen.Multiselect = true;
            //初试化初试打开路径
            FileOpen.InitialDirectory = @"D:\ArcGIS\AppGIS\";

            if (FileOpen.ShowDialog() == DialogResult.OK)
            {
                textBoxInput.Text = FileOpen.FileName;
            }
        }

        private void buttonoutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "shp文件(*.shp)|*.shp";
            SaveFile.Title = "输出shp文件";
            //对话框关闭前还原当前目录
            SaveFile.RestoreDirectory = true;
            SaveFile.FileName = (string)cboOverLay.SelectedItem + ".shp";

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = SaveFile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*outputpath = txtOutputPath.Text.ToString();

            Union1(inputpath, outputpath);
            //将生成图层加入MapControl 
            int index = outputpath.LastIndexOf("\\");
            m_Map.AddShapeFile(outputpath.Substring(0, index), outputpath.Substring(index));*/

            //判断是否选择要素
            if (this.textBoxInput.Text == "" || this.textBoxInput.Text == null ||
                this.textBoxinput1.Text == "" || this.textBoxinput1.Text == null)
            {
                txtMessage.Text = "请设置叠置要素！";
                return;
            }
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            //OverwriteOutput为真时，输出图层会覆盖当前文件夹下的同名图层
            gp.OverwriteOutput = true;
            //设置参与叠置分析的多个对象
            object inputFeat = this.textBoxInput.Text;
            object overlayFeat = this.textBoxinput1.Text;
            IGpValueTableObject pObject = new GpValueTableObjectClass();
            pObject.SetColumns(2);
            pObject.AddRow(ref inputFeat);
            pObject.AddRow(ref overlayFeat);

            //获取要素名称
            string str = System.IO.Path.GetFileName(this.textBoxInput.Text);
            int index = str.LastIndexOf(".");
            string strName = str.Remove(index);

            //设置输出路径
            strOutputPath = txtOutputPath.Text;

            //叠置分析结果
            IGeoProcessorResult result = null;

            //创建叠置分析实例，执行叠置分析
            string strOverlay = cboOverLay.SelectedItem.ToString();
            try
            {
                //添加处理过程消息
                txtMessage.Text = "开始叠置分析……" + "\r\n";
                switch (strOverlay)
                {
                    case "求交(Intersect)":
                        Intersect intersectTool = new Intersect();
                        //设置输入要素
                        intersectTool.in_features = pObject;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_intersect.shp";
                        intersectTool.out_feature_class = strOutputPath;
                        //执行求交运算
                        result = gp.Execute(intersectTool, null) as IGeoProcessorResult;
                        break;
                    case "求并(Union)":
                        Union unionTool = new Union();
                        //设置输入要素
                        unionTool.in_features = pObject;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_union.shp";
                        unionTool.out_feature_class = strOutputPath;
                        //执行联合运算
                        result = gp.Execute(unionTool, null) as IGeoProcessorResult;
                        break;
                    case "标识(Identity)":
                        Identity identityTool = new Identity();
                        //设置输入要素
                        identityTool.in_features = inputFeat;
                        identityTool.identity_features = overlayFeat;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_identity.shp";
                        identityTool.out_feature_class = strOutputPath;
                        //执行标识运算
                        result = gp.Execute(identityTool, null) as IGeoProcessorResult;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                //添加处理过程消息
                txtMessage.Text += "叠置分析过程出现错误：" + ex.Message + "\r\n";
            }
            //判断叠置分析是否成功
            if (result.Status != ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobSucceeded)
                txtMessage.Text += "叠置失败!";
            else
            {
                this.DialogResult = DialogResult.OK;
                txtMessage.Text += "叠置成功!";
            }
        }

        private void miOverlay_Load(object sender, EventArgs e)
        {
            this.cboOverLay.Items.Add("求交(Intersect)");
            this.cboOverLay.Items.Add("求并(Union)");
            this.cboOverLay.Items.Add("标识(Identity)");
            this.cboOverLay.SelectedIndex = 0;
            //设置默认输出路径
            string tempDir = @"D:\ArcGIS\AppGIS\";
            txtOutputPath.Text = tempDir;
        }

        private void buttoninput1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileOpen = new OpenFileDialog();
            FileOpen.Filter = "shp文件(*.shp)|*.shp";
            FileOpen.Title = "打开shp文件";
            //FileOpen.Multiselect = true;
            //初试化初试打开路径
            FileOpen.InitialDirectory = @"D:\ArcGIS\AppGIS\";

            if (FileOpen.ShowDialog() == DialogResult.OK)
            {
                textBoxinput1.Text = FileOpen.FileName;
            }
        }

    }
}
