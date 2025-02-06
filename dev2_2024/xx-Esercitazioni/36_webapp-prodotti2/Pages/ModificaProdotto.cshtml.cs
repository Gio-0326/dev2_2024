using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto { get; set; }
    public void OnGet(int id) // riceve un parametro id in ingresso, per poi andarloo a modificare
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto; // quando trova l'id corrispondente, lo assegna alla proprietà Prodotto
                break; // esce dal ciclo
            }
        }
    }
    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, string immagine) 
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json); // deserializza il file json in una lista di prodotti
        Prodotto prodotto = null; // Variabile locale  // dobbiamo dichiarare che è una variabile prodotto di tipo Prodotto a cui assegnamo null

        foreach (var p in prodotti) // itera su tutti i prodotti
        {
            if (p.Id == id)
            {
                prodotto = p; // Assegna alla variabile locale prodotto  l'id preso dal form della pagina ModificaProdotto
                break;
            }
        }
        /* Se il prodotto non è stato trovato, restituisci un errore
        if ( prodotto == null)
        {
            Gestisci il caso in cui il prodotto non viene trovato
            return NotFound();
        }
        */

        prodotto.Nome = nome;
        prodotto.Prezzo = prezzo;   
        prodotto.Dettaglio = dettaglio;
        prodotto.Immagine = immagine;

        // Scrivi il file JSON aggiornato
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
       
    }
}