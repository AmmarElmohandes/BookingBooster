﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirBnbWebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace AirBnbWebApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]       
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly AirBnbDbContext _context;

        public PropertiesController(AirBnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> Getproperties()
        {
            return await _context.properties.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var @property = await _context.properties.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(int id, Property @property)
        {
            if (id != @property.id)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
            var host = _context.hosts.FirstOrDefault(a => a.id == property.HostId);
            if (PropertyTitleExists(@property.Title))
            {
                return BadRequest(error: "This title already exists");
            }
            else if (host==null)
            {
                return BadRequest(error: "In valid HostId");
            }
            else
            {
                
                //property.host = _context.hosts.FirstOrDefault(a => a.id == 1);
                _context.properties.Add(@property);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProperty", new { id = @property.id }, @property);

            }
        }
        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var @property = await _context.properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.properties.Remove(@property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(int id)
        {
            return _context.properties.Any(e => e.id == id);
        }
        private bool PropertyTitleExists(string title)
        {
            return _context.properties.Any(e => e.Title == title);
        }
    }
}