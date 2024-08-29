using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Collections;
using System.Globalization;

namespace BankAccount;

public abstract class Database<T>
{
	private string ConnectionString = "Server=JON;Database=bankAccount;Trusted_Connection=True;";

	protected SqlConnection GetConnection()
	{
		SqlConnection connection = new SqlConnection(ConnectionString);
		connection.Open();
		return connection;
	}

	protected List<T> RunQuery(string query, Func<SqlDataReader, T> getValues)
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

	protected T RunSingleQuery(string query, Func<SqlDataReader, T> getValue)
	{
		using (SqlConnection connection = GetConnection())
		{
			using (SqlCommand command = new SqlCommand(query, connection))
			{
				using (SqlDataReader reader = command.ExecuteReader())
				{
					reader.Read();

					return getValue(reader);

				}
			}
		}
	}

	protected string FormatDecimal(decimal num)
	{
		CultureInfo culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
		culture.NumberFormat.NumberDecimalSeparator = ".";
		return num.ToString("F2", culture);
	}

	protected bool ExecuteNonQuery(string query)
	{
		using (SqlConnection connection = GetConnection())
		{
			using (SqlCommand command = new SqlCommand(query, connection))
			{
				try
				{
					command.ExecuteNonQuery();
					return true;
				}
				catch (SqlException)
				{
					return false;
				}
			}
		}
	}
}