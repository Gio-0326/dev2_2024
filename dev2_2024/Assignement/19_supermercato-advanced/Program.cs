
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


// creare una classe Dipendente

public class Dipendente
{
    private int prossimoId;
    private string username;
    private string ruolo;

    public Dipendente(List<ProdottoAdvanced> Prodotti)
    {
        
    }
}







