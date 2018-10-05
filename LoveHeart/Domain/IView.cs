using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    interface IView
    {
        void Draw();
        //List <String> InputValues();
        bool ActionButtonPressed(ConsoleKey key);
    }
}
