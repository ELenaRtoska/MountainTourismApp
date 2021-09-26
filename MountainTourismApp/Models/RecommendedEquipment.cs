using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class RecommendedEquipment
    {
        [Key]
        public int Id { get; set; }

        public Sherpa sherpaId { get; set; }

        public string hotDesc { get; set; }

        public string coldDesc { get; set; }

    }
}