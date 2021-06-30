using WebMoney.Utilities.DAL;
using WebMoney.Utilities.Models;
using WebMoney.Utilities.Repository;

namespace WebMoney.Utilities.Utils {
	public interface IUnitOfWork {
		MoneyContext context { get; }
		IRepository<Accounts> Account { get; }
		IRepository<BankCards> BankCard { get; }
		IRepository<Cash> Cash { get; }
		IRepository<Categories> Category { get; }
		IRepository<Currency> Currency { get; }
		IRepository<Design> Design { get; }
		IRepository<InterestAccounts> InterestAccount { get; }
		IRepository<Transactions> Transaction { get; }
		IRepository<User> User { get; }
		void Save();
	}
}