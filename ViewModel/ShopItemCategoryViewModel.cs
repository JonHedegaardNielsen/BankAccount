using BankAccount.Database;
using ReactiveUI;
using System;
using System.ComponentModel;
using System.Reactive;
namespace BankAccount;

public class ShopItemCategoryViewModel : ReactiveObject
{
	public ReactiveCommand<int, Unit> UpdateDataCommand;

	private SpendingCategory _category;
	public SpendingCategory Category
	{
		get => _category;
		set => this.RaiseAndSetIfChanged(ref _category, value);
	}

	private int _amountBought;
	public int AmountBought
	{
		get => _amountBought;
		set => this.RaiseAndSetIfChanged(ref _amountBought, value);
	}

	private decimal _amountSpent;
	public decimal AmountSpent
	{
		get => _amountSpent;
		set => this.RaiseAndSetIfChanged(ref _amountSpent, value);
	}

    public ShopItemCategoryViewModel(SpendingCategory category)
    {
        Category = category;
    }

	public void UpdateData(int bankAccountId)
	{
		AmountBought = TransactionDatabase.Instance.GetCategoryCount(Category, bankAccountId);
		AmountSpent = TransactionDatabase.Instance.GetUserExpensesOfCategory(Category, bankAccountId);
	}
}
