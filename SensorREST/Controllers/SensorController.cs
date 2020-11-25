using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;
using SensorREST.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        SensorManager mng = new SensorManager();

        // GET: api/<SensorController>
        [HttpGet]
        public IEnumerable<SensorData> Get()
        {
            return mng.Get();
        }

        // GET api/<SensorController>/5
        [HttpGet]
        [Route("{id}")]
        public SensorData GetId(int id)
        {
            return mng.GetId(id);
        }

        // POST api/<SensorController>
        [HttpPost]
        public void Post([FromBody] SensorData value)
        {
            mng.Post(value);
        }

        //// PUT api/<SensorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SensorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
