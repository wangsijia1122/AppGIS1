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
/*using ESRI.ArcGIS.Utility;*/



namespace AppGIS1
{
    public partial class AEGIS软件开发实践 : Form
    {
        IMap pMap;
        IActiveView pActiveView;

        public AEGIS软件开发实践()
        {
            InitializeComponent();   //窗体控件初始化
        }

        private void AEGIS软件开发实践_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            axTOCControl1.SetBuddyControl(axMapControl1);
            axToolbarControl1.SetBuddyControl(axMapControl1);
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            pMap = axMapControl1.Map;
            pActiveView = pMap as IActiveView;
            IEnvelope pEnv;
            pEnv = axMapControl1.TrackRectangle();
            pActiveView.Extent = pEnv;
            pActiveView.Refresh();
        }

        private void 地图加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFdlg = new OpenFileDialog();
            OpenFdlg.Title = "请选择地理数据";
            OpenFdlg.Filter = "Shape格式文件(*.shp)|*.shp";
            OpenFdlg.ShowDialog();
            string strFileName = OpenFdlg.FileName;
            if (strFileName == string.Empty)
                return;
            string pathName = System.IO.Path.GetDirectoryName(strFileName); // pathName文件夹路径
            string fileName = System.IO.Path.GetFileNameWithoutExtension(strFileName); // fileName不包含扩展名的文件名
            axMapControl1.AddShapeFile(pathName, fileName);
            axMapControl2.ClearLayers(); // 鹰眼视图显示单个图层，注释掉显示多个图层
            axMapControl2.AddShapeFile(pathName, fileName);
            axMapControl2.Extent = axMapControl2.FullExtent; // 设置为全局视图
        }
        
        //创建书签
        public void CreateBookmark(string sBookmarkName)//参数为书签名
        {
          //通过IAOIBookmark接口创造一个变量，其类型为AOIBookmark,用于保存当地的地图范围。
            IAOIBookmark aoiBookmark = new AOIBookmarkClass();
            if(aoiBookmark!=null)
            {
                aoiBookmark.Location = axMapControl1.ActiveView.Extent;
                aoiBookmark.Name = sBookmarkName;
            }  
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;//接口跳转
            if(bookmarks!=null)
            {
                bookmarks.AddBookmark(aoiBookmark);
            }
            cbBookmarkList.Items.Add(aoiBookmark.Name);
        }

        private void miCreateBookmark_Click(object sender, EventArgs e) // 点击创建书签事件
        {
            AdmitBookmarkName frmABN = new AdmitBookmarkName(this);
            frmABN.Show();
        }

        private void cbBookmarkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //访问地图所包含的书签，并获取书签序列
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            IEnumSpatialBookmark enumSpatialBookmark = bookmarks.Bookmarks;

            //对地图所包含的书签进行遍历，获取与组合框所选项名称相符的书签
            enumSpatialBookmark.Reset();
            ISpatialBookmark spatialBookmark = enumSpatialBookmark.Next();
            while (spatialBookmark !=null)
            {
                if (cbBookmarkList.SelectedItem.ToString()==spatialBookmark.Name)
                {
                    spatialBookmark.ZoomTo((IMap)axMapControl1.ActiveView);
                    axMapControl1.ActiveView.Refresh();
                    break;
                }

                spatialBookmark = enumSpatialBookmark.Next();
            }
        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            IMap pMap;
            pMap = axMapControl1.Map;
            for(int i=0;i<pMap.LayerCount;i++)
            {
                axMapControl2.Extent = axMapControl2.FullExtent;

            }
        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPt = new PointClass();
                pPt.X = e.mapX;
                pPt.Y = e.mapY;
                IEnvelope pEnvelope = axMapControl1.Extent as IEnvelope;
                pEnvelope.CenterAt(pPt);
                axMapControl1.Extent = pEnvelope;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

            }
            else if(e.button == 2)
            {
                IEnvelope pEnvelope = axMapControl2.TrackRectangle();
                axMapControl1.Extent = pEnvelope;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }

        }

        private void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button != 1)
                return;
            IPoint pPt = new PointClass();
            pPt.X = e.mapX;
            pPt.Y = e.mapY;
            axMapControl1.CenterAt(pPt);
            axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);


        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            IActiveView pAv = pGraphicsContainer as IActiveView;
            //在绘制前，清除axMapControl2中图形
            pGraphicsContainer.DeleteAllElements();
            IRectangleElement pRecElement = new RectangleElementClass();
            IElement pEle = pRecElement as IElement;
            IEnvelope pEnv;
            pEnv = e.newEnvelope as IEnvelope;
            pEle.Geometry = pEnv;
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 200;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            //产生一个线性符号
            ILineSymbol pLineSymbol=new SimpleLineSymbolClass();
            pLineSymbol.Width = 2;
            pLineSymbol.Color = pColor;
            //设置填充符号的属性
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            //设置透明颜色
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pLineSymbol;
            IFillShapeElement pFillShapeElement = pRecElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement(pEle, 0);
            axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private void miAccessData_Click(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);//构造函数
            DataBoard dataBoard = new DataBoard(
                "各大洲洲名",
            dataOperator.GetContinentsNames());       
            dataBoard.Show();
        }

        private void transformData_Click(object sender, EventArgs e) // 数据转换点击事件
        {
            Transform transform = new Transform(" ","qh1", " ", "traqh");
            transform.m_frmMain = this;//子窗体调用主窗体函数定义
            transform.Show();
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap pBasicMap = null;
            ILayer pLayer = null;
            object unk = null;
            object data = null;
            axTOCControl1.HitTest(e.x, e.y, ref item, ref pBasicMap, ref pLayer, ref unk, ref data);

        }

        private void miRenderSimply_Click(object sender, EventArgs e)
        {
            //获取渲染图层
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            ILayer layer = dataOperator.GetLayerByName("cntry02");

            //通过IRgbColor接口新建RgbColor类型对象，将其设置为红色
            IRgbColor rgbColor = new RgbColorClass();
            rgbColor.Red = 255;
            rgbColor.Green = 0;
            rgbColor.Blue  = 0;

            //获取渲染图层消息，并通过IColor接口访问设置好的颜色对象
            ISymbol symbol = MapComposer.GetSymbolFromLayer(layer);
            IColor color = rgbColor as IColor;

            //实现渲染图层的简单渲染，并判断是否成功。若函数返回true,当前活动视图刷新，显示渲染效果，并使得渲染图层菜单项不再可用；
            //若函数返回false,消息框提示失败
            bool bRes = MapComposer.RenderSimple(layer, color);
           if(bRes)
           {
                axTOCControl1.ActiveView.ContentsChanged();
                axMapControl1.ActiveView.Refresh();
                miRenderSimply.Enabled = false;
           }
           else
           {
                MessageBox.Show("简单渲染图层失败");
           }                      
        }

        private void miGetRendererInfo_Click(object sender, EventArgs e)
        {
            //获取渲染图层
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            ILayer layer = dataOperator.GetLayerByName("cntry02");

            //消息框提示该图层的渲染器类型信息
            MessageBox.Show(MapComposer.GetRendererTypeByLayer(layer));
        }
    }
}
