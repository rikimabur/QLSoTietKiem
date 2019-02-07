using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSoTietKiem.DTO.Model
{
    public class StaffManager_DTO
    {
        public int StaffCode { get; set; }
        public string StaffName { get; set; }
        public bool StaffGender { get; set; }
        public DateTime StaffBirthday { get; set; }
        public string StaffEmail { get; set; }
        public string StaffPhoneNumber { get; set; }
        public string StaffAddress { get; set; }
        public int StaffJobtitle { get; set; }
        public int StaffPaymentStore { get; set; }
        public string StaffAccount { get; set; }
        public string StaffPassword { get; set; }
        public int StaffPermission { get; set; }
    }
    public class StaffUpdateModel
    {
        public int StaffCode { get; set; }
        public string StaffName { get; set; }
        public bool StaffGender { get; set; }
        public DateTime StaffBirthday { get; set; }
        public string StaffEmail { get; set; }
        public string StaffPhoneNumber { get; set; }
        public string StaffAddress { get; set; }
        public int StaffJobtitle { get; set; }
        public int StaffPaymentStore { get; set; }
        public int StaffPermission { get; set; }
    }
    public class CustManager_DTO
    {
        public int CustCode { get; set; }
        public string CustName { get; set; }
        public bool CustGender { get; set; }
        public string CustPhoneNumber { get; set; }
        public string CustAddress { get; set; }
        public string CustCMND { get; set; }
        public DateTime CreateTimeCMND { get; set; }
        public DateTime CustBirthday { get; set; }
    }
}
