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
        public async Task<ActionResult> Get(int id, [FromBody] string values)
        {
            // convert id to object cuz id will be a jsonstring
            try
            {
                string k = "amount of conversations " + ConversationManager.getInstance().conversations.Count;

                return Ok(k);

            }catch(Exception e)
            {
                return StatusCode(500, e);
            }

        }

        // POST api/<ConversationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {
            try
            {
                ConversationManager.getInstance().AddConversation(value);
                
                // maybe delete later
                return Ok("a");
                
            }catch(Exception e)
            {
                return StatusCode(500, e);
            }

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
