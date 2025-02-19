using Microsoft.AspNetCore.Mvc.RazorPages;
using _37_webapp_Sqlite.Utilities;

namespace _37_webapp_Sqlite.Models;
// namespace Prodotti.Pages.Prodotti; se avessi il namespace

public class SearchModel : PageModel
{
    // proprietà pubblica che memorizzi la stringa di ricerca
    public string SearchTerm { get; set; }
    // La proprietà per memorizzare i risultati dei prodotti trovati
    public List<ProdottoViewModel> Prodotti { get; set; } = new List<ProdottoViewModel>();
    // PaginatedList è una classe generica che ti permette di gestire la paginazione dei risultati
    public PaginatedList<ProdottoViewModel> Products { get; set; }
    // Impostazione della dimensione di pagina (ovvero quanti risultati mostrare per pagina)
    public int PageSize { get; set; } = 5;

    // Metodo che viene chiamato quando la pagina è caricata (GET) e può ricevere i parametri `q` e `pageIndex` dalla query string
    public void OnGet(string q, int? pageIndex) 
    {

        // assegno la stringa di ricerca alla proprietà pubblica SearchTerm
        SearchTerm = q;
        // Verifica che la stringa di ricerca non sia vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            try
            {
                // Se pageIndex è diverso da null, assegna il suo valore a currentPage; altrimenti, assegna 1.
                int currentPage = pageIndex ?? 1;
                // Recupero il numero totale di prodotti
                int totalCount = DbUtils.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
                 // Calcola l'offset per la paginazione in base alla pagina corrente e alla dimensione della pagina
                int offset = (currentPage - 1) * PageSize;
                // La query SQL per ottenere i prodotti che corrispondono al termine di ricerca, uniti alle categorie (LEFT JOIN)
                string sql = $@"
                SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome 
                FROM Prodotti p 
                LEFT JOIN Categorie c ON p.CategoriaId = c.Id 
                WHERE p.Nome LIKE @searchTerm
                ORDER BY p.Id
                LIMIT {PageSize} OFFSET {offset}";
                
                // Esegue la query utilizzando DbUtils e restituisce i risultati in un elenco di oggetti ProdottoViewModel
                List<ProdottoViewModel> items = DbUtils.ExecuteReader(sql,
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                },
                cmd =>
                {
                     // Aggiunge il parametro per la query SQL, evitando vulnerabilità come l'SQL Injection
                    cmd.Parameters.AddWithValue("@searchTerm", $"%{q}%");
                }
            );
              // Crea l'oggetto PaginatedList, che contiene i risultati dei prodotti e le informazioni per la paginazione
            Products = new PaginatedList<ProdottoViewModel>(items, totalCount, currentPage, PageSize);
            }
            catch (Exception ex)
            {
                // Gestisce le eventuali eccezioni e le registra nel log (utilizzando un semplice logger)
                SimpleLogger.Log(ex);
            }
        }
        else
        {
            // Se il termine di ricerca è vuoto o nullo, restituisce una lista vuota di prodotti con una paginazione di 0 risultati
            Products = new PaginatedList<ProdottoViewModel>(new List<ProdottoViewModel>(),0,1, PageSize);
            return;
        }

    }
}
/*using var connection = DatabaseInitializer.GetConnection();
connection.Open();  

// query per selezionare i prodotti che contengono la stringa di ricerca
// il like è case insensitive di default in sqlite
// il like è una clausola che permette di fare una ricerca parziale

var sql = @"
SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
FROM Prodotti p
LEFT JOIN Categorie c ON p.CategoriaId = c.Id
WHERE p.Nome LIKE @searchTerm";

// creo un comando sql per eseguire la query
using var command = new SQLiteCommand (sql, connection);
// uso il parametro per evitare sql Injection con % + q + % in modo da cercare la stringa in qualsiasi parte del nome
command.Parameters.AddWithValue("@searchTerm", $"%{q}%");
// ottengo il reader
using var reader = command.ExecuteReader();
// finche il reader ha qualcosa da leggere
while (reader.Read())
{
    // aggiungo un nuovo prodotto alla lista Prodotti
    Prodotti.Add(new ProdottoViewModel
    { Id = reader.GetInt32(0),
      Nome = reader.GetString(1),
      Prezzo = reader.GetDouble(2),
      CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
    });
}*/
