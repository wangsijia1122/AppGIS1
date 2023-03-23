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
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;

namespace AppGIS1
{
    public partial class miClip : Form
    {
        //定义相关变量，实例化
        private static IMapDocument m_MapDocument = new MapDocumentClass();
        private static OpenFileDialog OpenFileDlg1 = new OpenFileDialog();
        private static SaveFileDialog SaveFileDlg = new SaveFileDialog();
        private static OpenFileDialog OpenFileDlg2 = new OpenFileDialog();
        private static string sFilePath;
        public string strOutputPath;

        public miClip()
        {
            InitializeComponent();
        }

        private void btnIutputPath_Click(object sender, EventArgs e)
        {
            ////定义OpenfileDialog 要裁剪的要素 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "加载要裁剪的要素";
            openFileDialog1.Filter = "ShapeFile(*.shp)|*.shp";
            openFileDialog1.Multiselect = false;
            //检验文件和路径是否存在
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            //初始化初始打开路径
            openFileDialog1.InitialDirectory = @"D:\ArcGIS\AppGIS\";
            DialogResult pDialogResult = openFileDialog1.ShowDialog();
            //读取文件路径到textBox1中
            if (pDialogResult != DialogResult.OK)
                return;
            this.textBox1.Text = openFileDialog1.FileName;
        }

        private void btnClipPath_Click(object sender, EventArgs e)
        {
            //打开shp文件对话框 用于裁剪输入要素的要素
            OpenFileDlg2.Title = "加载用于裁剪输入要素的要素";
            OpenFileDlg2.Filter = "shp文件(*.shp)|*.shp";
            OpenFileDlg2.ShowDialog();
            OpenFileDlg2.InitialDirectory = @"D:\ArcGIS\AppGIS\";
            sFilePath = OpenFileDlg2.FileName;
            textBox2.Text = OpenFileDlg2.FileName;//在textbox中显示选择的文件
            if (m_MapDocument.get_IsMapDocument(sFilePath))
            {
                m_MapDocument.Open(sFilePath, "");
            }

        }
        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            SaveFileDlg.Title = "输出要素类";
            SaveFileDlg.Filter = "要素类(*.shp)|*.shp";
            SaveFileDlg.OverwritePrompt = false;
            //读取文件输出路径到txtOutputPath
            if (sFilePath == "") return;
            DialogResult dr = SaveFileDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputPath.Text = SaveFileDlg.FileName;
        }

        private void geo_Clip_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text == string.Empty || this.textBox1.Text == string.Empty)
            {
                return;
            }
            //初始化Clip
            Geoprocessor GP = new Geoprocessor();
            ESRI.ArcGIS.AnalysisTools.Clip pClip = new ESRI.ArcGIS.AnalysisTools.Clip();
            //OverwriteOutput为真时，输出图层会覆盖当前文件夹下的同名图层
            GP.OverwriteOutput = true;
            //设置参与叠置分析的多个对象
            object inputFeat = this.textBox1.Text;
            object clipFeat = this.textBox2.Text;
            IGpValueTableObject pObject = new GpValueTableObjectClass();
            pObject.SetColumns(2);
            pObject.AddRow(ref inputFeat);
            pObject.AddRow(ref clipFeat);
            //获取要素名称
            string str = System.IO.Path.GetFileName(this.textBox1.Text);
            int index = str.LastIndexOf(".");
            string strName = str.Remove(index);
            //设置输出路径
            strOutputPath = txtOutputPath.Text;

            //叠置分析结果
            IGeoProcessorResult result = null;

            //执行分析
            pClip.in_features = inputFeat;
            pClip.clip_features = textBox2.Text;
            //设置输出路径
            strOutputPath += strName + "_" + "_clip.shp";
            pClip.out_feature_class = strOutputPath;
            //执行剪切运算
            result = GP.Execute(pClip, null) as IGeoProcessorResult;

            //判断叠置分析是否成功
            if (result.Status != ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobSucceeded)
            {
                MessageBox.Show("剪切失败");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("剪切成功");
            }

        }
    }
}
