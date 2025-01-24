var prodotti = new List<Prodotto>
{
    new Prodotto{ Id = 1, Nome = "Prodotto1", Prezzo = 1.5m },
    new Prodotto{ Id = 2, Nome = "Prodotto2", Prezzo = 2.0m },
    new Prodotto{ Id = 3, Nome = "Prodotto3", Prezzo = 3.0m },
    new Prodotto{ Id = 4, Nome = "Prodotto4", Prezzo = 4.0m },
    new Prodotto{ Id = 5, Nome = "Prodotto5", Prezzo = 5.0m },
    new Prodotto{ Id = 6, Nome = "Prodotto6", Prezzo = 6.0m },
    new Prodotto{ Id = 7, Nome = "Prodotto7", Prezzo = 7.0m },
    new Prodotto{ Id = 8, Nome = "Prodotto8", Prezzo = 8.0m },
    new Prodotto{ Id = 9, Nome = "Prodotto9", Prezzo = 9.0m },
    new Prodotto{ Id = 10, Nome = "Prodotto10", Prezzo = 10.0m },
};

int articoliPerPagina = 3; // Numero di articoli per pagina

MostraProdottiPaginati(prodotti, articoliPerPagina);

static void MostraProdottiPaginati(List<Prodotto> prodotti, int articoliPerPagina)
{
    // numero totale di prodotti
    int totaleProdotti = prodotti.Count;
    // calcolo del totale delle pagine con totale prodotti diviso gli articoli in ogni pagina
    int totalePagine = (int)Math.Ceiling((decimal)totaleProdotti / articoliPerPagina);
    // definsco la pagina corrente
    int paginaCorrente = 1; // Pagina iniziale

    while(true)
    {
        Console.Clear();
        Console.WriteLine($"Pagina  {paginaCorrente} di {totalePagine}");
        Console.WriteLine(new string('-', 30)); // Linea divisoria

        var prodottiPagina = prodotti // Lista di prodotti in modo da poter fare la paginazione
        // paginazione
        // Skip salta i primi n elementi
        // Take prende i primi n elementi
        .Skip((paginaCorrente - 1) * articoliPerPagina) // Salta i prodotti delle pagine precedenti
        .Take(articoliPerPagina); // Prendi i prodotti della pagina corrente

        foreach(var prodotto in prodottiPagina)
        {
            Console.WriteLine($"ID: {prodotto.Id} - Nome: {prodotto.Nome} - Prezzo: {prodotto.Prezzo}");
        }

        Console.WriteLine(new string('-', 30)); // Linea divisoria
        // stampo i pulsanti di navigazione
        Console.WriteLine("Navigazione: [<] Pagina precedente | [>] Prossima pagina | [E] Esci");

        // uso il readkey in modo da non dover premere invio

        var input = Console.ReadKey(true).Key; // il true serve per non mostare il tasto premuto

        if (input == ConsoleKey.RightArrow && paginaCorrente < totalePagine)
        {
            paginaCorrente++; // va avanti avendo come limite il totale delle pagine
        }
        else if (input == ConsoleKey.LeftArrow && paginaCorrente > 1)
        {
            paginaCorrente--; // va indietro avendo come limite la prima pagina
        }
        else if(input == ConsoleKey.Escape)
        {
            break;
        }
    }
}

public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }
}

