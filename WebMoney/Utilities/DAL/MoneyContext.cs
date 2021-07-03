using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.DAL {
	public class MoneyContext : DbContext {
		public MoneyContext() : base("HBEntities") { }

		public virtual DbSet<Accounts> Accounts { get; set; }
		public virtual DbSet<BankCards> BankCards { get; set; }
		public virtual DbSet<Cash> Cash { get; set; }
		public virtual DbSet<Categories> Categories { get; set; }
		public virtual DbSet<Currency> Currency { get; set; }
		public virtual DbSet<Design> Design { get; set; }
		public virtual DbSet<InterestAccounts> InterestAccounts { get; set; }
		public virtual DbSet<Transactions> Transactions { get; set; }
		public virtual DbSet<User> User { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<Accounts>()
				.HasMany(e => e.BankCards)
				.WithRequired(e => e.Accounts)
				.HasForeignKey(e => e.Account_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Accounts>()
				.HasMany(e => e.Cash)
				.WithRequired(e => e.Accounts)
				.HasForeignKey(e => e.Account_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Accounts>()
				.HasMany(e => e.InterestAccounts)
				.WithRequired(e => e.Accounts)
				.HasForeignKey(e => e.Account_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Accounts>()
				.HasMany(e => e.Transactions)
				.WithRequired(e => e.Accounts)
				.HasForeignKey(e => e.Account_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Accounts>()
				.Property(e => e.Design_Id)
				.IsOptional();

			modelBuilder.Entity<Categories>()
				.HasMany(e => e.Transactions)
				.WithRequired(e => e.Categories)
				.HasForeignKey(e => e.Category_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Currency>()
				.HasMany(e => e.Accounts)
				.WithRequired(e => e.Currency)
				.HasForeignKey(e => e.Currency_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Currency>()
				.HasMany(e => e.Transactions)
				.WithRequired(e => e.Currency)
				.HasForeignKey(e => e.Currency_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Design>()
				.HasMany(e => e.Accounts)
				.WithOptional(e => e.Design)
				.HasForeignKey(e => e.Design_Id)
				.WillCascadeOnDelete(false);


			modelBuilder.Entity<Design>()
				.HasMany(e => e.Categories)
				.WithRequired(e => e.Design)
				.HasForeignKey(e => e.Design_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Accounts)
				.WithRequired(e => e.User)
				.HasForeignKey(e => e.User_Id)
				.WillCascadeOnDelete(false);

			Database.SetInitializer(new MoneyInitializer()); //Ініціалізатор бази даних
		}
	}
}