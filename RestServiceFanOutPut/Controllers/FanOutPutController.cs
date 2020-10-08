using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oblikatoriskopgave1;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServiceFanOutPut.Controllers
{
    [Route("FanOutPut")]
    [ApiController]
    public class FanOutPutController : ControllerBase
    {
        private static int nextId = 5;
        private static readonly List<FanOutput> FanOutputs = new List<FanOutput>()
        {
            new FanOutput(1, "Room1", 16.5, 60),
            new FanOutput(2, "Room2", 20.5, 30),
            new FanOutput(3, "Room3", 19.5, 50),
            new FanOutput(4, "Room4", 24.5, 40),

        };


        // GET: api/<FanOutPutController>
        [HttpGet]
        public IEnumerable<FanOutput> Get()
        {
            return FanOutputs;
        }

        // GET api/<FanOutPutController>/5
        [HttpGet("{id}")]
        public FanOutput Get(int id)
        {
            return FanOutputs.Find(i => i.Id == id);
        }

        // POST api/<FanOutPutController>
        [HttpPost]
        public void Post([FromBody] FanOutput value)
        {
            value.Id = nextId;
            FanOutputs.Add(value);


        }

        // PUT api/<FanOutPutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutput value)
        {
            FanOutput FanOutputs = Get(id);
            if (FanOutputs != null)
            {
                FanOutputs.Name = value.Name;
                FanOutputs.Humidity = value.Humidity;
                FanOutputs.Temp = value.Temp;
            }

        }

        // DELETE api/<FanOutPutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutput fanOutput = Get(id);
            FanOutputs.Remove(fanOutput);
        }
    }
}
