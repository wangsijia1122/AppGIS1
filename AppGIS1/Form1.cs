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
/*using Symbology;*/
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
            string pathName = System.IO.Path.GetDirectoryName(strFileName);
            string fileName = System.IO.Path.GetFileNameWithoutExtension(strFileName);
            axMapControl1.AddShapeFile(pathName, fileName);
            axMapControl2.ClearLayers();
            axMapControl2.AddShapeFile(pathName, fileName);
            axMapControl2.Extent = axMapControl2.FullExtent;
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

        private void miCreateBookmark_Click(object sender, EventArgs e)
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

        public static bool ConvertFeatureClass(
            IWorkspace sourceWorkspace,
            IWorkspace targetWorkspace,
            string nameOfSourceFeatureClass,
            string nameOfTargetFeatureClass,
            IQueryFilter queryFilter)
        {
            //创建一个源工作空间名名称IWorkspaceName对象sourceWorkspaceName
            IDataset sourceWorkspaceDataset = (IDataset)sourceWorkspace;
            IWorkspaceName sourceWorkspaceName = (IWorkspaceName)sourceWorkspaceDataset.FullName;
            //创建源数据集名称IDatasetName对象sourceDatasetName
            IFeatureClassName sourceFeatureClassName = new FeatureClassNameClass();
            IDatasetName sourceDatasetName = (IDatasetName)sourceFeatureClassName;
            sourceDatasetName.WorkspaceName = sourceWorkspaceName;
            sourceDatasetName.Name = nameOfSourceFeatureClass;

            //创建一个目标工作空间名名称IWorkspaceName对象targetWorkspaceName
            IDataset targetWorkspaceDataset = (IDataset)targetWorkspace;
            IWorkspaceName targetWorkspaceName = (IWorkspaceName)targetWorkspaceDataset.FullName;
            //创建目标数据集名称IDatasetName对象targetDatasetName
            IFeatureClassName targetFeatureClassName = new FeatureClassNameClass();
            IDatasetName targetDatasetName = (IDatasetName)targetFeatureClassName;
            targetDatasetName.WorkspaceName = targetWorkspaceName;
            targetDatasetName.Name = nameOfTargetFeatureClass;

            //打开输入要素类，并获取其字段定义sourceFeatureClassFields
            ESRI.ArcGIS.esriSystem.IName sourceName = (ESRI.ArcGIS.esriSystem.IName)sourceFeatureClassName;
            IFeatureClass sourceFeatureClass = (IFeatureClass)sourceName.Open();
            //验证源和目标字段名称对象的有效性，因为要实现不同类型数据集之间的转换
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IFields targetFeatureClassFields;
            IFields sourceFeatureClassFields = sourceFeatureClass.Fields;
            IEnumFieldError enumFieldError;
            //设置字段检查对象的参数，报考源和目标工作空间
            fieldChecker.InputWorkspace = sourceWorkspace;
            fieldChecker.ValidateWorkspace = targetWorkspace;
            fieldChecker.Validate(sourceFeatureClassFields, out enumFieldError, out targetFeatureClassFields);

            //返回信息是否存在不匹配的字段
            if(enumFieldError !=null)
            {
                enumFieldError.Reset();
                IFieldError fieldError;
                while((fieldError = enumFieldError .Next ())!=null )
                {
                    String sErrorMsg= String.Format("导出数据是监测到字段匹配错误：{0}，{1}",sourceFeatureClassFields .get_Field(fieldError .FieldIndex ).Name ,fieldError .FieldError .ToString());
                    MessageBox.Show(sErrorMsg);
                }
                return false;//匹配错误返回转换失败

            }

            //循环输出字段，找到几何字段
            IField geometryField;
            for(int i=0;i<targetFeatureClassFields.FieldCount;i++)
            {
                if(targetFeatureClassFields.get_Field(i).Type ==esriFieldType.esriFieldTypeGeometry)
                {
                    geometryField = targetFeatureClassFields.get_Field(i);
                    //获取几何字段的几何定义
                    IGeometryDef geometryDef = geometryField.GeometryDef;
                    //给输出几何字段一个几何索引和格网尺寸
                    IGeometryDefEdit targetFCGeoDefEdit = (IGeometryDefEdit)geometryDef;
                    targetFCGeoDefEdit.GridCount_2 = 1;
                    targetFCGeoDefEdit.set_GridSize(0, 0);
                    targetFCGeoDefEdit.SpatialReference_2 = geometryField.GeometryDef.SpatialReference;
                    //如果要转换所有数据，则数据过滤对象为空即可，不然定义数据过滤条件
                    if(queryFilter==null)
                    {
                        queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = "";

                    }
                    //装载数据转换类，实现数据转换
                    IFeatureDataConverter fctofc = new FeatureDataConverterClass();
                    IEnumInvalidObject enumErrors = fctofc.ConvertFeatureClass(
                        sourceFeatureClassName, queryFilter, null, targetFeatureClassName, geometryDef, targetFeatureClassFields, "", 1000, 0);
                    //设置Flush自动推送要素参数为1000
                    return true;
                }
            }
            return false;

        }

        private void transformData_Click(object sender, EventArgs e)
        {
            Transform transform = new Transform("D:\\ArcGIS\\geo.gdb","qh1", "D:\\ArcGIS\\geo2.gdb", "traqh");
            
            transform.Show();
        }
    }
}
