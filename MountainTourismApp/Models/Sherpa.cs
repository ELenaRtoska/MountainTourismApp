using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class Sherpa
    {
        [Key]
        public int Id { get; set; }

        public int GPSFileId { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Licence")]
        public Boolean licence { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Years of experience")]
        public int yearsOfExperience { get; set; }
    }
}