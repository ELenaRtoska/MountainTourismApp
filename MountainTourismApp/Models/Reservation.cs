using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public List<Client> Clients { get; set; }
        public List<Mountain> Mountains { get; set; }
        public List<GPSFile> GPSFile { get; set; }
        public List<Sherpa> Sherpa { get; set; }
        public List<RecommendedEquipment> RecommendedEquipment { get; set; }

        public Reservation()
        {
            Clients = new List<Client>();
            Mountains = new List<Mountain>();
            GPSFile = new List<GPSFile>();
            Sherpa = new List<Sherpa>();
        }
    }
}