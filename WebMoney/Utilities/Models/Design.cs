using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	[Table("Design")]
	public partial class Design : IEntity {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Design() {
			Accounts = new HashSet<Accounts>();
			Categories = new HashSet<Categories>();
		}

		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
		public string Color { get; set; }

		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Accounts> Accounts { get; set; }
		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Categories> Categories { get; set; }
	}
}
