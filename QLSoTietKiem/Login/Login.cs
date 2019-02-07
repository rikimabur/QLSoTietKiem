using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSoTietKiem.Login
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void Login()
        {
            if (string.IsNullOrEmpty(txt_Password.Text) || string.IsNullOrEmpty(txt_UserName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Đăng Nhập và Mật Khẩu!","Thông báo");
            }
            else
            {
                try
                {
                    

                }
                catch
                {
                    MessageBox.Show("Tên Đăng Nhập hoặc Mật Khẩu không đúng. Vui lòng thử lại!", "Thông báo");
                }
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }

        private void txt_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }
    }
}
