using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using WebMoney.Utilities.Models;
using WebMoney.Utilities.Repository;

namespace WebMoney.Utilities.Utils {
	public class AutofacRegistraion {
		public static void ConfigureContainer() {
			// получаем экземпляр контейнера
			var builder = new ContainerBuilder();

			// регистрируем контроллер в текущей сборке
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			// регистрируем споставление типов
			builder.RegisterType<AccountRepository>().As<IRepository<Accounts>>().SingleInstance();
			builder.RegisterType<BankCardRepository>().As<IRepository<BankCards>>().SingleInstance();
			builder.RegisterType<CashRepository>().As<IRepository<Cash>>().SingleInstance();
			builder.RegisterType<CategoryRepository>().As<IRepository<Categories>>().SingleInstance();
			builder.RegisterType<CurrencyRepository>().As<IRepository<Currency>>().SingleInstance();
			builder.RegisterType<DesignRepository>().As<IRepository<Design>>().SingleInstance();
			builder.RegisterType<InterestAccountRepository>().As<IRepository<InterestAccounts>>().SingleInstance();
			builder.RegisterType<TransactionRepository>().As<IRepository<Transactions>>().SingleInstance();
			builder.RegisterType<UserRepository>().As<IRepository<User>>().SingleInstance();

			builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().SingleInstance();

			// создаем новый контейнер с теми зависимостями, которые определены выше
			var container = builder.Build();

			// установка сопоставителя зависимостей
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}

	}
}
