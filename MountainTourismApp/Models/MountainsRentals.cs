using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class MountainsRentals
    {
        public Mountain mountain { get; set; }
        public List<Client> clients { get; set; }
    }
}