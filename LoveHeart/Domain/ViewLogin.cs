using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewLogin : IView
    {
        //private Draw draw;
        private enum InputFields {USERNAME, PASSWORD, OTHER};
        private InputFields currInputField;
        private string userName;
        private string passWord;
        public string Response { private get; set; }
        private string message;
        public IView CurrentViewInternal { get; set; }
        

        public ViewLogin(string messageFromController = "")
        {
            Console.Clear();
            currInputField = InputFields.USERNAME;
            userName = "";
            passWord = "";
            Response = messageFromController;
            message = "";
        }

        public void Run(Render renderer)
        {
            while (!InputValue(renderer))
            {
                Draw(renderer);
            }

        }

        public void Draw(Render renderer)
        {

            renderer.WriteAt("Please log in",0,0);
            renderer.WriteAt("Username: ", 0, 2);
            renderer.WriteAt("Password: ", 0, 3);

            

            if (userName!=""&&passWord!="")
            {
                renderer.WriteAt("Is this correct? (Y)es (N)o", 0, 5);
                renderer.WriteAt("", 0, 6);
            }
            

            //ActionButtonPressed(Console.ReadKey().Key);
   
        }

        public bool ActionButtonPressed(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.Y:
                    message = "Login " + userName + " " + passWord +" ";
                    return true;

                    
                case ConsoleKey.N:
                    Console.Clear();
                    userName = "";
                    passWord = "";
                    
                    currInputField = InputFields.USERNAME;
                    break;
                case ConsoleKey.Escape:
                    ViewHandler.CurrentView = ViewHandler.Views.EndProgram;
                    return true;       
            }
            return false;
        }

        public virtual bool InputValue(Render renderer = null)
        {
            
            if (currInputField == InputFields.USERNAME)
            {
                renderer.WriteAt("", 10, 2);
                userName = Console.ReadLine();
                currInputField = InputFields.PASSWORD;
                renderer.WriteAt("", 10, 3);


            }
            else if(currInputField == InputFields.PASSWORD)
            {

                renderer.WriteAt("", 10, 3);
                passWord = Console.ReadLine();
                currInputField = InputFields.OTHER;
                //return true;
            }
            return ActionButtonPressed(Console.ReadKey().Key);
        }



        public string Message()
        {
            return message;
        }
    }
}
