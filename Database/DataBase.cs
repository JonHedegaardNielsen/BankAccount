﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BankAccount;

public abstract class Database<T>
{
	private string ConnectionString = Files.GetConnectionString();

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

	protected T RunSingleQuery<T>(string query, Func<SqlDataReader, T> getValue)
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

	protected int GetCount(SqlDataReader sqlDataReader) =>
		sqlDataReader.GetInt32(0);

	protected string FormatDecimal(decimal num)
	{
		return num.ToString().Replace(",", ".");
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