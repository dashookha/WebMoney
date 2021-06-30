using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	public partial class InterestAccounts : IEntity {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[MaxLength(1)]
		public byte[] Type { get; set; }
		public DateTime? OpeningDate { get; set; }
		public double? Amount { get; set; }
		public int? Term { get; set; }
		public double? InterestRate { get; set; }
		public int? TransactionRate { get; set; }

		public int Account_Id { get; set; }

		public virtual Accounts Accounts { get; set; }
	}
}
