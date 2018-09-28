using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McDonald.POC_PCPT.Data;
using McDonald.POC_PCPT.Data.Models.Service;
using McDonald.POC_PCPT.DataService;
using McDonald.POC_PCPT.WebApi.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McDonald.POC_PCPT.WebApi.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
      
        private readonly PCPTDataContext db;
        private PocMainViewModel viewModel;

        public MainController(PCPTDataContext context)
        {
            db = context;
            viewModel = new PocMainViewModel(db);
            
        }

        // get all the data from DB
        [HttpGet]
        public List<PocMain> GetAll()
        {
            try
            {
                return viewModel.pocMains();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    
        // post data to database
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PocMain  pocMain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                viewModel.PostDataToDB(pocMain);
                return Ok(pocMain);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}