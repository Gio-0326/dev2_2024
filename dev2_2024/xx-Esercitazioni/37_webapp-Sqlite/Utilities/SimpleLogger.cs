using System.IO;
namespace _37_webapp_Sqlite.Utilities;

public static class SimpleLogger
{
    // percorso del file di Log (puoi modificare il percorso se necessario)
    private static readonly string logFilePath = "log.txt";
    /// <summary>
    /// Registra un messaggio nel file di log con data e ora.
    /// </summary>
    /// <param name="message">Il messaggio da loggare</param>

    public static void Log(string message)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(logFilePath, append: true);
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
        catch (Exception)
        {
            // Se il logging fallisce, l'errore viene ignorato.
        }
    }
    /// <summary>
    /// Registra un'eccezione nel file di log.
    /// </summary>
    /// <param name="ex">L'eccezzione da loggare</param>
    public static void Log(Exception ex)
    {
        Log($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
    }
}
