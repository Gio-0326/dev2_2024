using System.Data.SQLite;


public static class DatabaseInitializer
{
    private static string _connectionString = "Data Source=prodottiapp.db"; // utilizzeremo _connectionString in un modo da ottenere la connessione 

    public static void InitializeDatabase()
    {
        using var connection = new SQLiteConnection(_connectionString); // creiamo una connessione al db tramite using per garantire che venga chiusa correttamente

        connection.Open(); // apriamo la connessione

        // gestisco l'eccezione se il db esiste già in sql
        // Creazione tabella Categorie

        var createCategorieTable = @"     
        CREATE TABLE IF NOT EXISTS Categorie 
        (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nome TEXT NOT NULL
        );
        ";

        // lancio il comando sulla connessione che ho creato
        using (var command = new SQLiteCommand(createCategorieTable, connection))

        {
            command.ExecuteNonQuery(); // ExecuteNonQuery esegue la query ma il comando sql non ritorna niente
        }

        var createProdottiTable = @"     
        CREATE TABLE IF NOT EXISTS Prodotti 
        (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nome TEXT NOT NULL,
        Prezzo REAL NOT NULL,
        CategoriaId INTEGER,
        FOREIGN KEY(CategoriaId) REFERENCES Categorie(Id)
    );
    ";
        // lancio il comando sulla connessione che ho creato
        using (var command = new SQLiteCommand(createProdottiTable, connection))
        {
            command.ExecuteNonQuery();
        }

        // Seed dei dati per Categorie solo la prima volta
        // seleziono il numero di categorie presenti nel db
        var countCommand = new SQLiteCommand("SELECT COUNT(*) FROM Categorie", connection);

        // dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
        // execute scalar ritorna un oggetto quindi faccio il casting a long per ottenere il valore numerico
        var count = (long)countCommand.ExecuteScalar();

        // se il count è uguale a zero, allora non ci sono categorie nel db e posso fare il seed dei dati
        if (count == 0)
        {

            var insertCategorie = @"
                INSERT INTO Categorie (Nome) VALUES
                ('Elettronica'),
                ('Abbigliamento'),
                ('Casa');
                ";

            // lancio il comando sulla connessione che ho creato
            using (var command = new SQLiteCommand(insertCategorie, connection))

            {
                command.ExecuteNonQuery();
            }
        }

        // Seed dei dati per Prodotti (solo se non esistono già)
        countCommand = new SQLiteCommand("SELECT COUNT(*) FROM Prodotti", connection);
        count = (long)countCommand.ExecuteScalar();

        if (count == 0)
        {
            var insertProdotti = @"
                INSERT INTO Prodotti (Nome, Prezzo, CategoriaId) VALUES
                ('Telefono', 299.99, (SELECT Id FROM Categorie WHERE Nome = 'Elettronica')),
                ('Maglietta', 19.99, (SELECT Id FROM Categorie WHERE Nome = 'Abbigliamento')),
                ('Divano', 49.99, (SELECT Id FROM Categorie WHERE Nome = 'Casa'));
                ";

            // lancio il comando sulla connessione che ho creato
            using (var command = new SQLiteCommand(insertProdotti, connection))
            {
                command.ExecuteNonQuery();
            }
        }

    }

    // Metodo per ottenere la connessione al database in modo da poter essere utlizzato in altre parti del codice
    // oltretutto database initializer è una classe statica quindi posso chiamare questo modo senza creare un'istanza della classe
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(_connectionString); // in questo modo la connessione è creata ma non aperta pero puo essere utilizzata in altri metodi
    }
}



