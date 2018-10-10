using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewHandler
    {
        public enum Views { Login, Reception, EndProgram, Customer , Main, AddCustomer, AddAnimalAndCustomer, AddAnimalToCustomer }
        //protected enum ViewInternal { Main, AddCustomer, AddAnimalAndCustomer, AddAnimalToCustomer };

        public static Views CurrentView = Views.Login;
        private IView currView;
        private bool running;


        public static string response;

        public static Render renderer;
        public ViewHandler()
        {
            renderer = new Render();
            running = true;

            currView = new ViewLogin();
        }
        public void ViewChange()
        {
            switch (CurrentView)
            {
                case Views.Login:
                    currView = new ViewLogin();
                    break;
                case Views.Customer:
                    //currView = new ViewCustomer();
                    break;
                case Views.Reception:
                    currView = new ViewReception("blabla");
                    break;
                case Views.EndProgram:
                    Console.Clear();
                    currView = new ViewEndProgram();
                    running = false;
                    break;
            }
            //currView.Draw();
        }
       
        
        public void Run(Controller controller)
        {
            while(running)
            {
                
                currView.Run(renderer);
                if(controller.Run(currView.Message()))
                {
                    
                }
                ViewChange();
                //ViewChange();
            }
        }
    }
}
