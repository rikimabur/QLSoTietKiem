using System;
using System.Configuration;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace QLSoTK.Helpers
{
    public static class Extensions
    {
        #region Mật khẩu
        // Mã hóa mật khẩu theo base 64
        public static string EncodeBase64(this Encoding encoding, string text)
        {
            if (text == null)
            {
                return null;
            }

            byte[] textAsBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }
        /// <summary>
        ///  Mã hóa Md5
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>string</returns>
        public static string Md5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static string DecodeBase64(this Encoding encoding, string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            byte[] textAsBytes = Convert.FromBase64String(encodedText);
            return encoding.GetString(textAsBytes);
        }

        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        public static string EncryptMD5(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string DecryptMD5(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        #endregion
        #region Kiểm tra validation
        // Kiểm tra email
        public static bool IsValidEmail(string email)
        {
            Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }
        // Kiêm tra số điện thoại
        public static bool IsValidPhone(string phone)
        {
            string MatchPhoneNumberPattern = @"/(09|01[2|6|8|9])+([0-9]{8})\b/g";
            if (phone != null) return Regex.IsMatch(phone, MatchPhoneNumberPattern);
            else return false;
        }
        public static bool IsNumber(string value)
        {
            return Regex.IsMatch("^[0-9]", value);
        }
        public static bool IsValidPassword(string plainText, out string ErrorMessage)
        {
            var input = plainText;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Mật khẩu mới không được rỗng");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Mật khẩu mới phải có ký tự thường";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Mật khẩu mới phải có ký tự hoa";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Mật khẩu mới phải có độ dài từ 8 tới 15 ký tự";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Mật khẩu mới phải có ký tự số";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Mật khẩu mới phải có ký tự đặc biệt";
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region Convert
        public static DateTime StringToDate(string str)
        {
            DateTime date = DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return date;
        }
        #endregion
        #region Get short text
        public static string GetShortName(string str)
        {
            string res = "";
            string[] tu = str.Split(' ');
            int len = tu.Length;
            for (int i = 0; i < len - 1; i++)
            {
                res += tu[i].Substring(0, 1);
            }
            res += tu[len - 1];
            return res;
        }

        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            //text = text.Replace(" ", "-"); //Comment lại để không đưa khoảng trắng thành ký tự -

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        #endregion
        #region Lấy giá trị value của key trong file app.config
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
        #endregion
        #region formart tiền tệ
        public static string stringToMoney(this string str)
        {
            return string.Format("{0:N0},000", str);
        }
        #endregion
        public static int GetMANV(int ma = 3)
        {
            ////frm_main frm_Main = new frm_main();
            ////var  a = frm_Main._loginTaiKhoan.MaNhanVien;
            return ma;
        }
        //public static void BackupDatabase(string backUpFile)
        //{
        //    ServerConnection con = new ServerConnection(@"xxxxx\SQLEXPRESS");
        //    Server server = new Server(con);
        //    Backup source = new Backup();
        //    source.Action = BackupActionType.Database;
        //    source.Database = "MyDataBaseName";
        //    BackupDeviceItem destination = new BackupDeviceItem(backUpFile, DeviceType.File);
        //    source.Devices.Add(destination);
        //    source.SqlBackup(server);
        //    con.Disconnect();
        //}
        //public static void RestoreDatabase(string backUpFile)
        //{
        //    ServerConnection con = new ServerConnection(@"xxxxx\SQLEXPRESS");
        //    Server server = new Server(con);
        //    Restore destination = new Restore();
        //    destination.Action = RestoreActionType.Database;
        //    destination.Database = "MyDataBaseName";
        //    BackupDeviceItem source = new BackupDeviceItem(backUpFile, DeviceType.File);
        //    destination.Devices.Add(source);
        //    destination.ReplaceDatabase = true;
        //    destination.SqlRestore(server);
        //}
    }
}
