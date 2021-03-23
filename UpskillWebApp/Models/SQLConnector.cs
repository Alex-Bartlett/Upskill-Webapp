using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UpskillWebApp.Models
{
	public class SQLConnector
	{
		

		/// <summary>
		/// Establish a connection to the Upskill database
		/// </summary>
		/// <returns>A connection var to the database</returns>
		public static SqlConnection Connect()
		{
			//Create a more secure way of retrieving the connection string. This is bad.
			string connectionString = @"Server = tcp:upskilljobmgmt.database.windows.net,1433; Initial Catalog = Upskill; Persist Security Info = False; User ID = AdminAccount; Password =@!llCQkr35Pb; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

			SqlConnection connection = new(connectionString); //Create a connection

			try //Try to open the connection. If successful, it will return. If not, error.
			{
				connection.Open();
				connection.Close();
				return connection;
			}
			catch
			{
				throw;
			}

		}
	}
}
