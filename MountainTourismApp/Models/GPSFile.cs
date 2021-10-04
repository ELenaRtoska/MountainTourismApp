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
        [Display(Name = "Наслов")]
        public string title { get; set; }

        [Display(Name = "Рута")]
        public string description { get; set; }

        [Display(Name = "Дистанца(km)")]
        public float distance { get; set; }

        [Display(Name = "D+")]
        public int positiveD { get; set; }

        [Display(Name = "D-")]
        public int negativeD { get; set; }

        [Display(Name = "Прикачи фајл")]
        public string filePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase uploadFile { get; set; }



    }
}