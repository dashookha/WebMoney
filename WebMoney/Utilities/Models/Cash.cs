using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	[Table("Cash")]
	public partial class Cash : IEntity {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public int Account_Id { get; set; }

		public virtual Accounts Accounts { get; set; }
	}
}
