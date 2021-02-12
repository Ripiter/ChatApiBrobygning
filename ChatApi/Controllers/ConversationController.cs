using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        
        // GET api/<ConversationController>
        //[HttpGet("{id}")]
        public async Task<ActionResult> Get()
        {
            // convert id to object cuz id will be a jsonstring
            try
            {
                string uuid = Request.Headers["zbc_auth_uuid"];
                //string k = ConversationManager.getInstance().GetMessagesAsString(uuid);

                return Ok("You used get");

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
                string uuid = Request.Headers["zbc_auth_uuid"];
                string name = Request.Headers["zbc_user_name"];

                if (ConversationManager.getInstance().IsAdmin(uuid, value))
                {
                    JObject json = JObject.Parse(value);
                    string message = (string)json["message"];
                    string messageTo = (string)json["messageTo"];
                    if(messageTo != null)
                        ConversationManager.getInstance().AddMessage(uuid, messageTo, message);
                }
                else
                {
                    ConversationManager.getInstance().AddConversation(value, uuid, name);
                }
                
                return Ok("someone will get to you soon");
                // maybe delete later
                
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
