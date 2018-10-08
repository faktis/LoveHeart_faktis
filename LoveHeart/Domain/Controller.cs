using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Controller
    {
        private IUser activeUser;
        private Dictionary<string, IUser> users;



        public Controller()
        {
            //users.Add("EdvinA", new Receptionist("edvin", "passWord"));
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

        public void Logout()
        {
            activeUser = null;
        }

        private bool UserNameAvailable(string userName)
        {
            if (!users.ContainsKey(userName))
            {
                return true;
            }
            return false;
        }

        public bool AddUser(IUser user)
        {
            if (UserNameAvailable(user.UserName))
            {
                users.Add(user.UserName, user);
                return true;
            }
            return false;
        }

        public bool AddCustomer(Customer customer)
        {
            if (UserNameAvailable(customer.UserName))
            {
                users.Add(customer.UserName, customer);
                return true;
            }
            return false;
        }

        public bool AddReceptionist(Receptionist receptionist)
        {
            if (UserNameAvailable(receptionist.UserName))
            {
                users.Add(receptionist.UserName, receptionist);
                return true;
            }
            return false;
        }

        public bool AddVeterinary(Veterinary veterinary)
        {
            if (UserNameAvailable(veterinary.UserName))
            {
                users.Add(veterinary.UserName, veterinary);
                return true;
            }
            return false;
        }
        

    }

    
        
}
