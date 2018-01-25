using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace poc_api.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "ChangedVal", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, string q)
        {
            return Ok(new Value { Id = id, Text = "Value" + id });
        }

        // POST api/values
        // formbody handles format baseed on what format handlers available from controller base
        //when using types can check if val conforms to model Value
        // IAction takes care of setting status 200 400 500 etc
        [HttpPost]
        public IActionResult Post([FromBody]Value val)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //throw new InvalidOperationException("Invalid Operations");

            }

            //save data to db

            return CreatedAtAction("Get", new { id = val.Id }, val);
        }

        // PUT api/values/5        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Value
    {
        public int Id { get; set; }

        //Text has to be 3 if not then modelstate will not be valid
        [MinLength(3)]
        public string Text { get; set; }

    }

}
