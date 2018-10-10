using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class MessageHandler
    {
        //public string Message { get; set; }
        public string Response { get; set; }
        public string Action { get; set; }
        public string []Parameters { get; set; }
        private string oldMessage;
        private string interpreter;
        


        public  MessageHandler()
        {
            Init();
        }
        public MessageHandler(string message)
        {
            Init();
            ParseMessage(message);
        }
        /*
        public bool Run()
        {
            if(MessageUpdated())
            {
                ParseMessage();
                //return true;
            }
            return true;
        }
        */

        private void Init()
        {
            Response = "NoResponse";
            Action = "NoAction";
            Parameters = new string[10];
            for(int i = 0; i < 10; i++)
            {
                Parameters[i] = "NoParameter";
            }
            oldMessage = "";
            interpreter = "";
        }
        /*
        public bool MessageUpdated()
        {
            if (Message != oldMessage)
            {
                oldMessage = Message;
                return true;
            }
            return false;
        }
        */
        

        public void ParseMessage(string message, int charIndex = 0 ,  int parameterIndex = 0)
        {

            if (message[charIndex] == ' ')
            {
                if (Action == "NoAction")
                {
                    Action = interpreter;
                    interpreter = "";
                }
                else 
                {
                    if (interpreter != " ")
                    {
                        Parameters[parameterIndex] = interpreter;
                        interpreter = "";
                        parameterIndex++;
                    }
                }
            }
            if (charIndex+1 < message.Length)
            {
                if (message[charIndex] != ' ')
                {
                    interpreter += message[charIndex];
                }
                charIndex++;
                ParseMessage(message ,charIndex, parameterIndex);
            }
            //return this;
        }
    }
}
