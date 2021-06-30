using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class InterestAccountRepository : CustomRepository<InterestAccounts> {
		protected override DbSet<InterestAccounts> collection { get; set; }

		public InterestAccountRepository() { }

		public InterestAccountRepository(DbContext context, DbSet<InterestAccounts> collection) : base(context, collection) { }
	}
}