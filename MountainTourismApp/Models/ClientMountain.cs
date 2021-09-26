using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MountainTourismApp.Models
{
    public class ClientMountain
    {
        public Mountain mountain { get; set; }
        public List<Client> Clients { get; set; }
        public int MountainId { get; set; }
        public int ClientId { get; set; }
    }
}