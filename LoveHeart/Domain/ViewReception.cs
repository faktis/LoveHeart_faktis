using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{

    class ViewReception : IView
    {

        public bool LoggedIn { get; set; }
        public string UserName { get; }
        private string message;
        ///private MessageHandler messagehandler;

        public ViewReception(string userName)
        {
            Console.Clear();
            UserName = userName;
            LoggedIn = true;
            message = "";
            //messageHandler comu

        }

        public virtual string Message()
        {
            return message;
        }

        public virtual void Run(Render renderer)
        {
            Draw(renderer);
        }

        public virtual void Draw(Render renderer)
        {
            renderer.WriteAt("Available Actions", 0, 0);
            renderer.WriteAt("Add (C)ustomer ", 0, 2);
            renderer.WriteAt("Add Animal and Add Customer", 0, 3);
            renderer.WriteAt("Add Animal to (E)xisting Customer", 0, 4);
            renderer.WriteAt("(V)iew Customers", 0, 5);
            renderer.WriteAt("Log (O)ut", 0, 6);
        }

        public virtual bool ActionButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.O:
                    LoggedIn = false;
                    message = "ViewLogin";
                    //ViewHandler.CurrentView = ViewHandler.Views.Login;
                    return true;
                case ConsoleKey.C:
                    message = "ViewCustomer";
                    return true;
                case ConsoleKey.Escape:
                    message = "ViewEndView";
                    return true;
            }
            return false;
        }

        public virtual bool InputValue(Render renderer)
        {
            return ActionButtonPressed(Console.ReadKey().Key);
        }


    }
}