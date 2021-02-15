using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class Message
    {
        public Message(Person person, string _text)
        {
            User = person;
            messageText = _text;
            messageSendTime = DateTime.Now.ToShortDateString();
        }

        private Person user;

        public Person User
        {
            get { return user; }
            set { user = value; }
        }


        private string messageText;

        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; }
        }
        private string messageSendTime;

        public string MessageSendTime
        {
            get { return messageSendTime; }
            set { messageSendTime = value; }
        }


    }
}
