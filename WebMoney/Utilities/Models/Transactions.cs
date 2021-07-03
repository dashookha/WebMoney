using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	public partial class Transactions : IEntity {
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public DateTime Datetime { get; set; } //Дата транзакции
		public double Amount { get; set; } //Сумма и валюта транзакции
		//true отчисление   false   поступление
		public bool Movement { get; set; } //Движение по карте в валюте карты
		public double RemainingAmount { get; set; } //Сумма остатка и валюта после транзакции
		public string Description { get; set; } //Детали (описание транзакции)
		public string Channel { get; set; } //Канал, через который была произведена операция и его местоположение
		[ForeignKey("Accounts")]
		public int Account_Id { get; set; }
		[ForeignKey("Currency")]
		public int Currency_Id { get; set; }
		[ForeignKey("Categories")]
		public int Category_Id { get; set; }

		public virtual Accounts Accounts { get; set; }
		public virtual Categories Categories { get; set; }
		public virtual Currency Currency { get; set; }
	}
}


/*
<statements status="excellent" credit="0.0" @*Сумма поступлений*@ debet="0.3" @*Сумма отчислений*@>
	<statement card="5168742060221193" @*Номер карты*@
			   appcode="591969"
			   trandate="2013-09-02" @*Дата транзакции*@
			   amount="0.10 UAH" @*Сумма и валюта транзакции*@
			   cardamount="-0.10 UAH" @*Движение по карте в валюте карты*@
			   rest="0.95 UAH" @*Сумма остатка и валюта после транзакции*@
			   terminal="Пополнение мобильного +380139917053 через «Приват24»" @*Канал, через который была произведена операция и его местоположение*@
			   description="" /> @*Детали (описание транзакции)*@
		</statements>
*/