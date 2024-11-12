
        double numeroUtente = 0;
        double numeroUtente1 = 0;
        string operatore = "";
        double risultato = 0;

        // Inserimento del primo numero con gestione degli errori
        void StampaMessaggio()
        {
            Console.WriteLine("Inserisci il primo numero:");
        }
        StampaMessaggio();
        
        try
        {
            void LeggeMessaggio()
            {
                numeroUtente = double.Parse(Console.ReadLine());
            }
            LeggeMessaggio();
        }
        catch (FormatException e)
        {
            void StampaMessaggio1()
            {
                Console.WriteLine("Errore: Devi inserire un numero valido.");
                return;
            }
            StampaMessaggio1();
        }

        // Inserimento del secondo numero con gestione degli errori
        void StampaMessaggio2()
        {
            Console.WriteLine("Inserisci il secondo numero:");
        }
        StampaMessaggio2();
        try
        {
            void LeggeMessaggio1()
            {
                numeroUtente1 = double.Parse(Console.ReadLine());
            }
            LeggeMessaggio1();
        }
        catch (FormatException e)
        {
            void StampaMessaggio3()
            {
                Console.WriteLine("Errore: Devi inserire un numero valido.");
                return;
            }
             StampaMessaggio3();
        }

        // Scelta dell'operatore
        void StampaMessaggio4()
        {
            Console.Write("Scegli l'operatore (+, -, *, /): ");
        }
        StampaMessaggio4();
        
        void LeggeMessaggio2()
        {
            operatore = Console.ReadLine();
        }
        LeggeMessaggio2();
    
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
                    void StampaMessaggio5()
                    {
                        Console.WriteLine("Errore: La divisione per zero non è consentita.");
                        return; 
                    }
                    StampaMessaggio5();
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
        catch (Exception e)
        {
            Console.WriteLine($"Si è verificato un errore: {e.Message}");
        }
    
    