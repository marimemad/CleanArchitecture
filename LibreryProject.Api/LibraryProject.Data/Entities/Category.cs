using LibraryProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Data.Entities
{
    public class Category : GeneralLocalizationEntity
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(500)]
        public string NameAr { get; set; }
        [StringLength(500)]
        public string NameEn { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
