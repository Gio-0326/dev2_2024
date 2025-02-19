namespace _37_webapp_Sqlite.Utilities;
public static class FrontendUtils
{
    /// <summary>
    /// Restituisce "active" se currentPage è uguale a expectedPage (ignorando il case), altrimenti una stringa vuota.
    /// </summary>
    public static string ActiveClass(string currentPage, string expectedPage)
    {
        return currentPage.Equals(expectedPage, StringComparison.OrdinalIgnoreCase) ? "active" : "";
    }
}