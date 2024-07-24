using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Entities
{
    public class Borrowing
    {
        [Key]
        public int BorrowingID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
    }
}
