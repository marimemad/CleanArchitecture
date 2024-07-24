using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
