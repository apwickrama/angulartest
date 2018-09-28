using McDonald.POC_PCPT.Data.Models.UI_Dropdown;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.DriveThru;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.FrontCounter;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.General;
using McDonald.POC_PCPT.Data.Models.UI_Dropdown.Kitchen;
using McDonald.POC_PCPT.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.WebApi.ViewModels
{
    public class DropDownViewModel
    {
        // craete instance of Respository pattern of each table

        // general Drop down repository
        Repository<Country> CountryObj;
        Repository<DayPart> DayPartObj;
        Repository<DayPartVersion> DayPartVersionObj;

        // DriveThru Drop down repository
        Repository<DTtype> DTtypeObj;
        Repository<DrinkMode> DrinkModeObj;
        Repository<DTRemoteOT> DTRemoteOTObj;

        // FrontCounter Drop down repository
        Repository<ServMode> ServModeObj;
        Repository<FCDrinkMode> FCDrinkModeObj;
        Repository<FCRemoteOT> FCRemoteOTObj;

        // Kitchen Drop down repository
        Repository<OperatingPlatform> OperatingPlatformObj;
        Repository<FryerWall> FryerWallObj;
        Repository<ArchDispenser> ArchDispenserObj;

        private readonly PCPTDataContext _context;

        public DropDownViewModel(PCPTDataContext context)
        {
            _context = context;
            CountryObj = new Repository<Country>(_context);
            DayPartObj = new Repository<DayPart>(_context);
            DayPartVersionObj = new Repository<DayPartVersion>(_context);

            DTtypeObj = new Repository<DTtype>(_context);
            DrinkModeObj = new Repository<DrinkMode>(_context);
            DTRemoteOTObj = new Repository<DTRemoteOT>(_context);

            ServModeObj = new Repository<ServMode>(_context);
            FCDrinkModeObj = new Repository<FCDrinkMode>(_context);
            FCRemoteOTObj = new Repository<FCRemoteOT>(_context);

            OperatingPlatformObj = new Repository<OperatingPlatform>(_context);
            FryerWallObj = new Repository<FryerWall>(_context);
            ArchDispenserObj = new Repository<ArchDispenser>(_context);
        }


        // get list of data
        // combine all dropdown data into list of dropdowns
        // to create single endpoint
        public List<DropDownProps>[] GetDropDowns()
        {
            List<DropDownProps>[] dropDownProps = new List<DropDownProps>[12];


            // get the data from general's tables and put into  list of dropdowns
            // General
            dropDownProps[0] = CountryObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[1] = DayPartObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[2] = DayPartVersionObj.SelectAll().ToList<DropDownProps>();

            // DriveThru
            dropDownProps[3] = DTtypeObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[4] = DrinkModeObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[5] = DTRemoteOTObj.SelectAll().ToList<DropDownProps>();

            // FrontCounter
            dropDownProps[6] = ServModeObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[7] = FCDrinkModeObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[8] = FCRemoteOTObj.SelectAll().ToList<DropDownProps>();

            // kitchen
            dropDownProps[9] = OperatingPlatformObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[10] = FryerWallObj.SelectAll().ToList<DropDownProps>();
            dropDownProps[11] = ArchDispenserObj.SelectAll().ToList<DropDownProps>();


            return dropDownProps;

        }
    }
}
