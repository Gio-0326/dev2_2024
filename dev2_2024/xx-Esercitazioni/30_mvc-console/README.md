# MVC Console
```csharp
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SQLite; // Importazione del namespace per utilizzare SQLite

var db = new Database(); // Modello di database in modo che sia possibile utilizzare i metodi per la gestione del database
var view = new View(db); // Modello di vista c è db tra parantesi perche la vista deve avere accesso al database
var controller = new Controller(db, view); // Modello di conroller che deve avere accesso al database e alla vista
controller.MainMenu(); // Metodo per gestire il menu principale

class Database
{
    private SQLiteConnection _connection; // Connessione al database che e private perche non deve essere accessibile dall'esterno
                                          // utilizziamo l underscore davanti al nome in modo da indicare che è una variabile privata

    public Database() // costruttore della classe database
    {
        _connection = new SQLiteConnection("Data Source=database.db"); // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection); // Creazione della tabella users
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection); // Creazione di un comando per inserire un nuovo utente
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public List<string> GetUsers() // metodo GetUsers che serve per ottenere la lista degli utenti
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati cosi abbiamo caricato i dati nel reader
        var users = new List<string>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            users.Add(reader.GetString(0)); // Aggiunta del nome dell'utente alla lista
                                            // utilizzo (0) perche il nome è il primo campo
        }
        return users; // Restituzione della lista degli utenti
    }
    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }
}

class View
{
    private Database _db; // Riferimento al modello di database

    public View(Database db) // costruttore della classe view che prende in input il modello di database
    {
        _db = db; // Inizializzazione del riferimento al modello
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi user");
        Console.WriteLine("3. Esci");
    }

    public void ShowUsers(List<string> users) // Metodo per visualizzare gli utenti
    {
        foreach (var user in users)
        {
            Console.WriteLine(user); // Visualizzazione dei nomi degli utenti
        }
    }

    public string GetUserName()
    {
        Console.WriteLine("Enter user name:");
        return Console.ReadLine();
    }

    public string GetInput()
    {
        return Console.ReadLine(); // Lettura dell'input dell'utente
    }
}

class Controller
{
    private Database _db; // Riferimento al modello di database
    private View _view; // Riferimento alla view

    public Controller(Database db, View view) // costruttore della classe controller che prende in input il modello di database e la view
    {
        _db = db; // Inizializzazione del riferimento al modello
        _view = view; // Inizializzazione del riferimento alla vista
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu(); // Visualizzazione del menu principale con metodo servito da view
            var input = _view.GetInput(); // Lettura dell'input dell'utente con metodo servito da view
            if (input == "1")
            {
                AddUser(); // Aggiunta di un utente
            }
            else if (input == "2")
            {
                ShowUsers(); // Visualizzazione degli utenti
            }
            else if (input == "3")
            {
                _db.CloseConnection(); // Chiusura della connessione al database
                break; // Uscita dal programma
            }
        }
    }

    private void AddUser()
    {
       var name = _view.GetUserName(); // La vista gestisce la richiesta del nome
        _db.AddUser(name); // Aggiunta dell'utente al database
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers(); // Lettura degli utenti dal database
        _view.ShowUsers(users); // Visualizzaizone degli utenti
    }
}
```

