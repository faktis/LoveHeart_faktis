using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class MessageHandler
    {
        public static string Message { get; set; }
        public string Response { get; set; }
        public string Action { get; set; }
        public string []Parameters { get; set; }




        private string oldMessage;
        private string tempString;

        public  MessageHandler()
        {
            Init();
        }

        public void Run()
        {
            if(MessageUpdated())
            {
                ParseMessage();

            }
        }

        private void Init()
        {
            Response = "NoResponse";
            Message = "NoMessage";
            Action = "NoAction";
            Parameters = new string[10];
            for(int i = 0; i < 10; i++)
            {
                Parameters[i] = "NoParameter";
            }
            oldMessage = Message;
            tempString = "";
        }

        public bool MessageUpdated()
        {
            if (Message != oldMessage)
            {
                oldMessage = Message;
                return true;
            }
            return false;
        }

        public void ParseMessage(int charIndex = 0 ,  int parameterIndex = 0)
        {
            if (Message[charIndex] == ' ')
            {
                if (Action == "NoAction")
                {
                    Action = tempString;
                    tempString = "";
                }
                else
                {
                    Parameters[parameterIndex] = tempString;
                    tempString = "";
                    parameterIndex++;
                }
            }
            if (charIndex != Message.Length)
            {

                tempString += Message[charIndex];
                ParseMessage(charIndex++, parameterIndex);
            } 
        }
    }
}
