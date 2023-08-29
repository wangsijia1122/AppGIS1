using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;

namespace AppGIS1
{
    public class MapAnalysis
    {
        public bool QueryIntersect(string srcLayerName, string tgtLayerName, IMap iMap, esriSpatialRelationEnum spatialRel)
        {
            DataOperator dataOperator = new DataOperator(iMap); 
            
            //定义并根据图层名称获取图层对象
            IFeatureLayer iSrcLayer = (IFeatureLayer)dataOperator.GetLayerByName(srcLayerName); 
            IFeatureLayer iTgtLayer = (IFeatureLayer)dataOperator.GetLayerByName(tgtLayerName); 
            
            //通过查询过滤获取Continents层中亚洲的几何
            IGeometry geom;
            IFeature feature;
            IFeatureCursor featCursor;
            IFeatureClass srcFeatClass;
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.WhereClause = "CNTRY_NAME='China'";//设置查询条件
            featCursor = iTgtLayer.FeatureClass.Search(queryFilter, false);
            feature = featCursor.NextFeature();
            geom = feature.Shape;//获取中国图形几何

            //根据所选择的几何对城市图层进行属性与空间过滤
            srcFeatClass = iSrcLayer.FeatureClass;
            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.Geometry = geom;
            spatialFilter.WhereClause = "NAME='湖南省'";//湖南省
            spatialFilter.SpatialRel = (ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum)spatialRel; 
            
            //定义要素选择对象，以要素搜索图层进行实例化
            IFeatureSelection featSelect = (IFeatureSelection)iSrcLayer;
            //以空间过滤器对要素进行选择，并建立新选择集
            featSelect.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false); 
            
            return true; 
        }

        /*public bool Buffer(string layerName, string sWhere, int iSize, IMap iMap)
        {
            //根据过滤条件获取城市名称为背景的城市要素几何
            IFeatureClass featClass;
            IFeature feature;
            IGeometry iGeom;

            DataOperator dataOperator = new DataOperator(iMap);
            IFeatureLayer featLayer=(IFeatureLayer)dataOperator.GetLayerByName(layerName);

            featClass = featLayer.FeatureClass;
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.WhereClause = sWhere;//设置过滤条件
            IFeatureCursor featCursor;
            featCursor = (IFeatureCursor)featClass.Search(queryFilter, false);
            int count = featClass.FeatureCount(queryFilter);

            feature = featCursor.NextFeature();
            iGeom = feature.Shape; 
            
            //设置空间的缓冲区作为空间查询的几何范围
            ITopologicalOperator ipTO = (ITopologicalOperator)iGeom;
            IGeometry iGeomBuffer = ipTO.Buffer(iSize); 
            
            //根据缓冲区几何对图层进行空间过滤
            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.Geometry = iGeomBuffer;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIndexIntersects; 
            
            //定义要素选择对象，以搜索图层进行实例化
            IFeatureSelection featSelect = (IFeatureSelection)featLayer;
            //以空间过滤器对要素进行选择，并建立新选择集
            featSelect.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false); 
            
            return true;
        }*/

        public string Statistic(string layerName, string fieldName, IMap iMap)
        {
            //根据给定图层名称获取图层对象
            DataOperator dataOperator = new DataOperator(iMap);
            IFeatureLayer featLayer = (IFeatureLayer)dataOperator.GetLayerByName(layerName); 

            //获取图层的数据统计对象

            IFeatureClass featClass = featLayer.FeatureClass;
            IDataStatistics dataStatistic = new DataStatistics();
            IFeatureCursor featCursor;
            featCursor = featClass.Search(null, false);
            ICursor cursor = (ICursor)featCursor;
            dataStatistic.Cursor = cursor;

            //指定统计字段为面积字段，统计出最小面积、最大面积及平均面积
            dataStatistic.Field = fieldName;
            IStatisticsResults statResult;
            statResult = dataStatistic.Statistics;
            double dMax;
            double dMin;
            double dMean;

            dMax = statResult.Maximum;
            dMin = statResult.Minimum;
            dMean = statResult.Mean;
            string sResult;

            sResult = "最大面积为" + dMax.ToString() + "；最小面积" + dMin.ToString() + "；平均面积" + dMean.ToString();


            return sResult;
        }
    }
}
