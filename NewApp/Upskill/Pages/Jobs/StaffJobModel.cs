using Upskill.Data;
using Upskill.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Upskill.Pages.Jobs
{
	public class StaffJobModel : CustomerNamePageModel
	{
		public List<AssignedStaffData> AssignedStaffDataList;

		public void PopulateAssignedStaffData(UpskillContext context, Job job)
		{
			var allStaffJobs = context.StaffJobs;
			var jobStaffJobs = new HashSet<int>(job.StaffJobs.Select(sj => sj.ID));
			AssignedStaffDataList = new List<AssignedStaffData>();
			foreach (var staffJob in allStaffJobs) //Get all staff jobs from database
			{
				if (staffJob.JobID == job.ID) //Only add the SJs that belong to the job
				{
					AssignedStaffDataList.Add(new AssignedStaffData
					{
						StaffJobID = staffJob.ID,
						StaffMemberName = staffJob.StaffMember.FullName,
						HoursWorked = staffJob.HoursWorked,
						Notes = staffJob.Notes
					});
				}
			}
		}
	}
}
