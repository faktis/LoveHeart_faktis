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
        //void InputFields(Enum @enum); 
        /*IView CurrentInternalViewCurre
        {
            get; set;
        }*/
        
    }
    interface IInput
    {
        bool ValidInput();
    }
}
