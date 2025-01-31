using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _35_webapp_prodotti.Pages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Prodotto> Prodotti { get; set; }
    public string Ricerca { get; set; }
    public void OnGet()
    {
        Prodotti = new List<Prodotto>()
        {
            new Prodotto { Nome = "Fanta", Prezzo = 100, Dettaglio = "Dettaglio 1" },
            new Prodotto { Nome = "Sprite", Prezzo = 200, Dettaglio = "Dettaglio 2"},
            new Prodotto { Nome = "Birra", Prezzo = 300, Dettaglio = "Dettaglio 3"}
        };

        List<Prodotto> prodottiFiltrati = new List<Prodotto>();

        if (!string.IsNullOrEmpty(Ricerca))
        {
            foreach (var prodotto in Prodotti)
            {
                if (prodotto.Nome.Contains(Ricerca))
                {
                    prodottiFiltrati.Add(prodotto);
                }
            }
        }
    }
}

