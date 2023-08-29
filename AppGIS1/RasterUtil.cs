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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.DataSourcesGDB;

namespace AppGIS1
{
    class RasterUtil
    {
        public IRasterWorkspaceEx OpenRasterDataset(string catalogName)
        {
            IRasterWorkspaceEx rasterWorkspaceEx = null;
            IRasterCatalog rasterCatalog;
            rasterCatalog = rasterWorkspaceEx.OpenRasterCatalog(catalogName);

            IRasterDataset rasterDataset;
            IFeatureClass featClass;
            featClass = rasterCatalog as IFeatureClass;
            IRasterCatalogItem rasterCatalogItem;
            IFeature feature;
            feature = featClass.GetFeature(1);
            rasterCatalogItem = (IRasterCatalogItem)feature;
            rasterDataset = rasterCatalogItem.RasterDataset;
            return rasterDataset as IRasterWorkspaceEx;
        }

        IRasterWorkspaceEx OpenRasterWorkspaceFromFileGDB(string filePath)
        {
            IWorkspaceFactory wsFactory = new FileGDBWorkspaceFactoryClass();
            IRasterWorkspaceEx ws = wsFactory.OpenFromFile(filePath, 0) as IRasterWorkspaceEx;
            return ws;
        }
        IRasterWorkspace OpenRasterWorkspaceFromFile(string filePath)
        {
            IWorkspaceFactory wsFactory = new RasterWorkspaceFactoryClass();
            IRasterWorkspace ws = wsFactory.OpenFromFile(filePath, 0) as IRasterWorkspace;
            return ws;
        }
        IRasterWorkspace GetRasterWorkspace(string pWsName)
        {
            try
            {
                IWorkspaceFactory pWorkFact = new RasterWorkspaceFactoryClass();
                return pWorkFact.OpenFromFile(pWsName, 0) as IRasterWorkspace;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        IRasterDataset OpenFileRasterDataset(string pFolderName, string pFileName)
        {
            IRasterWorkspace pRasterWorkspace = GetRasterWorkspace(pFolderName);
            IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pFileName);
            return pRasterDataset;
        }
        public bool CreateRaster(string filePath, string rasterName)
        {
            try
            {
                IRasterWorkspaceEx rasterWorkspace = this.OpenRasterWorkspaceFromFileGDB(filePath);
                IRasterDataset rasterDataset;
                //设置存储参数
                IRasterStorageDef storageDef = new RasterStorageDef();
                storageDef.CompressionType = esriRasterCompressionType.esriRasterCompressionJPEG;
                IRasterDef rasterDef = new RasterDef();
                ISpatialReferenceFactory2 srFactotry = new SpatialReferenceEnvironmentClass();
                int gcsType = (int)esriSRGeoCSType.esriSRGeoCS_WGS1984; 
                IGeographicCoordinateSystem geoCoordSystem = srFactotry.CreateGeographicCoordinateSystem(gcsType);
                ISpatialReference spatialRef = geoCoordSystem;
                rasterDef.SpatialReference = spatialRef;
                rasterDataset = rasterWorkspace.CreateRasterDataset(
                    rasterName, 3, rstPixelType.PT_FLOAT, storageDef, "DEFAULTS", rasterDef, null);
                return true;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "异常信息");
                return false;
            }
        }
        public bool RasterConvert(string fileGDB, string oldRasterName, string filePath, string newRasterName)
        {
            //try
            //{
                IWorkspace workspace;
                IRasterWorkspaceEx rasterWorkspaceEx;
                //打开输入工作空间
                rasterWorkspaceEx = this.OpenRasterWorkspaceFromFileGDB(fileGDB);
                //打开栅格数据集
                IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset(oldRasterName);
                //得到栅格波段
                IRasterBandCollection rasterBands = rasterDataset as IRasterBandCollection;
                //打开输出工作空间
                workspace = this.OpenRasterWorkspaceFromFile(filePath) as IWorkspace;
                //另存为给定文件名的图像文件
                rasterBands.SaveAs(newRasterName, workspace, "TIFF");
                return true;
           // }
            /*catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "异常信息");
                return false;
            }*/
        }
        public void Mosaic(string GDBName, string catalogName, string outputFolder, string outputName)
        {
            //try
            //{
                // 打开个人数据库
                IWorkspaceFactory workspaceGDBFactory = new AccessWorkspaceFactoryClass();
                IWorkspace GDBworkspace = workspaceGDBFactory.OpenFromFile(GDBName, 0);
                // 打开要被镶嵌的影像所在的栅格目录
                IRasterWorkspaceEx rasterWorkspaceEX = GDBworkspace as IRasterWorkspaceEx;
                IRasterCatalog rasterCatalog;
                rasterCatalog = rasterWorkspaceEX.OpenRasterCatalog(catalogName);
                // 定义一个影像镶嵌对象
                IMosaicRaster mosaicRaster = new MosaicRasterClass();
                //镶嵌栅格目录中的所有影像到一个输出栅格数据集
                mosaicRaster.RasterCatalog = rasterCatalog;
                //设置镶嵌选项
                mosaicRaster.MosaicColormapMode = rstMosaicColormapMode.MM_MATCH;
                mosaicRaster.MosaicOperatorType = rstMosaicOperatorType.MT_LAST;
                //打开输出栅格数据集所在的工作空间
                IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactoryClass();
                IWorkspace workspace = workspaceFactory.OpenFromFile(outputFolder, 0);
                // 保存到目标栅格数据集
                ISaveAs saveas = mosaicRaster as ISaveAs;
                saveas.SaveAs(outputName, workspace, "TIFF");

            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "异常信息");

            //}
        }

    }
}
