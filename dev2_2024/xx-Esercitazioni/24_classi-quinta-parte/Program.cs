
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Creare un oggetto di tipo ProdottoRepository per gestire il salvataggio e il caricamento dei dati
        ProdottoRepository repository= new ProdottoRepository();
        // Caricare i dati da file con il metodo CaricaProdotti della classe ProdottoRepository (respository)
        List<ProdottoAdvanced> prodotti = repository.CaricaProdotti();

        // Creare un oggetto di tipo ProdottoAdvancedManager per gestire i prodotti 
        ProdottoAdvancedManager manager = new ProdottoAdvancedManager();

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
            Console.Write("\nScelta:");
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
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    Console.Write("Giacenza: ");
                    int giacenza = int.Parse(Console.ReadLine());
                    manager.AggiungiProdotto(new ProdottoAdvanced { Id = id, NomeProdotto = nome, PrezzoProdotto = prezzo, GiacenzaProdotto = giacenza});
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

public class ProdottoAdvancedManager
{
    private List<ProdottoAdvanced> prodotti; // prodotti è private perchè non voglio che venga modificato dall'esterno

    public ProdottoAdvancedManager()
    {
        prodotti = new List<ProdottoAdvanced>(); // inizializzo la lista di prodotti nel costruttore pubblico in modo che sia accessibile dall'esterno
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
        }
    }
}



public class ProdottoRepository
{
    // la classe ProdottoRepository è una classe che si occupa di gestire la persistenza dei dati in modo centralizzato
    // i vantaggi di questa classe sono:
    // - centralizzazione della logica di accesso dei dati
    // - facilità di manutenzione
    // -facilità di test
    // - possibilità di cambiare il tipo di persistenza senza dover specificare il codice che utilizza la classe
    // possibilità di aggiungere logica di catching (memorizzazione temporanea dei dati) senza dover modificare il codice che utilizza la classe

    // filePath è il percorso del file in cui memorizzare i dati ed ha il modificatore private
    // perchè non voglio che venga modificato dall'esterno della classe prima di essere utilizzato
    private readonly string filePath = "prodotti.json";
    // metodo per salvare i dati su file
    // accetta un parametro di tipo List<ProdottoAdvanced> che rappresenta la lista di prodotti da salvare

    public void SalvaProdotti(List<ProdottoAdvanced> prodotti)
    {
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Dati salvati in {filePath}:\n{jsonData}\n");
    }

    // metodo per caricare i dati da file
    // restituisce una lista di prodotti se il file esiste e contiene dati
    public List<ProdottoAdvanced> CaricaProdotti()
    {
        if (File.Exists(filePath))
        {
            string readJsonData = File.ReadAllText(filePath);
            List<ProdottoAdvanced> prodotti = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData); // deserializza i dati letti dal file
            Console.WriteLine("Dati caricati da file:");
            foreach (var prodotto in prodotti)
            {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
            }
            return prodotti; // restituisco la lista di prodotti letti dal file in modo che possa essere utilizzata all'esterno della classe
        }
        else
        {
            Console.WriteLine("Nessun dato trovato. Inizializzare una nuova lista di prodotti.");
            return new List<ProdottoAdvanced>(); // restituisco una nuova lista di prodotti vuota se il file non esiste o è vuoto
            // in modo che possa essere utilizzata all'esterno della classe
        }
    }
}