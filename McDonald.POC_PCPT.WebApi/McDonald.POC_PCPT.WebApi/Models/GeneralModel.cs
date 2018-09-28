using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.WebApi.Models
{
    [Table("General")]
    public class GeneralModel
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string DayPart { get; set; }

        public string DayPartVersion { get; set; }

    }
}
