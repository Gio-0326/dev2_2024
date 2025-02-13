using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;
// namespace 37_webapp-SQLite.Pages.Prodotti // dichiaro
public class ProdottiModel : PageModel
{
    // creo una proprietà pubblica di tipo lista di prodotti view model
    // creo una lista di prodotti view model per contenere i dati dei prodotti

    public List<ProdottoViewModel> Prodotti { get; set; } = new List<ProdottoViewModel>();

    public void OnGet()
    { 
        // invoco il metodo GetConnection per ottenere la connessione al db
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
    }
}

