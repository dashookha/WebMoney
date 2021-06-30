using System.Collections.Generic;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Utils {
	public class ViewModel {
		public IEnumerable<Accounts> Account { get; set; }
		public IEnumerable<BankCards> BankCard { get; set; }
		public IEnumerable<Cash> Cash { get; set; }
		public IEnumerable<Categories> Category { get; set; }
		public IEnumerable<Currency> Currency { get; set; }
		public IEnumerable<Design> Design { get; set; }
		public IEnumerable<InterestAccounts> InterestAccount { get; set; }
		public IEnumerable<Transactions> Transaction { get; set; }
		public IEnumerable<User> User { get; set; }
	}
}