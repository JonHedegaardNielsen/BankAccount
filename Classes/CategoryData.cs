using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class CategoryData
{
	public ShopItemType Type { get; private set; }
	public int AmountBought { get; private set; }
	public decimal AmountSpent { get; private set; }

    public CategoryData(ShopItemType type, int amountBought, decimal amountSpent)
	{
        Type = type;
		AmountBought = amountBought;
		AmountSpent = amountSpent;
	}
}
