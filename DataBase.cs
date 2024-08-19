using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace BankAccount;

abstract class Database<T>
{
	private string ConnectionString = "Server=JON;Database=BankAccount;Trusted_Connection=True;";

	

	protected SqlConnection GetConnection()
	{
		SqlConnection connection = new SqlConnection(ConnectionString);
		connection.Open();
		return connection;
	}

	public List<T> RunQuery<T>(string query, Func<SqlDataReader, T> getValues)
	{
		List<T> values = new List<T>();

		using (SqlConnection connection = GetConnection())
		{
			using (SqlCommand command = new SqlCommand(query, connection))
			{
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						values.Add(getValues(reader));
					}
				}
			}
		}

		return values;
	}

	protected void ExecuteNonQuery(string query)
	{
		using (SqlConnection connection = GetConnection())
		{
			using (SqlCommand command = new SqlCommand(query, connection))
			{
				command.ExecuteNonQuery();
			}
		}
	}
}