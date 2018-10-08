using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    
    class ReceptionView : IView
    {

        private Draw draw;
        protected enum InternalView { Main, AddCustomer, AddAnimalAndCustomer, AddAnimalToCustomer };
        protected InternalView CurrInternalView { private get; set;  }
        public virtual IView CurrentInternalView { get; set; }
        public enum InputFields { get };

        private string userName;
        public  ReceptionView(string userName)
        {
            CurrInternalView = InternalView.Main;
            CurrentInternalView = null;
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


            while (CurrInternalView == InternalView.Main)
            {
                InputValue();
            }


            if (ActionButtonPressed(Console.ReadKey().Key))
            {

            }
        }

        public bool ActionButtonPressed(ConsoleKey key)
        {
            bool viewChangeInit = false;
            switch (key)
            {
                case ConsoleKey.O:
                    ViewHandler.CurrentView = ViewHandler.Views.Login;
                    viewChangeInit = true;
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    userName = "";
                    //ViewHandler.CurrentView = AddCustomerView:
                    draw.WriteAt("\t\t", 10, 2);
                    draw.WriteAt("\t\t", 10, 3);
                    //currInputField = InputFields.USERNAME;
                    break;
                case ConsoleKey.Escape:
                    ViewHandler.CurrentView = ViewHandler.Views.EndProgram;
                    viewChangeInit = true;
                    break;
            }

            return viewChangeInit;
        }



        public virtual bool InputValue()
        {
            if (ActionButtonPressed(Console.ReadKey().Key))
            {
                return true;
            }
            return false;  
        }


        internal class AddCustomerView : ReceptionView//, IInput
        {
            private string customerName;
            private string customerSocialSequrityNumber;
            InputFields = new enum {Hej, Nej }
            public AddCustomerView(string userName) : base(userName)
            {
                Init();
            }
            public void Init()
            {
                CurrInternalView = InternalView.AddCustomer;
            }
            public override void Draw()
            {

                Console.Clear();
                draw.WriteAt("Add Customer", 0, 0);
                draw.WriteAt("Name: ", 0, 2);
                draw.WriteAt("Social Sequrity Number: ", 0, 3);
                draw.WriteAt("(A)dd Customer or (R)eset values", 0, 6);


                while ( CurrInternalView == InternalView.AddCustomer)
                {

                    customerName = "";
                    customerSocialSequrityNumber =  "";
                    draw.WriteAt("\t\t", 10, 2);
                    draw.WriteAt("\t\t", 10, 3);
                }
            }
            public override bool InputValue()
            {
                return true;
            }
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
            }


}

    }

    

}
