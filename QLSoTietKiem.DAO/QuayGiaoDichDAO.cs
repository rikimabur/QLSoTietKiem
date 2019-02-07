using QLSoTietKiem.DAO.Helpers;
using QLSoTietKiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSoTietKiem.DAO
{
    public class QuayGiaoDichDAO
    {
        public static List<QuayGiaoDichDto> GetAllPaymentStore()
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    return ql.QuayGiaoDich.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("QuayGiaoDichDAO GetAllPaymentStore", ex.Message);
                return null;
            }
        }
        public static bool CreatePaymentStore(QuayGiaoDichDto _paymentStore)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    ql.QuayGiaoDich.Add(_paymentStore);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("QuayGiaoDichDAO CreatePaymentStore", ex.Message);
                return false;
            }
        }
    }
}
