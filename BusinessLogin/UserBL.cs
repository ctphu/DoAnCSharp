using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;

namespace BusinessLogic
{
    public class UserBL
    {
        public ResultMessageBO SaveUserregisrationBL(UserBO objUserBL) // passing Bussiness object Here
        {
            try
            {
                UserDA objUserda = new UserDA(); // Creating object of Dataccess
                return objUserda.AddUserDetails(objUserBL); // calling Method of DataAccess
            }
            catch
            {
                throw;
            }
        }
        public ResultMessageBO CheckUserLoginBL(UserBO objUserBL)
        {
            try
            {
                UserDA objUserda = new UserDA(); // Creating object of Dataccess
                return objUserda.CheckUserLogin(objUserBL); // calling Method of DataAccess
            }
            catch
            {
                throw;
            }
        }
        public List<UserBO> GetUserList()
        {
            try
            {
                UserDA objUserda = new UserDA(); // Creating object of Dataccess
                return objUserda.GetUserList(); // calling Method of DataAccess
            }
            catch
            {
                throw;
            }
        }
    }
}
