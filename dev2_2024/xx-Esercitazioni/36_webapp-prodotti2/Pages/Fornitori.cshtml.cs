using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
public class FornitoriModel : PageModel   //  La classe FornitoriModel è una pagina Razor che gestisce la logica per la visualizzazione della lista dei fornitori.
{
    private readonly ILogger<FornitoriModel> _logger;

    public FornitoriModel(ILogger<FornitoriModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Fornitore> Fornitori { get; set; } // Proprietà per i fornitori 
    // IEnumerable<Fornitore> è un'interfaccia che rappresenta una raccolta di oggetti Fornitore che possono essere iterati (come una lista o un array).

    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);

        Fornitori = fornitori;
    }
}
// Infine, questa riga assegna la lista dei fornitori deserializzati alla proprietà Fornitori.
//Questo rende i dati dei fornitori disponibili alla vista associata a questa pagina Razor. 
//In altre parole, i fornitori che sono stati letti e deserializzati dal file JSON saranno accessibili alla pagina .cshtml tramite @Model.Fornitori.