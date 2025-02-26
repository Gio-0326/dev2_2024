using Microsoft.AspNetCore.Mvc.RazorPages;
using _37_webapp_Sqlite.Utilities;


namespace _37_webapp_Sqlite.Models;
// namespace 37_webapp-SQLite.Pages.Prodotti // dichiaro
public class ProdottiModel : PageModel
{
    // creo una proprietà pubblica di tipo lista di prodotti view model
    // creo una lista di prodotti view model per contenere i dati dei prodotti

    public List<ProdottoViewModel> Prodotti { get; set; } = new List<ProdottoViewModel>();
    public PaginatedList<ProdottoViewModel> Products { get; set; }
    public int TotaleProdotti { get; set; }
    public int PageSize { get; set; } = 5; 
    // Il parametro 'pageIndex' è di tipo nullable (int?) per gestire la possibilità che non venga fornito un valore per la pagina.
    public void OnGet(int? pageIndex) 
    {
        try
        {
            // Se pageIndex è diverso da null, assegna il suo valore a currentPage; altrimenti, assegna 1.
            int currentPage = pageIndex ?? 1; 
            // Recupero il numero totale di prodotti
            int totalCount = DbUtils.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
            // Calcola l'offset per la query
            int offset = (currentPage - 1) * PageSize;

            string sql = $@"
            SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome, f.Nome as FornitoreNome
            FROM Prodotti p
            LEFT JOIN Categorie c ON p.CategoriaId = c.Id
            LEFT JOIN Fornitori f ON p.FornitoreId = f.Id
            ORDER BY p.Id
            LIMIT {PageSize} OFFSET {offset}";

            // Utilizzo di DbUtils per leggere la lista dei prodotti
            List<ProdottoViewModel> items = DbUtils.ExecuteReader(sql,
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
                    FornitoreNome  = reader.IsDBNull(4) ? "Nessuna" : reader.GetString(4)
                }
            );
            // Crea l'oggetto paginato
        Products = new PaginatedList<ProdottoViewModel>(items, totalCount, currentPage, PageSize);
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            TotaleProdotti = DbUtils.ExecuteScalar<int>("SELECT COUNT (*) FROM Prodotti");
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}

/* invoco il metodo GetConnection per ottenere la connessione al db
using var connection = DatabaseInitializer.GetConnection();
// apro la connessione
connection.Open();

// creo la query sql per ottenere i dati dei prodotti
// voglio accedere al nome della categoria quindi devo fare un join tra la tabella prodotti e la tabella categorie
// uso JOIN per ottenere solo i prodotti con categoria
// uso LEFT JOIN per ottenere anche i prodotti senza categoria
// posso usare p e c come alias per le tabelle prodotti e categorie se voglio usare i nomi completi delle tabelle devo usare Prodotti e Categorie
// pero usando Prodotti e Categorie il codice diventa piu lungo perchè devo assegnare i nomi completi delle tabelle ai campi
// il vantaggio di usare gli alias è che dopo posso usare p e c per accedere ai campi delle tabelle
var sql = @"
SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
FROM Prodotti p
LEFT JOIN Categorie c ON p.CategoriaId = c.Id";

// creo un comando sql per eseguire la query
using var command = new SQLiteCommand(sql, connection);

// uso il reader come un cursore per scorrere i record restituiti dalla query
using var reader = command.ExecuteReader();

// leggo i record restituiti dalla query finchè ce ne sono
while (reader.Read())
{
    // aggiungo i dati del prodotto alla lista di prodotti
    // uso prodotto view model perche voglio visualizzare il nome della categoria
    Prodotti.Add(new ProdottoViewModel {
    // faccio il get dei campi del record restituito dalla query
    Id = reader.GetInt32(0),
    Nome = reader.GetString(1),
    Prezzo = reader.GetDouble(2),
    // versione senza il controllo se la categoria è nulla
    // CategoriaNome = reader.GetString(3)
    // is db null controlla se il campo è null e restituisce true se è null
    // se è null restituisco l'elemento alla sinistra dei due punti
    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3) 
    });

}

// Prodotti più costosi (Top 5)
//ProdottiCostosi = Prodotti.OrderByDescending(p => p.Prezzo).Take(5).ToList();

// Prodotti più recenti (Top 5)
//ProdottiRecenti = Prodotti.OrderByDescending(p => p.DataAggiunta).Take(5).ToList();

// Prodotti elettronici
//ProdottiElettronica = Prodotti.Where(p => p.CategoriaNome.Equals("Elettronica", StringComparison.OrdinalIgnoreCase)).ToList();*/



