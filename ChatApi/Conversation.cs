using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class Conversation
    {
        public List<Message> messages = new List<Message>();

        private Person admin;

        public Person Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        private Person person;

        public Person User
        {
            get { return person; }
            set { person = value; }
        }

    }
}
