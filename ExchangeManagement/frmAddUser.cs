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
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            // TODO: Implement BtOKClick
            ResultMessageBO result;
            UserBO userBO = new UserBO();
            UserBL userBL = new UserBL();
            userBO.Username = tbUsername.Text;
            userBO.Password = tbPassword.Text;
            result = userBL.SaveUserregisrationBL(userBO);
            MessageBox.Show(result.ResultMessage);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
