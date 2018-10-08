using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{

    interface IView
    {
        void Draw();
        bool ActionButtonPressed(ConsoleKey key);
        bool InputValue();
        string Message();
        //void Message(string message);
    }
    interface IInput
    {
        bool ValidInput();
    }
}
