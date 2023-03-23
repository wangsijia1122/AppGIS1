using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Display;

namespace AppGIS1
{
    public class DataOperator
    {
        //保存当前地图对象
        public IMap m_map;

        //用于传入当前地图对象
        public DataOperator(IMap map)
        {
            m_map = map;
        }

        public ILayer GetLayerByName(String sLayerName)
        {
            //判断图层名或地图对象是否为空。若为空，函数返回空
            if (sLayerName==""||m_map==null)
            {
                return null;
            }

            //对地图对象中所有图层进行遍历。若某一图层的名称与指定图层名称相同，则返回该图层
            for(int i=0;i<m_map.LayerCount;i++)
            {
                if(m_map.get_Layer(i).Name==sLayerName)
                {
                    return m_map.get_Layer(i);
                }
            }

            //若地图对象中的所有图层名均与指定图层名不匹配，函数返回空
            return null;
        }

        public DataTable GetContinentsNames()
        {
            //获取“cntry02”图层，利用IFeatureLayer接口访问，并判断是否成功。若失败，函数返回空
            ILayer layer = GetLayerByName("cntry02");
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            if(featureLayer ==null)
            {
                return null;
            }
            //调用IFeatureLayer接口的Seach方法，获取要素指针（IFeatureCursor）接口对象，用于在之后遍历图层中的全部要素，并判断是否成功获取第一个要素。若失败，函数返回为空
            IFeature feature;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            feature = featureCursor.NextFeature();
            if(feature==null)
            {
                return null;
            }
            //新建DataTable类型对象，用于函数返回
            DataTable dataTable = new DataTable();

            //新建DataColumn类型对象，分别保存各个洲的序号和名称。设置完毕后加入DataTable的列集合（columns）中。
            DataColumn dataColumn = new DataColumn();
            dataColumn.ColumnName = "FID";
            dataColumn.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn();
            dataColumn.ColumnName = "CNTRY_NAME";
            dataColumn.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(dataColumn);
            DataRow dataRow;
            while (feature != null)
            {
                dataRow = dataTable.NewRow();
                dataRow[0] = feature.get_Value(0);
                dataRow[1] = feature.get_Value(6);
                dataTable.Rows.Add(dataRow);
                feature = featureCursor.NextFeature();

            }
            return dataTable;
        }

        public IFeatureClass CreatShapefile(
        String sParentDirectory,     //上级路径
        String sWorkspaceName,//包含shape文件的文件夹名
        String sFileName,
        String type
        )//shape文件名
        {
            //如果指定的路径和文件夹已经存在，则删除此文件夹
            if (System.IO.Directory.Exists(sParentDirectory + sWorkspaceName))
            {
                System.IO.Directory.Delete(sParentDirectory + sWorkspaceName, true);
            }

            //通过
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspaceName workspaceName = workspaceFactory.Create(sParentDirectory, sWorkspaceName, null, 0);
            ESRI.ArcGIS.esriSystem.IName name = workspaceName as ESRI.ArcGIS.esriSystem.IName;

            //打开新建的工作空间，并通过IFeatureWorkspace接口来访问它
            IWorkspace workspace = (IWorkspace)name.Open();
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            //shape文件在概念层次上是一个要素类。创建并编辑该要素类所需要的字段集
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;

            //创建并编辑“序号”字段。此字段为要素类必需字段
            IFieldEdit fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "OID";
            fieldEdit.AliasName_2 = "序号";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建并编辑“名称”字段
            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "Name";
            fieldEdit.AliasName_2 = "名称";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建地理定义，设置其空间参考和几何类型，为创建“形状”字段做准备
            IGeometryDefEdit geoDefEdit = new GeometryDefClass();
            ISpatialReference spatialReference = m_map.SpatialReference;
            geoDefEdit.SpatialReference_2 = spatialReference;
            if(type=="point")
            {
                geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            }
            if(type== "Polyline")
            {
                geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            }
            if(type== "Polygon")
            {
                geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
            }
            

            fieldEdit = new FieldClass();
            String sShapefileName = "Shape";
            fieldEdit.Name_2 = sShapefileName;
            fieldEdit.AliasName_2 = "形状";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geoDefEdit;
            fieldsEdit.AddField((IField)fieldEdit);


            IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(
                sFileName,
                fields,
                null,
                null,
                esriFeatureType.esriFTSimple,
                "Shape", "");
            if (featureClass == null)
            {
                return null;
            }
            return featureClass;
        }
        public bool AddFeatureClassToMap(IFeatureClass featureClass, String sLayerName)
        {
            if (featureClass == null || sLayerName == "" || m_map == null)
            {
                return false;
            }

            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = sLayerName;

            ILayer layer = featureLayer as ILayer;
            if (layer == null)
            {
                return false;
            }
            m_map.AddLayer(layer);
            IActiveView activeView = m_map as IActiveView;
            if (activeView == null)
            {
                return false;
            }
            activeView.Refresh();
            return true;
        }

        //在鼠标点击处，在图层上新增要素，并指定要素名称
        public bool AddFeatureToLayer(
            String sLayerName,//指定图层的名称
            String sFeatureName,//将被添加的要素名称
            IPoint point)//将被添加的要素坐标信息
        {
            if (sFeatureName == "" || sLayerName == "" || point ==null || m_map == null)
            {
                return false;
            }

            //对地图对象中的图层进行遍历。当某图层的名称与指定名称相同时，则跳出循环
            ILayer layer = null;
            for(int i=0;i<m_map .LayerCount;i++)
            {
                layer = m_map.get_Layer(i);
                if(layer .Name ==sLayerName )
                {
                    break;
                }
                layer = null;
            }
            //判断图层是否获取成功。若失败返回false
            if(layer ==null)
            {
                return false;
            }

            //通过IFeatureLayer接口访问获取到的图层，进一步获取其要素类
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureClass featureClass = featureLayer.FeatureClass;

            //
            IFeature feature = featureClass.CreateFeature();
            if(feature==null)
            {
                return false;
            }

            //对新创建的要素进行编辑，将其坐标、属性值进行设置。保存该要素，并判断是否成功。失败返回false
            feature.Shape = point;
            int index = feature.Fields.FindField("Name");
            feature.Store();
            if(feature==null)
            {
                return false;
            }

            //将地图对象转化为活动视图，并判断是否成功。失败返回false
            IActiveView activeView = m_map as IActiveView;
            if(activeView ==null)
            {
                return false;
            }

            //将活动视图进行刷新，新添加的要素将被展示在控件中。函数返回true
            activeView.Refresh();
            return true;
        }

        public bool AddPolylineToLayer(
            String sLayerName,//指定图层的名称
            String sFeatureName,//将被添加的要素名称
            IGeometry polyline)//将被添加的要素坐标信息
        {
            if (sFeatureName == "" || sLayerName == "" || polyline == null || m_map == null)
            {
                return false;
            }

            //对地图对象中的图层进行遍历。当某图层的名称与指定名称相同时，则跳出循环
            ILayer layer = null;
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                layer = m_map.get_Layer(i);
                if (layer.Name == sLayerName)
                {
                    break;
                }
                layer = null;
            }
            //判断图层是否获取成功。若失败返回false
            if (layer == null)
            {
                return false;
            }

            //通过IFeatureLayer接口访问获取到的图层，进一步获取其要素类
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureClass featureClass = featureLayer.FeatureClass;

            //
            IFeature feature = featureClass.CreateFeature();
            if (feature == null)
            {
                return false;
            }

            //对新创建的要素进行编辑，将其坐标、属性值进行设置。保存该要素，并判断是否成功。失败返回false
            feature.Shape = polyline;
            int index = feature.Fields.FindField("Name");
            feature.Store();
            if (feature == null)
            {
                return false;
            }

            //将地图对象转化为活动视图，并判断是否成功。失败返回false
            IActiveView activeView = m_map as IActiveView;
            if (activeView == null)
            {
                return false;
            }

            //将活动视图进行刷新，新添加的要素将被展示在控件中。函数返回true
            activeView.Refresh();
            return true;
        }
    }
}
