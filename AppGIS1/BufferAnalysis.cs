using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;

namespace AppGIS1
{
    public partial class BufferAnalysis : Form
    {
        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr wnd,uint Msg,IntPtr wParam,IntPtr lParam);
        private IHookHelper m_hookHelper = null;
        private const uint WM_VSCROLL = 0x0115;
        private const uint SB_BOTTOM = 7;
        public string strOutputPath;// 输出图层路径

        public BufferAnalysis(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookHelper = hookHelper;
        }
        private void BufferAnalysis_Load(object sender, EventArgs e)
        {
            if (null == m_hookHelper || null == m_hookHelper.Hook || 0 == m_hookHelper.FocusMap.LayerCount)
                return;

            //load all the feature layers in the map to the layers combo
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                cboLayers.Items.Add(layer.Name);
            }
            //select the first layer
            if (cboLayers.Items.Count > 0)
                cboLayers.SelectedIndex = 0;

            //set the default units of the buffer

            int units = Convert.ToInt32(m_hookHelper.FocusMap.MapUnits);
            cboUnits.SelectedIndex = units;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择输出数据位置";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog.SelectedPath+"\\"+ (string)cboLayers.SelectedItem + "_buffer.shp";
            }
        }

        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            IEnumLayer layers = GetLayers();
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }

            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //修改当前指针样式
            this.Cursor = Cursors.WaitCursor;

           //make sure that all parameters are okay
            double bufferDistance;
            double.TryParse(txtBufferDistance.Text, out bufferDistance);
            if (0.0 == bufferDistance)
            {
                MessageBox.Show("无效的缓冲距离！");
                return;
            }

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(textBox3.Text)) ||   
                ".shp" != System.IO.Path.GetExtension(textBox3.Text))
            {
                MessageBox.Show("无效的文件名！");
                return;
            }

            if (m_hookHelper.FocusMap.LayerCount == 0)
                return;

            //get the layer from the map
            IFeatureLayer layer = GetFeatureLayer((string)cboLayers.SelectedItem);
            if (null == layer)
            {
                txtMessages.Text += "图层 " + (string)cboLayers.SelectedItem + "未被找到！\r\n";
                return;
            }

            //scroll the textbox to the bottom
            ScrollToBottom();
            //add message to the messages box
            txtMessages.Text += "进行缓冲区的图层: " + layer.Name + "\r\n";

            txtMessages.Text += "\r\n正在获取空间数据。这可能需要几秒钟时间...\r\n";
            txtMessages.Update();
            //get an instance of the geoprocessor
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;//新生成的文件可以覆盖旧生成的文件
            txtMessages.Text += "正在进行缓冲区分析...\r\n";
            txtMessages.Update();

            //create a new instance of a buffer tool
            //ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(layer, textBox3.Text, Convert.ToString(bufferDistance) + " " + (string)cboUnits.SelectedItem);
            ESRI.ArcGIS.AnalysisTools.Buffer pBuffer = new ESRI.ArcGIS.AnalysisTools.Buffer();
            //设置获取缓冲区分析图层
            pBuffer.in_features = layer;
            pBuffer.out_feature_class = textBox3.Text;
            pBuffer.buffer_distance_or_field = Convert.ToString(bufferDistance) + " " + (string)cboUnits.SelectedItem;
            pBuffer.dissolve_option = "ALL";

            
            //execute the buffer tool (very easy :-))
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(pBuffer, null);
            if (results.Status != esriJobStatus.esriJobSucceeded)
            {
                txtMessages.Text += "缓冲区失败的图层: " + layer.Name + "\r\n";
            }
            else
            {
                txtMessages.Text += "创建缓冲区完成！";
                strOutputPath = textBox3.Text;
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("缓冲区生成成功！");

                //this.close();
                
            }
            txtMessages.Text += ReturnMessages(gp);
            //scroll the textbox to the bottom
            ScrollToBottom();

            txtMessages.Text += "\r\n完成！\r\n";
            txtMessages.Text += "------------------------------------------------------\r\n";
            //scroll the textbox to the bottom
            ScrollToBottom();
            
            this.Cursor = Cursors.Default;
            //修改当前指针样式
            this.Cursor = Cursors.Default;

            
        }

        private string ReturnMessages(Geoprocessor gp)
        {
            StringBuilder sb = new StringBuilder();
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    System.Diagnostics.Trace.WriteLine(gp.GetMessage(Count));
                    sb.AppendFormat("{0}\n", gp.GetMessage(Count));
                }
            }
            return sb.ToString();
        }

        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";
            IEnumLayer layers = m_hookHelper.FocusMap.get_Layers(uid, true);

            return layers;
        }

        private void ScrollToBottom()
        {
            PostMessage((IntPtr)txtMessages.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, (IntPtr)IntPtr.Zero);
        }

    }
}
