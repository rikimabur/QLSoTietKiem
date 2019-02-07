using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSoTK.Helpers
{
    public static class AddTabs
    {
        public static void AddTapControl(XtraTabControl xtraTabParent, string xtraItemName, UserControl userControl)
        {
            XtraTabPage _xtraTabPage = new XtraTabPage();
            _xtraTabPage.Name = "Test";
            _xtraTabPage.Text = xtraItemName;
            _xtraTabPage.Dock = DockStyle.Fill;
            _xtraTabPage.Controls.Add(userControl);
            xtraTabParent.TabPages.Add(_xtraTabPage);
        }

    }
}
