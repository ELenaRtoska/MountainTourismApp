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
        public string Name { get; set; }
        [Display(Name = "Image")]
        public string ImageURL { get; set; }
        [Required]
        public float Raiting { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Client> clients { get; set; }
    }
}