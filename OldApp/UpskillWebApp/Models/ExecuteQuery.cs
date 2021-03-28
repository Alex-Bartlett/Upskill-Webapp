using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace UpskillWebApp.Models
{
	public class ExecuteQuery
	{
        /// <summary>
        /// Returns a 2-dimensional list of results, each array in list is a row of the database.
        /// </summary>
        /// <param name="commandString">The sql query to be executed.</param>
        /// <returns></returns>
        public static List<string[]> ExecuteNestedReadQuery(string commandString)
        {
            List<string[]> results = new List<string[]>();

            SqlConnection connection = SQLConnector.Connect();
            using (connection)
            {
                try
                {
                    SqlCommand command = new SqlCommand(commandString, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        string[] subResults = new string[reader.FieldCount];

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            subResults[i] = (reader[i].ToString());
                        }

                        results.Add(subResults);
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
