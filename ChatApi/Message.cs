using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class Message
    {
        public Message(string _text)
        {
            messageText = _text;
            messageSendTime = DateTime.Now;
        }
        private string messageText;

        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; }
        }
        private DateTime messageSendTime;

        public DateTime MessageSendTime
        {
            get { return messageSendTime; }
            set { messageSendTime = value; }
        }


    }
}
