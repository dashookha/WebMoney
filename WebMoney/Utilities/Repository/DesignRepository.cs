using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class DesignRepository : CustomRepository<Design> {
		protected override DbSet<Design> collection { get; set; }

		public DesignRepository() { }

		public DesignRepository(DbContext context, DbSet<Design> collection) : base(context, collection) { }
	}
}