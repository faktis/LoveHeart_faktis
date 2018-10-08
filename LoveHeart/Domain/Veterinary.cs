using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Veterinary : User
    {
        public override void Init(string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
            AccessLevel = AccessLevel.Veterinary;
            UserId++;
        }

        public override string ToString()
        {
            return "$Account Type: Veterinary\n" +
                "Name: {UserName}";
        }
    }
}
