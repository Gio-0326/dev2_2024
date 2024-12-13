
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository = new ProdottoRepository();
        // Caricare i dati da file con il metodo CaricaProdotti della classe ProdottoRepository (respository)
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();

        // Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti 
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);

        // Menu interattivo per eseguire operazioni CRUD sui prodotti

        // variabile per controllare se il programma deve continuare o uscire
        bool continua = true;

        // il ciclo while continua finchè la variabile continua è true
        while (continua)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1.Visualizza Prodotti");
            Console.WriteLine("2.Aggiungi Prodotto");
            Console.WriteLine("3.Trova Prodotto per ID");
            Console.WriteLine("4.Aggiorna Prodotto");
            Console.WriteLine("5.Elimina Prodotto");
            Console.WriteLine("6.Esci");

            // acquisire l'input dell'utente
            // Console.Write("\nScelta:");
            // string scelta = Console.ReadLine();
            // string scelta acquisita mdiante il metodo LeggiInteri della classe InputManager
            string scelta = InputManager.LeggiIntero("\nScelta", 1, 6).ToString();
            // pulisco la console
            Console.Clear();

            // switch-case per gestire le scelte dell'utente che usa scelta come variabile di controllo
            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");

                    manager.StampaProdottiIncolonnati();

                    break;
                case "2":

                    string nome = InputManager.LeggiStringa("\nNome: ");

                    decimal prezzo = InputManager.LeggiDecimale("\nPrezzo: ");

                    int giacenza = InputManager.LeggiIntero("\nGiacenza: ");

                    manager.AggiungiProdotto(new ProdottoAdvanced { NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
                    break;
                case "3":
                    Console.Write("ID: ");
                    // int idProdotto = int.Parse(Console.ReadLine());
                    // acquisisco l'id mediante il metodo LeggiIntero della classe InputManager
                    int idProdotto = InputManager.LeggiIntero("\nID: ");

                    ProdottoAdvanced prodottoTrovato = manager.TrovaProdotto(idProdotto);
                    if (prodottoTrovato != null)
                    {
                        Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.NomeProdotto}");
                    }
                    else
                    {
                        Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                    }
                    break;
                case "4":
                    int idProdottoDaAggiornare = InputManager.LeggiIntero("\nID: ");

                    string nomeNuovo = InputManager.LeggiStringa("\nNome: ");

                    decimal prezzoNuovo = InputManager.LeggiDecimale("\nPrezzo: ");

                    int giacenzaNuova = InputManager.LeggiIntero("\nGiacenza: ");

                    manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced { NomeProdotto = nomeNuovo, PrezzoProdotto = prezzoNuovo, GiacenzaProdotto = giacenzaNuova });
                    break;
                case "5":
                    Console.Write("ID: ");
                    int idProdottoDaEliminare = InputManager.LeggiIntero("\nProdotto da eliminare: ");
                    manager.EliminaProdotto(idProdottoDaEliminare);
                    break;
                case "6":
                    // Salva ogni prodotto singolarmente
                    foreach (var prodotto in manager.OttieniProdotti())
                    {
                        repository.SalvaProdotti(prodotto);
                    }
                    continua = false; // imposto la variabile continua a false per uscire dal ciclo while 
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprovare.");
                    break;

            }
        }
    }
}



public class ProdottoAdvanced
{

    private int id;

    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
            }
            id = value; // imposta il valore della variabile privata id con il valore passato come argomento
        }
    }

    private string nomeProdotto;
    public string NomeProdotto
    {
        get { return nomeProdotto; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
            }
            nomeProdotto = value;
        }
    }

    private decimal prezzoProdotto;
    public decimal PrezzoProdotto
    {
        get { return prezzoProdotto; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Il prezzo deve essere maggiore di zero.");
            }
            prezzoProdotto = value;
        }
    }

    private int giacenzaProdotto;
    public int GiacenzaProdotto
    {
        get { return giacenzaProdotto; }
        set { giacenzaProdotto = value; }
    }

}

public class ProdottoAdvancedManager // (CRUD)
{
    private List<ProdottoAdvanced> prodotti; // prodotti è private perchè non voglio che venga modificato dall'esterno
    // questo new è necessario affinche dal dominio privato la classe possa comunicare all'esterno i dati aggiornati
    // un modo per rendere pubblico un dato privato
    private int prossimoId;

    private ProdottoRepository repository;
    public ProdottoAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        prodotti = Prodotti;
        repository = new ProdottoRepository();

        prossimoId = 1;

        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }

    // metodo per aggiungere un prodotto alla lista
    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotto.Id = prossimoId;
        prossimoId++;
        prodotti.Add(prodotto);
        Console.WriteLine($"Prodotto aggiunto con ID: {prodotto.Id}");
    }

    // metodo per visualizzare la lista di prodotti
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    // Ogni campo utilizza il formato {Campo - Larghezza} dove:
    // Campo è il valore da stampare
    // Larghezza specifica la larghezza del campo; il segno - allinea il testo a sinistra.
    // {"Nome", -20} significa che il nome del prodotto avrà una larghezza fissa di 20 caratteri, allineato a sinistra
    // Formato dei numeri:
    // Per i pezzi, viene usato il formato 0.00 per mostrare sempre due cifre decimali
    // Linea separatrice:
    // La riga Console.WriteLine(new string('-', 50)); stampa una line divisoria lunga 50 caratteri per migliorare la lggibilità

    public void StampaProdottiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
        $"{"ID",-5} {"Nome",-20} {"Prezzo",-10} {"Giacenza",-10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var prodotto in prodotti)
        {
            Console.WriteLine(
                $"{prodotto.Id,-5} {prodotto.NomeProdotto,-20} {prodotto.PrezzoProdotto,-10:0.00} {prodotto.GiacenzaProdotto,-10}"
            );
        }
    }

    // metodo per cercare un prodotto
    public ProdottoAdvanced TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                return prodotto;
            }
        }
        return null;
    }
    // metodo per modificare un prodotto esistente
    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    // metodo per eliminare un prodotto esistente
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
            // elimina il file JSON corrispondente al prodotto
            string filePath = Path.Combine("ProdottiJson", $"{prodotto.Id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Prodotto eliminato: {filePath}");
        }
    }
}

// La gestione dei file json è piu sicura se il path è privato
// dunque ogni file json avrà la propria Class Repository per salvare e caricare
public class ProdottoRepository
{

    private readonly string folderPath = "ProdottiJson";

    public ProdottoRepository()  // ho fatto un costruttore per vedere se esiste la cartella. Se non esiste la crea
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
    public void SalvaProdotti(ProdottoAdvanced prodotto)
    {
        string filePath = Path.Combine(folderPath, $"{prodotto.Id}.json"); // Ogni file è denominato con l'ID del prodotto
        string jsonData = JsonConvert.SerializeObject(prodotto, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Prodotto salvato in {filePath}");
    }

    // metodo per caricare i dati da file
    // restituisce una lista di prodotti se il file esiste e contiene dati
    public List<ProdottoAdvanced> CaricaProdotti()
    {
        List<ProdottoAdvanced> prodotti = new List<ProdottoAdvanced>(); // Crea una lista vuota che conterrà tutti i prodotti caricati

        if (Directory.Exists(folderPath)) // Verifica se la cartella esiste e contiene file
        {
            string[] filePaths = Directory.GetFiles(folderPath, "*.json"); // Ottiene tutti i percorsi dei file con estensione ".json" presenti nella cartella
            foreach (string filePath in filePaths) // Cicla su ogni file JSON trovato nella cartella
            {
                string jsonData = File.ReadAllText(filePath);  // Legge tutto il contenuto del file JSON
                ProdottoAdvanced prodotto = JsonConvert.DeserializeObject<ProdottoAdvanced>(jsonData);  // Mi deserializza il contenuto JSON in un oggetto 'ProdottoAdvanced'
                prodotti.Add(prodotto); // Aggiunge l'oggetto 'ProdottoAdvanced' alla lista di prodotti
                Console.WriteLine($"Prodotto caricato da {filePath}: {prodotto.NomeProdotto}");
            }
        }
        else
        {
            Console.WriteLine("La cartella non esiste o è vuota. Inizializzare una nuova lista di prodotti.");
        }

        return prodotti;   // Restituisce la lista di prodotti caricati (potrebbe essere vuota se la cartella non conteneva file)
    }
}

// classe di gestione degli input (InputManager) che può essere integrata per semplificare e standardizzare l'acquisizione e la validazione degli input dell'utente
// Questa classe aiuta a gestire i casi di errore e fornisce metodi per acquisire input di diversi tipo.
// uso ont-MinValue ed int.MaxValue per dare dei valori di default
// Quando chiami il metodo, puoi specificare solo i valori che ti interessano e ignorare gli altri
// Quando chiami il metodo con un solo valore (ad esempio 0 per min), non devi preoccuparti di speificare anche max se non è necessario
// come succede con il random che non ha un valore min prende 0 di default
// es int risultato = InputManager.LeggiIntero("Inserisci un numero") 
public static class InputManager
{
    // Il metodo LeggiIntero accetta un messaggio da visualizzare all'utente e un intervallo di valori interi consentiti
    // MinValue ed MaxValue sono i metodi di int che rappresentano
    public static int LeggiIntero(string messaggio, int min = int.MinValue, int max = int.MaxValue)
    {
        int valore; // variabile per memorizzare il valore intero acquisito
        // while che continua finchè l'utente non fornisce un input valido
        while (true)
        {
            Console.Write($"{messaggio} "); // messaggio e la variabile di input che dovrò passare al metodo
            string input = Console.ReadLine(); // acquisire l'input dell'utente come stringa
            // try parse per convertire la stringa in un intero e controllare se l'input è valido 
            if (int.TryParse(input, out valore) && valore >= min && valore <= max) // devo verificare se il valore e tra min e max e se è un intero
            {
                return valore; // restituire il valore intero se è valido
            }
            else
            {
                Console.WriteLine($"Inserire un valore intero compreso tra {min} e {max}."); // messaggio di errore
            }
        }
    }


    public static decimal LeggiDecimale(string messaggio, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        decimal valore; // variabile per memorizzare il valore decimale acquisito
        while (true)
        {
            Console.Write($"{messaggio} ");
            string input = Console.ReadLine();

            // sostituisco il punto con la virgola per gestire i numeri decimali
            if (input.Contains(",") && !input.Contains(".")) // se l'input contiene la virgola e non contiene il punto
            {
                input = input.Replace(".", ","); // sostituire la virgola con il punto
            }

            // try parse per convertire la stringa in un decimale e controllare se l'input è valido
            if (decimal.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;
            }
            Console.WriteLine($"Errore: Inserire un numero decimale compreso tra {min} e {max}");
        }
    }

    public static string LeggiStringa(string messaggio, bool obbligatorio = true)
    {
        while (true)
        {
            Console.Write($"{messaggio}"); // messaggio e la variabile di input che dovrò passare al metodo
            string input = Console.ReadLine(); // acquisire l'input dell'utente come stringa
            if (!string.IsNullOrWhiteSpace(input) || !obbligatorio) // se l'input non è vuoto o non è obbligatorio
            {
                return input; // restituisce il valore della stringa
            }
            Console.WriteLine("Errore: Il valore non può essere vuoto."); // messaggio di errore

        }
    }

    public static bool LeggiConferma(string messaggio)
    {
        while (true)
        {
            Console.Write($"{messaggio} (s/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "s" || input == "si")
            {
                return true;
            }
            if (input == "n" || input == "no")
            {
                return false;
            }
        }
    }
}