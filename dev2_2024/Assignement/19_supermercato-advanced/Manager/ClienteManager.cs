public class ClienteManager // (CRUD)
{
    private ClienteRepository repository;
    private int prossimoId;
    private List<Cliente> clienti;
    

    public ClienteManager(List<Cliente> Clienti)
    {
        clienti = Clienti;
        
        repository = new ClienteRepository();

        prossimoId = 1;

        foreach (var cliente in clienti)
        {
            if (cliente.id >= prossimoId)
            {
                prossimoId = cliente.id + 1;
            }
        }
    }

    


    // metodo per aggiungere un prodotto alla lista
    public void AggiungiCliente(Cliente cliente)
    {
        cliente.id = prossimoId;
        prossimoId++;
        clienti.Add(cliente);
        Console.WriteLine($"Cliente aggiunto con ID: {cliente.id}");
    }

    // metodo per visualizzare la lista di prodotti
    public List<Cliente> OttieniProdotti()
    {
        return clienti;
    }


    public void StampaClientiIncolonnati()
    {
        // Intestazioni con larghezza fissa
        Console.WriteLine(
        $"{"ID",-5} {"Username",-20} {"PercentualeSconto",-10} {"Credito",-10} "
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var cliente in clienti)
        {
            Console.WriteLine(
                $"{cliente.id,-5} {cliente.username,-20} {cliente.percentualeSconto,-10:0.00} {cliente.credito,-10}" 
            );
        }
    }

    
    public Cliente TrovaCliente(int id)
    {
        foreach (var cliente in clienti)
        {
            if (cliente.id == id)
            {
                return cliente;
            }
        }
        return null;
    }
    
    /*public void AggiornaProdotto(int id, Prodotto nuovoProdotto)
    {
        var prodotto = TrovaProdottoNelCarrello(id);
        if (prodotto != null)
        {
            prodotto.Nome = nuovoProdotto.Nome;
            prodotto.Prezzo = nuovoProdotto.Prezzo;
            prodotto.Giacenza = nuovoProdotto.Giacenza;
            prodotto.Categoria = nuovoProdotto.Categoria;
        }
    }*/

    // metodo per eliminare un prodotto esistente
    public void EliminaCliente(int id)
    {
        var cliente = TrovaCliente(id);
        if (cliente != null)
        {
            clienti.Remove(cliente);
            // elimina il file JSON corrispondente al prodotto
            string filePath = Path.Combine("Data/Clienti", $"{cliente.id}.json");
            File.Delete(filePath);
            Console.WriteLine($"Prodotto eliminato: {filePath}");
        }
    }
}