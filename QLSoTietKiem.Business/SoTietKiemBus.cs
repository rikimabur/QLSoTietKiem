using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO;
using QLSoTietKiem.DTO.Model;
using System.Collections.Generic;
using System;

namespace QLSoTietKiem.Business
{
    /// <summary>
    /// Nghiệp vụ quản lý của sổ tiết kiệm
    /// </summary>
    public class SoTietKiemBus
    {
        /// <summary>
        /// Lấy danh sách tất cả các sổ tiết kiệm
        /// </summary>
        /// <returns></returns>
        public static List<SoTietKiem_DTO> GetAll()
        {
            return SoTietKiemDao.GetAll();
        }

        /// <summary>
        /// Lấy thông tin của một sổ tiết kiệm
        /// </summary>
        /// <param name="id">mã sổ tiết kiệm</param>
        /// <returns></returns>
        public static SoTietKiem_DTO GetById(int id)
        {
            return SoTietKiemDao.GetById(id);
        }

        /// <summary>
        /// Thêm một sổ tiết kiệm mới
        /// </summary>
        /// <param name="stkDto">SoTietKiemDto</param>
        /// <returns></returns>
        public static bool Add(SoTietKiemDto stkDto,int maQuayGD = 1)
        {
            if(SoTietKiemDao.Add(stkDto))
            {
                GiaoDichDto giaoDichDto = new GiaoDichDto();
                int mastk = SoTietKiemDao.GetSTKTopOne();
                giaoDichDto.MaSTK = mastk;
                giaoDichDto.GhiChu = "Mở sổ tiết kiệm";
                giaoDichDto.MaKyH = stkDto.MaKyHan;
                giaoDichDto.MaNV = stkDto.MaNV;
                giaoDichDto.MaQuayGD = maQuayGD;
                giaoDichDto.MaKHang = stkDto.MaKhachHang;
                giaoDichDto.SoTienGui = stkDto.SoTienGui;
                giaoDichDto.TongTien = stkDto.SoTienGui;
                giaoDichDto.TongTienLai = 0;
                giaoDichDto.TinhTrang = true;
                giaoDichDto.LoaiGD = 1;
                giaoDichDto.NgayGiaoDich = DateTime.Now;
                GiaoDichDao.Add(giaoDichDto);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cập nhật thông tin của một sổ tiết kiệm
        /// </summary>
        /// <param name="soTietKiemDto"></param>
        /// <returns></returns>
        public static bool Update(SoTietKiemDto soTietKiemDto, int maQuayGD = 1)
        {
            if(SoTietKiemDao.Update(soTietKiemDto))
            {
                // Xóa giao dịch trước khi thực hiện giao dịch mới
                GiaoDichDao.Delete(soTietKiemDto.MaSTK);
                GiaoDichDto giaoDichDto = new GiaoDichDto();
                giaoDichDto.MaSTK = soTietKiemDto.MaSTK;
                giaoDichDto.GhiChu = "Mở sổ tiết kiệm";
                giaoDichDto.MaKyH = soTietKiemDto.MaKyHan;
                giaoDichDto.MaNV = soTietKiemDto.MaNV;
                giaoDichDto.MaQuayGD = maQuayGD;
                giaoDichDto.MaKHang = soTietKiemDto.MaKhachHang;
                giaoDichDto.SoTienGui = soTietKiemDto.SoTienGui;
                giaoDichDto.TongTien = soTietKiemDto.SoTienGui;
                giaoDichDto.TongTienLai = 0;
                giaoDichDto.TinhTrang = true;
                giaoDichDto.LoaiGD = 0;
                giaoDichDto.NgayGiaoDich = DateTime.Now;
                GiaoDichDao.Add(giaoDichDto);
                return true;
            }
            return false;
        }
   

        /// <summary>
        /// Tạo sổ mới khi có điều kiện(TH này rất ít xảy ra)
        /// B1:
        /// nếu khách hàng muốn lấy số tiền cũ + số tiền mới thêm vào thì tính toán trước khi thêm vào
        ///     1. nếu khách hàng chưa đủ tháng thì lấy mức lãi xuất vô thường hạn 
        ///     2. nếu khách hàng quá tháng mà số quay vòng = với kỳ hạn gửi(số tháng gửi) thì tính toán bình thường theo
        ///     thời hạn. cứ nghĩ (số tháng hiện tại % số tháng gửi) == 0
        ///     vd: gửi 3 tháng mà: tháng thứ 3 6 9 thì có thể nhận đủ lãi theo thời hạn 3 tháng
        ///     3.  (số tháng hiện tại % số tháng gửi) != 0
        ///     Ta sẽ tính như sau: số tháng hiện tại % số tháng gửi chia lấy phần nguyên thì tính theo số 2 như trên
        ///     còn phần dư thì ta tính theo lãi không thời hạn. Sau đó cộng 2 cái đó lại với nhau
        ///     VD: gửi 3 tháng mà: tháng thứ 7
        ///     7 % 3 = 2 => A = 2 * số lãi suất
        ///     7 - 2*3 = 1 => B = 1 * số lãi suất không thời hạn
        ///     Kết quả  = A + B
        /// Kết quả trường hợp 1: Khi tính xong kết quả TH 1 thì ta tính ra số tiền lãi
        /// Kết quả = Lãi Suất + số tiền cũ +  số tiền mới
        /// B2:
        /// Sau đó tạo sổ mới cho người gửi nhớ ghi note vào trong sổ mới 
        /// gồm: số tiền cũ + số tháng + lãi xuất + kỳ hạn + ngày Kết sổ(có thể có hoặc không  vì nó bằng với ngày mở sổ hiện tại) + sô tài khoản củ
        /// B3: chuyển trạng thái sổ cũ về 2 
        /// </summary>
        /// <param name="maSTK"></param>
        /// <param name="stkDto"></param>
        /// <returns>0: Thành công</returns>
        /// <returns>1: lỗi không tìm thấy</returns>
        /// <returns>2: lỗi từ server</returns>
        public static int AddExist(int maSTK, SoTietKiemDto stkDto)
        {
            var _soTietKiem = SoTietKiemDao.GetById(maSTK);
            if (_soTietKiem != null)
            {
                return 0;
            }
            return 2;
        }

        /// <summary>
        /// Kiểm tra điều kiện cần và đủ để rút một sổ tiết kiệm
        /// </summary>
        /// <param name="date"></param>
        /// <param name="sothang"></param>
        /// <returns></returns>
        public static string CheckSTK(DateTime dateBegin,DateTime dateEnd, int sothang)
        {
            return SoTietKiemDao.CheckSTK(dateBegin, dateEnd, sothang);
        }

        /// <summary>
        /// Tình lãi xuất của một sổ bất kỳ
        /// </summary>
        /// <param name="soTietKiem_DTO"></param>
        /// <returns></returns>
        public static double TinhLaiXuat(SoTietKiem_DTO soTietKiem_DTO)
        {
            return SoTietKiemDao.TinhLaiXuat(soTietKiem_DTO);
        }

        /// <summary>
        /// Xóa bỏ sổ tiết kiệm(Update lại trạng thái là đã xóa sổ = 0)
        /// </summary>
        /// <param name="id">mã sổ tiết tiệm</param>
        /// <returns></returns>
        public static bool Delete(int id,int manv ,double tongTien, double tongLai, int maQuayGD = 1)
        {
            var soTietKiemDto = SoTietKiemDao.Delete(id);
            if (soTietKiemDto != null)
            {
                GiaoDichDto giaoDichDto = new GiaoDichDto();
                int mastk = SoTietKiemDao.GetSTKTopOne();
                giaoDichDto.MaSTK = mastk;
                giaoDichDto.GhiChu = "Rút sổ tiết kiệm";
                giaoDichDto.MaKyH = soTietKiemDto.MaKyHan;
                giaoDichDto.MaNV = manv;
                giaoDichDto.MaQuayGD = maQuayGD;
                giaoDichDto.MaKHang = soTietKiemDto.MaKhachHang;
                giaoDichDto.SoTienGui = soTietKiemDto.SoTienGui;
                giaoDichDto.TongTien = tongTien;
                giaoDichDto.TongTienLai = tongLai;
                giaoDichDto.TinhTrang = true;
                giaoDichDto.LoaiGD = 1;
                giaoDichDto.NgayGiaoDich = DateTime.Now;
                GiaoDichDao.Add(giaoDichDto);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Lấy danh sách tất cả các sổ tiết kiệm mà chưa rút
        /// </summary>
        /// <returns></returns>
        public static List<SoTietKiem_DTO> GetListActive()
        {
            return SoTietKiemDao.GetListActive();
        }
    }
}
