using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HohoTraveltestlagi.Models
{
    public class PackageClass
    {
        public int PackID { get; set; }
        public string PackName { get; set; }
        public string PackTrip { get; set; }
        public Nullable<int> PackPrice { get; set; }
        public string IsDeleted { get; set; }
    }
}