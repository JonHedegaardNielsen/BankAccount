using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class ShopItem
{
	public int Id { get; private set; }
	public string Name { get; private set; }
	public string Description { get; private set; }
	public decimal Price { get; private set; }

	public ShopItem(int id, string name, string description, decimal price)
	{
		Id = id;
		Name = name;
		Description = description;
		Price = price;
	}


}
