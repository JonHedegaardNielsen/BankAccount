﻿using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;

namespace BankAccount;

public class ShopMainViewModel : ReactiveObject
{
	private ShopItemType _itemType;
	public ObservableCollection<ShopItemAmountControl> ItemsAmountContols { get; } = new();
	private ShopItemType[] ShopItemTypes;
	private object? _currentPage;
	public object? CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

	private decimal _itemPrice;
	public decimal ItemPrice
	{
		get => _itemPrice;
		set => this.RaiseAndSetIfChanged(ref _itemPrice, value);
	}

	public ShopItemType ItemType
	{
		get => _itemType;
		set
		{
			this.RaiseAndSetIfChanged(ref _itemType, value);
			ItemPrice = ShopItem.ShopItemTypes[value].Price;
		}
	}

	private decimal _balance = ShopUser.CurrentUser.UserBankAccount.Balance;
	public decimal Balance
	{
		get => ShopUser.CurrentUser.UserBankAccount.Balance;
		set => this.RaiseAndSetIfChanged(ref _balance, value);
	}

	public ReactiveCommand<string,Unit> BuyItemCommand { get; }
	public ReactiveCommand<Unit, Unit> LogOutCommand { get; }
	public ReactiveCommand<Unit, Unit> DeleteUserCommand { get; }

	public ShopMainViewModel(object? currentPage)
	{
		CurrentPage = currentPage;
		LogOutCommand = ReactiveCommand.Create(LogOut);
		BuyItemCommand = ReactiveCommand.Create<string>(BuyItem);
		DeleteUserCommand = ReactiveCommand.Create(DeleteCurrentUser);

		ShopItemTypes = ShopItem.ShopItemTypes.Keys.ToArray();

		foreach (KeyValuePair<ShopItemType, ShopItem> shopItem in ShopItem.ShopItemTypes)
			ItemsAmountContols.Add(new(shopItem.Value));

	}

	private void BuyItem(string ItemType)
	{
		ShopItemType type = (ShopItemType)Enum.Parse(typeof(ShopItemType), ItemType);
		ShopUser.CurrentUser.BuyItem((ShopItemType)Enum.Parse(typeof(ShopItemType), ItemType));

		int index = Array.IndexOf(ShopItemTypes, type);
		ItemsAmountContols[index] = new(ShopItem.ShopItemTypes[type]);

		Balance -= ItemPrice;
	}

	private void LogOut()
	{
		ShopUser.CurrentUser.LogOut();
		CurrentPage = new LoginPage();
	}

	private void DeleteCurrentUser()
	{
		ShopUserDatabase.Instance.DeleteUserFromUserId(ShopUser.CurrentUser.Id);
		LogOut();
	}
}
