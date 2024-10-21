using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
	public class BankAccountViewModel : ReactiveObject
	{
		public ReactiveCommand<Unit, Unit> AddMoneyCommand { get; }
        private readonly BankAccount BankAccount;
        private decimal _balance;
        public decimal Balance
        {
            get => _balance; 
            set => this.RaiseAndSetIfChanged(ref _balance, value);
        }

        public string Name => BankAccount.Name;
        public int Id => BankAccount.Id;



        public BankAccountViewModel(BankAccount bankAccount)
        {
            BankAccount = bankAccount;
            Balance = bankAccount.Balance;
            AddMoneyCommand = ReactiveCommand.Create(AddMoney);
        }

        private void AddMoney()
        {
			BankAccount.Balance += 10;
            Balance = BankAccount.Balance;
            BankAccountDatabase.Instance.UpdateBalance(BankAccount.Id, BankAccount.Balance);
		}
	}
}
