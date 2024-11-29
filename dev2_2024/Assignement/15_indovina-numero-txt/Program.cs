
    {
        Console.Clear();
        Random random = new Random();
        string risposta = "s";

        do
        {
            int numeroDaIndovinare = 0;
            int punteggio = 0;
            bool haIndovinato = false;
            int tentativi = 0;
            string nomeUtente = "";

            // 1. Scegli il livello di difficoltà
            int scelta = SelezionaDifficolta(out numeroDaIndovinare, out punteggio, out tentativi, random);

            // 2. Ottieni il nome dell'utente
            nomeUtente = OttieniNomeUtente();

            Console.Clear();

            // 3. Gioca il gioco e gestisci i tentativi
            haIndovinato = GiocaGioco(numeroDaIndovinare, punteggio, tentativi, nomeUtente);

            // 4. Salva i tentativi nel file
            if (haIndovinato)
            {
                SalvaTentativiNelFile(nomeUtente, numeroDaIndovinare, tentativi);
            }

            // 5. Chiedi se l'utente vuole giocare di nuovo
            risposta = RichiediNuovaPartita();

        } while (risposta.ToLower() == "s");
    }

    // Funzione per selezionare il livello di difficoltà
    static int SelezionaDifficolta(out int numeroDaIndovinare, out int punteggio, out int tentativi, Random random)
    {
        int scelta;
        do
        {
            Console.WriteLine("Scegli il livello di difficolta':");
            Console.WriteLine("1. Facile (1-50, 10 tentativi)");
            Console.WriteLine("2. Medio (1-100, 7 tentativi)");
            Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

            bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);
            // pulisco la console
            Console.Clear();
            if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
            {
                Console.WriteLine("Scelta non valida.");
            }
        } while (scelta < 1 || scelta > 3);

        switch (scelta)
        {
            case 1:
                numeroDaIndovinare = random.Next(1, 51);
                punteggio = 100;
                tentativi = 10;
                break;
            case 2:
                numeroDaIndovinare = random.Next(1, 101);
                punteggio = 200;
                tentativi = 7;
                break;
            case 3:
                numeroDaIndovinare = random.Next(1, 201);
                punteggio = 300;
                tentativi = 5;
                break;
            default:
                numeroDaIndovinare = 0;
                punteggio = 0;
                tentativi = 0;
                break;
        }

        return scelta;
    }

    // Funzione per ottenere il nome dell'utente
    static string OttieniNomeUtente()
    {
        Console.WriteLine("Inserisci il tuo nome:");
        return Console.ReadLine();
    }

    // Funzione per gestire la logica del gioco
    static bool GiocaGioco(int numeroDaIndovinare, int punteggio, int tentativi, string nomeUtente)
    {
        bool haIndovinato = false;
        int numeroUtente = 0;
        Dictionary<string, List<int>> tentativiUtenti = new Dictionary<string, List<int>>();

        Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

        while (!haIndovinato && tentativi > 0)
        {
            Console.Write("Tentativo: ");
            bool successo = int.TryParse(Console.ReadLine(), out numeroUtente);
            // pulisco la console
            Console.Clear();

            if (!successo)
            {
                Console.WriteLine("Inserisci un numero valido.");
                continue;
            }

            tentativi--;
            // aggiungo il tentativo alla lista del nomeUtente
            if (!tentativiUtenti.ContainsKey(nomeUtente))
            {
                tentativiUtenti.Add(nomeUtente, new List<int>());
            }

            tentativiUtenti[nomeUtente].Add(numeroUtente); // aggiungo il tentativo alla lista del nomeUtente

            if (numeroUtente < numeroDaIndovinare)
            {
                Console.WriteLine("Il numero da indovinare è maggiore.");
            }
            else if (numeroUtente > numeroDaIndovinare)
            {
                Console.WriteLine("Il numero da indovinare è minore.");
            }
            else
            {
                Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
                haIndovinato = true;
            }

            if (!haIndovinato && tentativi == 0)
            {
                Console.WriteLine($"Hai esaurito i tentativi. Il numero era {numeroDaIndovinare}.");
            }

        }

        if (haIndovinato)
        {
            // stampa il punteggio dell'utente
            Console.WriteLine($"Punteggio: {punteggio}");
        }

        Console.WriteLine("Tentativi effettuati: ");
        foreach (var tentativoUtente in tentativiUtenti)
        {
            Console.WriteLine($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}");
        }

        return haIndovinato;
    }

    // Funzione per salvare i tentativi dell'utente in un file di testo
    static void SalvaTentativiNelFile(string nomeUtente, int numeroDaIndovinare, int tentativi)
    {
        string percorsoFile = "tentativi_utenti.txt";

        // Creiamo una stringa che contiene i dettagli dei tentativi
        string contenuto = $"Utente: {nomeUtente}\nNumero da indovinare: {numeroDaIndovinare}\nTentativi: {tentativi}\n\n";

        // Scriviamo i dati nel file
        try
        {
            // Se il file non esiste, lo crea. Se esiste, aggiunge le informazioni
            File.AppendAllText(percorsoFile, contenuto);
            Console.WriteLine("I tuoi tentativi sono stati salvati!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Errore durante il salvataggio: {e.Message}");
        }
    }

    // Funzione per chiedere se l'utente vuole giocare di nuovo
    static string RichiediNuovaPartita()
    {
        Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
        string risposta = Console.ReadLine();
        Console.Clear();

        while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
        {
            Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
            risposta = Console.ReadLine();
            Console.Clear();
        }

        return risposta;
    }

