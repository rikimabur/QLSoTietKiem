using System;
using System.Configuration;
using System.Windows.Forms;

namespace QLSoTK.Helpers
{
    public static class Commons
    {
        // Khới tạo password
        public static void InitTextPassWord(TextBox textBox)
        {
            textBox.Text = "";
            textBox.PasswordChar = '*';
        }
        // phân biệt nam nữ
        public static string GetGender(int id)
        {
            return id == 1 ? "Nam" : "Nữ";
        }
        // Lấy giá trị trong appsetting
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
        #region Thông Báo
        public static void MessageInfo(string message, string info = "Thông Báo")
        {
            MessageBox.Show(message, info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MessageErr(string message, string eror = "Thông Báo")
        {
            MessageBox.Show(message, eror, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MessageValid(TextBox text, string message, string error = "Thông Báo")
        {
            MessageErr(message, error);
            text.Focus();
        }
        public static DialogResult MessageConfirm(string message, string info = "Thông Báo", string ok  = "Đồng Ý",string no ="Không Đồng Ý")
        {
            return MessageBox.Show(message, info,MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
        #endregion
        #region Định dạng tiền tệ
        public static Func<string , string> FormatMoney  = (tien) => string.Format("{0:N0},000 đ", tien);
        #endregion
    }
}
