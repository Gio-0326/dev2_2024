//Il file nome.cshtml.cs è un file di codice C# (code-behind) che contiene la logica per la pagina. 
//In pratica, il file .cshtml.cs è dove definisci la logica che si occupa della gestione dei dati, dell'elaborazione delle richieste e della preparazione della vista da inviare al client.
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _36_webapp_prodotti2.Pages;
// La classe NomeModel eredita dalla classe PageModel. 
// Ogni pagina Razor ha una classe di modello (model), e il file .cshtml.cs è dove la definisci. 
// Questa classe contiene proprietà e metodi che gestiscono la logica di business.
public class ProdottiModel : PageModel 
{
    // Proprietà del modello
    private readonly ILogger<ProdottiModel> _logger; // _Logger è un campo privato di tipo ILogger<IndexModel>
    // serve per visualizzare i messaggi di Log relativi a IndexModel

    public ProdottiModel(ILogger<ProdottiModel> logger) // Costruttore di IndexModel
    {
        _logger = logger;
        logger.LogInformation("Prodotti caricati");
    }

    public IEnumerable<Prodotto> Prodotti { get; set; }  //Questa è una proprietà che contiene il dato che vuoi visualizzare sulla pagina. 
                                                         // Nel nostro esempio, questa proprietà sarà il nome che viene mostrato nella vista.
    //public string Ricerca { get; set; }                // IEnumerable interfaccia di base di raccolte generiche,
                                                         // Espone l'enumeratore, che supporta una semplice iterazione su una raccolta di un tipo specificato. 
    public int numeroPagine { get; set; } // aggiunta una proprietà per il numero di pagine
    
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)   // Metodo che viene eseguito quando la pagina viene caricata
    {          
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var allProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);                                                                                                      

        // Inizializziamo la lista filtrata
        
       
        var prodottiFiltrati = new List<Prodotto>(); // una nuova lista che soddisa i criteri

        // Iteriamo su tutti i prodotti
        foreach (var prodotto in allProdotti)
        {
            bool aggiungi = true;

            // Applichiamo il filtro per maxPrezzo se presente
            if (minPrezzo.HasValue) // per contollare se il valore è stato assegnato
            {
                if (prodotto.Prezzo < minPrezzo.Value) // è il corrispettivo di hasvalue, restituisce il valore del nullable
                {
                    aggiungi = false; // non viene aggiunto il prodotto alla lista filtrata
                }
            }
            if (maxPrezzo.HasValue)
            {
                if (prodotto.Prezzo > maxPrezzo.Value)
                {
                    aggiungi = false;
                }
            }

            // Se il prodotto soddisfa tutti i criteri, lo aggiungiamo alla lista filtrata
            if (aggiungi)
            {
                prodottiFiltrati.Add(prodotto);
            }
        }

        // Assegniamo i prodotti filtrati alla proprietà Prodotti
        Prodotti = prodottiFiltrati;
         numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0); // calcola il numero di pagine // abbiamo messo int tra parentesi per fare un casting esplicito ad un numero intero
                                                                  // Math.Ceiling  arrotonda il numero di pagine all'interno più vicino
                                                                  // Prodotti.Count() restituisce il numero di prodotti
                                                                  // 6.0 è il numero di prodotti per pagina
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6); // esegue la paginazione // 
        // (??) operatore di coalescenza se pageIndex
        // Take prende i successivi 6
    }
}

// public void OnGet(): Il metodo OnGet viene eseguito ogni volta che la pagina viene richiesta tramite un HTTP GET (per esempio, quando un utente accede alla pagina). 
//In questo caso, il metodo imposta il valore della proprietà Ricerca a ricerca.
//Quando la pagina viene richiesta, il framework .NET esegue il metodo OnGet e popola i dati nella proprietà Nome. Poi, la vista (nome.cshtml) accederà a questa proprietà attraverso @Model.Nome per visualizzare il dato.


/*Interazione tra i due file:
nome.cshtml.cs è il "code-behind" che gestisce la logica, popola i dati e prepara il modello da visualizzare.
nome.cshtml è la vista che presenta i dati all'utente finale.
In sintesi:

nome.cshtml: Si occupa della parte visiva della pagina, che include HTML e codice Razor per visualizzare i dati.
nome.cshtml.cs: Contiene la logica di business e di gestione dei dati, ed è responsabile della preparazione della pagina prima che venga mostrata all'utente.
Questi due file lavorano insieme per separare la logica di business dalla presentazione, rendendo il codice più manutenibile e leggibile.*/

//.Keep
//.Peek
