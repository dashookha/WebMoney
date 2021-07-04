using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebMoney.Utilities.Models;
using WebMoney.Utilities.Utils;

namespace WebMoney.Controllers {
	public class TransactionController : Controller {
		// GET: Transaction
		private readonly IUnitOfWork db;

		public TransactionController(IUnitOfWork db) {
			this.db = db;
		}

		public ActionResult Index() {
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				Category = db.Category.GetList(),
				Design = db.Design.GetList()
			};
			return View(model);
		}

		public ActionResult ViewIndex() {
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				Category = db.Category.GetList(),
			};
			return View(model);
		}

		[HttpGet]
		public ActionResult AddTransaction() {
			Transactions transaction = new Transactions();
			return View(transaction);
		}
		[HttpPost]
		public ActionResult AddTransaction(Transactions transaction) {
			transaction.Id = db.Transaction.GetList().Count + 1;
			db.Transaction.Create(transaction);
			db.Save();
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				Category = db.Category.GetList(),
				User = db.User.GetList()
			};
			return View("Index", model);
		}

		[HttpGet]
		public ActionResult EditTransaction(int Id = -1) {
			if (Id == -1) return RedirectToAction("Index");
			else {
				Transactions transactions = db.Transaction.GetById(Id);
				return View(transactions);
			}
		}

		[HttpPost]
		public ActionResult EditTransaction(Transactions transactions) {
			if (ModelState.IsValid) {
				db.Transaction.Update(transactions);
				db.Save();
			}

			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Category = db.Category.GetList(),
				Design = db.Design.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};
			return View("Index", model);
		}


		[HttpDelete]
		public ActionResult DeleteT(int Id) {
			db.Transaction.Delete(Id);
			db.Save();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Search() {
			return View();
		}

		[HttpPost]
		public ActionResult Search(string str) {
			List<Transactions> transactions = db.Transaction.GetList();
			var d = from t in transactions where t.Datetime.ToShortDateString().Contains(str) select t;
			var o = from t in transactions where t.Description.Contains(str) select t;
			var s = from t in transactions where t.Amount.ToString().Contains(str) select t;

			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Transaction = o.OrderByDescending(i => i.Datetime),
				Category = db.Category.GetList(),
			};
			return View(model);
		}
	}
}