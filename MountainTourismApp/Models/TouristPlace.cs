using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class TouristPlace
    {
        [Key]
        public int Id { get; set; }

        public int SherpaId { get; set; }

        [Display(Name = "Слика")]
        public string ImageURL { get; set; }

        [Display(Name = "Име")]
        public string name { get; set; }

        [Display(Name = "Опис")]
        public string description { get; set; }
    }
}