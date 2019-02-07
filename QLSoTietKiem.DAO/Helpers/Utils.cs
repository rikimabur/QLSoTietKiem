using System;
using System.Text;

namespace QLSoTietKiem.DAO.Helpers
{
    public static class Utils
    {
        #region mã hóa password
        // Mã hóa theo MD5
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        #endregion
        /// <summary>
        /// Kiểm tra số tiền nhập vào so với kỳ hạn
        /// True: nếu số tiền trong kỳ hạn bé hơn bằng số tiền nhập vào
        /// </summary>
        public static Func<double, double, bool> KiemTraSoTienGui = (soTienGui, soTienHieuLuc) => soTienGui > soTienHieuLuc; 
        /// <summary>
        /// Kiểm tra ngày rút tiền phải lớn hơn 15 ngày
        /// </summary>
        /// <param name="dateBegin"> ngày bắt đầu</param>
        /// <param name="dateEnd">Ngày kết thúc. mặt định là ngày hiện tại</param>
        /// <returns>bool</returns>
        public static bool KiemTraNgayRut(DateTime dateBegin, DateTime? date = null)
        {
            return (DateTime.Now - dateBegin).TotalDays > 15;
        }
        /// <summary>
        ///  kiểm tra ngày rút với sổ tiết kiệm không thời hạn
        /// </summary>
        /// <param name="dateBegin"></param>
        /// <returns>bool</returns>
        public static bool KiemTraSoThangLai(DateTime dateBegin)
        {
            DateTime dateEnd = DateTime.Now;
            if ((dateEnd.Year - dateBegin.Year) > -1)
                return true;
            if ((dateEnd.Month - dateBegin.Month) > -1)
                return true;
            return false;
        }
        #region Công thức tính lãi xuất
        /// <summary>
        ///  Tính lãi theo số kỳ hạn 
        ///  - Lãi suất theo tháng và lãi xuất không thời hạn
        ///  - Lãi suất tự động quay vòng nếu khách hàng không rút sổ đúng thời hạn
        /// </summary>
        /// <param name="dateBegin"> Ngày trong sổ</param>
        /// <param name="dateEnd"> Ngày hiện tại bạn muốn rút</param>
        /// <param name="soThang"> Số tháng là 0: không thời hạn. </param>
        /// <param name="tien"></param>
        /// <param name="laiSuatTheoThang"></param>
        /// <param name="laiXuatKhongThoiHan"></param>
        /// <returns></returns>
        public static double TinhLaiXuat(DateTime dateBegin, DateTime ngayDaoHan, int soThang, double tien, decimal laiSuatTheoThang, decimal laiXuatKhongThoiHan)
        {
            laiSuatTheoThang = laiSuatTheoThang / 100; // lãi theo phần trăm
            laiXuatKhongThoiHan = laiXuatKhongThoiHan / 100;//lãi theo phần trăm
            DateTime dateEnd = DateTime.Now;
            if (ngayDaoHan.Day == dateEnd.Day && ngayDaoHan.Month == dateEnd.Month && ngayDaoHan.Year == dateEnd.Year)
            {
                int _thang = (dateBegin.Year == ngayDaoHan.Year) ? ngayDaoHan.Month - dateBegin.Month : ((12 - dateBegin.Month) + ngayDaoHan.Year);
                return (double)((laiSuatTheoThang) * (_thang/3)) * tien;
            }
           
            int _numberMonth = TotalMonth(dateBegin, dateEnd);
            // Lãi xuất không thời hạn
            if (soThang < 1)
                return Math.Round((double)(_numberMonth * laiXuatKhongThoiHan),0);
            // só tháng (đã tíTotalMonthnh tới quay vòng)
            int _totalMonth = _numberMonth / soThang; // số kỳ hạn mình nhận được

            if (_totalMonth < 0)
                return 0;
            int _totalRemainDay = TotalDay(dateBegin, dateEnd);
            if (_totalRemainDay > DateTime.DaysInMonth(dateBegin.Year, dateBegin.Month))
            {
                _totalMonth += 1;
            }
            // Số tháng dư còn lại được tính theo lãi xuất không thời hạn
            int _remainMonth = _numberMonth - (_totalMonth * soThang);
            if(_remainMonth < 0)
            {
                _remainMonth = 0;
            }
            // tính số ngày dư hiện tại
            //int _remainDay = dateEnd.Day -  dateBegin.Day;
            // Lấy ngày của 1 tháng
            double _getTotalMoney = 0;
            if (_totalRemainDay > 0)
            {
                // tính tháng 
                // nếu tháng bắt đầu = ngày kết thúc thì lấy tháng hiện tại.
                // Ngươc lại nếu tháng kết thúc lớn hơn tháng bắt đầu thì lấy thấy kết thúc để tính
                int _tatalDayofmonth = (dateEnd.Month == dateBegin.Month) ? DateTime.DaysInMonth(dateEnd.Year, dateEnd.Month) : DateTime.DaysInMonth(dateEnd.Year, dateEnd.AddMonths(1).Month);
                _getTotalMoney = (double)((_totalRemainDay / _tatalDayofmonth) * laiXuatKhongThoiHan) * tien;
            }
            return Math.Round((double)((_totalMonth * laiSuatTheoThang) + (_remainMonth * laiXuatKhongThoiHan)) + _getTotalMoney,0);
        }
        /// <summary>
        /// Tính số tháng hiện tại
        /// </summary>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        private static int TotalMonth(DateTime dateBegin, DateTime dateEnd)
        {
            int _yearBegin = dateBegin.Year;
            int _yearEnd = dateEnd.Year;
            if (_yearEnd > _yearBegin)
            {
                int _monthBegin = 12 - dateBegin.Month;
                int _monthEnd = dateEnd.Month;
                return (_monthEnd + _monthBegin) + ((_yearEnd - _yearBegin) * 12);
            }
            return dateEnd.Month - dateBegin.Month;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        private static int TotalDay(DateTime dateBegin, DateTime dateEnd)
        {
            if (dateBegin.Month == dateEnd.Month)
                return dateEnd.Day - dateBegin.Day;
            return DateTime.DaysInMonth(dateBegin.Year, dateBegin.Month) - dateBegin.Day + dateEnd.Day;
        }
        #endregion
    }
}
