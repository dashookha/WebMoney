using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	public partial class Categories : IEntity {
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Categories() {
			Transactions = new HashSet<Transactions>();
		}

		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[ForeignKey("Design")]
		public int Design_Id { get; set; }

		public virtual Design Design { get; set; }
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Transactions> Transactions { get; set; }
	}
}
