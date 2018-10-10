using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewEndProgram : IView
    {
        public bool ActionButtonPressed(ConsoleKey key)
        {
            throw new NotImplementedException();
        }

        public void Draw(Render renderer)
        { 
            Console.WriteLine("Thank you, come again\n");
        }

        
        public bool InputValue(Render renderer)
        {
            throw new NotImplementedException();
        }

        public string Message()
        {
            return "Terminate";
        }

        public void Run(Render renderer)
        {
            Draw(renderer);
        }
    }
}
