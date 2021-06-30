using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class TransactionRepository : CustomRepository<Transactions> {
		protected override DbSet<Transactions> collection { get; set; }

		public TransactionRepository() { }

		public TransactionRepository(DbContext context, DbSet<Transactions> collection) : base(context, collection) { }
	}
}