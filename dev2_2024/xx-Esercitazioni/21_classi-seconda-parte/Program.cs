
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        List<ProdottoAdvanced> prodotti = new List<ProdottoAdvanced>
         {
        new ProdottoAdvanced { Id = 1, NomeProdotto = "Prodotto A", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100 },
        new ProdottoAdvanced { Id = 2, NomeProdotto = "Prodotto B", PrezzoProdotto = 10.50m, GiacenzaProdotto = 100 }
         };

        string filePath = "prodotti.json";
        string jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine($"Dati serializzati e salvati in {filePath}:\n{jsonData}\n");

        // Deserialzzare i dati dal file JSON
        string readJsonData = File.ReadAllText(filePath);
        List<ProdottoAdvanced> prodottiDeserializzati = JsonConvert.DeserializeObject<List<ProdottoAdvanced>>(readJsonData);

        Console.WriteLine("Dati deserializzati:");
        foreach (var prodotto in prodottiDeserializzati)
        {
            Console.WriteLine($"ID: {prodotto.Id}, Nome: {prodotto.NomeProdotto}, Prezzo: {prodotto.PrezzoProdotto}, Giacenza: {prodotto.GiacenzaProdotto}");
        }

        // Testare errori con try-catch

        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.Id = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.NomeProdotto = "";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

        try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.PrezzoProdotto = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

         try
        {
            ProdottoAdvanced prodotto = new ProdottoAdvanced();
            prodotto.GiacenzaProdotto = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }

    }
}



    // esempio di classe con proprietà private rese pubbliche tramite metodi get e set dopo aver applicato delle regole di validazione
    public class ProdottoAdvanced
    {
        // definisco una variabile privata id
        // la definisco privata in modo che non possa essere ,odificata direttamente dall'esterno della classe
        // cosi solo la classe ProdottoAdvanced può accedere e modificare la variabile id
        private int id; // campo privato

        // definisco una proprietà pubblica Id in modo che possa essere letta e scritta dall'esterno della classe
        // il vantaggio di utilizzare una proprietà è che posso controllare l'accesso alla variabile privata id e applicare delle regole di validazione
        // ad esempio posso controllare che il valore passato come argomento sia maggiore di zero
        public int Id
        {
            get { return id; } // restituisce il valore della variabile privata id richiamata dall'esterno della classe ProdottoAdvanced
                               // set { id = value; } // imposta il valore della variabile privata id con il valore passato come argomento
                               // implemento la logica di validazione per il valore passato come argomento
                               // se il valore passato come argomento è minore o uguale a zero, sollevo un'eccezione
                               // l'eccezione interrompe l'esecuzione del programma e mostra un messaggio di errore
                               // l'eccezione può essere catturata e gestita da un blocco try-catch
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

    

