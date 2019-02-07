using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using QLSoTK.Helpers;
using System;
using System.Windows.Forms;

namespace QLSoTK.DanhMuc
{
    public partial class frm_SaoLuu : Form
    {
        public frm_SaoLuu()
        {
            InitializeComponent();
        }
        // button đóng form trở lại form main
        private void simplebtn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // button sao lưu dữ liệu
        private void simplebtn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textEdit_duongdan.Text))
            {
                MessageBox.Show("Đường dẫn bạn chưa chọn", "Thong bao", MessageBoxButtons.OK);
                textEdit_duongdan.Focus();
                    return;
            }
            if (string.IsNullOrWhiteSpace(textEdit_tentaptin.Text))
            {
                MessageBox.Show("Tên tệp tin chưa nhập", "Thong bao", MessageBoxButtons.OK);
                textEdit_tentaptin.Focus();
                return;
            }
            string _link = textEdit_duongdan.Text + "/" + textEdit_tentaptin.Text + ".bak";
            progressBarControl_back.Text = "0";
            try
            {
                Server dbServer = new Server(new ServerConnection(Commons.GetByKey("serverName"), Commons.GetByKey("userSQl"), ""));
                Backup backup = new Backup() { Action = BackupActionType.Database, Database = Commons.GetByKey("databaseName") };
                backup.Devices.AddDevice(_link, DeviceType.File);
                backup.Initialize = true;
                backup.PercentComplete += DbBackup_PercentComplete;
                backup.Complete += DbBackup_Complete;
                backup.SqlBackupAsync(dbServer);
            }
            catch (Exception ex)
            {

            }
        }
        // Hiển thị thanh progressbar
        private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl_back.Invoke((MethodInvoker)delegate
            {
                progressBarControl_back.EditValue = e.Percent;
                progressBarControl_back.Update();
            });
            progressBarControl_back.Invoke((MethodInvoker)delegate
            {
                progressBarControl_back.Text = $"{e.Percent}%";
            });
        }
        // Thông báo việc backup dữ liệu 
        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {

            if (e.Error != null)
            {
                MessageBox.Show("Sao lưu dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Sao lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void textEdit_duongdan_Click(object sender, EventArgs e)
        {
            // This line calls the folder diag
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
            // This is what will execute if the user selects a folder and hits OK (File if you change to FileBrowserDialog)
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folder = dlg.SelectedPath;
                textEdit_duongdan.Text = folder;
            }
            else
            {
                // This prevents a crash when you close out of the window with nothing
            }
        }
    }
}
