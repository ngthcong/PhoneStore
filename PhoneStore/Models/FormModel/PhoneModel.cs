using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class PhoneModel
    {
        [Required]
        
        public string pScreen { get; set; }
        [Required]
        public string pFrontCam { get; set; }
        public string pRearCam { get; set; }
        [Required]
        public string pCPU { get; set; }
        [Required]
        public string pRAM { get; set; }
        [Required]
        public string pGPU { get; set; }
        [Required]
        public string pROM { get; set; }
        [Required]
        public string pStorage { get; set; }
        [Required]
        public string pSensor { get; set; }
        [Required]
        public string pSimType { get; set; }
        [Required]
        public string pConnect { get; set; }
        [Required]
        public string pBattery { get; set; }
        [Required]
        public string pWarranty { get; set; }
        [Required]
        public string pOrigin { get; set; }
        [Required]
        public string pYOM { get; set; }
        
    }
}
