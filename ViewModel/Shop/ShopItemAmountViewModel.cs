using ReactiveUI;

namespace BankAccount;

public class ShopItemAmountViewModel : ReactiveObject
{
    private ShopItem ShopItem;
    public ShopItemType Name => ShopItem.Name;
    public decimal Price => ShopItem.Price;
    public int Amountbought => ShopItem.Amountbought;
    public decimal AmountSpent => ShopItem.TotalAmountSpent;
    public SpendingCategory Category => ShopItem.Category;

    public ShopItemAmountViewModel(ShopItem shopItem)
    {
        ShopItem = shopItem;
    }
}
