using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using McDonald.POC_PCPT.DataService;
using McDonald.POC_PCPT.Data;
using Microsoft.AspNetCore.Cors;

namespace McDonald.POC_PCPT.WebApi.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly DataService.PCPTDataContext _context;
        private Repository<GeneralModel> db;
        public GeneralController(DataService.PCPTDataContext context)
        {
            _context = context;
            db = new Repository<GeneralModel>(context);
        }

        // GET: api/General
        [HttpGet]
        public IEnumerable<GeneralModel> GetGeneral()
        {
            return db.SelectAll();
        }

        // GET: api/General/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneralModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var generalModel = await _context.General.FindAsync(id);

            if (generalModel == null)
            {
                return NotFound();
            }

            return Ok(generalModel);
        }

        // PUT: api/General/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralModel([FromRoute] int id, [FromBody] GeneralModel generalModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != generalModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(generalModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralModelExists(id))
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

        // POST: api/General
        [HttpPost]
        public async Task<IActionResult> PostGeneralModel([FromBody] GeneralModel generalModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(generalModel);
            db.Save();
            //_context.General.Add(generalModel);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralModel", new { id = generalModel.ID }, generalModel);
        }

        // DELETE: api/General/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var generalModel = await _context.General.FindAsync(id);
            if (generalModel == null)
            {
                return NotFound();
            }

            _context.General.Remove(generalModel);
            await _context.SaveChangesAsync();

            return Ok(generalModel);
        }

        private bool GeneralModelExists(int id)
        {
            return _context.General.Any(e => e.ID == id);
        }
    }
}