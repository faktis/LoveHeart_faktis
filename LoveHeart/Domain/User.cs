﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{

    abstract class User : IUser
    {
        public virtual string UserName { get; set; }
        public virtual string PassWord { private get; set; }
        public virtual AccessLevel AccessLevel { get; protected set; }



        public virtual int UserId { get; set; }
        //protected User(string userName, string passWord)

        public bool PassWordPass(string passWord)
        {
            if (passWord == PassWord)
            {
                return true;
            }
            return false;
        }
        public abstract void Init();
        public abstract override string ToString();
        public User(string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
            UserId++;
        }

       

        
        
        
            

    }
}