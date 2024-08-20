using System.Globalization;

namespace LibraryProject.Data.Commons
{
    public class GeneralLocalizationEntity
    {
        public string LocalizeName(string textAr, string textEN)
        {
            CultureInfo CultureInfo = Thread.CurrentThread.CurrentCulture;
            if (CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEN;
        }
    }
}
