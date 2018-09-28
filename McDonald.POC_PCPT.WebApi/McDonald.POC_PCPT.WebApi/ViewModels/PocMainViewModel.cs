using McDonald.POC_PCPT.Data;
using McDonald.POC_PCPT.Data.Models.Service;
using McDonald.POC_PCPT.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.WebApi.ViewModels
{
    public class PocMainViewModel
    {

        // create instances of Respository pattern of each table
        Repository<GeneralModel> gObj;
        Repository<DriveThruModel> dtObj;
        Repository<FrontCounterModel> fcObj;
        Repository<KitchenModel> kObj;
        private readonly PCPTDataContext _context;

        public PocMainViewModel(PCPTDataContext context)
        {
            _context = context;
            gObj = new Repository<GeneralModel>(_context);
            dtObj = new Repository<DriveThruModel>(_context);
            fcObj = new Repository<FrontCounterModel>(_context);
            kObj = new Repository<KitchenModel>(_context);
        }

        /// <summary>
        /// Store data to database(General,DriveThru,FrontCounter,Kitchen)
        /// </summary>
        /// <param name="pocMain"></param>
        public void PostDataToDB(PocMain pocMain)
        {
            // spilt the data from pocMain object and store into specific tables
            gObj.Add(new GeneralModel() { Country = pocMain.Country, DayPart = pocMain.DayPart, DayPartVersion = pocMain.DayPartVersion });
            dtObj.Add(new DriveThruModel() { DrinkMode = pocMain.DrinkMode, DTRemoteOT = pocMain.DTRemoteOT, DTtype = pocMain.DTtype });
            fcObj.Add(new FrontCounterModel() { FCDrinkMode = pocMain.FCDrinkMode, FCRemoteOT = pocMain.FCRemoteOT, ServMode = pocMain.ServMode });
            kObj.Add(new KitchenModel() { ArchDispenser = pocMain.ArchDispenser, FryerWall = pocMain.FryerWall, OperatingPlatform = pocMain.OperatingPlatform });
            gObj.Save();
          
        }

        /// <summary>
        /// Get all data from General,DriveThru,FrontCounter,Kitchen and combine in single pocMain object
        /// </summary>
        /// <returns></returns>
        public List<PocMain> pocMains()
        {
            var s = (from dt in _context.DriveThru
                     join g in _context.General on dt.ID equals g.ID
                     join fc in _context.FrontCounter on dt.ID equals fc.ID
                     join k in _context.Kitchen on dt.ID equals k.ID
                     select new PocMain
                     {
                         DTtype = dt.DTtype,
                         DTRemoteOT = dt.DTRemoteOT,
                         DrinkMode = dt.DrinkMode,
                         ServMode = fc.ServMode,
                         FCRemoteOT = fc.FCRemoteOT,
                         FCDrinkMode = fc.FCDrinkMode,
                         Country = g.Country,
                         DayPart = g.DayPart,
                         DayPartVersion = g.DayPartVersion,
                         OperatingPlatform = k.OperatingPlatform,
                         ArchDispenser = k.ArchDispenser,
                         FryerWall = k.FryerWall
                     }).ToList();
            return s;
        }

    }
}
