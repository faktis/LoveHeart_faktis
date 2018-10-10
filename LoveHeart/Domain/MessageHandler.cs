using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class MessageHandler
    {
        public string Message { get; set; }
        public string Response { get; set; }
        public string Action { get; set; }
        public string []Parameters { get; set; }
        private string oldMessage;
        private string interpreter;
        


        public  MessageHandler()
        {
            Init();
        }

        public bool Run()
        {
            if(MessageUpdated())
            {
                ParseMessage();
                return true;
            }
            return false;
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
            interpreter = "";
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
            if (charIndex+1 < Message.Length)
            {
                if(Message[charIndex] != ' ')
                    interpreter += Message[charIndex];
                charIndex++;
                ParseMessage(charIndex, parameterIndex);
            }
        }
    }
}
