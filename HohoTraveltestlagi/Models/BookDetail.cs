using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HohoTraveltestlagi.Models
{
    public class BookDetail
    {
        public int BookID { get; set; }
        public Nullable<System.DateTime> BookDate { get; set; }
        public Nullable<int> PackID { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustPhNum { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public Nullable<System.DateTime> TravelDate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string BookMessage { get; set; }
        public string BookStatus { get; set; }

        public virtual Package Package { get; set; }
    }
}