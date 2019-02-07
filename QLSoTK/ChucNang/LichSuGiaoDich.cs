using DevExpress.XtraGrid.Localization;
using QLSoTietKiem.Business;
using System;
using System.Windows.Forms;

namespace QLSoTK.ChucNang
{
    public partial class LichSuGiaoDich : UserControl
    {
        public LichSuGiaoDich()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        #region change button clear and find of gridcontrol
        public class MyGridLocalizer : GridLocalizer
        {
            public override string GetLocalizedString(GridStringId id)
            {
                string retval = "";
                switch (id)
                {
                    case GridStringId.FindControlClearButton: return "Làm mới";
                    case GridStringId.FindControlFindButton: return "Tìm";

                    default:
                        retval = "";
                        break;
                }
                return retval;
            }
        }
        #endregion

        private void LichSuGiaoDich_Load(object sender, EventArgs e)
        {
            var lstlichsu = GiaoDichBus.GetAll();
            if (lstlichsu != null)
            {
                gridControl_lichsu.DataSource = lstlichsu;
            }
            GridLocalizer.Active = new MyGridLocalizer();
        }

        // close user control
        private void simple_close_Click(object sender, EventArgs e)
        {
            frm_main f = this.ParentForm as frm_main;
            f.Tab_Closed();
        }
    }
}
