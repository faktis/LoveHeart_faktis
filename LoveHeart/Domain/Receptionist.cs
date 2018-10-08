﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Receptionist : User
    {

        public Receptionist(string userName, string passWord) : base( userName, passWord )
        {
            Init();
        }
        public override void Init()
        {
            AccessLevel = AccessLevel.Receptionist;
        }

        public override string ToString()
        {
            return "$Account Type: Receptionist\n" +
                "Name: {UserName}";
        }
       
    }
}