using DevExpress.Skins;
using DevExpress.UserSkins;
using QLSoTK.Helpers;
using QLSoTK.Login;
using System;
using System.Windows.Forms;
namespace QLSoTK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //System.Threading.Thread.CurrentThread.CurrentUICulture =
            //  new System.Globalization.CultureInfo("ro");

            //Register manager
            MessageBoxManager.Register();

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            //Application.Run(new frmLogin());
            Application.Run(new frm_main());
            //Application.Run(new frm_SaoLuu());
        }
    }
}
