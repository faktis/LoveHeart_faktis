using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewHandler
    {
        //public enum Views { Login, Reception, EndProgram, Customer , Main, AddCustomer, AddAnimalAndCustomer, AddAnimalToCustomer }
        //protected enum ViewInternal { Main, AddCustomer, AddAnimalAndCustomer, AddAnimalToCustomer };

        //public static Views CurrentView = Views.Login;
        private IView currView;
        private bool running;

        private string serverMessage;
        

        public static Render renderer;
        public ViewHandler()
        {
            renderer = new Render();
            running = true;
            serverMessage = "";
            currView = new ViewLogin();
        }
        public void ViewChange()
        {
            switch (serverMessage)
            {
                case "ViewLogin":
                    currView = new ViewLogin();
                    break;
                case "ViewCustomer":
                    //currView = new ViewCustomer();
                    break;
                case "ViewReception":
                    currView = new ViewReception("blabla");
                    break;
                case "ViewEndProgram":
                    Console.Clear();
                    currView = new ViewEndProgram();
                    running = false;
                    break;
                default:
                    Console.WriteLine(serverMessage);
                    break;
            }
            //currView.Draw();
        }
       
        
        public void Run(Controller controller)
        {
            while(running)
            {
                
                currView.Run(renderer);
                if (currView.Message() != "")
                {
                    serverMessage = controller.Run(new MessageHandler(currView.Message()));
                    ViewChange();
                }
            }
        }
    }
}
