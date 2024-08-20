using LibraryProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Data.Entities
{
    public class Book : GeneralLocalizationEntity
    {
        [Key]
        public int BookID { get; set; }
        [StringLength(200)]
        public string NameAr { get; set; }
        [StringLength(200)]
        public string NameEn { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Publisher { get; set; }
        [StringLength(500)]
        public string Auther { get; set; }
        public DateTime PublishDate { get; set; }
        public int NCopies { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Borrowing> Borrowings { get; set; } = new HashSet<Borrowing>();
    }
}
