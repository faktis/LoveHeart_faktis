using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{

    class ViewReception : IView
    {

        private Draw draw;

        protected enum ViewInternal { Main, AddCustomer, AddAnimalAndCustomer, AddAnimalToCustomer };
        protected virtual ViewInternal CurrentInternalView { get; set; }
        protected IView CurrentView { private get; set; }





        private string userName;
        public ViewReception(string userName)
        {
            CurrentInternalView = ViewInternal.Main;
            CurrentView = this;
            Console.Clear();
            draw = new Draw();
            this.userName = userName;
        }
        public virtual void Draw()
        {

            draw.WriteAt("Available Actions", 0, 0);
            draw.WriteAt("Add (C)ustomer ", 0, 2);
            draw.WriteAt("Add Animal and Add Customer", 0, 3);
            draw.WriteAt("Add Animal to (E)xisting Customer", 0, 4);
            draw.WriteAt("(V)iew Customers", 0, 5);
            draw.WriteAt("Log (O)ut", 0, 6);


            while (CurrentInternalView == ViewInternal.Main)
            {
                InputValue();
            }


            if (ActionButtonPressed(Console.ReadKey().Key))
            {

            }
        }

        public virtual bool ActionButtonPressed(ConsoleKey key)
        {
            //bool viewChangeInit = false;
            switch (key)
            {
                case ConsoleKey.O:
                    ViewHandler.CurrentView = ViewHandler.Views.Login;
                    return true;
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    userName = "";
                    ViewHandler.CurrentView = ViewAddCustomer:
                    draw.WriteAt("\t\t", 10, 2);
                    draw.WriteAt("\t\t", 10, 3);
                    //currInputField = InputFields.USERNAME;
                    break;
                case ConsoleKey.Escape:
                    ViewHandler.CurrentView = ViewHandler.Views.EndProgram;
                    return true;
                    //break;
            }

            return false;//viewChangeInit;
        }



        public virtual bool InputValue()
        {
            if (ActionButtonPressed(Console.ReadKey().Key))
            {
                return true;
            }
            return false;
        }


        internal class ViewAddCustomer : ViewReception, IView
        {         
            private string name;
            private string socialSequrityNumber;
            private enum InputFields { Name, SocialSequrityNumber, Other }
            private InputFields currentInputField;
            public ViewAddCustomer(string userName) : base(userName)
            {
                Init();
            }
            public void Init()
            {
                CurrentInternalView = ViewInternal.AddCustomer;
                currentInputField = InputFields.Name;
            }
            public override void Draw()
            {

                Console.Clear();
                draw.WriteAt("Add Customer", 0, 0);
                draw.WriteAt("Name: ", 0, 2);
                draw.WriteAt("Social Sequrity Number: ", 0, 3);
                draw.WriteAt("(A)dd Customer or (R)eset values", 0, 6);


                while (CurrentInternalView == ViewInternal.AddCustomer)
                {
                    InputValue();
                }
            }
            public override bool InputValue()
            {
                if (currentInputField == InputFields.Name)
                {
                    draw.WriteAt("", 10, 2);
                    name = Console.ReadLine();
                    currentInputField = InputFields.SocialSequrityNumber;
                    //draw.WriteAt("", 10, 3);
                }
                else if (currentInputField == InputFields.SocialSequrityNumber)
                {
                    draw.WriteAt("", 10, 3);
                    socialSequrityNumber = Console.ReadLine();
                    currentInputField = InputFields.Other;
                    //draw.WriteAt("", 10, 4);
                    return true;
                }
                else
                {
                    draw.WriteAt("Is this information correct? (Y)es or (N)o", 10, 5);
                    if (ActionButtonPressed(Console.ReadKey().Key))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override bool ActionButtonPressed(ConsoleKey key)
            {
                //bool viewChangeInit = false;
                switch (key)
                {
                    case ConsoleKey.O:
                        ViewHandler.CurrentView = ViewHandler.Views.Login;
                        return true;
                        //break;
                    case ConsoleKey.C:
                        Console.Clear();
                        userName = "";
                        draw.WriteAt("\t\t", 10, 2);
                        draw.WriteAt("\t\t", 10, 3);
                        break;
                    case ConsoleKey.Escape:
                        ViewHandler.CurrentView = ViewHandler.Views.EndProgram;
                        return true;
                        //break;
                }

                return false;
            }
        }
    }
}
