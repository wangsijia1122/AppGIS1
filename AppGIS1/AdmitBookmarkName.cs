using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;

namespace AppGIS1
{
    public partial class AdmitBookmarkName : Form
    {
        public AEGIS软件开发实践 m_frmMain;

        public AdmitBookmarkName(AEGIS软件开发实践 frm)
        {
            InitializeComponent();
            if (frm != null)
            {
                m_frmMain = frm;
            }
        }


        private void btnAdmit_Click(object sender, EventArgs e)
        {
            if (m_frmMain != null || tbBookmarkName.Text == "")
            {
                m_frmMain.CreateBookmark(tbBookmarkName.Text);
            }
            this.Close();
        }
    }
}
