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
    public class FrontCounterController : ControllerBase
    {
        private Repository<FrontCounterModel> db;
        private readonly PCPTDataContext _context;

        public FrontCounterController(PCPTDataContext context)
        {
            _context = context;
            db = new Repository<FrontCounterModel>(context);
        }

        // GET: api/DriveThru
        [HttpGet]
        public IEnumerable<FrontCounterModel> GetDriveThru()
        {
            return db.SelectAll();
        }

        // GET: api/DriveThru/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFrontCounterModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var FrontCounterModel = await _context.DriveThru.FindAsync(id);

            if (FrontCounterModel == null)
            {
                return NotFound();
            }

            return Ok(FrontCounterModel);
        }

        // PUT: api/DriveThru/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrontCounterModel([FromRoute] int id, [FromBody] FrontCounterModel FrontCounterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != FrontCounterModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(FrontCounterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrontCounterModelExists(id))
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
        public async Task<IActionResult> PostFrontCounterModel([FromBody] FrontCounterModel FrontCounterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Add(FrontCounterModel);
            db.Save();
            //_context.DriveThru.Add(FrontCounterModel);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrontCounterModel", new { id = FrontCounterModel.ID }, FrontCounterModel);
        }

        // DELETE: api/DriveThru/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrontCounterModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var FrontCounterModel = await _context.DriveThru.FindAsync(id);
            if (FrontCounterModel == null)
            {
                return NotFound();
            }

            _context.DriveThru.Remove(FrontCounterModel);
            await _context.SaveChangesAsync();

            return Ok(FrontCounterModel);
        }

        private bool FrontCounterModelExists(int id)
        {
            return _context.FrontCounter.Any(e => e.ID == id);
        }
    }
}