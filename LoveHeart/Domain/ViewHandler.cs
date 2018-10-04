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
            currView.Draw();
        }
        public void Run()
        {
            while(running)
            {
                currView.Draw();
            }
        }
    }
}
