using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;//regex正则匹配
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;

namespace AppGIS1
{
    public partial class RasterCalculate : Form
    {
        IMap pmap;
        public string strOutputPath;// 输出图层路径
        private string folder;//输出文件夹
        private IGeoDataset GeoDataset1;
        private IGeoDataset GeoDataset2;
        private IGeoDataset result;
        private IMathOp mathOp;
        private ILogicalOp logicalOp;


        public RasterCalculate(AxMapControl axMapControl1)
        {
            InitializeComponent();
            pmap = axMapControl1.Map;
            mathOp = new RasterMathOps() as IMathOp;
            logicalOp = new RasterMathOps() as ILogicalOp;
        }

        private void jian_Click(object sender, EventArgs e)
        {
            try
            {
                if(cboinput1.SelectedItem==null||cboinput2.SelectedItem==null)
                {
                    MessageBox.Show("未选择图层");
                        return;
                }
                result = mathOp.Minus(GeoDataset1, GeoDataset2);
                ShowResult(result, folder, output.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "异常信息");
            }
        }

        private void ShowResult(IGeoDataset result,string folder,string ouput)
        {
            //打开输出栅格数据集所在的工作空间
            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactoryClass();
            IWorkspace pWorkspace = workspaceFactory.OpenFromFile(folder, 0);
            ISaveAs2 pSaveAs = result as ISaveAs2;
            pSaveAs.SaveAs(ouput, pWorkspace, "TIFF");
            MessageBox.Show("成功！");
        }

        private void RasterCalculate_Load(object sender, EventArgs e)
        {
            if (null == pmap|| 0 == pmap.LayerCount)
                return;

            for(int i=0;i<pmap.LayerCount;i++)
            {
                cboinput1.Items.Add(pmap.get_Layer(i).Name);
                cboinput2.Items.Add(pmap.get_Layer(i).Name);
            }
            //select the first layer
            if (cboinput1.Items.Count > 0)
                cboinput1.SelectedIndex = 0;
            if (cboinput2.Items.Count > 0)
                cboinput2.SelectedIndex = 0;
            this.cbomath.Items.Add("+");
            this.cbomath.Items.Add("-");
            this.cbomath.Items.Add("*");
            this.cbomath.Items.Add("/");
            this.cbomath.Items.Add(">");
            this.cbomath.Items.Add("<");
            this.cbomath.Items.Add("==");
            this.cbomath.Items.Add("!=");
            this.cbomath.SelectedIndex = 0;
        }

        private void cboinput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = GetLayerFromName((string)cboinput1.SelectedItem);
                IRasterLayer rasterLayer = layer as IRasterLayer;
                IRaster raster = rasterLayer.Raster;
                GeoDataset1 = raster as IGeoDataset;
            
            }
            catch
            {
                MessageBox.Show("未输入栅格数据");
            }

        }
        public ILayer GetLayerFromName(String sLayerName)
        {
            //判断图层名或地图对象是否为空。若为空，函数返回空
            if (sLayerName == "" || pmap == null)
            {
                return null;
            }

            //对地图对象中所有图层进行遍历。若某一图层的名称与指定图层名称相同，则返回该图层
            for (int i = 0; i < pmap.LayerCount; i++)
            {
                if (pmap.get_Layer(i).Name == sLayerName)
                {
                    return pmap.get_Layer(i);
                }
            }

            //若地图对象中的所有图层名均与指定图层名不匹配，函数返回空
            return null;
        }

        private void cboinput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = GetLayerFromName((string)cboinput2.SelectedItem);
                IRasterLayer rasterLayer = layer as IRasterLayer;
                IRaster raster = rasterLayer.Raster;
                GeoDataset2 = raster as IGeoDataset;

            }
            catch
            {
                MessageBox.Show("未输入栅格数据");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择输出数据位置";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folder = folderBrowserDialog.SelectedPath;
                output.Text = folderBrowserDialog.SelectedPath + "\\" + "result.tif";
                strOutputPath = output.Text;
            }
        }

        private void jia_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboinput1.SelectedItem == null || cboinput2.SelectedItem == null)
                {
                    MessageBox.Show("未选择图层");
                    return;
                }
                result = mathOp.Minus(GeoDataset1, GeoDataset2);
                ShowResult(result, folder, output.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "异常信息");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cboinput1.SelectedItem == null || cboinput2.SelectedItem == null)
            {
                MessageBox.Show("未选择图层");
                return;
            }
            string strmath = cbomath.SelectedItem.ToString();
            try
            {
                switch (strmath)
                {
                    case "+":
                        result = mathOp.Plus(GeoDataset1, GeoDataset2);
                        ShowResult(result, folder, output.Text);
                        break;
                    case "-":
                        result = mathOp.Minus(GeoDataset1, GeoDataset2);
                        ShowResult(result, folder, output.Text);
                        break;
                    case "*":
                        result = mathOp.Times(GeoDataset1, GeoDataset2);
                        ShowResult(result, folder, output.Text);
                        break;
                    case "/":
                        result = mathOp.Divide(GeoDataset1, GeoDataset2);
                        ShowResult(result, folder, output.Text);
                        break;
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "异常信息");
            }

        }
    }
}
