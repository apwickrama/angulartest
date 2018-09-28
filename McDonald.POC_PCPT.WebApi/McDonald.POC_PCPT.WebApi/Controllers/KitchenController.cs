using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McDonald.POC_PCPT.Data;
using McDonald.POC_PCPT.DataService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McDonald.POC_PCPT.WebApi.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
        private Repository<KitchenModel> db;
        private readonly PCPTDataContext _context;

        public KitchenController(PCPTDataContext context)
        {
            _context = context;
            db = new Repository<KitchenModel>(context);
        }

        // GET: api/DriveThru
        [HttpGet]
        public IEnumerable<KitchenModel> GetDriveThru()
        {
            return db.SelectAll();
        }

        // GET: api/DriveThru/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKitchenModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var KitchenModel = await _context.DriveThru.FindAsync(id);

            if (KitchenModel == null)
            {
                return NotFound();
            }

            return Ok(KitchenModel);
        }

        // PUT: api/DriveThru/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitchenModel([FromRoute] int id, [FromBody] KitchenModel KitchenModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != KitchenModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(KitchenModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitchenModelExists(id))
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
        public async Task<IActionResult> PostKitchenModel([FromBody] KitchenModel KitchenModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Add(KitchenModel);
            db.Save();
            //_context.DriveThru.Add(KitchenModel);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetKitchenModel", new { id = KitchenModel.ID }, KitchenModel);
        }

        // DELETE: api/DriveThru/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitchenModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var KitchenModel = await _context.DriveThru.FindAsync(id);
            if (KitchenModel == null)
            {
                return NotFound();
            }

            _context.DriveThru.Remove(KitchenModel);
            await _context.SaveChangesAsync();

            return Ok(KitchenModel);
        }

        private bool KitchenModelExists(int id)
        {
            return _context.Kitchen.Any(e => e.ID == id);
        }
    }
}