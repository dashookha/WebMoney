using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMoney.Utilities.Models;
using WebMoney.Utilities.Utils;

namespace WebMoney.Controllers {
	public class HomeController : Controller {
		private readonly IUnitOfWork db;

		public HomeController(IUnitOfWork db) {
			this.db = db;
		}

		[HttpGet]
		public ActionResult Index() {
			return View(new User());
		}
		[HttpPost]
		public ActionResult Index(User user) {
			// Создать объект cookie-набора
			HttpCookie cookie = new HttpCookie("My localhost cookie");

			var u = db.User.GetList();
			var mail = u.FirstOrDefault(x => x.Username == user.Username);
			if (mail != null && mail.Password == user.Password) {
				// Установить значения в нем
				cookie["Username"] = user.Username;
				cookie["Password"] = user.Password;

				// Добавить куки в ответ
				Response.Cookies.Add(cookie);

				return RedirectToRoute(new { controller = "Category", action = "Index" });
			}
			return View();
		}

		[HttpGet]
		public ActionResult Registration() {
			User u = new User();
			return View(u);
		}

		[HttpPost]
		public ActionResult Registration(User user) {
			if (ModelState.IsValid) {
				db.User.Create(user);
				db.Save();
				return RedirectToRoute(new { controller = "Category", action = "Index" });
			}
			return View();
		}

		public ActionResult Exit() {
			return View("Index");
		}

		public ActionResult Analytics() {
			ViewModel model = new ViewModel {
				Account = db.Account.GetList(),
				Category = db.Category.GetList(),
				Design = db.Design.GetList(),
				Transaction = db.Transaction.GetList().OrderByDescending(d => d.Datetime),
				User = db.User.GetList()
			};
			return View(model);
		}
	}
}