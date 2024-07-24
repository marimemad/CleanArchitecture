using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Gender { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Borrowing> Borrowing { get; set; } = new HashSet<Borrowing>();
    }
}
