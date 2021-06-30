using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.DAL {
	public class MoneyContext : DbContext {
		public MoneyContext() : base("MoneyEntities") { }

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

			Database.SetInitializer(new MoneyInitializer()); //Ініціалізатор бази даних

			modelBuilder.Entity<Accounts>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Accounts>()
				.Property(e => e.Status)
				.IsFixedLength();

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

			modelBuilder.Entity<BankCards>()
				.Property(e => e.Merchant)
				.IsUnicode(false);

			modelBuilder.Entity<BankCards>()
				.Property(e => e.CardNumber)
				.IsUnicode(false);

			modelBuilder.Entity<BankCards>()
				.Property(e => e.CreditLimit)
				.IsUnicode(false);

			modelBuilder.Entity<Categories>()
				.HasMany(e => e.Transactions)
				.WithRequired(e => e.Categories)
				.HasForeignKey(e => e.Category_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Currency>()
				.Property(e => e.First_СС)
				.IsUnicode(false);

			modelBuilder.Entity<Currency>()
				.Property(e => e.Second_СС)
				.IsUnicode(false);

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
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Design>()
				.Property(e => e.Picture)
				.IsUnicode(false);

			modelBuilder.Entity<Design>()
				.Property(e => e.Color)
				.IsUnicode(false);

			modelBuilder.Entity<Design>()
				.HasMany(e => e.Accounts)
				.WithRequired(e => e.Design)
				.HasForeignKey(e => e.Design_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Design>()
				.HasMany(e => e.Categories)
				.WithRequired(e => e.Design)
				.HasForeignKey(e => e.Design_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<InterestAccounts>()
				.Property(e => e.Type)
				.IsFixedLength();

			modelBuilder.Entity<Transactions>()
				.Property(e => e.Merchant)
				.IsUnicode(false);

			modelBuilder.Entity<Transactions>()
				.Property(e => e.Movement)
				.IsUnicode(false);

			modelBuilder.Entity<Transactions>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Transactions>()
				.Property(e => e.Channel)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.Property(e => e.Username)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.Property(e => e.Password)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Accounts)
				.WithRequired(e => e.User)
				.HasForeignKey(e => e.User_Id)
				.WillCascadeOnDelete(false);

		}
	}
}