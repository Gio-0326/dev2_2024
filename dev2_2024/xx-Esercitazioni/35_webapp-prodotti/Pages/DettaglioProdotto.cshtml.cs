using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _35_webapp_prodotti.Pages;

public class DettaglioProdottoModel : PageModel
{
    private readonly ILogger<DettaglioProdottoModel> _logger;

    public DettaglioProdottoModel(ILogger<DettaglioProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto { get; set; }
    public void OnGet(Prodotto prodotto)
    {
        Prodotto = prodotto;
    }
}

