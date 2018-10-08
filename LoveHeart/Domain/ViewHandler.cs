using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewHandler
    {
        public enum Views { Login, Reception, EndProgram }
        public static Views CurrentView = Views.Login;
        private IView currView;
        private static bool running = true;

        public ViewHandler()
        {
            currView = new ViewLogin();
        }
        public void ViewChange()
        {
            switch (CurrentView)
            {
                case Views.Login:
                    currView = new ViewLogin();
                    break;
                case Views.EndProgram:
                    Console.Clear();
                    currView = new ViewEndProgram();
                    running = false;
                    break;
            }
            currView.Draw();
        }
        public void Run()
        {
            while(running)
            {
                currView.Draw();
                ViewChange();
            }
        }
    }
}
