using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.Data.Models.Service
{
    [Table("FrontCounter")]
    public class FrontCounterModel
    {
        public int ID { get; set; }
        public string ServMode { get; set; }
        public string FCRemoteOT { get; set; }
        public string FCDrinkMode { get; set; }
    }
}
