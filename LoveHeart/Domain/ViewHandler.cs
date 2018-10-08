using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewHandler
    {
        public enum Views { Login, Reception, EndProgram, Customer }
        public static Views CurrentView = Views.Login;
        private IView currView;
        private static bool running;
        private static string message;
        private string oldMessage;

        public ViewHandler()
        {
            running = true;
            message = "NoMessage";
            oldMessage = message;
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
                    currView = new ViewCustomer();
                    break;
                case Views.EndProgram:
                    Console.Clear();
                    currView = new ViewEndProgram();
                    running = false;
                    break;
            }
            currView.Draw();
        }
        public bool MessageUpdated()
        {
            if(message != oldMessage)
            {
                oldMessage = message;
                return true;
            }
            return false;
        }
        public void Run()
        {
            while(running)
            {
                currView.Draw();
                if(MessageUpdated())
                {

                }
                ViewChange();
            }
        }
        public bool MessageHandled()
        {

            return false;
        }
    }
}
