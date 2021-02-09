using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class ConversationManager
    {
        private static ConversationManager instance = null;

        private ConversationManager()
        {

        } 

        public static ConversationManager getInstance()
        {
            if (instance == null)
                instance = new ConversationManager();

            return instance;
        }


        public List<Conversation> conversations = new List<Conversation>();

    }
}
