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


        public void AddConversation(string _body, params string[] headers)
        {
            JObject json = JObject.Parse(_body);
            string personID = headers[0];
            string message = (string)json["Username"];

            if (!ContainsPerson(personID))
            {
                // _value is json object, person and message are from converting it
                Conversation c = new Conversation();
                c.PersonID = personID;
                c.messages.Add(new Message(personID, message));

                conversations.Add(c);
            }
            else
            {
                AddMessage(personID, message);
            }
        }

        public void AddMessage(string personID, string message)
        {
            GetConversation(personID).messages.Add(new Message(personID, message));
        }
        public void AddMessage(string personID, string toPersonID, string message)
        {
            GetConversation(toPersonID).messages.Add(new Message(personID, message));
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

        public string GetMessagesAsString(string personID, bool oldMessages = false)
        {
            if (IsLastMessage(personID) && oldMessages == false)
                return "";

            return JsonConverter.Serialize(GetMessages(personID));
        }
        public List<Message> GetMessages(string personID)
        {
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
                if (messages[messages.Count - 1].PersonID == personID)
                    return true;
            }

            return false;
        }

        public bool IsAdmin(string uuid, string _value = "")
        {
            if (AdminUUID.Contains(uuid))
                return true;
            
            JObject json = JObject.Parse(_value);
            string message = (string)json["message"];
            
            if (message.Contains("/admin password"))
            {
                AdminUUID.Add(uuid);
                return true;
            }

            return false;
        }

    }
}
