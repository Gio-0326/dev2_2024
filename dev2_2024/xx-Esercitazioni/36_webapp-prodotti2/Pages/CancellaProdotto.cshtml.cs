using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class CancellaProdottoModel : PageModel
{
    private readonly ILogger<CancellaProdottoModel> _logger;

    public CancellaProdottoModel(ILogger<CancellaProdottoModel> logger)
    {
        _logger = logger;
    }

    //[TempData]
    // public string messaggio { get; set; }
    public Prodotto Prodotto { get; set; }
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
            }
        }
        // messaggio = "Ciao";
        // TempData.Keep("messaggio");
    }
    public IActionResult OnPost(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        for (int i = 0; i < prodotti.Count; i++)
        {
            if (prodotti[i].Id == id) // se il puntatore del prodotto è uguale al numero di id
            {
                prodotti.RemoveAt(i);
                break;
            }
        }
        
        
       System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
       
       return RedirectToPage("Prodotti");


    }
}