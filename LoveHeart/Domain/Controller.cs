using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Controller
    {
        private IUser activeUser;
        private Dictionary<string, IUser> users;

        public string Response { get; private set; }

        private MessageHandler messageHandler;

        public Controller()
        {
            users = new Dictionary<string, IUser>();

            //////test
            ///
            users.Add("00", new Receptionist("00", "00"));



            ///////

        

            messageHandler = new MessageHandler();
            activeUser = null;
            Response = "";
        }

        public bool Run(string message)
        {
            //messageHandler.Message = message;
            messageHandler.Message = message;
            if (messageHandler.Run())
            {
                
                if (Proccess())
                {
                    //messageHandler
                    return true;
                    //MessageHandler.Message = "blabal";
                }
            }
            return false; 
        }

        private bool Proccess()
        {
            switch(messageHandler.Action)
            {
                case "Login":
                    return Login(messageHandler.Parameters[0], messageHandler.Parameters[1]);
                case "LogOut":
                    return LogOut();    
            }
            return false;
        }

        private bool Login(string userName, string passWord)
        {
            if (users.ContainsKey(userName))
            {
                if (users[userName].PassWordPass(passWord))
                {
                    activeUser = users[userName];
                    messageHandler.Response = "Successfull Login";
                    ViewHandler.CurrentView = ViewHandler.Views.Reception;
                    return true;
                }
            }
            messageHandler.Response = "Failed login";
            return false;
        }

        public bool LogOut()
        {
            activeUser = null;
            messageHandler.Response = "User logged out";
            return true;
        }

        private bool UserNameAvailable(string userName)
        {
            if (!users.ContainsKey(userName))
            {
                messageHandler.Response = "Already exist user with that name";
                return true;
            }
            return false;
        }

        public bool AddUser(IUser user)
        {
            if (UserNameAvailable(user.UserName))
            {
                users.Add(user.UserName, user);
                messageHandler.Response = "Created User Account";
                return true;
            }
            return false;
        }

        public bool AddCustomer(Customer customer)
        {
            if (UserNameAvailable(customer.UserName))
            {
                users.Add(customer.UserName, customer);
                messageHandler.Response = "Created Customer Account";
                return true;
            }
            return false;
        }

        public bool AddReceptionist(Receptionist receptionist)
        {
            if (UserNameAvailable(receptionist.UserName))
            {
                users.Add(receptionist.UserName, receptionist);
                messageHandler.Response = "Created Receptionist Account";
                return true;
            }
            return false;
        }

        public bool AddVeterinary(Veterinary veterinary)
        {
            if (UserNameAvailable(veterinary.UserName))
            {
                users.Add(veterinary.UserName, veterinary);
                messageHandler.Response = "Created Veterinary Account";
                return true;
            }
            return false;
        }

        public bool AddSystemAdministrator(SystemAdministrator systemAdministrator)
        {
            if (UserNameAvailable(systemAdministrator.UserName))
            {
                users.Add(systemAdministrator.UserName, systemAdministrator);
                messageHandler.Response = "Created System Administrator Account";
                return true;
            }
            return false;
        }




    }



}
