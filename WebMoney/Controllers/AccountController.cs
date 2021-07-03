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

		public ActionResult AccountsCash(int Id) {
			Accounts account = db.Account.GetById(Id);
			ViewBag.i = Id;
			model = new ViewModel {
				Account = db.Account.GetList(),
				Cash = db.Cash.GetList(),
				InterestAccount = db.InterestAccount.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};

			return View(account);
		}

		[HttpGet]
		public ActionResult AddAccount() {
			Accounts account = new Accounts();
			return View(account);
		}

		[HttpPost]
		public ActionResult AddAccount(Accounts account) {
			account.Id = db.Account.GetList().Count + 1;

			db.Account.Create(account);

			Cash cash = new Cash() {
				Id = db.Cash.GetList().Count + 1,
				Account_Id = account.Id
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

		public ActionResult BankAccounts(int Id) {
			return View(db.Account.GetById(Id));
		}

		public ActionResult AccountsContribution() {
			return View(model);
		}

		public ActionResult AccountsCredit() {
			return View(model);
		}
	}
}