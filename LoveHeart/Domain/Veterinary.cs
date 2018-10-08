using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Veterinary : User
    {
        public Veterinary(string userName, string passWord) : base(userName, passWord)
        {
            Init();
        }

        public override void Init()
        {
            AccessLevel = AccessLevel.Veterinary;
        }

        public override string ToString()
        {
            return "$Account Type: Veterinary\n" +
                "Name: {UserName}";
        }
    }
}
