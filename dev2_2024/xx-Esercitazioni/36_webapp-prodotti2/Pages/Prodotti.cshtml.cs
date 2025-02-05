//Il file nome.cshtml.cs è un file di codice C# (code-behind) che contiene la logica per la pagina. 
//In pratica, il file .cshtml.cs è dove definisci la logica che si occupa della gestione dei dati, dell'elaborazione delle richieste e della preparazione della vista da inviare al client.
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _36_webapp_prodotti2.Pages;
// La classe NomeModel eredita dalla classe PageModel. 
// Ogni pagina Razor ha una classe di modello (model), e il file .cshtml.cs è dove la definisci. 
// Questa classe contiene proprietà e metodi che gestiscono la logica di business.
public class ProdottiModel : PageModel 
{
    // Proprietà del modello
    private readonly ILogger<ProdottiModel> _logger; // _Logger è un campo privato di tipo ILogger<IndexModel>
    // serve per registrare i messaggi di Log relativi a IndexModel

    public ProdottiModel(ILogger<ProdottiModel> logger) // Costruttore di IndexModel
    {
        _logger = logger;
        logger.LogInformation("Prodotti caricati");
    }

    public IEnumerable<Prodotto> Prodotti { get; set; }  //Questa è una proprietà che contiene il dato che vuoi visualizzare sulla pagina. 
                                                         // Nel nostro esempio, questa proprietà sarà il nome che viene mostrato nella vista.
    //public string Ricerca { get; set; }
    public int numeroPagine { get; set; } // aggiunta una proprietà per il numero di pagine

    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)   // Metodo che viene eseguito quando la pagina viene caricata
    {                                                                                                                
        var allProdotti = new List<Prodotto>()
        {
            new Prodotto { Id = 1, Nome = "Fanta", Prezzo = 100, Dettaglio = "Dettaglio 1", Immagine="data:image/jpeg;base64,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" },
            new Prodotto { Id = 2, Nome = "Sprite", Prezzo = 200, Dettaglio = "Dettaglio 2", Immagine="https://th.bing.com/th/id/OIP.x1Zi7kYOxIoAbUZEpqSRQwHaHa?w=188&h=188&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 3, Nome = "Birra", Prezzo = 300, Dettaglio = "Dettaglio 3 Dettaglio 3 Dettaglio 3 Dettaglio 3 Dettaglio 3 Dettaglio 3 Dettaglio 3 Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 4, Nome = "Birra", Prezzo = 400, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 5, Nome = "Birra", Prezzo = 500, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 6, Nome = "Birra", Prezzo = 600, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 7, Nome = "Birra", Prezzo = 700, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 8, Nome = "Birra", Prezzo = 800, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 9, Nome = "Birra", Prezzo = 900, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 10, Nome = "Birra", Prezzo = 1000, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 11, Nome = "Birra", Prezzo = 1100, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 12, Nome = "Birra", Prezzo = 1200, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"},
            new Prodotto { Id = 13, Nome = "Birra", Prezzo = 1300, Dettaglio = "Dettaglio 3", Immagine="https://th.bing.com/th/id/OIP.bRiAOFZq-k9idcWWGnchmgHaJQ?w=148&h=185&c=7&r=0&o=5&pid=1.7"}
        };

        // Inizializziamo la lista filtrata
        var prodottiFiltrati = new List<Prodotto>();

        // Iteriamo su tutti i prodotti
        foreach (var prodotto in allProdotti)
        {
            bool aggiungi = true;

            // Applichiamo il filtro per maxPrezzo se presente
            if (minPrezzo.HasValue)
            {
                if (prodotto.Prezzo < minPrezzo.Value)
                {
                    aggiungi = false;
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
         numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0); // calcola il numero di pagine
                                                                  // Math.Ceiling  arrotonda il numero di pagine all'interno più vicino
                                                                  // Prodotti.Count() restituisce il numero di prodotti
                                                                  // 6.0 è il numero di prodotti per pagina
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6); // esegue la paginazione
    }
}

// public void OnGet(): Il metodo OnGet viene eseguito ogni volta che la pagina viene richiesta tramite un HTTP GET (per esempio, quando un utente accede alla pagina). 
//In questo caso, il metodo imposta il valore della proprietà Ricerca a ricerca.
//Quando la pagina viene richiesta, il framework .NET esegue il metodo OnGet e popola i dati nella proprietà Nome. Poi, la vista (nome.cshtml) accederà a questa proprietà attraverso @Model.Nome per visualizzare il dato.


/*Interazione tra i due file:
nome.cshtml.cs è il "code-behind" che gestisce la logica, popola i dati e prepara il modello da visualizzare.
nome.cshtml è la vista che presenta i dati all'utente finale (nel nostro caso, mostra il nome "Mario Rossi").
In sintesi:

nome.cshtml: Si occupa della parte visiva della pagina, che include HTML e codice Razor per visualizzare i dati.
nome.cshtml.cs: Contiene la logica di business e di gestione dei dati, ed è responsabile della preparazione della pagina prima che venga mostrata all'utente.
Questi due file lavorano insieme per separare la logica di business dalla presentazione, rendendo il codice più manutenibile e leggibile.*/