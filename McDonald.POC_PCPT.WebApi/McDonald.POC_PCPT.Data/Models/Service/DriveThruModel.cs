using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.Data.Models.Service
{
    [Table("DriveThru")]
    public class DriveThruModel
    {
        public int ID { get; set; }
        public string DTtype { get; set; }
        public string DTRemoteOT { get; set; }
        public string DrinkMode { get; set; }

    }
}
