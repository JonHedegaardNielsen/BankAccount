using BankAccount.Database;
using ReactiveUI;
using System;
using System.ComponentModel;
using System.Reactive;
namespace BankAccount;

public class ShopItemCategoryViewModel : ReactiveObject
{
	private SpendingCategory _category;
	public SpendingCategory Category
	{
		get => _category;
		set => this.RaiseAndSetIfChanged(ref _category, value);
	}

	public int AmountBought => TransactionDatabase.Instance.GetCategoryCount(Category, BankUser.CurrentUser.Id);

	public decimal AmountSpent => TransactionDatabase.Instance.GetUserExpensesOfCategory(Category, BankUser.CurrentUser.Id);

    public ShopItemCategoryViewModel(SpendingCategory category)
    {
        Category = category;
    }
}
