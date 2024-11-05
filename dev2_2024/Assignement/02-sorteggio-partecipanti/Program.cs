        // Lista dei partecipanti predefiniti
        List<string> partecipanti = new List<string>
        {
            "Giorgio", "Andrea", "Anita", "Ivan", "Tamer", 
            "Diego", "Felipe", "Sofia"
        };

        // Oggetto per il generatore di numeri casuali
        Random random = new Random();

        // Continua finché ci sono partecipanti nella lista
        while (partecipanti.Count > 0)
        {
            // Estrai un indice casuale
            int indiceCasuale = random.Next(partecipanti.Count);

            // Prendi il partecipante con l'indice casuale
            string partecipanteEstratto = partecipanti[indiceCasuale];

            // Stampa il nome estratto
            Console.WriteLine($"Il partecipante estratto è: {partecipanteEstratto}");

            // Rimuovi il partecipante estratto dalla lista
            partecipanti.RemoveAt(indiceCasuale);
        }

        Console.WriteLine("Tutti i partecipanti sono stati estratti!");
    
