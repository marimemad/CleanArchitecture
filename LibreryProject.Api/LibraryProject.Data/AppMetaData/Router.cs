namespace LibraryProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api/";
        public const string version = "V1/";
        public const string rule = root + version;

        public static class UserRouting
        {
            public const string prefix = rule + "User/";

            public const string List = prefix + "List/";
            public const string GetById = prefix + "{id}/";
            public const string Create = prefix + "Create/";
            public const string Edite = prefix + "Edite/";
            public const string Delete = prefix + "Delete/{id}";
            public const string Pagenated = prefix + "Pagenated";

        }

        public static class BookRouting
        {
            public const string prefix = rule + "Book/";

            public const string GetById = prefix + "id/";


        }
    }
}
