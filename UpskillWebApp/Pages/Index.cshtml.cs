using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UpskillWebApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			
		}

		public string TestConnection()
		{
			SqlConnection connection = Models.SQLConnector.Connect();
			try
			{
				connection.Open();
				return "success";
			}catch(Exception e)
			{
				return e.ToString();
			}
		}

        public List<string> GetFirstCustomer()
		{
            string query = @"SELECT * FROM jobs";
            List<string> customer = ExecuteReadQuery(query);
            return customer;
		}

        private static List<string> ExecuteReadQuery(string commandString)
        {
            List<string> results = new List<string>();

            SqlConnection connection = Models.SQLConnector.Connect();
            using (connection)
            {
                try
                {
                    SqlCommand command = new SqlCommand(commandString, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    int fieldCount;

                    while (reader.Read())
                    {
                        fieldCount = reader.FieldCount;

                        for (int i = 0; i < fieldCount; i++)
                        {
                            results.Add(reader[i].ToString());
                        }
                    }
                    reader.Close();
                    return results;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    throw;
                }
            }
        }
    }
}
