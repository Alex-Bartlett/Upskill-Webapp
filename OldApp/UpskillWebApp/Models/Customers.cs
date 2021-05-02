using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UpskillWebApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Jobs = new HashSet<Job>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string HouseNumber { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
