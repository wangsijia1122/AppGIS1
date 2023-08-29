using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;

namespace AppGIS1
{
    public partial class AttributeTable : Form
    {
        ILayer mLayer;
        public AttributeTable(ILayer pLayer)
        {
            InitializeComponent();
            mLayer = pLayer;
        }

        private void AttributeTable_Load(object sender, EventArgs e)
        {
            OpenAttributeTable(); //自定义方法 
        }
		public void OpenAttributeTable()
		{
			IFeatureLayer pFeatureLayer = mLayer as IFeatureLayer; //**
			IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass; //** using ESRI.ArcGIS.Geodatabase;

			DataTable dt = new DataTable();
			if (pFeatureClass != null)
			{
				DataColumn dc;
				for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
				{
					dc = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
					dt.Columns.Add(dc);//获取所有列的属性值
				}
				IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
				IFeature pFeature = pFeatureCursor.NextFeature();
				DataRow dr;
				while (pFeature != null)
				{
					dr = dt.NewRow();
					for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
					{
						//判断feature的形状
						if (pFeature.Fields.get_Field(j).Name == "Shape")
						{
							if (pFeature.Shape.GeometryType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint)
							{
								dr[j] = "点";
							}
							if (pFeature.Shape.GeometryType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline)
							{
								dr[j] = "线";
							}
							if (pFeature.Shape.GeometryType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon)
							{
								dr[j] = "面";
							}
						}
						else
						{
							dr[j] = pFeature.get_Value(j).ToString();//增加行
						}
					}
					dt.Rows.Add(dr);
					pFeature = pFeatureCursor.NextFeature();
				}
			}
			this.dataGridView1.DataSource = dt;
		}
    }
}
