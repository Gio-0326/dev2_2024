public class ProdottoAdvancedManager // (CRUD)
{
    private List<ProdottoAdvanced> prodotti; // prodotti è private perchè non voglio che venga modificato dall'esterno
    // questo new è necessario affinche dal dominio privato la classe possa comunicare all'esterno i dati aggiornati
    // un modo per rendere pubblico un dato privato
    private int prossimoId;

    private ProdottoRepository repository;
    public ProdottoAdvancedManager(List<ProdottoAdvanced> Prodotti)
    {
        prodotti = Prodotti;
        repository = new ProdottoRepository();

        prossimoId = 1;

        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }

    // metodo per aggiungere un prodotto alla lista
    public void AggiungiProdotto(ProdottoAdvanced prodotto)
    {
        prodotto.Id = prossimoId;
        prossimoId++;
        prodotti.Add(prodotto);
        Console.WriteLine($"Prodotto aggiunto con ID: {prodotto.Id}");
    }

    // metodo per visualizzare la lista di prodotti
    public List<ProdottoAdvanced> OttieniProdotti()
    {
        return prodotti;
    }

    // Ogni campo utilizza il formato {Campo - Larghezza} dove:
    // Campo è il valore da stampare
    // Larghezza specifica la larghezza del campo; il segno - allinea il testo a sinistra.
    // {"Nome", -20} significa che il nome del prodotto avrà una larghezza fissa di 20 caratteri, allineato a sinistra
    // Formato dei numeri:
    // Per i pezzi, viene usato il formato 0.00 per mostrare sempre due cifre decimali
    // Linea separatrice:
    // La riga Console.WriteLine(new string('-', 50)); stampa una line divisoria lunga 50 caratteri per migliorare la lggibilità

    public void StampaProdottiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
        $"{"ID",-5} {"Nome",-20} {"Prezzo",-10} {"Giacenza",-10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var prodotto in prodotti)
        {
            Console.WriteLine(
                $"{prodotto.Id,-5} {prodotto.NomeProdotto,-20} {prodotto.PrezzoProdotto,-10:0.00} {prodotto.GiacenzaProdotto,-10}"
            );
        }
    }

    // metodo per cercare un prodotto
    public ProdottoAdvanced TrovaProdotto(int id)
    {
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                return prodotto;
            }
        }
        return null;
    }
    // metodo per modificare un prodotto esistente
    public void AggiornaProdotto(int id, ProdottoAdvanced nuovoProdotto)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotto.NomeProdotto = nuovoProdotto.NomeProdotto;
            prodotto.PrezzoProdotto = nuovoProdotto.PrezzoProdotto;
            prodotto.GiacenzaProdotto = nuovoProdotto.GiacenzaProdotto;
        }
    }

    // metodo per eliminare un prodotto esistente
    public void EliminaProdotto(int id)
    {
        var prodotto = TrovaProdotto(id);
        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
            // elimina il file JSON corrispondente al prodotto
            string filePath = Path.Combine("ProdottiJson", $"{prodotto.Id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Prodotto eliminato: {filePath}");
        }
    }
}