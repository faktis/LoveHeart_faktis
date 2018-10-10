using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    abstract class View : IView
    {
        public abstract bool ActionButtonPressed(ConsoleKey key);
        public abstract void Draw(Render renderer);
        public abstract bool InputValue(Render renderer);
        public abstract string Message();

        public abstract void Run(Render renderer);
        
        
    }
}
