using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{

    interface IView
    {
        void Draw();
        bool ActionButtonPressed(ConsoleKey key);
        IView CurrentInternalView
        {
            get; set;
        }
        
    }
    interface IInput
    {
        bool ValidInput();
    }
}
