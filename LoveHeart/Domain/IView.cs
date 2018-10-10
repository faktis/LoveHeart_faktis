using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{

    interface IView
    {
        void Draw( Render renderer );
        void Run( Render renderer );
        bool ActionButtonPressed(ConsoleKey key);
        bool InputValue( Render renderer);
        string Message();
    }
    interface IInput
    {
        bool ValidInput();
    }
}
