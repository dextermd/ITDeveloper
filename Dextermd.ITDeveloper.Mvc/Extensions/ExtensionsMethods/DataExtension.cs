namespace Dextermd.ITDeveloper.Mvc.Extensions.ExtensionsMethods
{
    public static class DataExtension
    {
        public static string ToMoldavianDate(this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy");
        }

        public static string ToMoldavianDateTime(this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
