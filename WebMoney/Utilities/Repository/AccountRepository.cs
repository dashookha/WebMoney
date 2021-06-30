using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class AccountRepository : CustomRepository<Accounts> {
		protected override DbSet<Accounts> collection { get; set; }

		public AccountRepository() { }

		public AccountRepository(DbContext context, DbSet<Accounts> collection) : base(context, collection) { }
	}
}