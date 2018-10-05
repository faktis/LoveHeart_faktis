using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewHandler
    {
        public enum Views { LOGIN, RECEPTIONVIEW, ENDPROGRAM }
        public static Views CurrentView = Views.LOGIN;
        private IView currView;
        private static bool running = true;

        public ViewHandler()
        {
            currView = new LoginView();
        }
        public void ViewChange()
        {
            switch (CurrentView)
            {
                case Views.LOGIN:
                    currView = new LoginView();
                    break;
                //case Views.RECEPTIONVIEW:
                //    currView = new ReceptionView();
                //    break;
                case Views.ENDPROGRAM:
                    Console.Clear();
                    currView = new EndProgramView();
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
