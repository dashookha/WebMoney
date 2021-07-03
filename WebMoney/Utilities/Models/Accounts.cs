using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	public partial class Accounts : IEntity {
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Accounts() {
			BankCards = new HashSet<BankCards>();
			Cash = new HashSet<Cash>();
			InterestAccounts = new HashSet<InterestAccounts>();
			Transactions = new HashSet<Transactions>();
		}

		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		//[MaxLength(1)]
		public bool Status { get; set; }
		public double? Balance { get; set; }
		
		public int? Design_Id { get; set; }
		[ForeignKey("Currency")]
		public int Currency_Id { get; set; }

		[ForeignKey("User")]
		public int User_Id { get; set; }

		public virtual Currency Currency { get; set; }
		[ForeignKey("Design_Id")]
		public virtual Design Design { get; set; }

		public virtual User User { get; set; }

		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<BankCards> BankCards { get; set; }
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Cash> Cash { get; set; }
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<InterestAccounts> InterestAccounts { get; set; }
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Transactions> Transactions { get; set; }
	}
}