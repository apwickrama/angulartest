using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using McDonald.POC_PCPT.Data;
using McDonald.POC_PCPT.DataService;
using Microsoft.AspNetCore.Cors;

namespace McDonald.POC_PCPT.WebApi.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DriveThruController : ControllerBase
    {
        private Repository<DriveThruModel> db;
        private readonly PCPTDataContext _context;

        public DriveThruController(PCPTDataContext context)
        {
            _context = context;
            db = new Repository<DriveThruModel>(context);
        }

        // GET: api/DriveThru
        [HttpGet]
        public IEnumerable<DriveThruModel> GetDriveThru()
        {
            return db.SelectAll();
        }

        // GET: api/DriveThru/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriveThruModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driveThruModel = await _context.DriveThru.FindAsync(id);

            if (driveThruModel == null)
            {
                return NotFound();
            }

            return Ok(driveThruModel);
        }

        // PUT: api/DriveThru/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriveThruModel([FromRoute] int id, [FromBody] DriveThruModel driveThruModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driveThruModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(driveThruModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriveThruModelExists(id))
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

        // POST: api/DriveThru
        [HttpPost]
        public async Task<IActionResult> PostDriveThruModel([FromBody] DriveThruModel driveThruModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Add(driveThruModel);
            db.Save();
            //_context.DriveThru.Add(driveThruModel);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriveThruModel", new { id = driveThruModel.ID }, driveThruModel);
        }

        // DELETE: api/DriveThru/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriveThruModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driveThruModel = await _context.DriveThru.FindAsync(id);
            if (driveThruModel == null)
            {
                return NotFound();
            }

            _context.DriveThru.Remove(driveThruModel);
            await _context.SaveChangesAsync();

            return Ok(driveThruModel);
        }

        private bool DriveThruModelExists(int id)
        {
            return _context.DriveThru.Any(e => e.ID == id);
        }
    }
}