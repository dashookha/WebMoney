using System.Linq;
using System.Web.Mvc;
using WebMoney.Utilities.Models;
using WebMoney.Utilities.Utils;

namespace WebMoney.Controllers {
	public class CategoryController : Controller {
		// GET: Category
		private readonly IUnitOfWork db;
		private ViewModel model;

		public CategoryController(IUnitOfWork db) {
			this.db = db;
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Category = db.Category.GetList(),
				Design = db.Design.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};
		}

		public ActionResult Index() {
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Category = db.Category.GetList(),
				Design = db.Design.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};
			return View(model);
		}

		public ActionResult ViewIndex() {
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Category = db.Category.GetList(),
				Design = db.Design.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};
			return View(model);
		}

		public ActionResult CategoryCRUD() {
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Category = db.Category.GetList(),
				Design = db.Design.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};
			return View(model);
		}

		[HttpGet]
		public ActionResult AddCategories() {
			Categories category = new Categories();
			return View(category);
		}

		[HttpPost]
		public ActionResult AddCategories(Categories category) {
			category.Id = db.Category.GetList().Count + 1;
			if (ModelState.IsValid) {
				db.Category.Create(category);
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

		[HttpGet]
		public ActionResult EditCategories(int Id = -1) {
			if (Id == -1) return RedirectToAction("Index");
			else {
				Categories category = db.Category.GetById(Id);
				return View(category);
			}
		}

		[HttpPost]
		public ActionResult EditCategories(Categories category) {
			if (ModelState.IsValid) {
				db.Category.Update(category);
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
		public void DeleteCategories(int Id) {
			db.Category.Delete(Id);
			db.Save();
		}
	}
}