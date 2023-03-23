using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;



namespace AppGIS1
{
    public partial class Print : Form
    {
        public Print(IHookHelper hookHelper)
        {
            InitializeComponent();
            axPageLayoutControl1.PageLayout = hookHelper.PageLayout;
        }

        private void Print_Load(object sender, EventArgs e)
        {
            cboPageSize.Items.Add("Letter - 8.5in x 11in.");
            cboPageSize.Items.Add("Legal - 8.5in x 14in.");
            cboPageSize.Items.Add("Tabloid - 11in x 17in.");
            cboPageSize.Items.Add("C - 17in x 22in.");
            cboPageSize.Items.Add("D - 22in x 34in.");
            cboPageSize.Items.Add("E - 34in x 44in.");
            cboPageSize.Items.Add("A5 - 148mm x 210mm.");
            cboPageSize.Items.Add("A4 - 210mm x 297mm.");
            cboPageSize.Items.Add("A3 - 297mm x 420mm.");
            cboPageSize.Items.Add("A2 - 420mm x 594mm.");
            cboPageSize.Items.Add("A1 - 594mm x 841mm.");
            cboPageSize.Items.Add("A0 - 841mm x 1189mm.");
            cboPageSize.Items.Add("Custom Page Size.");
            cboPageSize.Items.Add("Same as Printer Form.");
            cboPageSize.SelectedIndex = 7;

            optPortrait.Checked = true;
            EnableOrientation(true);

            cboscale.Items.Add("单线交互式比例尺");
            cboscale.Items.Add("双线交互式比例尺");
            cboscale.Items.Add("中空式比例尺");
            cboscale.Items.Add("线式比例尺");
            cboscale.Items.Add("分割式比例尺");
            cboscale.Items.Add("阶梯式比例尺");
            cboscale.SelectedIndex = 0;
        }
        private void EnableOrientation(bool b)
        {
            optPortrait.Enabled = b;
            optLandscape.Enabled = b;
        }

        private void optPortrait_Click(object sender, EventArgs e)//横向点击
        {
            if (optPortrait.Checked == true)
            {
                //Set the page orientation
                if (axPageLayoutControl1.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
                {
                    axPageLayoutControl1.Page.Orientation = 1;
                }
            }
        }

        private void optLandscape_Click(object sender, EventArgs e)//纵向点击
        {
            if (optLandscape.Checked == true)
            {
                //Set the page orientation
                if (axPageLayoutControl1.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
                {
                    axPageLayoutControl1.Page.Orientation = 2;
                }
            }
        }

        private void cboPageSize_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Orientation cannot change if the page size is set to 'Same as Printer'
            if (cboPageSize.SelectedIndex == 13)
                EnableOrientation(false);
            else
                EnableOrientation(true);
            //Set the page size
            axPageLayoutControl1.Page.FormID = (esriPageFormID)cboPageSize.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddScalebar(axPageLayoutControl1.PageLayout);

            IPrinter printer = axPageLayoutControl1.Printer;
            IPage page = axPageLayoutControl1.Page;
            page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
            //打印首张页面且无重叠
            axPageLayoutControl1.PrintPageLayout(1, 1, 0); 
        }

        public void AddScalebar(IPageLayout pageLayout)
        {
            IGraphicsContainer container = pageLayout as IGraphicsContainer;
            IActiveView activeView = pageLayout as IActiveView;
            // 获得MapFrame   
            IFrameElement frameElement = container.FindFrame(activeView.FocusMap);
            IMapFrame mapFrame = frameElement as IMapFrame;
            //根据MapSurround的uid，创建相应的MapSurroundFrame和MapSurround   
            UID uid = new UIDClass();
            uid.Value = "esriCarto.AlternatingScaleBar";
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid, null);
            //设置MapSurroundFrame中比例尺的样式   
            IMapSurround mapSurround = mapSurroundFrame.MapSurround;
            IScaleBar markerScaleBar = ((IScaleBar)mapSurround);
            markerScaleBar.LabelPosition = esriVertPosEnum.esriBelow;
            markerScaleBar.UseMapSettings();
            //QI，确定mapSurroundFrame的位置   
            IElement element = mapSurroundFrame as IElement;
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords(0.2, 0.2, 1, 2);
            element.Geometry = envelope;
            //使用IGraphicsContainer接口添加显示   
            container.AddElement(element, 0);
            activeView.Refresh();

        }

        private void cboscale_SelectedIndexChanged(object sender, EventArgs e)
        {

            AddScalebar(axPageLayoutControl1.PageLayout);
        }

    }
}
