using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.WebApi.Models
{
    [Table("Kitchen")]
    public class KitchenModel
    {
        public int ID { get; set; }
        public string OperatingPlatform { get; set; }
        public string ArchDispenser { get; set; }
        public string FryerWall { get; set; }
    }
}
