using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	public partial class BankCards : IEntity {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[Required]
		public string Merchant { get; set; }
		public string CardNumber { get; set; }
		public string CreditLimit { get; set; }

		public int Account_Id { get; set; }

		public virtual Accounts Accounts { get; set; }
	}
}
