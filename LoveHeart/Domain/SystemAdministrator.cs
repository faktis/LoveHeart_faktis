using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class SystemAdministrator : User
    {
        public SystemAdministrator(string userName, string passWord) : base( userName, passWord )
        {

        }

        public override void Init()
        {

            AccessLevel = AccessLevel.SystemAdministrator;

        }



        public override string ToString()
        {
            return "$Account Type: System Administrator\n" +
                "Name: {UserName}";
        }
    }
}
