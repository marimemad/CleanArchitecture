using LibraryProject.Core.Wrappers;

namespace LibraryProject.Core.Features.BookFeature.Queries.Responses
{
    public class GetBookByIdResponce
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Auther { get; set; }
        public DateTime PublishDate { get; set; }
        public int NCopies { get; set; }
        public virtual PaginatedResult<BorrowingResponce> BorrowingsList { get; set; }
        public virtual ICollection<CategoryResponce> Categories { get; set; } = new HashSet<CategoryResponce>();
    }

    public class CategoryResponce
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }

    public class BorrowingResponce
    {
        public int BorrowingID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public string BorrowingUser { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public BorrowingResponce(int borrowingID, int userID, int bookID, string borrowingUser, DateTime borrowDate, DateTime returnDate)
        {
            BorrowingID = borrowingID;
            UserID = userID;
            BookID = bookID;
            BorrowingUser = borrowingUser;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }
    }
}
