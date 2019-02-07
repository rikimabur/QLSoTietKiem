using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using QLSoTietKiem.Business;
using QLSoTietKiem.DTO;
using QLSoTK.Helpers;
using System;
using System.Windows.Forms;

namespace QLSoTK.DanhMuc
{
    /// <summary>
    /// Giao diện kỳ hạn vay
    /// </summary>
    public partial class KyHanVay : UserControl
    {
        public KyHanVay()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        private void toolStripbtn_dong_Click_1(object sender, EventArgs e)
        {
            frm_main f = this.ParentForm as frm_main;
            f.Tab_Closed();
        }
        private void KyHanVay_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.Dock = DockStyle.Fill;
            this.checkBox_status.Visible = false;
            gridView_KyHan.DataSource = null;
            var _kyHan = KyHanVayBus.GetAll();
            if (_kyHan != null)
            {
                gridView_KyHan.DataSource = KyHanVayBus.GetAll();
            }
        }
        // KeyPress lãi xuất
        private void txt_interest_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }
        // lưu khi chỉnh sửa
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (checkedValid() != "")
            {
                MessageBox.Show(checkedValid(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            KyHanVayDto KyHanVay_DTO = new KyHanVayDto();
            KyHanVay_DTO.SoThang = Convert.ToInt32(num_number.Value);
            KyHanVay_DTO.LaiSuat = decimal.Parse(txt_interest_rate.Text);
            KyHanVay_DTO.MucTien = decimal.Parse(txt_money.Text);
            KyHanVay_DTO.GhiChu = txt_note.Text;

            KyHanVay_DTO.MaKyHan = int.Parse(txt_MaKH.Text);
            KyHanVay_DTO.TinhTrang = (checkBox_status.Checked ? true : false);
            var message = KyHanVayBus.Update(KyHanVay_DTO);
            Commons.MessageInfo(message);
            gridView_KyHan.DataSource = KyHanVayBus.GetAll();
            return;
        }
        /// <summary>
        ///  load lại danh sách kỳ kỳ hạn vay khi event click row gridcontrol
        /// </summary>
        /// <param name="KyHanVay_DTO"></param>
        private void LoadKyHanVay(KyHanVayDto KyHanVay_DTO)
        {
            txt_MaKH.Text = KyHanVay_DTO.MaKyHan.ToString();
            num_number.Value = KyHanVay_DTO.SoThang;
            txt_interest_rate.Text = KyHanVay_DTO.LaiSuat.ToString();
            txt_money.Text = KyHanVay_DTO.MucTien.ToString();
            txt_note.Text = KyHanVay_DTO.GhiChu;
            checkBox_status.Checked = KyHanVay_DTO.TinhTrang;
        }
        // event key presss khi nhập tiền
        private void txt_money_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (((sender as TextBox).Text.Length > 10))
            {
                e.Handled = true;
                Commons.MessageInfo("Số Tiền quy định của ngân hàng không vượt quá 99 tỉ");
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        // bắt sự kiện rowclick in gridview
        private void gridView_KyHanVay_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView_KyHanVay.GetFocusedRowCellValue("MaKyHan") != null)
            {
                var _maKyHanVay = int.Parse(gridView_KyHanVay.GetFocusedRowCellValue("MaKyHan").ToString());
                // cập nhật lại trạng thái xóa
                if (gridView_KyHanVay.FocusedColumn.ColumnEditName.Equals("btnRemove"))
                {
                    if (Commons.MessageConfirm("Bạn Chắc Chắn Muốn Xóa Kỳ Hạn Này") == DialogResult.Yes)
                    {
                        if (KyHanVayBus.Delete(_maKyHanVay))
                        {
                            gridView_KyHan.DataSource = null;
                            gridView_KyHan.DataSource = KyHanVayBus.GetAll();
                            Commons.MessageInfo("Xóa Thành Công!");
                            return;
                        }
                        else
                        {
                            Commons.MessageErr("Xóa Không Thành Công!");
                            return;
                        }
                    }
                }
                // Cập nhật lại tình trạng hoạt động
                if (gridView_KyHanVay.FocusedColumn.ColumnEditName.Equals("btnActive"))
                {
                    if (Commons.MessageConfirm("Bạn Chắc Chắn Muốn Kích Hoạt Không") == DialogResult.Yes)
                    {
                        var _soThang = int.Parse(gridView_KyHanVay.GetFocusedRowCellValue("SoThang").ToString());
                        if (KyHanVayBus.CheckNumberMonth(_soThang))
                        {
                            Commons.MessageErr(string.Format("Kỳ hạn {0} đang hoạt động",_soThang));
                            return;
                        }
                        if (KyHanVayBus.UpdateStatus(_maKyHanVay))
                        {
                            gridView_KyHan.DataSource = null;
                            gridView_KyHan.DataSource = KyHanVayBus.GetAll();
                            Commons.MessageInfo("Kích hoạt thành công!");
                            return;
                        }
                        else
                        {
                            Commons.MessageErr("Kích hoạt Không Thành Công!");
                            return;
                        }
                    }
                }
                else
                {
                    int id = Convert.ToInt32(gridView_KyHanVay.GetFocusedRowCellValue("MaKyHan").ToString());
                    var _kyHanVay = KyHanVayBus.GetById(id);
                    if (_kyHanVay != null)
                    {
                        LoadKyHanVay(_kyHanVay);
                    }
                }
            }
            else
            {
                Init();
            }
        }
        // khởi tạo form rỗng
        private void Init()
        {
            num_number.Value = 0;
            txt_interest_rate.Text = "";
            txt_money.Text = "";
            txt_note.Text = "";
            checkBox_status.Checked = true;
            txt_MaKH.Text = "";
        }
        private void toolStripbtn_reload_Click(object sender, EventArgs e)
        {
            Init();
        }
        // kiêm tra validation trên form
        private string checkedValid()
        {
            if (num_number.Value < 0 || num_number.Value > 12)
                return "Số tháng không hợp lệ.";
            if (string.IsNullOrEmpty(txt_money.Text) || float.Parse(txt_money.Text) < 0)
                return "Số tiền nhập sai";
            if (string.IsNullOrEmpty(txt_interest_rate.Text) || float.Parse(txt_interest_rate.Text) > 100 || float.Parse(txt_interest_rate.Text) < 1)
                return "Lãi xuất nhập sai.";
            return "";
        }
        // bắt sự kiện textchange của mã khách hàng
        private void txt_MaKH_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_MaKH.Text))
            {
                this.checkBox_status.Visible = true;
                toolStripButton_Save.Visible = false;
            }

        }
        // event khi thay đổi 1 dòng trên gridview
        private void gridView_KyHanVay_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView gv = sender as GridView;
            string value = Convert.ToString(gv.GetRowCellValue(e.RowHandle, status));
            bool _flag = value.ToLower().Equals("đã xóa");
            // khởi tạo button
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            if (_flag)
            {
                //đổi màu
                //e.Appearance.BackColor = Color.Gray;
                //e.Appearance.ForeColor = Color.Blue;
                //đổi button
                buttonEdit = btnActive;
                gridView_KyHanVay.Columns[6].ColumnEdit = buttonEdit;

            }
            else
            {
                //đổi màu
                //e.Appearance.BackColor = Color.White;
                //đổi button
                buttonEdit = btnRemove;
                gridView_KyHanVay.Columns[6].ColumnEdit = buttonEdit;
            }
        }
        // Tạo mới 1 kỳ hạn
        private void toolStripbtn_create_Click(object sender, EventArgs e)
        {
            if (checkedValid() != "")
            {
                MessageBox.Show(checkedValid(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            KyHanVayDto KyHanVay_DTO = new KyHanVayDto();
            KyHanVay_DTO.SoThang = Convert.ToInt32(num_number.Value);
            KyHanVay_DTO.LaiSuat = decimal.Parse(txt_interest_rate.Text);
            KyHanVay_DTO.MucTien = decimal.Parse(txt_money.Text);
            KyHanVay_DTO.GhiChu = txt_note.Text;
            txt_MaKH.Text = null;
            if(KyHanVayBus.CheckNumberMonth(KyHanVay_DTO.SoThang))
            {
                Commons.MessageErr("Số tháng đã tồn tại.");
                return;
            }
            if (KyHanVayBus.Add(KyHanVay_DTO))
            {
                Commons.MessageInfo("Thêm Thành Công!");
            }
            else
            {
                Commons.MessageErr("Thêm Không Thành Công!");
            }
            gridView_KyHan.DataSource = KyHanVayBus.GetAll();
        }
        // keypress khi nhập số tháng
        private void num_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as NumericUpDown).Value > 12 )
            {
                num_number.Value = num_number.Maximum;
                e.Handled = true;
            }
            if((sender as NumericUpDown).Value < 0)
            {
                num_number.Value = num_number.Minimum;
                e.Handled = true;
            }
        }
    }
}
