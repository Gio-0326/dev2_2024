using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
public class ProdottoDettaglioModel : PageModel
{
    private readonly ILogger<ProdottoDettaglioModel> _logger;

    public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
    {
        _logger = logger;
        logger.LogInformation("Pagina Prodotto Dettaglio Caricata");
    }

    public Prodotto Prodotto { get; set; }
    public void OnGet(int id) // l'id è sufficiente perchè gli abbiamo passato gli altri parametri tr
    {
        
        // non e necessario mettere var perchè il tipo è già definito in Prodotto
        
        var json =  System.IO.File.ReadAllText("wwwroot/json/prodotti.json"); // legge i prodotti dal file json
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto; // se l'id del prodotto corrisponde a quello passato come parametro, allora assegno il prodotto a Prodotto
                break;
            }
        }
    }
}

        