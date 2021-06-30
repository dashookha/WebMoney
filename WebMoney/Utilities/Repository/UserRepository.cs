using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	internal class UserRepository : CustomRepository<User> {
		protected override DbSet<User> collection { get; set; }

		public UserRepository() { }

		public UserRepository(DbContext context, DbSet<User> collection) : base(context, collection) { }
	}
}