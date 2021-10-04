using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class Client
    {
        public Client()
        {
            mountains = new List<Mountain>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Display(Name = "Адреса")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Планинарски клуб")]
        public string Club { get; set; }
        [Range(1,99)]
        [Display(Name = "Години")]
        public int Age { get; set; }

        public virtual ICollection<Mountain> mountains { get; set; }
    }
}