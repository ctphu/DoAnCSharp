using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using BusinessLogic;

namespace ExchangeManagement
{
    public partial class frmMain : Form
    {
        public int UserID;
        private List<UserPermissionBO> listPermission;
        UserBL userBL;
        public frmMain()
        {
            InitializeComponent();
            userBL = new UserBL();
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserList fUserList = frmUserList.GetInstance();
            if (!fUserList.Visible)
            {
                fUserList.MdiParent = this;
                fUserList.Show();
                fUserList.WindowState = FormWindowState.Maximized;
            }
            else
            {
                fUserList.BringToFront();
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.Text = UserID.ToString();
            listPermission = userBL.GetPermission(UserID, "MAIN");
            CheckPermission();
        }

        private void CheckPermission()
        {
            //UserPermissionBO userPermission = new UserPermissionBO();
            //userPermission.UserID = UserID;
            //userPermission.Permission = "USERLIST";
            UserPermissionBO result = listPermission.Find(item => item.Permission == "USERLIST");
            if (result != null)
            {
                userListToolStripMenuItem.Enabled = true;
            }
            else
            {
                userListToolStripMenuItem.Enabled = false;
            }

            result = listPermission.Find(item => item.Permission == "USERPERMISSION");
            if (result != null)
            {
                permissionListToolStripMenuItem.Enabled = true;
            }
            else
            {
                permissionListToolStripMenuItem.Enabled = false;
            }
        }

        private void permissionListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
