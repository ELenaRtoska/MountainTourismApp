using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class Mountain
    {
        public Mountain()
        {
            clients = new List<Client>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Планина")]
        public string Name { get; set; }
        [Display(Name = "Слика")]
        public string ImageURL { get; set; }
        [Required]
        [Display(Name = "Рејтинг")]
        public float Raiting { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }

        public virtual ICollection<Client> clients { get; set; }
    }
}