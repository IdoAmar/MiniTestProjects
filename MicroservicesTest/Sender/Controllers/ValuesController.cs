using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "This is the Sender";
        }

        // Sending the information to the recieving microservice through the RabbitMQ eventbus
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            PersonSendInfo personInfo = new PersonSendInfo("ido", new DateTime(1997, 12, 24), 22, "Programmer");
            //serializing the info to Json format to send through the rabbitMQ eventbus
            string serializedPersonInfo = JsonConvert.SerializeObject(personInfo.GetPersonListWithoutAge());
            //encrypting the message before sending
            string encryptedMessage = SimpleEncryption.Encrypt(serializedPersonInfo);
            SenderEventBus senderEvent = new SenderEventBus(encryptedMessage);
            return "[Message Sent.]";
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
