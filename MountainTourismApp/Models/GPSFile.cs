using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainTourismApp.Models
{
    public class GPSFile
    {
        [Key]
        public int Id { get; set; }

        public int mountainId { get; set; }

        public string title { get; set; }

        [Display(Name = "Route")]
        public string description { get; set; }

        [Display(Name = "Distance(km)")]
        public float distance { get; set; }

        [Display(Name = "D+")]
        public int positiveD { get; set; }

        [Display(Name = "D-")]
        public int negativeD { get; set; }

        [Display(Name = "Upload File")]
        public string filePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase uploadFile { get; set; }



    }
}