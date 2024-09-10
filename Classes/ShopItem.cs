using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class ShopItem
{
	public int Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public decimal Price { get; private set; }

	public ShopItem(int id, string name, decimal price)
	{
		Id = id;
		Name = name;
		
		Price = price;
	}

	public ShopItem(string name, decimal price)
	{
		Price = price;
		Name = name;
	}
}
