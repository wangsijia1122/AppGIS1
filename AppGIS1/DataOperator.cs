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

    }
}
