using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessObject;

namespace ExchangeManagement
{
    /*
    Form nay co mot so yeu cau nhu sau. Neu user co quyen hien thi co the dieu chinh
    them, xoa sua cac user khac tru user cua minh. 
    */
    public partial class frmUserList : Form
    {
        private static frmUserList _instance;
        public static frmUserList GetInstance()
        {
            if (_instance == null||_instance.IsDisposed) _instance = new frmUserList();
            return _instance;
        }

        List<UserBO> listUser;
        BindingSource bsUser;
        UserBO userCurrent;

        public frmUserList()
        {
            InitializeComponent();
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            UserBL userBL = new UserBL();
            listUser = userBL.GetUserList();
            bsUser = new BindingSource { DataSource = listUser };
            dgvUserList.DataSource = bsUser;
        }

        private void SetButtonEnable(bool pbIsEnable)
        {
            btAddUser.Enabled = pbIsEnable;
            btDeleteUser.Enabled = pbIsEnable;
            btUpdate.Enabled = pbIsEnable;
        }

        private void dgvUserList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvUserList.CurrentRow != null)
            {
                userCurrent = (UserBO)dgvUserList.CurrentRow.DataBoundItem;
                tbUsername.Text = userCurrent.Username;
                tbPassword.Text = userCurrent.Password;
                cbIsDisable.Checked = userCurrent.IsDisable;
                if (userCurrent.UserID == ((frmMain)this.MdiParent).UserID)
                {
                    SetButtonEnable(false);
                }
                else
                {
                    SetButtonEnable(true);
                }
            }
        }
    }
}
