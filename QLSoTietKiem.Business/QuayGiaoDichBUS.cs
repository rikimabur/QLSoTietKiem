using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO;

namespace QLSoTietKiem.Business
{
    public class QuayGiaoDichBUS
    {
        public static List<PaymentStoreResult> getDataSourcePaymentCombo()
        {
            List<QuayGiaoDichDto> _paymentStoreDTO = new List<QuayGiaoDichDto>();
            List<PaymentStoreResult> g_PaymentStore = new List<PaymentStoreResult>();
            _paymentStoreDTO = QuayGiaoDichDAO.GetAllPaymentStore(); 
            foreach (var item in _paymentStoreDTO)
            {
                PaymentStoreResult _paymentStore = new PaymentStoreResult();
                _paymentStore.PaymentStoreCode = item.MaQGD;
                _paymentStore.PaymentStoreName = item.TenQuayGiaoDich;
                _paymentStore.PaymentStoreAddress = item.DiaChi;
                g_PaymentStore.Add(_paymentStore);
            }
            return g_PaymentStore;
        }
        public bool CreatePaymentStore(QuayGiaoDichDto _paymentStore, out string Message)
        {
            if(string.IsNullOrEmpty(_paymentStore.TenQuayGiaoDich))
            {
                Message = "Tên chi nhánh không được rỗng";
                return false;
            }
            else if (string.IsNullOrEmpty(_paymentStore.DiaChi))
            {
                Message = "Địa chỉ chi nhánh không được rỗng";
                return false;
            }
            else if (!QuayGiaoDichDAO.CreatePaymentStore(_paymentStore))
            {
                Message = "Lỗi tạo chi nhánh";
                return false;
            }
            else
            {
                Message = "Tạo chi nhánh thành công";
                return true;
            }
        }
    }
    public class PaymentStoreResult
    {
        public int PaymentStoreCode { set; get; }
        public string PaymentStoreName { set; get; }
        public string PaymentStoreAddress { set; get; }
    }
}
