using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Upskill.Models;

namespace Upskill.Pages.Jobs
{
	public class CustomerNamePageModel : PageModel
	{
		public SelectList CustomerNameSL { get; set; }

		public void PopulateCustomerDropDownList(UpskillContext _context,
			object selectedCustomer = null)
		{
			var customersQuery = from c in _context.Customers
								 orderby c.Surname
								 select c;

			CustomerNameSL = new SelectList(customersQuery.AsNoTracking(), "ID", "FullName", selectedCustomer);
		}


        /// <summary>
        /// Generates a job reference using the given job's properties
        /// </summary>
        /// <param name="thisJob">The job to change the reference of</param>
        /// <param name="_context"></param>
        /// <returns>Job reference as ID_NAME_ADDRESS</returns>
        public string GenerateJobReference(Job thisJob, UpskillContext _context)
        {
            StringBuilder strb = new();
            strb.Append(thisJob.ID);
            strb.Append('_');

            //Get the customer model from ID
            IQueryable<Customer> customerQuery = from c in _context.Customers
                                                 where c.ID == thisJob.CustomerID
                                                 select c;
            Customer customer = customerQuery.AsNoTracking().First(); //Run the query

            string surname = customer.Surname.Replace(" ", ""); //Remove the white spaces from these
            string address = thisJob.Address.Replace(" ", "");

            if (surname.Length > 10)
            {
                strb.Append(surname.Substring(0, 9));
            }
            else
            {
                strb.Append(surname);
            }
            strb.Append('_');

            if (address.Length > 10)
            {
                strb.Append(address.Substring(0, 10));
            }
            else
            {
                strb.Append(address);
            }

            return strb.ToString();

        }
    }
}
