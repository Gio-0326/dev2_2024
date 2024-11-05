        // Richiesta di input
        Console.Write("Inserisci il numero di squadre: ");
        int numeroSquadre = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il numero di partecipanti per squadra: ");
        int numeroPartecipantiPerSquadra = int.Parse(Console.ReadLine());

        // Calcola il numero totale di partecipanti
        Console.Write("Inserisci il numero totale di partecipanti: ");
        int numeroPartecipantiTotale = int.Parse(Console.ReadLine());

        // Controllo se i partecipanti totali sono sufficienti
        if (numeroPartecipantiTotale < numeroSquadre)
        {
            Console.WriteLine("Il numero di partecipanti deve essere maggiore o uguale al numero di squadre.");
            return;
        }

        // Creazione della lista dei partecipanti
        List<string> partecipanti = new List<string>();
        for (int i = 0; i < numeroPartecipantiTotale; i++)
        {
            Console.Write($"Inserisci il nome del partecipante #{i + 1}: ");
            partecipanti.Add(Console.ReadLine());
        }

        // Mescolamento casuale dei partecipanti
        Random rng = new Random();
        int n = partecipanti.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = partecipanti[k];
            partecipanti[k] = partecipanti[n];
            partecipanti[n] = value;
        }

        // Creazione delle squadre
        List<List<string>> squadre = new List<List<string>>();
        int partecipantiPerSquadra = numeroPartecipantiTotale / numeroSquadre;
        int extra = numeroPartecipantiTotale % numeroSquadre;

        // Inizializzazione delle squadre vuote
        for (int i = 0; i < numeroSquadre; i++)
        {
            squadre.Add(new List<string>());
        }

        // Assegnamento partecipanti alle squadre
        int index = 0;
        for (int i = 0; i < numeroSquadre; i++)
        {
            int numeroPartecipantiDaAssegnare = partecipantiPerSquadra + (i < extra ? 1 : 0);

            for (int j = 0; j < numeroPartecipantiDaAssegnare; j++)
            {
                squadre[i].Add(partecipanti[index]);
                index++;
            }
        }

        // Visualizzazione dei gruppi
        Console.WriteLine("\nLe squadre sorte sono:");
        for (int i = 0; i < numeroSquadre; i++)
        {
            Console.WriteLine($"\nSquadra {i + 1}:");
            foreach (var partecipante in squadre[i])
            {
                Console.WriteLine(partecipante);
            }
        }


