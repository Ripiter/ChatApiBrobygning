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

        // 0 for user and 1 for admin
        private short[] lastGet = new short[2];
                
        public short[] LastGet
        {
            get { return lastGet; }
            set { lastGet = value; }
        }


        private Person person;

        public Person User
        {
            get { return person; }
            set { person = value; }
        }

        public short GetShortFromID(string personID)
        {
            if (User.PersonID == personID)
                return LastGet[0];
            else 
                return LastGet[1];
        }

        public void SetShortFromID(string personID, short value)
        {
            if (User.PersonID == personID)
                LastGet[0] = value;
            else
                LastGet[1] = value;
        }

    }
}
