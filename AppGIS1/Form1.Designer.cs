
namespace AppGIS1
{
    partial class AEGIS软件开发实践
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AEGIS软件开发实践));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAccessData = new System.Windows.Forms.ToolStripMenuItem();
            this.transformData = new System.Windows.Forms.ToolStripMenuItem();
            this.miCarto = new System.Windows.Forms.ToolStripMenuItem();
            this.miRenderSimply = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetRendererInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.命令菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图组成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageLayout对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.专题图制作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.cbBookmarkList = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.空间类型ToolStripMenuItem,
            this.miCarto,
            this.命令菜单ToolStripMenuItem,
            this.地图组成ToolStripMenuItem,
            this.pageLayout对象ToolStripMenuItem,
            this.专题图制作ToolStripMenuItem,
            this.miCreateBookmark});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地图加载ToolStripMenuItem,
            this.结束ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 地图加载ToolStripMenuItem
            // 
            this.地图加载ToolStripMenuItem.Name = "地图加载ToolStripMenuItem";
            this.地图加载ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.地图加载ToolStripMenuItem.Text = "地图加载";
            this.地图加载ToolStripMenuItem.Click += new System.EventHandler(this.地图加载ToolStripMenuItem_Click);
            // 
            // 结束ToolStripMenuItem
            // 
            this.结束ToolStripMenuItem.Name = "结束ToolStripMenuItem";
            this.结束ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.结束ToolStripMenuItem.Text = "结束";
            // 
            // 空间类型ToolStripMenuItem
            // 
            this.空间类型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAccessData,
            this.transformData});
            this.空间类型ToolStripMenuItem.Name = "空间类型ToolStripMenuItem";
            this.空间类型ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.空间类型ToolStripMenuItem.Text = "空间数据";
            // 
            // miAccessData
            // 
            this.miAccessData.Name = "miAccessData";
            this.miAccessData.Size = new System.Drawing.Size(270, 34);
            this.miAccessData.Text = "访问图层数据";
            this.miAccessData.Click += new System.EventHandler(this.miAccessData_Click);
            // 
            // transformData
            // 
            this.transformData.Name = "transformData";
            this.transformData.Size = new System.Drawing.Size(270, 34);
            this.transformData.Text = "空间数据转换";
            this.transformData.Click += new System.EventHandler(this.transformData_Click);
            // 
            // miCarto
            // 
            this.miCarto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRenderSimply,
            this.miGetRendererInfo});
            this.miCarto.Name = "miCarto";
            this.miCarto.Size = new System.Drawing.Size(98, 28);
            this.miCarto.Text = "地图表现";
            // 
            // miRenderSimply
            // 
            this.miRenderSimply.Name = "miRenderSimply";
            this.miRenderSimply.Size = new System.Drawing.Size(270, 34);
            this.miRenderSimply.Text = "简单渲染图层";
            this.miRenderSimply.Click += new System.EventHandler(this.miRenderSimply_Click);
            // 
            // miGetRendererInfo
            // 
            this.miGetRendererInfo.Name = "miGetRendererInfo";
            this.miGetRendererInfo.Size = new System.Drawing.Size(270, 34);
            this.miGetRendererInfo.Text = "获取渲染器信息";
            this.miGetRendererInfo.Click += new System.EventHandler(this.miGetRendererInfo_Click);
            // 
            // 命令菜单ToolStripMenuItem
            // 
            this.命令菜单ToolStripMenuItem.Name = "命令菜单ToolStripMenuItem";
            this.命令菜单ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.命令菜单ToolStripMenuItem.Text = "命令菜单";
            // 
            // 地图组成ToolStripMenuItem
            // 
            this.地图组成ToolStripMenuItem.Name = "地图组成ToolStripMenuItem";
            this.地图组成ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.地图组成ToolStripMenuItem.Text = "地图组成";
            // 
            // pageLayout对象ToolStripMenuItem
            // 
            this.pageLayout对象ToolStripMenuItem.Name = "pageLayout对象ToolStripMenuItem";
            this.pageLayout对象ToolStripMenuItem.Size = new System.Drawing.Size(16, 28);
            // 
            // 专题图制作ToolStripMenuItem
            // 
            this.专题图制作ToolStripMenuItem.Name = "专题图制作ToolStripMenuItem";
            this.专题图制作ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.专题图制作ToolStripMenuItem.Text = "专题图制作";
            // 
            // miCreateBookmark
            // 
            this.miCreateBookmark.Name = "miCreateBookmark";
            this.miCreateBookmark.Size = new System.Drawing.Size(98, 28);
            this.miCreateBookmark.Text = "创建书签";
            this.miCreateBookmark.Click += new System.EventHandler(this.miCreateBookmark_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 32);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1052, 28);
            this.axToolbarControl1.TabIndex = 1;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1052, 401);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 60);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1052, 426);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axLicenseControl1);
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1052, 401);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.axMapControl2);
            this.splitContainer2.Size = new System.Drawing.Size(350, 401);
            this.splitContainer2.SplitterDistance = 91;
            this.splitContainer2.TabIndex = 0;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(350, 91);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl2.Location = new System.Drawing.Point(0, 0);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(350, 306);
            this.axMapControl2.TabIndex = 0;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(138, 155);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(698, 401);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // cbBookmarkList
            // 
            this.cbBookmarkList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbBookmarkList.FormattingEnabled = true;
            this.cbBookmarkList.Location = new System.Drawing.Point(684, 6);
            this.cbBookmarkList.Name = "cbBookmarkList";
            this.cbBookmarkList.Size = new System.Drawing.Size(122, 26);
            this.cbBookmarkList.TabIndex = 3;
            this.cbBookmarkList.SelectedIndexChanged += new System.EventHandler(this.cbBookmarkList_SelectedIndexChanged);
            // 
            // AEGIS软件开发实践
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 486);
            this.Controls.Add(this.cbBookmarkList);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AEGIS软件开发实践";
            this.Text = "AEGIS软件开发实践";
            this.Load += new System.EventHandler(this.AEGIS软件开发实践_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCarto;
        private System.Windows.Forms.ToolStripMenuItem 命令菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图组成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageLayout对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 专题图制作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图加载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ToolStripMenuItem miCreateBookmark;
        private System.Windows.Forms.ComboBox cbBookmarkList;
        private System.Windows.Forms.ToolStripMenuItem miAccessData;
        private System.Windows.Forms.ToolStripMenuItem transformData;
        private System.Windows.Forms.ToolStripMenuItem miRenderSimply;
        private System.Windows.Forms.ToolStripMenuItem miGetRendererInfo;
    }
}

