using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class CurrencyRepository : CustomRepository<Currency> {
		protected override DbSet<Currency> collection { get; set; }

		public CurrencyRepository() { }

		public CurrencyRepository(DbContext context, DbSet<Currency> collection) : base(context, collection) { }
	}
}