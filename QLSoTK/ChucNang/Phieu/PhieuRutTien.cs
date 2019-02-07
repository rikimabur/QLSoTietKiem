using QLSoTietKiem.DTO.Model;
using System;

namespace QLSoTK.ChucNang.Phieu
{
    public partial class PhieuRutTien : DevExpress.XtraReports.UI.XtraReport
    {

        public PhieuRutTien()
        {
            RutSoTietKiem rutSoTietKiem = new RutSoTietKiem();
            rutSoTietKiem.PhieuRutEvent += InitPhieu;
            InitializeComponent();
        }
        private void InitPhieu(PhieuRut_DTO phieuRut_DTO)
        {
            xrLabel_LoaiTien.Text = phieuRut_DTO.LoaiTien;
            xrLabel_Ngay.Text = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");
            xrLabel_ngaycap.Text = phieuRut_DTO.NgaySinh;
            xrLabel_noicap.Text = phieuRut_DTO.NoiCap;
            xrLabel_cmnd.Text = phieuRut_DTO.CMND;
            xrLabel_diachi.Text = phieuRut_DTO.DiaChi;
            sdt.Text = phieuRut_DTO.SDT;
            xrLabel_khachhang.Text = phieuRut_DTO.HoTenKh;
            xrLabel_chinhanh.Text = "HCM";
            xrLabel_sotienbangso.Text = phieuRut_DTO.SoTienGui.ToString();
            xrLabel_tonglai.Text = phieuRut_DTO.TongLai.ToString();
            xrLabel_tiennhan.Text = phieuRut_DTO.TongNhan.ToString();
        }

    }
}
