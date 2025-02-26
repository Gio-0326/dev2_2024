﻿
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        ProdottoRepository repository = new ProdottoRepository();

        ClienteRepository clienteRepository = new ClienteRepository();
        List<Cliente> clienti = new List<Cliente>();

        Cliente cliente = new Cliente();
        Prodotto prodotto = new Prodotto();
        
        List<Prodotto> prodotti = repository.CaricaProdotti();
        ClienteManager clienteManager = new ClienteManager(clienti);

        ProdottoManager manager = new ProdottoManager(prodotti);
        Console.WriteLine("Benvenuto nel supermercato!");

        bool continua = true;
        Console.WriteLine("Chi sei? \n1.Cliente \n2.Dipendente");
        string scelta = InputManager.LeggiIntero("\nScelta", 1, 2).ToString();
        while (continua)
        {

            switch (scelta)
            {
                case "1": // Cliente
                    Console.WriteLine("\nSei un cliente frequente o un nuovo cliente?");
                    Console.WriteLine("1.Cliente frequente");
                    Console.WriteLine("2.Nuovo cliente");
                    string tipoCliente = InputManager.LeggiIntero("\nScelta", 1, 2).ToString();

                    if (tipoCliente == "1") // Cliente frequente
                    {
                        Console.WriteLine("Benvenuto, cliente frequente!");
                        
                        Console.WriteLine("Inserisci il tuo username: ");
                        string username = InputManager.LeggiStringa("\nUsername: ");
                        Cliente clienteFrequente = clienteManager.TrovaCliente(cliente.id);
                        List<Cliente> Clienti = clienteRepository.CaricaClienti();

                        if (clienteFrequente != null)
                        {
                            Console.WriteLine($"Benvenuto, {clienteFrequente.username}! Il tuo carrello contiene:");
                            manager.StampaProdottiIncolonnati(); // Supponendo che Cliente abbia una lista di Prodotti chiamata "Carrello"
                        }
                        else
                        {
                            Console.WriteLine("Cliente non trovato. Registrati come nuovo cliente.");
                        }
                        break;

                    }
                    else // Nuovo cliente
                    {
                        Console.WriteLine("Benvenuto, nuovo cliente!");
                        Console.WriteLine("Inserisci il tuo username: ");
                        string Username = InputManager.LeggiStringa("\nUsername: ");
                        // Crea un nuovo cliente e aggiungilo alla lista
                        Cliente nuovoCliente = new Cliente { username = Username, carrello = new List<Prodotto>() };
                        clienteManager.AggiungiCliente(nuovoCliente, prodotto);
                        Console.WriteLine($"Cliente {Username} registrato con successo!");
                        clienteRepository.SalvaClienti(nuovoCliente);

                    }

                    Console.WriteLine("\n--------Menu Cliente--------");
                    Console.WriteLine("1.Visualizza Prodotti nel carrello");
                    Console.WriteLine("2.Aggiungi Prodotto al carrello");
                    Console.WriteLine("3.Trova Prodotto per ID");
                    Console.WriteLine("4.Aggiorna Prodotto nel carrello");
                    Console.WriteLine("5.Elimina Prodotto nel carrello");
                    Console.WriteLine("6.Esci");
                    string scelta2 = InputManager.LeggiIntero("\nScelta", 1, 6).ToString();

                    switch (scelta2)
                    {
                        case "1":
                            Console.WriteLine("\nProdotti:");

                            manager.StampaProdottiIncolonnati();

                            break;
                        case "2":

                            string nome = InputManager.LeggiStringa("\nNome: ");

                            decimal prezzo = InputManager.LeggiDecimale("\nPrezzo: ");

                            int giacenza = InputManager.LeggiIntero("\nGiacenza: ");

                            string categoria = InputManager.LeggiStringa("\nCategoria: ");

                            manager.AggiungiProdotto( new Prodotto  { Nome = nome, Prezzo = prezzo, Giacenza = giacenza, Categoria = categoria });

                            break;
                        case "3":
                            Console.Write("ID: ");

                            int idProdotto = InputManager.LeggiIntero("\nID: ");

                            Prodotto prodottoTrovato = manager.TrovaProdotto(idProdotto);
                            if (prodottoTrovato != null)
                            {
                                Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.Nome}");
                            }
                            else
                            {
                                Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                            }
                            break;
                        case "4":
                            int idProdottoDaAggiornare = InputManager.LeggiIntero("\nID: ");

                            string nomeNuovo = InputManager.LeggiStringa("\nNome: ");

                            decimal prezzoNuovo = InputManager.LeggiDecimale("\nPrezzo: ");

                            int giacenzaNuova = InputManager.LeggiIntero("\nGiacenza: ");

                            string categoriaNuova = InputManager.LeggiStringa("\nCategoria: ");

                            manager.AggiornaProdotto(idProdottoDaAggiornare, new Prodotto { Nome = nomeNuovo, Prezzo = prezzoNuovo, Giacenza = giacenzaNuova, Categoria = categoriaNuova });
                            break;
                        case "5":
                            Console.Write("ID: ");
                            int idProdottoDaEliminare = InputManager.LeggiIntero("\nProdotto da eliminare: ");
                            manager.EliminaProdotto(idProdottoDaEliminare);
                            break;
                        case "6":
                            foreach (var item in manager.OttieniProdotti())
                            {
                                repository.SalvaProdotti(item);
                            }
                            continua = false; // imposto la variabile continua a false per uscire dal ciclo while 
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprovare.");
                            break;
                    }
                    break;


                case "2": // Dipendente

                    Console.WriteLine("\n--------Menu Dipendente--------");
                    Console.WriteLine("1.Visualizza Prodotti del catalogo");
                    Console.WriteLine("2.Aggiungi Prodotto al catalogo");
                    Console.WriteLine("3.Trova Prodotto per ID");
                    Console.WriteLine("4.Aggiorna Prodotto del catalogo");
                    Console.WriteLine("5.Elimina Prodotto dal catalogo");
                    Console.WriteLine("6.Esci");
                    string scelta3 = InputManager.LeggiIntero("\nScelta", 1, 6).ToString();

                    switch (scelta3)
                    {
                        case "1":
                            Console.WriteLine("\nProdotti:");

                            manager.StampaProdottiIncolonnati();

                            break;
                        case "2":

                            string nome = InputManager.LeggiStringa("\nNome: ");

                            decimal prezzo = InputManager.LeggiDecimale("\nPrezzo: ");

                            int giacenza = InputManager.LeggiIntero("\nGiacenza: ");

                            string categoria = InputManager.LeggiStringa("\nCategoria: ");

                            manager.AggiungiProdotto(new Prodotto { Nome = nome, Prezzo = prezzo, Giacenza = giacenza, Categoria = categoria });
                            break;
                        case "3":
                            Console.Write("ID: ");

                            int idProdotto = InputManager.LeggiIntero("\nID: ");

                            Prodotto prodottoTrovato = manager.TrovaProdotto(idProdotto);
                            if (prodottoTrovato != null)
                            {
                                Console.WriteLine($"\nProdotto trovato per ID {idProdotto}: {prodottoTrovato.Nome}");
                            }
                            else
                            {
                                Console.WriteLine($"\nProdotto non trovato per ID {idProdotto}");
                            }
                            break;
                        case "4":
                            int idProdottoDaAggiornare = InputManager.LeggiIntero("\nID: ");

                            string nomeNuovo = InputManager.LeggiStringa("\nNome: ");

                            decimal prezzoNuovo = InputManager.LeggiDecimale("\nPrezzo: ");

                            int giacenzaNuova = InputManager.LeggiIntero("\nGiacenza: ");

                            string categoriaNuova = InputManager.LeggiStringa("\nCategoria: ");

                            manager.AggiornaProdotto(idProdottoDaAggiornare, new Prodotto { Nome = nomeNuovo, Prezzo = prezzoNuovo, Giacenza = giacenzaNuova, Categoria = categoriaNuova });
                            break;
                        case "5":
                            Console.Write("ID: ");
                            int idProdottoDaEliminare = InputManager.LeggiIntero("\nProdotto da eliminare: ");
                            manager.EliminaProdotto(idProdottoDaEliminare);
                            break;
                        case "6":
                            // Salva ogni prodotto singolarmente
                            foreach (var item in manager.OttieniProdotti())
                            {
                                repository.SalvaProdotti(item);
                            }
                            continua = false; // imposto la variabile continua a false per uscire dal ciclo while 
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprovare.");
                            break;
                    }
                    break;
            }
        }
    }
}























