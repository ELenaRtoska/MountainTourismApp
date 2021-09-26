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
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Club { get; set; }
        [Range(1,99)]
        public int Age { get; set; }

        public virtual ICollection<Mountain> mountains { get; set; }
    }
}