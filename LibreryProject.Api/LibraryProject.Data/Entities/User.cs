using LibraryProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Data.Entities
{
    public class User : GeneralLocalizationEntity
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(200)]
        public string NameAr { get; set; }
        [StringLength(200)]
        public string NameEn { get; set; }
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
