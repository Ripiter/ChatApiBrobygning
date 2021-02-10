using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class ConversationManager
    {
        private static ConversationManager instance = null;
        public List<Conversation> conversations = new List<Conversation>();

        private ConversationManager()
        {

        } 

        public static ConversationManager getInstance()
        {
            if (instance == null)
                instance = new ConversationManager();

            return instance;
        }


        public void AddConversation(string _value)
        {
            if(!ContainsPerson("Steve"))
            {
                // _value is json object, person and message are from converting it
                string personID = "Steve";
                string message = "Hello world";

                Conversation c = new Conversation();
                c.PersonID = personID;
                c.messages.Add(new Message(message));

                conversations.Add(c);
            }
            else
            {
                GetConversation("Steve").messages.Add(new Message("Hello world"));
            }
        }

        private bool ContainsPerson(string _personId)
        {
            for (int i = 0; i < conversations.Count; i++)
            {
                if (conversations[i].PersonID == _personId)
                    return true;
            }

            return false;
            
        }

        private Conversation GetConversation(string _personId)
        {
            for (int i = 0; i < conversations.Count; i++)
            {
                if (conversations[i].PersonID == _personId)
                    return conversations[i];
            }

            return null;
        }
    }
}
