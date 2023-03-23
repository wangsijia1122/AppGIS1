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
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;


namespace AppGIS1
{
    public class DrawPolygon
    {
        /*private IGeometry _polygon = null;//定义一个几何对象，作为绘制结果
        private INewPolygonFeedback _polyFeedback = null;//定义一个多边形反馈对象
        private IPoint _startPoint = null;//多边形起始结点
        private IPoint _endpoint = null;//多边形终止结点

        private bool _drawStart = false;//多边形绘制开始标记
        public event AfterDrawGeometry eventAfterDrawGeometry;

        protected AxMapControl mapControl1 = null;
        protected ESRI.ArcGIS.Controls.IHookHelper myHook;

        //返回结果多边形
        public IGeometry Polygon
        {
            get { return _polygon; }
        }

        public override void OnCreate(object hook)
        {
            myHook.Hook = hook;
            if (myHook == null)
                myHook = new ESRI.ArcGIS.Controls.HookHelperClass();
            if(_drawStart )
            {
                (myHook.Hook as IMapcontrol3).CurrentTool = this;
                _polyFeedback = new NewPolygonFeedbackClass();
                _polyFeedback.Display = myHook.ActiveView.ScreenDisplay;
            }
        }

        public override void OnClick( )
        {
            _polygon = null;
            _drawStart = true;
            (myHook.Hook as IMapControl).CurrentTool = this;
            _polyFeedback = new NewPolygonFeedbackClass();
            _polyFeedback.Display = myHook.ActiveView.ScreenDisplay;
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            if (button == 1)
            {
                if (_startPoint == null)
                {
                    _startPoint = (myHook.FocusMap as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                    _polyFeedback.Start(_startPoint);
                }
            }
            else
            {
                _endpoint = (myHook.FocusMap as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(x.y);
                _polyFeedback.AddPoint(_endpoint);
            }
        }
        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            if (_startPoint != null)
            {
                IPoint movepoint = (myHook.FocusMap as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                _polyFeedback.MoveTo(movepoint);
            }

        }
        public override void Refresh(int hDC)
        {
            base.Refresh(hDC);
            if (_polyFeedback != null)
            {
                (_polyFeedback as IDisplayFeedback).Refresh(hDC);
            }
        }
        public override void OnDoubleClick()
        {
            _polygon = _polyFeedback.Stop();
            _startPoint = null;
            _drawStart = false;
        }*/

    }
}
