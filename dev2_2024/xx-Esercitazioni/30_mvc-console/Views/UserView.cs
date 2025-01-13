using System.Data.SQLite; // Importazione del namespace per utilizzare SQLite
public class UserView
{
    private Database _db; // Riferimento al modello di database

    public UserView(Database db) // costruttore della classe view che prende in input il modello di database
    {
        _db = db; // Inizializzazione del riferimento al modello
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi user");
        Console.WriteLine("3. Esci");
    }

    public void ShowUsers(List<User> users) // Metodo per visualizzare gli utenti
    {
        foreach (var user in users)
        {
            // Console.WriteLine(user); // Visualizzazione dei nomi degli utenti
            Console.WriteLine($"{user.Id} - {user.Name}"); // Visualizzaione degli utenti
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