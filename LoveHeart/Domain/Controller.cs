using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Controller
    {
        private IUser activeUser;
        private Dictionary <string, IUser> users;
        


        public Controller()
        {
            users.Add("EdvinA", new Receptionist("edvin", "passWord"));
            activeUser = null;
        }

        public bool Login(string userName, string passWord)
        {
            if (users.ContainsKey(userName))
            {
                if (users[userName].PassWordPass(passWord))
                {
                    activeUser = users[userName];
                    return true;
                }
            }
            return false;
        }

        
    }
}
