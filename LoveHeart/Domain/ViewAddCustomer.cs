using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class ViewAddCustomer : ViewReception, IView
    {
        private string name;
        private string socialSequrityNumber;
        private enum InputFields { Name, SocialSequrityNumber, Other }
        private InputFields currentInputField;

        private string message;
        

        public ViewAddCustomer(string userName) : base(userName)
        {
            Init();
        }

        public void Init()
        {
            currentInputField = InputFields.Name;
        }

        public override string Message()
        {
            return message;
        }

        public override void Run(Render renderer)
        {
            while ( !InputValue( renderer ) )
            {
                Draw( renderer );
            }

            //ViewHandler.MessageHandler.Message = Message();
        }

        public override void Draw(Render renderer)
        {
            Console.Clear();
            renderer.WriteAt("Add Customer", 0, 0);
            renderer.WriteAt("Name: ", 0, 2);
            renderer.WriteAt("Social Sequrity Number: ", 0, 3);
            //
        }

        public override bool InputValue(Render renderer)
        {
            if (currentInputField == InputFields.Name)
            {
               renderer.WriteAt("", 10, 2);
                name = Console.ReadLine();
                currentInputField = InputFields.SocialSequrityNumber;

            }
            else if (currentInputField == InputFields.SocialSequrityNumber)
            {
                renderer.WriteAt("", 10, 3);
                socialSequrityNumber = Console.ReadLine();
                currentInputField = InputFields.Other;
            }
            else
            {
                renderer.WriteAt("(A)dd Customer or (R)eset values", 0, 6);
                
                return ActionButtonPressed(Console.ReadKey().Key);

            }
            return false;
        }

        public override bool ActionButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    message = "$MakeCustomer { user } { socialSequrityNumber } ";
                    return true;
                case ConsoleKey.R:
                    Console.Clear();
                    name = "";
                    socialSequrityNumber = "";
                    currentInputField = InputFields.Name;
                    return false;
                case ConsoleKey.Escape:
                    message = "ViewEndProgram";
                    return true;

            }

            return false;
        }
    }
}


