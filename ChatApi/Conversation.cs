using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class Conversation
    {
        public List<Message> messages = new List<Message>();

        private string adminID;

        public string AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        private string personID;

        public string PersonID
        {
            get { return personID; }
            set { personID = value; }
        }

    }
}
