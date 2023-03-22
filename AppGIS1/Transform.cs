using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;


namespace AppGIS1
{
    public partial class Transform : Form
    {
        public AEGIS软件开发实践 m_frmMain;
        public Transform(string sourcePath, string sourceName, string targetPath, string targetName)
        {
            InitializeComponent();
            textBox1.Text = sourcePath;
            textBox2.Text= sourceName;
            textBox3.Text= targetPath;
            textBox4.Text= targetName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sourcePath = textBox1.Text;
            string sourceName = textBox2.Text;
            string targetPath = textBox3.Text;
            string targetName = textBox4.Text;

            Console.WriteLine(sourcePath);
            Console.WriteLine(sourceName);
            Console.WriteLine(targetPath);
            Console.WriteLine(targetName);

            IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass(); // 打开文件地理数据库
            IWorkspace workspace1 = workspaceFactory.OpenFromFile(sourcePath, 0);
            IFeatureWorkspace accessWorkspace = workspace1 as IFeatureWorkspace;
            
            //关闭资源锁定  
            IWorkspaceFactoryLockControl ipWsFactoryLock = (IWorkspaceFactoryLockControl)workspaceFactory;
            if (ipWsFactoryLock.SchemaLockingEnabled)
            {
                ipWsFactoryLock.DisableSchemaLocking();
            }

            IWorkspaceFactory2 workspaceFactory2 = new FileGDBWorkspaceFactoryClass();
            IWorkspace workspace2 = workspaceFactory.OpenFromFile(targetPath, 0);

            IWorkspaceFactoryLockControl ipWsFactoryLock2 = (IWorkspaceFactoryLockControl)workspaceFactory2;
            if (ipWsFactoryLock.SchemaLockingEnabled)
            {
                ipWsFactoryLock.DisableSchemaLocking();
            }

            bool Con_result = ConvertFeatureClass(workspace1, workspace2, sourceName, targetName, null);
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
            if (enumFieldError != null)
            {
                enumFieldError.Reset();
                IFieldError fieldError;
                while ((fieldError = enumFieldError.Next()) != null)
                {
                    String sErrorMsg = String.Format("导出数据是监测到字段匹配错误：{0}，{1}", sourceFeatureClassFields.get_Field(fieldError.FieldIndex).Name, fieldError.FieldError.ToString());
                    MessageBox.Show(sErrorMsg);
                }
                return false;//匹配错误返回转换失败

            }

            //循环输出字段，找到几何字段
            IField geometryField;
            for (int i = 0; i < targetFeatureClassFields.FieldCount; i++)
            {
                if (targetFeatureClassFields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
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
                    if (queryFilter == null)
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
    }
}
