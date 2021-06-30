using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class CashRepository : CustomRepository<Cash> {
		protected override DbSet<Cash> collection { get; set; }

		public CashRepository() { }

		public CashRepository(DbContext context, DbSet<Cash> collection) : base(context, collection) { }
	}
}