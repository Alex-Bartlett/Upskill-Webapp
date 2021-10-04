using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public IndexModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

		public string NameSort { get; set; }
		public string StatusSort { get; set; }
        public string DateSort { get; set; }
		public string IDSort { get; set; }
		public string CurrentFilter { get; set; }
		public string CurrentSort { get; set; }

		public IList<Job> Jobs { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            IDSort = string.IsNullOrEmpty(sortOrder) ? "id_asc" : ""; //The default sort is by ID descending. An empty string implies default sorting.
            StatusSort = sortOrder == "status_asc" ? "status_desc" : "status_asc";//Sets the sort type, or toggles between ascending or descending when the same sort is clicked.
            DateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc"; //Shortened if statement. If the sort order is "date_asc", set it to "date_desc". Else, set to "date_asc".
            NameSort = sortOrder == "name_asc" ? "name_desc" : "name_asc"; //Name = customer surname

            CurrentFilter = searchString;

            IQueryable<Job> jobsQuery = from j in _context.Jobs
                                        select j;

			if (!String.IsNullOrEmpty(searchString))
			{
                jobsQuery = jobsQuery.Where(j => j.Customer.Surname.Contains(searchString) //These are the columns to be searched through when the user searches
                                              || j.Customer.FirstName.Contains(searchString)
                                              || j.JobReference.Contains(searchString)
                                              || j.Address.Contains(searchString)
                                              || j.Postcode.Contains(searchString));
			}
            
            switch (sortOrder)
			{
                case "id_asc":
                    jobsQuery = jobsQuery.OrderBy(j => j.ID);
                    break;
                case "status_asc":
                    jobsQuery = jobsQuery.OrderBy(j => j.Status);
                    break;
                case "status_desc":
                    jobsQuery = jobsQuery.Where(j => j.Status != Job.statusType.Invoiced)
                        .OrderByDescending(j => j.Status);
                    break;
                case "date_asc":
                    jobsQuery = jobsQuery.OrderBy(j => j.DueDate == null)
                        .ThenBy(j => j.DueDate);
                    break;
                case "date_desc":
                    jobsQuery = jobsQuery.OrderByDescending(j => j.DueDate)
                        .ThenBy(j => j.DueDate == null);
                    break;
                case "name_asc":
                    jobsQuery = jobsQuery.OrderBy(j => j.Customer.Surname);
                    break;
                case "name_desc":
                    jobsQuery = jobsQuery.OrderByDescending(j => j.Customer.Surname);
                    break;
                default:
                    jobsQuery = jobsQuery.OrderByDescending(j => j.ID);
                    break;
			}

            Jobs = await jobsQuery
                .Include(j => j.Customer)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get a string for a colour based on the status provided.
        /// </summary>
        /// <param name="status">The status to recolour</param>
        /// <returns>The name of the colour required for the status</returns>
        public string GetStatusColour(string status)
        {
            if(status is null)
			{
                return "black";
			}
            switch (status.ToLower())
            {
                case "pending":
                    return "green";
                case "started":
                    return "goldenrod"; //A slightly darker yellow that is easier to read on the white background.
                case "completed":
                    return "red";
                case "invoiced":
                    return "grey";
                default:
                    return "black";
            }
        }
    }
}
