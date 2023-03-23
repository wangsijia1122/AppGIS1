using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Display;

namespace AppGIS1
{
    class MapComposer
    {
        public static String GetRendererTypeByLayer(ILayer layer)
        {
            //判断图层是否获取成功。若失败，函数返回“图层获取失败”
            if(layer ==null)
            {
                return "图层获取失败";
            }

            //使用IGeoFeatureLayer接口访问指定图层，并获取其渲染器。
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
            IFeatureRenderer featureRenderer = geoFeatureLayer.Renderer;

            //判断该图层渲染器是否为备选渲染器类型之一，如匹配成功返回其类型信息
            if(featureRenderer is ISimpleRenderer)
            {
                return "SimpleRenderer";
            }
            else if(featureRenderer is IUniqueValueRenderer)
            {
                return "UniqueValueRenderer";
            }
            else if (featureRenderer is IDotDensityRenderer)
            {
                return "IDotDensityRenderer";
            }
            else if (featureRenderer is IChartRenderer)
            {
                return "IChartRenderer";
            }
            else if (featureRenderer is IProportionalSymbolRenderer )
            {
                return "IProportionalSymbolRenderer";
            }
            else if (featureRenderer is IRepresentationRenderer )
            {
                return "IRepresentationRenderer";
            }
            else if (featureRenderer is IClassBreaksRenderer )
            {
                return "IProportionalSymbolRenderer";
            }
            else if (featureRenderer is IBivariateRenderer )
            {
                return "IBivariateRenderer";
            }

            //若渲染器类型匹配失败，则返回“未知或渲染器获取失败”
            return "未知或渲染器获取失败";

        }

        //添加静态变量成员函数GetRendererType,用于获取指定图层的符号信息
        public static ISymbol GetSymbolFromLayer(ILayer layer)
        {
            //判断图层是否获取成功。若失败，函数返回空
            if(layer==null)
            {
                return null;
            }

            //利用IFeatureLayer接口访问指定图层，获取到图层中的第一个要素，判断是否成功。若失败，函数返回空
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            if(feature==null)
            {
                return null;
            }

            //利用IGeoFeatureLayer访问指定图层，获取其渲染器，并判断是否成功。若失败，函数返回空
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            IFeatureRenderer featureRenderer = geoFeatureLayer.Renderer;
            if(featureRenderer ==null)
            {
                return null;
            }

            //通过IFeatureRenderer接口的方法获取图层要素对应的符号信息，并作为函数结果返回.
            ISymbol symbol = featureRenderer.get_SymbolByFeature(feature);
            return symbol;
        }

        //添加静态变量函数RenderSimple,用于统一设置指定图层符号的颜色，并进行简单渲染。
        public static bool RenderSimple(ILayer layer ,IColor color)
        {
            //判断图层和颜色是否获取成功。若失败，函数返回false。
            if(layer==null||color ==null)
            {
                return false;
            }

            //调用GetSymbolFromLayer成员函数，获取指定图层的符号，并判断是否成功
            //若失败，函数返回false
            ISymbol symbol=GetSymbolFromLayer(layer);
            if(symbol ==null)
            {
                return false;
            }

            //获取指定图层的要素类，并判断是否成功。若失败，函数返回false
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureClass featureClass = featureLayer.FeatureClass;
            if(featureClass ==null)
            {
                return false;
            }
            //获取指定图层要素类的几何形状信息，并进行匹配。根据不同形状，设置不用类型符号颜色。若几何形状不属于Point,MultiPoint,PolyLine和Polygon,则函数返回false
            esriGeometryType geoType = featureClass.ShapeType;
            switch(geoType )
            {
                case esriGeometryType.esriGeometryPoint:
                    {
                        IMarkerSymbol makerSymbol = symbol as IMarkerSymbol;
                        makerSymbol.Color = color;
                        break;
                    }
                case esriGeometryType.esriGeometryMultipoint:
                    {
                        IMarkerSymbol makerSymbol = symbol as IMarkerSymbol;
                        makerSymbol.Color = color;
                        break;
                    }
                case esriGeometryType.esriGeometryPolyline:
                    {
                        ISimpleLineSymbol simpleLineSymbol = symbol as ISimpleLineSymbol;
                        simpleLineSymbol.Color = color;
                        break;
                    }
                case esriGeometryType.esriGeometryPolygon:
                    {
                        IFillSymbol fillSymbol = symbol as IFillSymbol;
                        fillSymbol.Color = color;
                        break;
                    }
                default:
                    return false;
            }

            //新建简单渲染器对象，设置其符号。通过IFeatureRenderer接口访问它，并判断是否成功。失败返回false
            ISimpleRenderer simpleRenderer = new SimpleRendererClass();
            simpleRenderer.Symbol = symbol;
            IFeatureRenderer featureRenderer = simpleRenderer as IFeatureRenderer;
            if(featureRenderer ==null)
            {
                return false;
            }

            //通过IGeoFeatureLayer接口访问指定图层，并设置其渲染器。函数返回true
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            geoFeatureLayer.Renderer = featureRenderer;
            return true;
        }
    }
}
