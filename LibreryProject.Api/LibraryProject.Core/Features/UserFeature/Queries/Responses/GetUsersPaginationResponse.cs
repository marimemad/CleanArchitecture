namespace LibraryProject.Core.Features.UserFeature.Queries.Responses
{
    public class GetUsersPaginationResponse
    {
        public int UserID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public GetUsersPaginationResponse(int userID, string nameAr, string nameEn, string email, string gender, int age)
        {
            UserID = userID;
            Email = email;
            Gender = gender;
            Age = age;
            NameEn = nameEn;
            NameAr = nameAr;
        }
    }
}
