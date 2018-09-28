using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.Data.Models.Service
{
    public class PocMain
    {
        public string DTtype { get; set; }
        public string DTRemoteOT { get; set; }
        public string DrinkMode { get; set; }

        public string ServMode { get; set; }
        public string FCRemoteOT { get; set; }
        public string FCDrinkMode { get; set; }

        public string Country { get; set; }
        public string DayPart { get; set; }

        public string DayPartVersion { get; set; }

        public string OperatingPlatform { get; set; }
        public string ArchDispenser { get; set; }
        public string FryerWall { get; set; }
    }
}
