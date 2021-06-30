using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	public partial class Transactions : IEntity {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[Required]
		public string Merchant { get; set; }
		public DateTime Datetime { get; set; }
		public double Amount { get; set; } //Сумма
		[Required]
		public string Movement { get; set; } //Движение
		public double RemainingAmount { get; set; } //Оставшаяся сумма
		public string Description { get; set; }
		public string Channel { get; set; }

		public int Account_Id { get; set; }
		public int Currency_Id { get; set; }
		public int Category_Id { get; set; }

		public virtual Accounts Accounts { get; set; }
		public virtual Categories Categories { get; set; }
		public virtual Currency Currency { get; set; }
	}
}
