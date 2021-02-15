using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class ConversationManager
    {
        private static ConversationManager instance = null;

        private List<Conversation> conversations = new List<Conversation>();

        public List<Conversation> Conversations
        {
            get { return conversations; }
            set { conversations = value; }
        }

        public List<string> adminUUID = new List<string>();

        public List<string> AdminUUID
        {
            get { return adminUUID; }
            set { adminUUID = value; }
        }


        private ConversationManager()
        {

        } 

        public static ConversationManager getInstance()
        {
            if (instance == null)
                instance = new ConversationManager();

            return instance;
        }


        public void AddConversation(JObject _body, Person _person, params string[] headers)
        {
            JObject json = _body;

            string message = (string)json["Username"];

            if (!ContainsPerson(_person.PersonID))
            {
                // _value is json object, person and message are from converting it
                Conversation c = new Conversation();
                c.User = _person;
                c.messages.Add(new Message(_person, message));

                conversations.Add(c);
            }
            else
            {
                AddMessage(_person, message);
            }
        }

        public void AddMessage(Person person, string message)
        {
            GetConversation(person.PersonID).messages.Add(new Message(person, message));
        }
        public void AddMessage(Person person, string toPersonID, string message)
        {
            GetConversation(toPersonID).messages.Add(new Message(person, message));
        }

        private bool ContainsPerson(string _personId)
        {
            for (int i = 0; i < conversations.Count; i++)
            {
                if (conversations[i].User.PersonID == _personId)
                    return true;
            }

            return false;
            
        }

        private Conversation GetConversation(string _personId)
        {
            for (int i = 0; i < conversations.Count; i++)
            {
                if (conversations[i].User.PersonID == _personId)
                    return conversations[i];
            }

            return null;
        }

        public string GetMessagesAsString(string personID, bool oldMessages = false)
        {
            if (personID == "")
                return "Error cant find your id";

            if (IsLastMessage(personID) && oldMessages == false)
                return "";


            return JsonConverter.Serialize(GetMessages(personID));
        }
        public List<Message> GetMessages(string personID)
        {
            if (personID == "")
                return null;

            return GetConversation(personID).messages;
        }

        /// <summary>
        /// Check if the owner of the last message is the same
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        private bool IsLastMessage(string personID)
        {
            List<Message> messages = GetMessages(personID);

            if(messages.Count > 0)
            {
                if (messages[messages.Count - 1].User.PersonID == personID)
                    return true;
            }

            return false;
        }

        public bool IsAdmin(string uuid, string message = "")
        {
            if (AdminUUID.Contains(uuid))
                return true;
            
            if (message.Contains("/admin password"))
            {
                AdminUUID.Add(uuid);
                return true;
            }

            return false;
        }

        public List<Person> GetPeopleWaiting()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < conversations.Count; i++)
            {
                if (conversations[i].Admin == null)
                    people.Add(conversations[i].User);
            }

            return people;
        }

    }
}
