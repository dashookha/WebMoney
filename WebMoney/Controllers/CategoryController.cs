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
			Design design = new Design();
			return View(design);
		}

		[HttpPost]
		public ActionResult AddCategories(Design design) {
			design.Id = db.Design.GetList().Count + 1;

			db.Design.Create(design);

			Categories categories = new Categories() {
				Id = db.Category.GetList().Count + 1,
				Design = design
			};

			if (ModelState.IsValid) {
				db.Design.Create(design);
				db.Category.Create(categories);

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
				Design design = db.Design.GetById(Id);
				return View(design);
			}
		}

		[HttpPost]
		public ActionResult EditCategories(Design design) {
			if (ModelState.IsValid) {
				db.Design.Update(design);
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
			db.Design.Delete(Id);
			db.Category.Delete(Id);
			db.Save();
		}
	}
}