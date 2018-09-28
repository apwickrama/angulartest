using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.General;
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
    public class DropDownController : ControllerBase
    {
        private readonly PCPTDataContext db;
        private DropDownViewModel viewModel;

        public DropDownController(PCPTDataContext context)
        {
            db = context;
            viewModel = new DropDownViewModel(db);
        }

        // get all dropdown data from DB
        [HttpGet]
        public List<DropDownProps>[] GetAll()
        {
            try
            {
                
                return viewModel.GetDropDowns();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}