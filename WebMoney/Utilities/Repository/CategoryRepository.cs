using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class CategoryRepository : CustomRepository<Categories> {
		protected override DbSet<Categories> collection { get; set; }

		public CategoryRepository() { }

		public CategoryRepository(DbContext context, DbSet<Categories> collection) : base(context, collection) { }
	}
}