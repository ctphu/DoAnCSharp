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
    }
}
