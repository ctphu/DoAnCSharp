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
    public partial class frmLogin : Form
    {
        public int UserID;
        int iLoginFailed;
        const int cNumberLoginFailed=3;

        public frmLogin()
        {
            InitializeComponent();
            iLoginFailed = 1;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            UserID = 0;
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            ResultMessageBO result;
            UserBO userBO = new UserBO();
            UserBL userBL = new UserBL();
            userBO.Username = tbUsername.Text;
            userBO.Password = tbPassword.Text;
            result = userBL.CheckUserLoginBL(userBO);
            if (result.ResultCode > 0)
            {
                UserID = result.ResultCode;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ResultMessage);
                if (iLoginFailed < cNumberLoginFailed)
                {
                    iLoginFailed += 1;
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
