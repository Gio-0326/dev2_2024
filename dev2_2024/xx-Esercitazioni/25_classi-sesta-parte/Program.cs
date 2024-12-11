using Newtonsoft.Json;
// comando installazione pacchetto Newtonsoft.Json
// dotnet add package Newtonsoft.Json
class Program
{
    static void Main(string[] args)
    {
       // Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository = new ProdottoRepository();

        // Caricare i dati da file con il metodo CaricaProdotti della classe ProdottoRepository (repository)
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();

        // Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager(prodotti);

        // Menu interattivo per eseguire operazioni CRUD sui prodotti

        // variabile per controllare se il programma deve continuare o uscire
        bool continua = true;

        // il ciclo while continua finché la variabile continua è true
        while (continua)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Visualizza Prodotti");
            Console.WriteLine("2. Aggiungi Prodotto");
            Console.WriteLine("3. Trova Prodotto per ID");
            Console.WriteLine("4. Aggiorna Prodotto");
            Console.WriteLine("5. Elimina Prodotto");
            Console.WriteLine("6. Esci");

            // acquisire l'input dell'utente
            Console.Write("\nScelta: ");
            string scelta = Console.ReadLine();

            // switch-case per gestire le scelte dell'utente che usa scelta come variabile di controllo
            switch (scelta)
            {
                case "1":
                    Console.WriteLine("\nProdotti:");

                    // Visualizzare i prodotti con il metodo OttieniProdotti della classe ProdottoAdvancedManager (manager)
                    foreach (var prodotto in manager.OttieniProdotti())
                    {
                        Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
                    }
                    break;
                case "2":
                    // Console.Write("ID: ");
                    // int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza: ");
                    int giacenza = int.Parse(Console.ReadLine());
                    // manager.AggiungiProdotto(new ProdottoAdvanced { Id = id, NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
                    manager.AggiungiProdotto(new ProdottoAdvanced { NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza });
                    break;
                case "3":
                    Console.Write("ID: ");
                    int idProdotto = int.Parse(Console.ReadLine());
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
                    Console.Write("ID: ");
                    int idProdottoDaAggiornare = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nomeNuovo = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzoNuovo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza: ");
                    int giacenzaNuova = int.Parse(Console.ReadLine());
                    manager.AggiornaProdotto(idProdottoDaAggiornare, new ProdottoAdvanced { NomeProdotto = nomeNuovo, PrezzoProdotto = prezzoNuovo, GiacenzaProdotto = giacenzaNuova });
                    break;
                case "5":
                    Console.Write("ID: ");
                    int idProdottoDaEliminare = int.Parse(Console.ReadLine());
                    manager.EliminaProdotto(idProdottoDaEliminare);
                    break;
                case "6":
                    repository.SalvaProdotti(manager.OttieniProdotti());
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
    private static int ultimoId = 0; 

    

    private int id;
    public int Id
    {
        get { return id; }
        private set { id = value; } // Rende il setter privato per impedire modifiche manuali all'ID
                                    // value e definito implicitamente dal compilatore e rappresenta il valore assegnato alla proprietà
                                    // value è una variabile locale e non può essere utilizzata all'esterno del setter
                                    // value è quello che si chiama un parametro implicito cioè non lo devo dichiarare io ma è già dichiarato dal compilatore
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

    // Costruttore per generare automaticamente l'ID
    // quando viene creato un nuovo oggetto ProdottoAdvanced con il costruttore vuoto (senza parametri) viene chiamato questo costruttore (costruttore di default) 
    // che genera un nuovo ID e lo assegna all'oggetto usando il metodo GeneraId
    // invece gli altri parametri (NomeProdotto, PrezzoProdotto, GiacenzaProdotto) vengono inizializzati con i valori di default (null, 0, 0)
    // ed in seguito vengono assegnati i valori inseriti dall'utente
    public ProdottoAdvanced()
    {
        Id = GeneraId();
    }

    // Metodo statico per generare un ID progressivo
    // è statico perche in questo caso mi serve che sia condiviso tra tutte le istanze della classe in modo che l'ID sia univoco per ogni prodotto
    private static int GeneraId()
    {
        ultimoId++;
        return ultimoId;
    }
    /*
    Prodotto prodotto1 = new Prodotto
        {
            NomeProdotto = "Prodotto A",
            PrezzoProdotto = 10.50m,
            GiacenzaProdotto = 100
        };
    Console.WriteLine($"Prodotto 1 - ID: {prodotto1.Id}, Nome: {prodotto1.NomeProdotto}");
    */

}

public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti; // prodotti e private perche non voglio che venga modificato dall'esterno

    public ProdottoAdvancedManager(List<ProdottoAdvanced> prodottiIniziali = null) 
    {
        if (prodottiIniziali != null)
        {
            prodotti = prodottiIniziali;
        }
        else
        {
             prodotti = new List<ProdottoAdvanced>();
        }
        
    }

    // metodo per aggiungere un prodotto alla lista
    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotti.Add(prodotto);
    }

    // metodo per visualizzare la lista di prodotti
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        
        return prodotti;
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

    // metodo per mpdificare un prodotto esistente
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

    // metodo per eliminare un prodotto
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
        }
    }
}

public class ProdottoRepository
{
    private readonly string filePath = "prodotti.json"; // il percorso del file in cui memorizzare i dati
    
    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Dati salvati in {filePath}:\n");
       
    }

    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if (File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData); // deserializzo i dati letti dal file
            Console.WriteLine("Dati caricati da file:");
            foreach (var prodotto in prodotti)
            {
                Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
            }
            // restituisco la lista di prodotti letti dal file in modo che possa essere utilizzata all'esterno della classe
            return prodotti;
        }
        else
        {
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            // restituisco una nuova lista di prodotti vuota se il file non esiste o è vuoto in modo che possa essere utilizzata all'esterno della classe
            return new List<ProdottoAdvanced>();
        }
    }
}