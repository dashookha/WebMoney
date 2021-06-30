using WebMoney.Utilities.DAL;
using WebMoney.Utilities.Models;
using WebMoney.Utilities.Repository;

namespace WebMoney.Utilities.Utils {
	public class EFUnitOfWork : IUnitOfWork {
		public MoneyContext context { get; set; } = new MoneyContext();

		private IRepository<Accounts> a;
		public IRepository<Accounts> Account {
			get {
				if (a == null) a = new AccountRepository(context, context.Accounts);
				return a;
			}
			private set { }
		}

		private IRepository<BankCards> ba;
		public IRepository<BankCards> BankCard {
			get {
				if (ba == null) ba = new BankCardRepository(context, context.BankCards);
				return ba;
			}
			private set { }
		}

		private IRepository<Cash> ch;
		public IRepository<Cash> Cash {
			get {
				if (ch == null) ch = new CashRepository(context, context.Cash);
				return ch;
			}
			private set { }
		}

		private IRepository<Categories> cy;
		public IRepository<Categories> Category {
			get {
				if (cy == null) cy = new CategoryRepository(context, context.Categories);
				return cy;
			}
			private set { }
		}

		private IRepository<Currency> cr;
		public IRepository<Currency> Currency {
			get {
				if (cr == null) cr = new CurrencyRepository(context, context.Currency);
				return cr;
			}
			private set { }
		}

		private IRepository<Design> d;
		public IRepository<Design> Design {
			get {
				if (d == null) d = new DesignRepository(context, context.Design);
				return d;
			}
			private set { }
		}

		private IRepository<InterestAccounts> ia;
		public IRepository<InterestAccounts> InterestAccount {
			get {
				if (ia == null) ia = new InterestAccountRepository(context, context.InterestAccounts);
				return ia;
			}
			private set { }
		}

		private IRepository<Transactions> t;
		public IRepository<Transactions> Transaction {
			get {
				if (t == null) t = new TransactionRepository(context, context.Transactions);
				return t;
			}
			private set { }
		}

		private IRepository<User> u;
		public IRepository<User> User {
			get {
				if (u == null) u = new UserRepository(context, context.User);
				return u;
			}
			private set { }
		}

		public void Save() {
			context.SaveChanges();
		}
	}
}