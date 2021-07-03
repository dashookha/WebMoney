using System;
using System.Data.Entity;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.DAL {
	//DropCreateDatabaseAlways
	//CreateDatabaseIfNotExists
	//DropCreateDatabaseIfModelChanges
	internal class MoneyInitializer : DropCreateDatabaseAlways<MoneyContext> {
		protected override void Seed(MoneyContext context) {
			Currency currency1 = new Currency {
				First_СС = "грн."
			};
			User user1 = new User {
				Id = 1,
				Username = "Example",
				Password = "123123",
				Email = "example@gmail.com"
			};

			Accounts account1 = new Accounts {
				Id = 1,
				Name = "Карта",
				Balance = 0,
				Status = true,
				Currency = currency1,
				User = user1
			}; 
			Accounts account2 = new Accounts {
				Id = 2,
				Name = "Наличные",
				Balance = 10,
				Currency = currency1,
				User = user1,
				Status = true
			};

			BankCards bankcard = new BankCards {
				Id = 1,
				Accounts = account1
			};
			Cash cash1 = new Cash {
				Id = 1,
				Accounts = account2
			};

			Design design1 = new Design {
				Id = 1,
				Name = "Зарплата",
				Picture = "atm.png",
				Color = "#a6d6af"
			};

			Design design2 = new Design {
				Id = 2,
				Name = "Путешествия",
				Picture = "bus.png",
				Color = "#f8d6a3"
			};
			Design design3 = new Design {
				Id = 3,
				Name = "Продукты",
				Picture = "cart.png",
				Color = "#a1cff7"
			};
			Design design4 = new Design {
				Id = 4,
				Name = "Сбережения",
				Picture = "moneybox.png",
				Color = "#bcaba4"
			};
			Design design5 = new Design {
				Id = 5,
				Name = "Переводы",
				Picture = "transfer.png",
				Color = "#f8a3c0"
			};


			Categories category1 = new Categories {
				Id = 1,
				Design = design1
			};
			Categories category2 = new Categories {
				Id = 2,
				Design = design2
			};
			Categories category3 = new Categories {
				Id = 3,
				Design = design3
			};
			Categories category4 = new Categories {
				Id = 4,
				Design = design4
			};
			Categories category5 = new Categories {
				Id = 5,
				Design = design5
			};

			Transactions transaction1 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 27, 15, 38, 0),
				Amount = 131.79,
				Movement = false,
				RemainingAmount = 3.02,
				Channel = "Железнодорожные билеты: Filiya GIOC AT, ID платежа 1688976324",
				Accounts = account1,
				Categories = category2,
				Currency = currency1
			};
			Transactions transaction2 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 27, 15, 37, 0),
				Amount = 34.81,
				Movement = true,
				RemainingAmount = 134.81,
				Channel = "Перевод от DARIA LIAKHOVSKA",
				Accounts = account1,
				Categories = category5,
				Currency = currency1
			};
			Transactions transaction3 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 18, 12, 33, 0),
				Amount = 21.00,
				Movement = false,
				RemainingAmount = 100.15,
				Channel = "Продукты: АШАН 015, Київ, вул. Горького, 176",
				Accounts = account1,
				Categories = category3,
				Currency = currency1
			};
			Transactions transaction4 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 18, 10, 51, 0),
				Amount = 25.32,
				Movement = false,
				RemainingAmount = 123.68,
				Channel = "Продукты: VELYKA KYSHENYA, Kyiv",
				Accounts = account1,
				Categories = category3,
				Currency = currency1
			};
			Transactions transaction5 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 18, 9, 15, 0),
				Amount = 10.00,
				Movement = false,
				RemainingAmount = 150.00,
				Channel = "Перевод на карту ПриватБанка через приложение Приват24. Получатель: Пакало Валерія Анатоліївна",
				Accounts = account1,
				Categories = category5,
				Currency = currency1
			};
			Transactions transaction6 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 17, 5, 43, 0),
				Amount = 4.32,
				Movement = false,
				RemainingAmount = 160.00,
				Channel = "Перевод в свою «Копилку» 26**58. Округление остатка по карте до 10 UAH.",
				Accounts = account1,
				Categories = category4,
				Currency = currency1
			};
			Transactions transaction7 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 16, 22, 46, 0),
				Amount = 8.41,
				Movement = false,
				RemainingAmount = 136.18,
				Channel = "Перевод на свою «Копилку» 26*58. 10% от расходов.",
				Accounts = account1,
				Categories = category4,
				Currency = currency1
			};
			Transactions transaction8 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 16, 22, 43, 0),
				Amount = 84.06,
				Movement = false,
				RemainingAmount = 144.59,
				Channel = "Продукты: Велика Кишеня, м.Київ, ш.Залiзничне, буд.57",
				Accounts = account1,
				Categories = category3,
				Currency = currency1
			};
			Transactions transaction9 = new Transactions {
				Id = 1,
				Datetime = new DateTime(2021, 6, 11, 23, 4, 0),
				Amount = 8.00,
				Movement = false,
				RemainingAmount = 11.20,
				Channel = "Услуги туризма и транспортных перевозок: KYIVSKYI METROPOLITEN, KYIV",
				Accounts = account1,
				Categories = category2,
				Currency = currency1
			};

			Transactions transaction10 = new Transactions {
				Id = 11,
				Datetime = new DateTime(2021, 6, 8, 15, 36, 0),
				Amount = 8.00,
				Movement = false,
				RemainingAmount = 20.48,
				Channel = "Услуги туризма и транспортных перевозок: KYIVSKYI METROPOLITEN, KYIV",
				Accounts = account1,
				Categories = category2,
				Currency = currency1
			};
			Transactions transaction11 = new Transactions {
				Id = 12,
				Datetime = new DateTime(2021, 6, 8, 15, 1, 0),
				Amount = 5.52,
				Movement = false,
				RemainingAmount = 28.48,
				Channel = "Перевод на свою «Копилку» 26*58. 10% от расходов.",
				Accounts = account1,
				Categories = category4,
				Currency = currency1
			};
			Transactions transaction12 = new Transactions {
				Id = 13,
				Datetime = new DateTime(2021, 6, 8, 14, 58, 0),
				Amount = 55.20,
				Movement = false,
				RemainingAmount = 34.00,
				Channel = "Продукты: MAGAZYN 0485, KYYIV",
				Accounts = account1,
				Categories = category3,
				Currency = currency1
			};
			Transactions transaction13 = new Transactions {
				Id = 14,
				Datetime = new DateTime(2021, 6, 29, 20, 20, 0),
				Amount = 8.00,
				Movement = false,
				RemainingAmount = 10.00,
				Channel = "Услуги туризма и транспортных перевозок: KYIVSKYI METROPOLITEN, KYIV",
				Accounts = account2,
				Categories = category2,
				Currency = currency1
			};

			context.User.AddRange(new[] { user1 });
			context.Accounts.AddRange(new[] { account1 });
			context.Cash.AddRange(new[] { cash1 });
			context.Design.AddRange(new[] { design1, design2, design3, design4, design5 });
			context.Categories.AddRange(new[] { category1, category2, category3, category4, category5 });
			context.Transactions.AddRange(new[] { transaction1, transaction2, transaction3, transaction4, transaction5, transaction6, 
				transaction7, transaction8, transaction9, transaction10, transaction11, transaction12, transaction13 });

			base.Seed(context);
		}
	}
}