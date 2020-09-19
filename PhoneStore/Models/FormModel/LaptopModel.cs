using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.FormModel
{
    public class LaptopModel
    {
        [Required]
        public string lScreen { get; set; }
      
        [Required]
        public string lCPU { get; set; }
        [Required]
        public string lRAM { get; set; }
        [Required]
        public string lGPU { get; set; }
        [Required]
        public string lOS { get; set; }
        [Required]
        public string lStorage { get; set; }
        [Required]
      
        public string lWeight { get; set; }
        [Required]
        public string lDimension { get; set; }
        [Required]
        public string lBattery { get; set; }
        [Required]
        public string lWarranty { get; set; }
        [Required]
        public string lOrigin { get; set; }
        [Required]
        public string lYOM { get; set; }
    }
}
