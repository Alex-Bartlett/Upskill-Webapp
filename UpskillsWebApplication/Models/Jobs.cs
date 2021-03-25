using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UpskillsWebApplication.Models
{
    public partial class Jobs
    {
        public int JobId { get; set; }
        public string JobReference { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinished { get; set; }
        public decimal? QuotedAmount { get; set; }
        public decimal? InvoicedAmount { get; set; }
        public decimal? HoursWorked { get; set; }
        public decimal? DaysWorked { get; set; }
        public int CustomerId { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }
        public DateTime? DateDue { get; set; }
        public string Staff { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
