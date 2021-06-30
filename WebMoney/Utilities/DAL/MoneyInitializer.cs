using System;
using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.DAL {
	internal class MoneyInitializer : DropCreateDatabaseAlways<MoneyContext> {
		protected override void Seed(MoneyContext context) {
			User user1 = new User {
				Id = 1,
				Username = "Example",
				Password = "123123",
				Email = "example@gmail.com"
			};

			Accounts account1 = new Accounts {
				Id = 1,
				Name = "Наличные",
				Balance = 10,
				User_Id = 1
			};
			Accounts account2 = new Accounts {
				Id = 2,
				Name = "Карта",
				Balance = 0,
				User_Id = 1
			};
			Cash cash1 = new Cash {
				Id = 1,
				Account_Id = 1
			};
			BankCards bankcard = new BankCards {
				Id = 2,
				Account_Id = 2
			};

			Design design1 = new Design {
				Id = 1,
				Name = "Транспорт",
				Picture = "~/Graphic/img/bus.png",
				Color = "#f8d6a3"
			};
			Design design2 = new Design {
				Id = 2,
				Name = "Продукты",
				Picture = "~/Graphic/img/cart.png",
				Color = "#a1cff7"
			};
			Design design3 = new Design {
				Id = 3,
				Name = "Покупки",
				Picture = "~/Graphic/img/e-commerce.png",
				Color = "#bcaba4"
			};
			Design design4 = new Design {
				Id = 4,
				Name = "Здоровье",
				Picture = "~/Graphic/img/consultation.png",
				Color = "#a6d6af"
			};
			Design design5 = new Design {
				Id = 5,
				Name = "Досуг",
				Picture = "~/Graphic/img/video (2).png",
				Color = "#f8a3c0"
			};


			Categories category1 = new Categories {
				Id = 1,
				Design_Id = 1
			};
			Categories category2 = new Categories {
				Id = 2,
				Design_Id = 2
			};
			Categories category3 = new Categories {
				Id = 3,
				Design_Id = 3
			};
			Categories category4 = new Categories {
				Id = 4,
				Design_Id = 4
			};
			Categories category5 = new Categories {
				Id = 5,
				Design_Id = 5
			};

			Transactions transaction1 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 28, 4, 9, 0),
				Amount = 3.02,
				Movement = "Перевод в свою «Копилку» 26**58. Округление остатка по карте до 10 UAH.",
				RemainingAmount = 0.00,
				Account_Id = 2,
				Category_Id = 5
			};
			Transactions transaction2 = new Transactions {
				Id = 2,
				Datetime = new DateTime(2021, 6, 27, 15, 38, 0),
				Amount = 131.79,
				Movement = "Железнодорожные билеты: Filiya GIOC AT, ID платежа 1688976324",
				RemainingAmount = 3.02,
				Account_Id = 2,
				Category_Id = 1
			};
			Transactions transaction3 = new Transactions {
				Id = 3,
				Datetime = new DateTime(2021, 6, 27, 15, 37, 0),
				Amount = 34.81,
				Movement = "Перевод от DARIA LIAKHOVSKA",
				RemainingAmount = 134.81,
				Account_Id = 2,
				Category_Id = 5
			};
			Transactions transaction4 = new Transactions {
				Id = 4,
				Datetime = new DateTime(2021, 6, 26, 21, 54, 0),
				Amount = 100.00,
				Movement = "Перевод с карты ПриватБанка через приложение Приват24. Отправитель: Біда Наталія Анатоліївна",
				RemainingAmount = 100.00,
				Account_Id = 2,
				Category_Id = 5
			};
			Transactions transaction5 = new Transactions {
				Id = 5,
				Datetime = new DateTime(2021, 6, 23, 16, 51, 0),
				Amount = 500.00,
				Movement = "Перевод со своей карты",
				RemainingAmount = 0.00,
				Account_Id = 2,
				Category_Id = 5
			};
			Transactions transaction6 = new Transactions {
				Id = 6,
				Datetime = new DateTime(2021, 6, 23, 16, 49, 0),
				Amount = 500.00,
				Movement = "Перевод с карты ПриватБанка через приложение Приват24. Отправитель: Біда Наталія Анатоліївна",
				RemainingAmount = 500.00,
				Account_Id = 2,
				Category_Id = 5
			};
			Transactions transaction7 = new Transactions {
				Id = 7,
				Datetime = new DateTime(2021, 6, 18, 12, 33, 0),
				Amount = 25.35,
				Movement = "Продукты: АШАН 015, Київ, вул. Горького, 176",
				RemainingAmount = 0.00,
				Account_Id = 2,
				Category_Id = 2
			};
			Transactions transaction8 = new Transactions {
				Id = 8,
				Datetime = new DateTime(2021, 6, 16, 23, 59, 0),
				Amount = 28.14,
				Movement = "ВОЗВРАТ ТОВАРА",
				RemainingAmount = 25.35,
				Account_Id = 2,
				Category_Id = 3
			};

			context.User.AddRange(new[] { user1 });
			context.Accounts.AddRange(new[] { account1 });
			context.Cash.AddRange(new[] { cash1 });
			context.Design.AddRange(new[] { design1, design2, design3, design4, design5 });
			context.Categories.AddRange(new[] { category1, category2, category3, category4, category5 });
			context.Transactions.AddRange(new[] { transaction1, transaction2, transaction3, transaction4, transaction5, transaction6, transaction7, transaction8 });

			base.Seed(context);
		}
	}
}