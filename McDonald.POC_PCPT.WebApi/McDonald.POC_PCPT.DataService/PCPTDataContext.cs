using McDonald.POC_PCPT.Data;
using McDonald.POC_PCPT.Data.Models.Service;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.DriveThru;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.FrontCounter;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.General;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.Kitchen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.DataService
{
    public class PCPTDataContext : DbContext
    {
        public PCPTDataContext(DbContextOptions<PCPTDataContext> options) : base(options)
        {

        }

        // main component tables
        public DbSet<KitchenModel> Kitchen { get; set; }
        public DbSet<FrontCounterModel> FrontCounter { get; set; }
        public DbSet<GeneralModel> General { get; set; }
        public DbSet<DriveThruModel> DriveThru { get; set; }


        // dropdown tables 
        // General field
        public DbSet<Country> Country { get; set; }
        public DbSet<DayPart> DayPart { get; set; }
        public DbSet<DayPartVersion> DayPartVersion { get; set; }

        // DriveThru field
        public DbSet<DTtype> DTtype { get; set; }
        public DbSet<DTRemoteOT> DTRemoteOT { get; set; }
        public DbSet<DrinkMode> DrinkMode { get; set; }

        // FrontCounter
        public DbSet<ServMode> ServMode { get; set; }
        public DbSet<FCDrinkMode> FCDrinkMode { get; set; }
        public DbSet<FCRemoteOT> FCRemoteOT { get; set; }

        // kitchen
        public DbSet<ArchDispenser> ArchDispenser { get; set; }
        public DbSet<FryerWall> FryerWall { get; set; }
        public DbSet<OperatingPlatform> OperatingPlatform { get; set; }

    }
}
