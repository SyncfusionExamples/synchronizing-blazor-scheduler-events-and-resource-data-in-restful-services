using BlazorScheduler.Server.Data;
using BlazorScheduler.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorScheduler.Server.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly SchedulerContext _context;

        public ScheduleController(SchedulerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EventModel> Get()
        {
            return _context.EventModels.ToList();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPut]
        public void Put(DateTime StartDate, DateTime EndDate, [FromBody] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(eventModel).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public void Post([FromBody] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.EventModels.Add(eventModel);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(eventModel).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EventModel eventModel = _context.EventModels.Find(id);
                    _context.EventModels.Remove(eventModel);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

    }

}
