using System;
using LoveHeart.Domain;

namespace LoveHeart
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewHandler viewHandler = new ViewHandler();
            
            Controller controller = new Controller();
            viewHandler.Run(controller);
            //controller.Run();
        }
    }
}
