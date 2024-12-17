public class ClienteManager // (CRUD)
{
    private ClienteRepository repository;
    private int prossimoId;
    List<Prodotto> carrello;
    List<Purchases> storicoAcquisti;

    public ClienteManager(List<Prodotto> Carrello, List<Purchases> StoricoAcquisti)
    {
        carrello = Carrello;
        storicoAcquisti = StoricoAcquisti;
        repository = new ClienteRepository();

        prossimoId = 1;

        foreach (var prodotto in carrello)
        {
            if (prodotto.Id >= prossimoId)
            {
                prossimoId = prodotto.Id + 1;
            }
        }
    }

    


    // metodo per aggiungere un prodotto alla lista
    public void AggiungiProdottoAlCarrello(Prodotto prodotto)
    {
        prodotto.Id = prossimoId;
        prossimoId++;
        carrello.Add(prodotto);
        Console.WriteLine($"Prodotto aggiunto con ID: {prodotto.Id}");
    }

    // metodo per visualizzare la lista di prodotti
    public List<Prodotto> OttieniProdotti()
    {
        return carrello;
    }


    public void StampaProdottiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
        $"{"ID",-5} {"Nome",-20} {"Prezzo",-10} {"Giacenza",-10} {"Categoria",-10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var prodotto in carrello)
        {
            Console.WriteLine(
                $"{prodotto.Id,-5} {prodotto.Nome,-20} {prodotto.Prezzo,-10:0.00} {prodotto.Giacenza,-10} {prodotto.Categoria,-10}"
            );
        }
    }

    // metodo per cercare un prodotto
    public Prodotto TrovaProdottoNelCarrello(int id)
    {
        foreach (var prodotto in carrello)
        {
            if (prodotto.Id == id)
            {
                return prodotto;
            }
        }
        return null;
    }
    // metodo per modificare un prodotto esistente
    public void AggiornaProdotto(int id, Prodotto nuovoProdotto)
    {
        var prodotto = TrovaProdottoNelCarrello(id);
        if (prodotto != null)
        {
            prodotto.Nome = nuovoProdotto.Nome;
            prodotto.Prezzo = nuovoProdotto.Prezzo;
            prodotto.Giacenza = nuovoProdotto.Giacenza;
            prodotto.Categoria = nuovoProdotto.Categoria;
        }
    }

    // metodo per eliminare un prodotto esistente
    public void EliminaProdottoNelCarrello(int id)
    {
        var prodotto = TrovaProdottoNelCarrello(id);
        if (prodotto != null)
        {
            carrello.Remove(prodotto);
            // elimina il file JSON corrispondente al prodotto
            string filePath = Path.Combine("ClientiJson", $"{prodotto.Id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Prodotto eliminato: {filePath}");
        }
    }
}