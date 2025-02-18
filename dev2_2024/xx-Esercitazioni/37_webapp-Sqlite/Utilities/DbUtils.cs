using System.Data.SQLite;
namespace _37_webapp_Sqlite.Utilities;

public static class DbUtils
{
    /// <summary>
    /// Esegue una query che non restituisce dati (INSERT, UPDATE, DELETE).
    /// </summary>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParametres">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il numero di righe interessate.</returns>
    // Uso Action per passare un metodo come parametro (in questo caso command) 
    public static int ExecuteNonQuery(string sql, Action<SQLiteCommand> setupParametres = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        setupParametres?.Invoke(command); // il metodo Invoke esegue il delegate setupParametres cioe la funzione che gli passiamo
        return command.ExecuteNonQuery();
    }
    /// <summary>
    /// Esegue una query che restituisce un valore scalare.
    /// </summary>
    /// <typeparam name="T">Il tipo del valore atteso.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="setupParametres">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Il valore restituito convertito al tipo T.</returns>

    public static T ExecuteScalar<T>(string sql, Action<SQLiteCommand> setupParametres = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        setupParametres?.Invoke(command);
        var result = command.ExecuteScalar();
        if (result == null || result == DBNull.Value)
        return default(T);
        return (T)Convert.ChangeType(result, typeof(T));

    }

    /// <summary>
    /// Esegue una query che restituisce più righe e le converte in una lista di oggetti di tipo T.
    /// </summary>
    /// <typeparam name="T">Il tipo di oggetto da restituire per ogni riga.</typeparam>
    /// <param name="sql">La query SQL.</param>
    /// <param name="converter">Funzione per convertire una riga (SqliteDataReader) in un oggetto T.
    /// <param name="setupParametres">Opzionale: callback per aggiungere parametri al comando.</param>
    /// <returns>Una lista di oggetti di tipo T.</returns>

    public static List<T> ExecuteReader<T>(string sql, Func<SQLiteDataReader, T> converter, Action<SQLiteCommand> setupParametres = null)
    {
        var list = new List<T>();
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        setupParametres?.Invoke(command);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(converter(reader));
        }
        return list;
    }
}


// int count = DbUtils.ExecuteScalar<int>("SELECT COUNT(*) FROM PRODOTTI");