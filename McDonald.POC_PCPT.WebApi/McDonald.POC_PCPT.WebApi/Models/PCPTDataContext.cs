using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.WebApi.Models
{
    public class PCPTDataContext : DbContext
    {
        public PCPTDataContext(DbContextOptions<PCPTDataContext> options) : base(options)
        {

        }
        public DbSet<KitchenModel> Kitchen { get; set; }
        public DbSet<FrontCounterModel> FrontCounter { get; set; }
        public DbSet<GeneralModel> General { get; set; }
        public DbSet<DriveThruModel> DriveThru { get; set; }


    }
}
