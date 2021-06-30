using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class BankCardRepository : CustomRepository<BankCards> {
		protected override DbSet<BankCards> collection { get; set; }

		public BankCardRepository() { }

		public BankCardRepository(DbContext context, DbSet<BankCards> collection) : base(context, collection) { }
	}
}