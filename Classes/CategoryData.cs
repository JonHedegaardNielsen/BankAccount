using BankAccount.Database;
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

    public CategoryData(ShopItemType type)
	{
        Type = type;
		
	}

	void UpdateData(BankAccount bankAccount)
	{
		//AmountBought = ShopItemDatabase.Instance.SelectCountItemType(ShopUserDatabase.Instance.SelectUserId(bankAccount.Id), Type);
		//decimal? amountSpent = ShopItemDatabase.Instance.GetTotalExpensesofCategory(bankAccount.Id);
		//if (amountSpent != null)
		//	AmountSpent = (decimal)amountSpent;
	}
}
