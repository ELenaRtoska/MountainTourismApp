using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class FinalReservation
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Корисничко име")]
        public string userEmail { get; set; }
        [Display(Name = "Планинарски водич")]
        public string finalSherpa { get; set; }
        [Display(Name = "GPS фајл")]
        public string gpsFile { get; set; }
        [Display(Name = "Планина")]
        public string mountain { get; set; }
        [Display(Name = "Датум и време")]
        public DateTime dateTime { get; set; }
        [Display(Name = "Број на планинари")]
        public int hikers { get; set; }
    }
}