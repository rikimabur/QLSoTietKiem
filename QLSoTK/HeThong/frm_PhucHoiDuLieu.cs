using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using QLSoTK.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSoTK.DanhMuc
{
    public partial class frm_PhucHoiDuLieu : Form
    {
        public frm_PhucHoiDuLieu()
        {
            InitializeComponent();
        }

        private void simpleButton_save_Click(object sender, EventArgs e)
        {
            try
            {
                Server dbServer = new Server(new ServerConnection(Commons.GetByKey("serverName"), Commons.GetByKey("userDatabase"), ""));
                Restore restore = new Restore();
                restore.Database = "SMO";  // your database name

                // define options       
                restore.Action = RestoreActionType.Database;
                restore.Devices.AddDevice(@"C:\SMOTest.bak", DeviceType.File);
                restore.PercentCompleteNotification = 10;
                restore.ReplaceDatabase = true;

                // define a callback method to show progress
                restore.PercentComplete += new PercentCompleteEventHandler(res_PercentComplete);

                // execute the restore    
                restore.SqlRestore(dbServer);
            }
            catch (Exception ex)
            {

            }
        }
        private static void res_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            // do something......
        }

        private void simpleButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
