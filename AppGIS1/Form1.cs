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
/*using ESRI.ArcGIS.Utility;*/



namespace AppGIS1
{
    public partial class AEGIS软件开发实践 : Form
    {
        IMap pMap;
        IActiveView pActiveView;
        public ILayer pLayer; //定义一个全局变量pLayer 选中的图层
        private IActiveViewEvents_Event ave; //响应图层移除事件
        private List<ILayer> plstLayers = null;//单击ComboBox获取图层名：
        private IFeatureLayer pCurrentLyr = null;
        private IEngineEditor pEngineEditor = null;
        private IEngineEditLayers pEngineEditLayers = null;

        //IPointCollection lineCollect;//添加点集合;
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
            IEnvelope pEnv;//定义范围
            pEnv = axMapControl1.TrackRectangle();
            pActiveView.Extent = pEnv;
            pActiveView.Refresh();

            //在添加要素菜单项被勾选时进行以下操作
            //添加点要素
            if (miAddFeature.Checked == true)
            {
                IPoint point = new PointClass();
                point.PutCoords(e.mapX, e.mapY);

                DataOperator dataOperator = new DataOperator(axMapControl1.Map);
                dataOperator.AddFeatureToLayer("ObservationStation", "观测站", point);
                return;

            }

            //添加线要素
            if (miAddLine.Checked == true)
            {
                IGeometry polyline = axMapControl1.TrackLine();
                ILineElement pLineElement = new LineElementClass();
                IElement pElement = pLineElement as IElement;
                pElement.Geometry = polyline;
                IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                pGraphicsContainer.AddElement((IElement)pLineElement, 0);
                DataOperator dataOperator = new DataOperator(axMapControl1.Map);
                dataOperator.AddPolylineToLayer("ObservationStation", "观测站", polyline);
                return;
            }

            //添加面要素
            if (miAddPolygon.Checked == true)
            {
                IGeometry Polygon = axMapControl1.TrackPolygon();
                IPolygonElement PolygonElement = new PolygonElementClass();
                IElement pElement = PolygonElement as IElement;
                pElement.Geometry = Polygon;
                IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                pGraphicsContainer.AddElement((IElement)PolygonElement, 0);
                DataOperator dataOperator = new DataOperator(axMapControl1.Map);
                dataOperator.AddPolylineToLayer("ObservationStation", "观测站", Polygon);
                pActiveView.Refresh();
            }

        }

        private void 地图加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFdlg = new OpenFileDialog();
            OpenFdlg.Title = "请选择地理数据";
            OpenFdlg.Filter = "Shapefile文件|*.shp|栅格文件(*.jpg,*.bmp,*.tif,*.img)|*.jpg;*.bmp;*.tif;*.img|mxd|*.mxd|Access文件(*.mdb)|*.mdb|lyr文件(*.lyr)|*.lyr";
            OpenFdlg.ShowDialog();
            string strFileName = OpenFdlg.FileName;
            if (strFileName == string.Empty)
                return;

            string pathName = System.IO.Path.GetDirectoryName(strFileName); // pathName文件夹路径
            string fileName = System.IO.Path.GetFileNameWithoutExtension(strFileName); // fileName不包含扩展名的文件名
            string fName = System.IO.Path.GetFileName(strFileName); // fName包含扩展名
            if (Regex.IsMatch(strFileName, @"(.*)(\.shp)$"))//加载矢量图层
            {
                axMapControl1.AddShapeFile(pathName, fileName);
                //axMapControl2.ClearLayers(); // 鹰眼视图显示单个图层，注释掉显示多个图层
                axMapControl2.AddShapeFile(pathName, fileName);
            }
            else if (Regex.IsMatch(strFileName, @"(.*)(\.jpg|\.bmp|\.tif|\.img)$"))
            {
                IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();//新建一个Raster工厂类

                IRasterWorkspace pRasterWorkspace = pWorkspaceFactory.OpenFromFile(pathName, 0) as IRasterWorkspace;//使用工厂类打开一个栅格工作空间

                IRasterDataset rasterDataset = new RasterDatasetClass();//新建栅格数据集和栅格图层   
                IRasterLayer rasterLay = new RasterLayerClass();

                IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(fName);
                //影像金字塔判断与创建
                IRasterPyramid3 pRasPyrmid;
                pRasPyrmid = pRasterDataset as IRasterPyramid3;
                if (pRasPyrmid != null)
                {
                    if (!(pRasPyrmid.Present))
                    {
                        pRasPyrmid.Create(); //创建金字塔
                    }
                }
                IRaster pRaster;
                pRaster = pRasterDataset.CreateDefaultRaster();
                IRasterLayer pRasterLayer;
                pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromRaster(pRaster);

                axMapControl1.AddLayer(pRasterLayer, 0);
                axMapControl2.AddLayer(pRasterLayer, 0);
            }
            else if (Regex.IsMatch(strFileName, @"(.*)(\.mxd)$"))
            {
                axMapControl1.LoadMxFile(strFileName);
                axMapControl1.ActiveView.Refresh();
                axMapControl2.LoadMxFile(strFileName);
                axMapControl2.ActiveView.Refresh();
            }
            else if (Regex.IsMatch(strFileName, @"(.*)(\.lyr)$"))
            {
                axMapControl1.AddLayerFromFile(strFileName);
                axMapControl1.ActiveView.Refresh();
            }
            axMapControl2.Extent = axMapControl2.FullExtent;
        }
        //退出程序
        private void Exit_Click(object sender, EventArgs e)
        {
            while (MessageBox.Show("是否退出当前窗体？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }
        //创建书签
        public void CreateBookmark(string sBookmarkName)//参数为书签名
        {
            //通过IAOIBookmark接口创造一个变量，其类型为AOIBookmark,用于保存当地的地图范围。
            IAOIBookmark aoiBookmark = new AOIBookmarkClass();
            if (aoiBookmark != null)
            {
                aoiBookmark.Location = axMapControl1.ActiveView.Extent;
                aoiBookmark.Name = sBookmarkName;
            }
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;//接口跳转
            if (bookmarks != null)
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
            while (spatialBookmark != null)
            {
                if (cbBookmarkList.SelectedItem.ToString() == spatialBookmark.Name)
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
            for (int i = 0; i < pMap.LayerCount; i++)//当主视图替换时鹰眼视图也替换
            {
                axMapControl2.Extent = axMapControl2.FullExtent;
            }
            ave = axMapControl1.Map as IActiveViewEvents_Event;
            ave.ItemDeleted += new IActiveViewEvents_ItemDeletedEventHandler(ave_ItemDeleted);
        }
        void ave_ItemDeleted(object Item)
        {
            if (Item is ILayer)
            {
                ILayer pLayer = Item as ILayer;
                MessageBox.Show("图层" + pLayer.Name + "已被移除!");
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
            else if (e.button == 2)
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
            ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
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
            Transform transform = new Transform(" ", "qh1", " ", "traqh");
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
            axTOCControl1.HitTest(e.x, e.y, ref item, ref pBasicMap, ref pLayer, ref unk, ref data); //获取鼠标点击信息
        }

        private void miRenderSimply_Click(object sender, EventArgs e)//简单渲染
        {
            //获取渲染图层
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            ILayer layer = dataOperator.GetLayerByName("cntry02");

            //通过IRgbColor接口新建RgbColor类型对象，将其设置为红色
            IRgbColor rgbColor = new RgbColorClass();
            rgbColor.Red = 255;
            rgbColor.Green = 0;
            rgbColor.Blue = 0;

            //获取渲染图层消息，并通过IColor接口访问设置好的颜色对象
            ISymbol symbol = MapComposer.GetSymbolFromLayer(layer);
            IColor color = rgbColor as IColor;

            //实现渲染图层的简单渲染，并判断是否成功。若函数返回true,当前活动视图刷新，显示渲染效果，并使得渲染图层菜单项不再可用；
            //若函数返回false,消息框提示失败
            bool bRes = MapComposer.RenderSimple(layer, color);
            if (bRes)
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

        private void miPageLayout_Click(object sender, EventArgs e)
        {
            //点击“显示页面布局”菜单项并使其被勾选时。显示页面布局控件，隐藏地图控件，
            //并使工具条控件和TOC控件与页面控件进行关联，同时激活“打印”菜单项，反之则做逆向操作
            if (miPageLayout.Checked == false)
            {
                axToolbarControl1.SetBuddyControl(axPageLayoutControl1.Object);
                axTOCControl1.SetBuddyControl(axPageLayoutControl1.Object);

                axPageLayoutControl1.Show();
                axMapControl1.Hide();

                miPageLayout.Checked = true;
                miMap.Checked = false;
                miPrint.Enabled = true;

            }
            else
            {
                axToolbarControl1.SetBuddyControl(axMapControl1.Object);
                axTOCControl1.SetBuddyControl(axMapControl1.Object);

                axPageLayoutControl1.Hide();
                axMapControl1.Show();

                miPageLayout.Checked = false;
                miMap.Checked = true;
                miPrint.Enabled = false;
            }
        }

        private void miMap_Click(object sender, EventArgs e)
        {
            //点击“显示地图”菜单项并使其被勾选时，显示地图控件，隐藏页面布局控件，
            //并使工具条控件和TOC控件与地图控件进行关联，同时“打印”菜单项灰化；反之则做逆向操作
            if (miMap.Checked == false)
            {
                axToolbarControl1.SetBuddyControl(axMapControl1.Object);
                axTOCControl1.SetBuddyControl(axMapControl1.Object);

                axPageLayoutControl1.Hide();
                axMapControl1.Show();

                miPageLayout.Checked = false;
                miMap.Checked = true;
                miPrint.Enabled = false;
            }
            else
            {
                axToolbarControl1.SetBuddyControl(axPageLayoutControl1.Object);
                axTOCControl1.SetBuddyControl(axPageLayoutControl1.Object);

                axPageLayoutControl1.Show();
                axMapControl1.Hide();

                miPageLayout.Checked = true;
                miMap.Checked = false;
                miPrint.Enabled = true;
            }
        }

        private void miPrint_Click(object sender, EventArgs e)
        {
            //通过IPrinter接口访问页面布局控件默认的打印机，并判断是否成功。若失败，消息框提示“获取默认打印机失败”
            IPrinter printer = axPageLayoutControl1.Printer;
            if (printer == null)
            {
                MessageBox.Show("获取默认打印机失败");
            }

            //消息框提示“是否使用默认打印机：打印机名称？”。若点击“取消”，则退出打印作业
            String sMsg = "是否使用默认打印机：" + printer.Name + "?";
            if (MessageBox.Show(sMsg, "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            //通过IPaper接口访问打印机的纸张，设置其方向为纵向
            IPaper paper = printer.Paper;
            paper.Orientation = 1;

            //通过IPage接口访问布局控件的页，设置其打印分页为缩小到一页。
            IPage page = axPageLayoutControl1.Page;
            page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
            //打印首张页面且无重叠
            axPageLayoutControl1.PrintPageLayout(1, 1, 0);


        }

        private void miOutput_Click(object sender, EventArgs e)//地图输出
        {
            IActiveView docActiveView;
            IExport docExport;
            IPrintAndExport docPrintExport;
            int iOutputResolution = 300;

            if (miPageLayout.Checked == false)//如果页面布局是当前视图，则输出页面布局
            {
                docActiveView = axMapControl1.ActiveView;
            }
            else
            {
                docActiveView = axPageLayoutControl1.ActiveView;
            }

            docExport = new ExportJPEGClass();
            docPrintExport = new PrintAndExportClass();
            //设置输出文件名
            docExport.ExportFileName = "D:\\Export.JPG";
            //输出当前视图到输出文件
            docPrintExport.Export(docActiveView, docExport, iOutputResolution, true, null);
            MessageBox.Show("输出成功");

        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            IActiveView pActiveView = (IActiveView)this.axPageLayoutControl1.ActiveView.FocusMap;
            IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
            displayTransformation.VisibleBounds = this.axMapControl1.Extent;
            axPageLayoutControl1.ActiveView.Refresh();

            //布局视图与数据视图的同步
            IObjectCopy pObjectCopy = new ObjectCopy() as IObjectCopy;
            object copyFromMap = this.axMapControl1.Map;
            object copiedMap = pObjectCopy.Copy(copyFromMap);//复制地图到copiedMap中
            object copyToMap = axPageLayoutControl1.ActiveView.FocusMap;
            pObjectCopy.Overwrite(copiedMap, ref copyToMap); //复制地图
            axPageLayoutControl1.ActiveView.Refresh();
        }

        private void miPrintSetting_Click(object sender, EventArgs e)//打印页面设置
        {
            IHookHelper hookHelper = new HookHelperClass();
            hookHelper.Hook = this.axPageLayoutControl1.Object;
            Print print = new Print(hookHelper);
            print.Show();
        }

        private void miCreateShapefile_Click(object sender, EventArgs e)
        {
            IHookHelper hookHelper = new HookHelperClass();
            hookHelper.Hook = this.axMapControl1.Object;
            CreatShape createshape = new CreatShape(hookHelper);
            createshape.Show();
        }

        private void AddFeature_Click(object sender, EventArgs e)
        {
            if (miAddFeature.Checked == false)
            {
                miAddFeature.Checked = true;
            }
            else
            {
                miAddFeature.Checked = false;
            }
        }

        private void miAddLine_Click(object sender, EventArgs e)
        {
            if (miAddLine.Checked == false)
            {
                miAddLine.Checked = true;
            }
            else
            {
                miAddLine.Checked = false;
            }
        }

        private void miAddPolygon_Click(object sender, EventArgs e)
        {
            if (miAddPolygon.Checked == false)
            {
                miAddPolygon.Checked = true;
            }
            else
            {
                miAddPolygon.Checked = false;
            }
        }

        private void miSpatilFilter_Click(object sender, EventArgs e)
        {
            MapAnalysis mapAnalysis = new MapAnalysis();
            mapAnalysis.QueryIntersect("bou2_4p", "cntry02", axMapControl1.Map, esriSpatialRelationEnum.esriSpatialRelationIntersection);
            IActiveView activeView;
            activeView = axMapControl1.ActiveView;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, 0, axMapControl1.Extent);
        }

        private void miBuffer_Click(object sender, EventArgs e)
        {
            IHookHelper hookHelper = new HookHelperClass();
            hookHelper.Hook = this.axMapControl1.Object;
            BufferAnalysis buffer = new BufferAnalysis(hookHelper);
            //buffer.Show();
            if (buffer.ShowDialog() == DialogResult.OK)
            {
                //获取输出文件路径
                string strOverlayPath = buffer.strOutputPath;
                //叠置分析后的图层载入到MapControl
                int index = strOverlayPath.LastIndexOf("\\");
                this.axMapControl1.AddShapeFile(strOverlayPath.Substring(0, index), strOverlayPath.Substring(index));
            }
        }

        private void miStatistic_Click(object sender, EventArgs e)
        {
            MapAnalysis mapAnalysis = new MapAnalysis();
            string sMsg;
            sMsg = mapAnalysis.Statistic("cntry02", "SQMI", axMapControl1.Map);
            MessageBox.Show(sMsg);
        }

        private void axTOCControl1_OnMouseMove(object sender, ITOCControlEvents_OnMouseMoveEvent e)
        {
            int index = axToolbarControl1.HitTest(e.x, e.y, false); //
            if (index != -1)
            {
                ESRI.ArcGIS.Controls.IToolbarItem toolBarItem = axToolbarControl1.GetItem(index);
                MessageLabel.Text = toolBarItem.Command.Message;
            }
            else
            {
                MessageLabel.Text = "就绪";
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            ScaleLabel.Text = "比例尺1：" + ((long)this.axMapControl1.MapScale).ToString();
            CoordinateLabel.Text = "当前坐标 X=" + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + this.axMapControl1.MapUnits.ToString().Substring(4); ;
        }

        private void axTOCControl1_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            //实例化函数中的五个参数
            esriTOCControlItem Item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null; //Map object,if selected
            ILayer layer = null; //Layer object,if selected
            object group = null; //Group Layer,if selected
            object groupIndex = null; //Layer index,if group Layer selected

            //根据鼠标所在的位置测试判断其所指向的对象
            //HitTest()函数
            axTOCControl1.HitTest(e.x, e.y, ref Item, ref map, ref layer, ref group, ref groupIndex);

            if (e.button == 2 && Item == esriTOCControlItem.esriTOCControlItemLayer) //点击对象是图层的话，就显示右键菜单  e.button=2代表鼠标右击，=1是单击左键
            {
                pLayer = layer;
                //显示右键菜单，并定义其相对控件的位置
                contextMenuStrip1.Show(axTOCControl1, e.x, e.y);
            }
        }

        private void RemoveLayer_Click(object sender, EventArgs e) //删除图层
        {
            if (pLayer != null) //选中图层
            {
                axMapControl1.Map.DeleteLayer(pLayer); //调用DeleteLayer方法删除图层
                axMapControl2.ClearLayers(); ; //调用DeleteLayer方法删除图层
                pLayer = null;
            }
        }

        private void OpenAttributeTable_Click(object sender, EventArgs e) //打开属性表
        {
            AttributeTable pAttributeTable = new AttributeTable(pLayer); //**
            pAttributeTable.Show();
            pAttributeTable.Text = "属性表：" + pLayer.Name;
        }

        private void getpath_Click(object sender, EventArgs e)
        {
            IDatasetName pDatasetName = (pLayer as IDataLayer2).DataSourceName as IDatasetName;
            IWorkspaceName pWorkspaceName = pDatasetName.WorkspaceName;
            MessageBox.Show(pWorkspaceName.PathName + pLayer.Name);
        }

        private void SaveMxd_Click(object sender, EventArgs e)
        {
            try
            {
                if (axMapControl1.LayerCount == 0)
                {
                    MessageBox.Show("无可存地图文档！");
                    return;
                }
                else if (axMapControl1.LayerCount != 0)
                {
                    MessageBox.Show("是否保存当前操作？");
                    string sMxdFileName = axMapControl1.DocumentFilename;
                    IMapDocument pMapDocument = new MapDocumentClass();
                    if (sMxdFileName != null && axMapControl1.CheckMxFile(sMxdFileName))
                    {
                        if (pMapDocument.get_IsReadOnly(sMxdFileName))
                        {
                            MessageBox.Show("本地图文档是只读的，不能保存！");
                            pMapDocument.Close();
                            return;
                        }
                    }
                    else
                    {
                        SaveFileDialog pSavedlg = new SaveFileDialog();
                        pSavedlg.Title = "请选择保存路径";
                        pSavedlg.OverwritePrompt = true;
                        pSavedlg.Filter = "ArcMap文档(*.mxd)|*.mxd|ArcMap模板(*.mxt)|*.mxt";
                        pSavedlg.RestoreDirectory = true;
                        if (pSavedlg.ShowDialog() == DialogResult.OK)
                        {
                            sMxdFileName = pSavedlg.FileName;
                        }
                        else
                        {
                            return;
                        }
                    }
                    pMapDocument.New(sMxdFileName);
                    pMapDocument.ReplaceContents(axMapControl1.Map as IMxdContents);
                    pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                    pMapDocument.Close();
                    MessageBox.Show("保存地图文档成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存地图文档失败" + ex.Message);
            }
        }

        private void CreateMxd_Click(object sender, EventArgs e)
        {
            NewMapDoc();
        }
        public string NewMapDoc()
        {
            SaveFileDialog SaveFileDlg = new SaveFileDialog();
            SaveFileDlg.Title = "输入需要新建地图文档的名称";
            SaveFileDlg.Filter = "地图文件(*.mxd)|*.mxd";
            SaveFileDlg.ShowDialog();
            string strDocFileN = string.Empty;
            strDocFileN = SaveFileDlg.FileName;
            if (strDocFileN == string.Empty)
                return null;
            MapDocumentClass pMapDocument = new MapDocumentClass();
            pMapDocument.New(strDocFileN);
            pMapDocument.Open(strDocFileN, "");
            axMapControl1.Map = pMapDocument.get_Map(0);
            axMapControl1.DocumentFilename = pMapDocument.DocumentFilename;
            pMapDocument.Close();
            return axMapControl1.DocumentFilename;
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            try
            {

                if (axMapControl1.LayerCount != 0)
                {
                    MessageBox.Show("是否另存当前操作？");
                    string sMxdFileName = axMapControl1.DocumentFilename;
                    IMapDocument pMapDocument = new MapDocumentClass();
                    if (sMxdFileName != null && axMapControl1.CheckMxFile(sMxdFileName))
                    {
                        if (pMapDocument.get_IsReadOnly(sMxdFileName))
                        {
                            MessageBox.Show("本地图文档是只读的，不能保存！");
                            pMapDocument.Close();
                            return;
                        }
                    }
                    else
                    {
                        SaveFileDialog pSavedlg = new SaveFileDialog();
                        pSavedlg.Title = "请选择另存路径";
                        pSavedlg.OverwritePrompt = true;
                        pSavedlg.Filter = "ArcMap文档(*.mxd)|*.mxd|ArcMap模板(*.mxt)|*.mxt";
                        pSavedlg.RestoreDirectory = true;
                        if (pSavedlg.ShowDialog() == DialogResult.OK)
                        {
                            sMxdFileName = pSavedlg.FileName;
                        }
                        else
                        {
                            return;
                        }
                    }
                    pMapDocument.New(sMxdFileName);
                    pMapDocument.ReplaceContents(axMapControl1.Map as IMxdContents);
                    pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                    pMapDocument.Close();
                    MessageBox.Show("另存地图文档成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("另存地图文档失败" + ex.Message);
            }
        }

        private void mioverlay_Click(object sender, EventArgs e)
        {
            miOverlay overlayform = new miOverlay();
            if (overlayform.ShowDialog() == DialogResult.OK)
            {
                //获取输出文件路径
                string strOverlayPath = overlayform.strOutputPath;
                //叠置分析后的图层载入到MapControl
                int index = strOverlayPath.LastIndexOf("\\");
                this.axMapControl1.AddShapeFile(strOverlayPath.Substring(0, index), strOverlayPath.Substring(index));
            }

        }
        private void CreateRasterDataset_Click(object sender, EventArgs e)
        {
            CreateRasterDataset createrasterdataset = new CreateRasterDataset();
            createrasterdataset.Show();
        }

        private void rasterConvert_Click(object sender, EventArgs e)
        {
            rasterconvert convert = new rasterconvert();
            convert.Show();

        }

        private void miMosaic_Click(object sender, EventArgs e)
        {
            mosaic mosaic = new mosaic();
            mosaic.Show();
            
        }

        private void miclip_Click(object sender, EventArgs e)
        {
            miClip Cli1 = new miClip();
            if (Cli1.ShowDialog() == DialogResult.OK)
            {
                //获取输出文件路径
                string strClipPath = Cli1.strOutputPath;
                //缓冲区图层载入到MapControl
                int index = strClipPath.LastIndexOf("\\");
                this.axMapControl1.AddShapeFile(strClipPath.Substring(0, index), strClipPath.Substring(index));

            }
        }

        private void miPan_Click_1(object sender, EventArgs e)
        {
            ESRI.ArcGIS.Controls.ControlsMapPanToolClass tool = new ControlsMapPanToolClass();
            tool.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = tool;
        }

        private void 栅格计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RasterCalculate rastercalculate = new RasterCalculate(axMapControl1);
            rastercalculate.Show();

        }

        private void 插入指北针ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertNorth(axPageLayoutControl1);
        }
        public static void InsertNorth(AxPageLayoutControl axPageLayout)
        {
            IElement pElement = axPageLayout.FindElementByName("MarkerNorthArrow");
            if (pElement != null)
            {
                axPageLayout.ActiveView.GraphicsContainer.DeleteElement(pElement);  //删除已经存在的图例
            }
            IPageLayout pPageLayout = axPageLayout.PageLayout;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IActiveView pActiveView = pPageLayout as IActiveView;
            UID pID = new UIDClass();
            pID.Value = "esriCore.MarkerNorthArrow";

            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
            if (pMapFrame == null) return;
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pID, null);
            if (pMapSurroundFrame == null) return;
            IEnvelope pEnv = new EnvelopeClass();
            pEnv.PutCoords(16, 25, 31, 40);
            pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = pEnv;
            pMapSurroundFrame.MapSurround.Name = "MarkerNorthArrow";
            INorthArrow pNorthArrow = pMapSurroundFrame.MapSurround as INorthArrow;
            pGraphicsContainer.AddElement(pElement, 0);
            axPageLayout.ActiveView.Refresh();
        }

        private void 插入比例尺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
            IMap pMap = pActiveView.FocusMap as IMap;
            IGraphicsContainer pGraphicsContainer = pActiveView as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
            pMap = pActiveView.FocusMap as IMap;
            pGraphicsContainer = pActiveView as IGraphicsContainer;
            pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;//设置比例尺样式
            IMapSurround pMapSurround;
            IScaleBar pScaleBar;
            pScaleBar = new ScaleLineClass();
            pScaleBar.Units = pMap.MapUnits;
            pScaleBar.Divisions = 2;
            pScaleBar.Subdivisions = 4;
            pScaleBar.DivisionsBeforeZero = 0;
            pScaleBar.LabelPosition = esriVertPosEnum.esriBelow;
            pScaleBar.LabelGap = 3.6;
            pScaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndFirstMidpoint;

            pMapSurround = pScaleBar;
            pMapSurround.Name = "ScaleBar";
            //定义UID
            UID uid = new UID();
            uid.Value = "esriCarto.ScaleLine";
            //定义MapSurroundFrame对象      
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(uid, null);
            pMapSurroundFrame.MapSurround = pMapSurround;
            //定义Envelope设置Element摆放的位置
            IEnvelope pEnvelope = new EnvelopeClass();
            //设置元素在pagelayout中的坐标位置，个人可调整
            pEnvelope.PutCoords(2, 1.5, 10, 2.5);
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = pEnvelope;
            pGraphicsContainer.AddElement(pElement, 0);

        }

        private void 插入图例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertLegend(axPageLayoutControl1);
        }
        public void InsertLegend(AxPageLayoutControl axPageLayout)
        {
            //Get the GraphicsContainer
            IGraphicsContainer graphicsContainer = axPageLayoutControl1.GraphicsContainer;

            //Get the MapFrame
            IMapFrame mapFrame = (IMapFrame)graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap);

            if (mapFrame == null) return;

            //Create a legend
            UID uID = new UIDClass();
            uID.Value = "esriCarto.Legend";

            //Create a MapSurroundFrame from the MapFrame
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uID, null);
            if (mapSurroundFrame == null) return;
            if (mapSurroundFrame.MapSurround == null) return;
            //Set the name
            mapSurroundFrame.MapSurround.Name = "Legend";

            //Envelope for the legend
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords(16, 2, 19.4, 3.4);

            //Set the geometry of the MapSurroundFrame
            IElement element = (IElement)mapSurroundFrame;
            element.Geometry = envelope;

            //Add the legend to the PageLayout
            axPageLayoutControl1.AddElement(element, Type.Missing, Type.Missing, "Legend", 0);

            //Refresh the PageLayoutControl
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

    }
}
