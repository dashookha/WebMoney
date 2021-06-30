using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	[Table("User")]
	public partial class User : IEntity {
		public User() {
			Accounts = new HashSet<Accounts>();
		}
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		public string Email { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Accounts> Accounts { get; set; }
	}
}
