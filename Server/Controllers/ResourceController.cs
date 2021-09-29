using BlazorScheduler.Server.Data;
using BlazorScheduler.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorScheduler.Server.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly SchedulerContext _context;

        public ResourceController(SchedulerContext context)
        {
            _context = context;
        }

        // GET: api/<ResourceController>
        [HttpGet]
        public IEnumerable<ResourceModel> Get()
        {
            return _context.ResourceModels.ToList();
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ResourceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ResourceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ResourceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }

}
