﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewLogin : IView
    {
        private Draw draw;
        private enum InputFields {USERNAME, PASSWORD, OTHER};
        private InputFields currInputField;
        private string userName;
        private string passWord;
        public IView CurrentViewInternal { get; set; }

        public ViewLogin()
        {
            Console.Clear();
            draw = new Draw();
            currInputField = InputFields.USERNAME;
            userName = "";
            passWord = "";
        }

        public void Run()
        {
            while (InputValue())
            {
                Draw();
            }
        }

        public void Draw()
        {
            
            draw.WriteAt("Please log in",0,0);
            draw.WriteAt("Username: ", 0, 2);
            draw.WriteAt("Password: ", 0, 3);

            

            if (userName!=""&&passWord!="")
            {
                draw.WriteAt("Is this correct? (Y)es (N)o", 0, 5);
                draw.WriteAt("", 0, 6);
            }

            if (ActionButtonPressed(Console.ReadKey().Key))
            {
                
            }
        }

        public bool ActionButtonPressed(ConsoleKey key)
        {
            //bool viewChangeInit = false;
            switch(key)
            {
                case ConsoleKey.Y:
                    ViewHandler.CurrentView = ViewHandler.Views.Reception;
                    return true;
                   
                case ConsoleKey.N:
                    Console.Clear();
                    userName = "";
                    passWord = "";
                    draw.WriteAt("\t\t", 10, 2);
                    draw.WriteAt("\t\t", 10, 3);
                    currInputField = InputFields.USERNAME;
                    break;
                case ConsoleKey.Escape:
                    ViewHandler.CurrentView = ViewHandler.Views.EndProgram;
                    return true;
                    
            }
            
            return false;
        }

        public virtual bool InputValue()
        {
            
            if (currInputField == InputFields.USERNAME)
            {
                draw.WriteAt("", 10, 2);
                userName = Console.ReadLine();
                currInputField = InputFields.PASSWORD;
                draw.WriteAt("", 10, 3);


            }
            else if(currInputField == InputFields.PASSWORD)
            {

                draw.WriteAt("", 10, 3);
                passWord = Console.ReadLine();
                currInputField = InputFields.OTHER;
                return true;
            }
            return ActionButtonPressed(Console.ReadKey().Key);
        }
    }
}
