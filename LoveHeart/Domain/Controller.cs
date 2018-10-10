using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Controller
    {
        private IUser activeUser;
        private Dictionary<string, IUser> users;
        private string oldMessage;
        private string response;
        public string ServerResponse
        {
            get { return response; }
            private set { response = value; }
        }


        //public string Response { get; private set; }


        

        //private MessageHandler messageHandler;

        public Controller()
        {
            users = new Dictionary<string, IUser>();

            //////test
            ///
            users.Add("00", new Receptionist("00", "00"));




            ///////

        

            //messageHandler = new MessageHandler();
            activeUser = null;
            oldMessage = "NoMessage";
            response = "NoResponse";
        }

        public string Run(string message)
        {
            MessageHandler messageHandler = new MessageHandler(message);
            if (message != oldMessage)
            {
               
                oldMessage = message;
                Proccess(messageHandler);
            }
            
               
            
            


            return response;
            
        }

        private bool Proccess(MessageHandler message)
        {
            switch(message.Action)
            {
                case "TryLogin":
                    return Login(message.Parameters[0], message.Parameters[1]);
                case "ViewLogin":
                    return ViewLogin();
                case "ViewEndView":
                    return LogOut();
                case "AddCustomer":
                    return AddCustomer();
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
                    response = "ViewReception";
                    return true;
                }
                response = "Wrong password";
                return false;
            }
            response = "Could not find any users with that name";
            return false;
        }

        public bool LogOut()
        {
            activeUser = null;
            response = "ViewEndProgram";
            return true;
        }

        private bool ViewLogin()
        {
            response =  "ViewLogin";
            return true;
        }

        private bool UserNameAvailable(string userName)
        {
            if (!users.ContainsKey(userName))
            {
                response = "Already exist user with that name";
                return true;
            }
            return false;
        }

        public bool AddUser(IUser user)
        {
            if (UserNameAvailable(user.UserName))
            {
                users.Add(user.UserName, user);
                response = "Created User Account";
                return true;
            }
            return false;
        }

        public bool AddCustomer(Customer customer = null)//)
        {

                response = "AddCustomer";
                return true;

        }

        public bool AddReceptionist(Receptionist receptionist)
        {
            if (UserNameAvailable(receptionist.UserName))
            {
                users.Add(receptionist.UserName, receptionist);
                response = "Created Receptionist Account";
                return true;
            }
            return false;
        }

        public bool AddVeterinary(Veterinary veterinary)
        {
            if (UserNameAvailable(veterinary.UserName))
            {
                users.Add(veterinary.UserName, veterinary);
                response = "Created Veterinary Account";
                return true;
            }
            return false;
        }

        public bool AddSystemAdministrator(SystemAdministrator systemAdministrator)
        {
            if (UserNameAvailable(systemAdministrator.UserName))
            {
                users.Add(systemAdministrator.UserName, systemAdministrator);
                response = "Created System Administrator Account";
                return true;
            }
            return false;
        }




    }



}
