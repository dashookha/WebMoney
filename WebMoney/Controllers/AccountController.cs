using System.Linq;
using System.Web.Mvc;
using WebMoney.Utilities.Models;
using WebMoney.Utilities.Utils;

namespace WebMoney.Controllers {
	public class AccountController : Controller {
		// GET: Account
		private readonly IUnitOfWork db;
		private ViewModel model;

		public AccountController(IUnitOfWork db) {
			this.db = db;
			model = new ViewModel {
				Account = db.Account.GetList(),
				Cash = db.Cash.GetList(),
				InterestAccount = db.InterestAccount.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};
		}

		public ActionResult Index() {
			return View(model);
		}

		/*----------------------CASH----------------------*/
		[HttpGet]
		public ActionResult AddCash() {
			Accounts account = new Accounts();
			return View(account);
		}

		[HttpPost]
		public ActionResult AddCash(Accounts account) {
			account.Id = db.Account.GetList().Count + 1;

			db.Account.Create(account);

			Cash cash = new Cash() {
				Id = db.Cash.GetList().Count + 1,
				Accounts = account
			};

			db.Cash.Create(cash);

			db.Save();

			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Cash = db.Cash.GetList(),
				InterestAccount = db.InterestAccount.GetList(),
				User = db.User.GetList()
			};
			return View("Index", model);
		}

		/*----------------------BANKCARD----------------------*/
		[HttpGet]
		public ActionResult AddBankCard() {
			Accounts account = new Accounts();
			return View(account);
		}

		[HttpPost]
		public ActionResult AddBankCard(Accounts account) {
			account.Id = db.Account.GetList().Count + 1;

			db.Account.Create(account);

			Cash cash = new Cash() {
				Id = db.Cash.GetList().Count + 1,
				Accounts = account
			};

			db.Cash.Create(cash);

			db.Save();

			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Cash = db.Cash.GetList(),
				InterestAccount = db.InterestAccount.GetList(),
				User = db.User.GetList()
			};
			return View("Index", model);
		}

		/*----------------------CONTRIBUTION----------------------*/
		[HttpGet]
		public ActionResult AddContribution() {
			Accounts account = new Accounts();
			return View(account);
		}

		[HttpPost]
		public ActionResult AddContribution(Accounts account) {
			account.Id = db.Account.GetList().Count + 1;

			db.Account.Create(account);

			Cash cash = new Cash() {
				Id = db.Cash.GetList().Count + 1,
				Accounts = account
			};

			db.Cash.Create(cash);

			db.Save();

			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Cash = db.Cash.GetList(),
				InterestAccount = db.InterestAccount.GetList(),
				User = db.User.GetList()
			};
			return View("Index", model);
		}

		/*----------------------CREDIT----------------------*/
		[HttpGet]
		public ActionResult AddCredit() {
			Accounts account = new Accounts();
			return View(account);
		}

		[HttpPost]
		public ActionResult AddCredit(Accounts account) {
			account.Id = db.Account.GetList().Count + 1;

			db.Account.Create(account);

			Cash cash = new Cash() {
				Id = db.Cash.GetList().Count + 1,
				Accounts = account
			};

			db.Cash.Create(cash);

			db.Save();

			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Cash = db.Cash.GetList(),
				InterestAccount = db.InterestAccount.GetList(),
				User = db.User.GetList()
			};
			return View("Index", model);
		}
	}
}