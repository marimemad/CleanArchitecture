using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Entities
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Publisher { get; set; }
        [StringLength(500)]
        public string Auther { get; set; }
        public DateTime PublishDate { get; set; }
        public int NCopies { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
