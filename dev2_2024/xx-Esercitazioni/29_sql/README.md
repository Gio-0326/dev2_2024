## DA TERMINALE
sqlite3 database.db
.open database.db
CREATE TABLE prodotti (id INTEGER, nome TEXT);
INSERT INTO prodotti (id, nome) VALUES (1, 'mela'), (2, 'pera');
SELECT * FROM prodotti;
SELECT * FROM prodotti ORDER BY nome DESC;
SELECT * FROM prodotti ORDER BY nome ASC;
UPDATE prodotti SET prezzo = 1.50 WHERE nome = 'banane';
CREATE TABLE categoria (id INTEGER PRIMARY KEY, nome TEXT NOT NULL);
.tables
categoria prodotti
INSERT INTO categoria (nome) VALUES ('frutta');
DELETE FROM categoria WHERE nome = 'verdura';
ALTER TABLE prodotti ADD COLUMN id_categoria;
.mode table - SELECT * FROM prodotti;
.mode column
.mode html
.mode markdown
.mode json
.mode excel
ALTER TABLE prodotti DROP COLUMN id_categoria;
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, disponibile BOOLEAN, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
.schema prodotti
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
.schema categorie

## CON Csharp
```csharp
// rotta del file database
string path = "database.db"; 

// se non esiste crealo
if (!File.Exists(path))
{
    // crea l file el database
    SQLiteConnection.CreateFile(path); 
    // creo la connessione al database, la versione 3 è un indicicazione della versione del database
    // e può essere personalizzata
    SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");

    connection.Open(); // apre la connessione

    string sql = @"
                CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                INSERT INTO categorie (nome) VALUES ('frutta'),('verdura'),('verura');
                INSERT INTO categorie (nome) VALUES ('latticini');
                ";

    // creiamo il comando per eseguire lo script su quella connessione a quel database
    SQLiteCommand command = new SQLiteCommand(sql, connection);

    // esegue la Query senza ricevere un ritorno (.ExecuteNonQuery)
    command.ExecuteNonQuery();

    //chiudiamo la connessione (! MOLTO IMPORTANTE: ogni azione  )

        /*

    connection.Open(); // apre la connessione

    // i comandi sql vanni qui

    connection.Close() // chiude la connessione

    */
SQLiteConnection connection1 = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione con il database
connection1.Open(); // apre la connessione in sql
string sql1 = @"CREATE TABLE pokemon (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, tipo TEXT, hp INTEGER, prezzo REAL)"; // istruzione sql dentro una stringa per interagire con il database
SQLiteCommand command1 = new SQLiteCommand(sql1, connection1); // l'oggetto che esegue il comando attraverso la connessione
//command1.ExecuteNonQuery(); // esegue il comando
connection1.Close(); // chiude la connessione alla fine di ogni istruzione


connection1.Open(); // apre la connessione in sql
sql1 = @"INSERT INTO pokemon (nome, tipo, hp, prezzo) VALUES ('pikachu', 'elettrico', 50, 3.20)"; // istruzione sql dentro una stringa per interagire con il database
command1 = new SQLiteCommand(sql1, connection1); // l'oggetto che esegue il comando attraverso la connessione
command1.ExecuteNonQuery(); // esegue il comando
connection1.Close(); // chiude la connessione alla fine di ogni istruzione*/

    ```
    
}


