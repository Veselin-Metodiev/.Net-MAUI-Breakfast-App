namespace BreakfastApp
{
    public static class Constants
    {
        // Database
        public const string DatabaseFilename = "Breakfasts.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        //Alerts
        public const string IncorrectDataTitle = "Incorrect Data!";
        public const string IncorrectDataMessage = "Please make sure you don't leave empty fields";
        public const string IncorrectDataBtnText = "OK";

        public const string IncorrectUriTitle = "Incorrect Image Uri!";
        public const string IncorrectUriMessage = "The URI you have provided is incorrect";
        public const string IncorrectUriBtnText = "OK";
    }
}
