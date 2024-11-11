
        double numeroUtente = 0;
        double numeroUtente1 = 0;
        string operatore = "";
        double risultato = 0;

        // Inserimento del primo numero con gestione degli errori
        Console.WriteLine("Inserisci il primo numero:");
        try
        {
            numeroUtente = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: Devi inserire un numero valido.");
            return; 
        }

        // Inserimento del secondo numero con gestione degli errori
        Console.WriteLine("Inserisci il secondo numero:");
        try
        {
            numeroUtente1 = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: Devi inserire un numero valido.");
            return; 
        }

        // Scelta dell'operatore
        Console.Write("Scegli l'operatore (+, -, *, /): ");
        operatore = Console.ReadLine();

        try
        {
            // Calcolo del risultato in base all'operatore scelto
            if (operatore == "+")
            {
                risultato = numeroUtente + numeroUtente1;
            }
            else if (operatore == "-")
            {
                risultato = numeroUtente - numeroUtente1;
            }
            else if (operatore == "*")
            {
                risultato = numeroUtente * numeroUtente1;
            }
            else if (operatore == "/")
            {
                if (numeroUtente1 == 0)
                {
                    Console.WriteLine("Errore: La divisione per zero non è consentita.");
                    return; 
                }
                risultato = numeroUtente / numeroUtente1;
            }
            else
            {
                Console.WriteLine("Errore: Operatore non valido.");
                return; 
            }

            // Visualizzazione del risultato
            Console.WriteLine($"Il risultato di {numeroUtente} {operatore} {numeroUtente1} è: {risultato}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
        }
    
    