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

        [Display(Name = "Слика")]
        public string ImageURL { get; set; }

        [Display(Name = "Име")]
        public string name { get; set; }

        [Display(Name = "Лиценца")]
        public Boolean licence { get; set; }

        [Display(Name = "Опис")]
        public string description { get; set; }

        [Display(Name = "Години искуство")]
        public int yearsOfExperience { get; set; }

        [Display(Name = "Планинарски клуб")]
        public string club { get; set; }

        [Display(Name = "Број на планинари")]
        public int hikers { get; set; }

        [Display(Name = "Датум и време")]
        public DateTime dateTime { get; set; }
    }
}