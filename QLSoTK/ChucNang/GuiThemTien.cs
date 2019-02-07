using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSoTK.ChucNang
{
    public partial class GuiThemTien : UserControl
    {
        public delegate void GuiThemTien_Handevent();
        public event GuiThemTien_Handevent Closed;
        public GuiThemTien()
        {
            InitializeComponent();
        }
        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Closed();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (Validation())
            //{
            //    SoTietKiemBus.UpdateTienGui(Convert.ToInt32(gridLookUpEditMaSTk.EditValue), Convert.ToDouble(txtSoTienGui.Text));
            //}
        }

        private void gridLookUpEditMaSTk_EditValueChanged_1(object sender, EventArgs e)
        {
            var idSoTK = Convert.ToInt32(gridLookUpEditMaSTk.EditValue);
            txtTenKhachHang.Text = gridLookUpEditMaSTk.Text;
            //txtTongTien.Text = SoTietKiemBus.GetById(idSoTK).SoTienGui.ToString();
            //gridLookUpEditLoaiTien.EditValue = SoTietKiemBus.GetById(idSoTK).MaLoaiTien.ToString();
        }

        private void GuiThemTien_Load(object sender, EventArgs e)
        {
            //txtTongTien.ReadOnly = true;
            //txtTenKhachHang.ReadOnly = true;

            //gridLookUpEditLoaiTien.Properties.DataSource = SoTietKiemBus.GetLoaiTien().Select(c => new
            //{
            //    Id = c.Id,
            //    TypeMoney = c.TypeMoney
            //}).ToList();
            //gridLookUpEditLoaiTien.Properties.DisplayMember = "TypeMoney";
            //gridLookUpEditLoaiTien.Properties.ValueMember = "Id";
            //gridLookUpEditLoaiTien.Properties.PopulateViewColumns();
            //gridLookUpEditLoaiTien.Properties.View.Columns["Id"].Visible = false;

            //gridLookUpEditMaSTk.Properties.DataSource = SoTietKiemBus.GetAll().Select(c => new
            //{
            //    MaSTK = c.MaSTK,
            //    TenKH = c.KhachHang
            //}).ToList();
            //gridLookUpEditMaSTk.Properties.DisplayMember = "TenKH";
            //gridLookUpEditMaSTk.Properties.ValueMember = "MaSTK";
            //gridLookUpEditMaSTk.Properties.PopulateViewColumns();
            //gridLookUpEditMaSTk.Properties.View.Columns["TenKH"].Visible = false;
        }

        private bool Validation()
        {
            var ErrorMessage = string.Empty;
            var Valid = true;
            if (string.IsNullOrEmpty(gridLookUpEditLoaiTien.EditValue.ToString()) || string.IsNullOrEmpty(txtSoTienGui.Text))
            {
                Valid = false;
                ErrorMessage = "Thông tin mã tiết kiệm hoặc tiền gửi bị trống, mời điền lại";
            }
            if (!Valid)
            {
                MessageBox.Show(ErrorMessage);
            }
            return Valid;
        }
    }
}
