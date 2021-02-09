using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        // GET: api/<ConversationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConversationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // convert id to object cuz id will be a jsonstring
            string personID = "abc";
            string message = "Hello world";

            Conversation c = new Conversation();
            c.PersonID = personID;
            c.messages.Add(new Message(message));

            ConversationManager.getInstance().conversations.Add(c);


            return "amount of conversations " + ConversationManager.getInstance().conversations.Count;
        }

        // POST api/<ConversationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConversationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConversationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
