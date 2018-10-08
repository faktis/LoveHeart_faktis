using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    public enum AccessLevel { Receptionist, Veterinary , SystemAdministrator }


    

    interface IUser
    {

        int UserId { get; set; }
        string UserName { get; }
        string PassWord { set; }
        AccessLevel AccessLevel { get; }
        void Init();
        bool PassWordPass(string passWord);
        string ToString();
        
    }
}
