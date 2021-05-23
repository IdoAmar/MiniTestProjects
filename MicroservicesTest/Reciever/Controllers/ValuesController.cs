using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Reciever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private RecieverEventBus _recieverEventBus;

        // GET api/values

        public ValuesController([FromServices] RecieverEventBus recieverEventBus)
        {
            _recieverEventBus= recieverEventBus;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "This is the Reciever";
        }
        // Recieving the information from the sending microservice and saving it into a person object
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            //decrypting the message
            string encryptedMessage = _recieverEventBus.GetCurrentMessage();
            string decryptedMessage = SimpleDecryption.Decrypt(encryptedMessage);
            // if the message is not empty convert the json information back to a list and saving it
            if (!String.IsNullOrEmpty(decryptedMessage))
            {
                PersonRecievedInfo personInfo = new PersonRecievedInfo(JsonConvert.DeserializeObject<ArrayList>(decryptedMessage));
            }
            // displaying the json formatted list
            return new string[] { decryptedMessage };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
