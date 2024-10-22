Random random = new Random(); 

int numeroDaIndovinare = random.Next(1, 101); 
int puntiPenalizzati = 20;
int massimoPunteggio = 100;
int punteggio = massimoPunteggio;
int tentativi = 0;
bool haIndovinato = false;
Console.Clear();
Console.WriteLine("Indovina il numero (tra 1 e 100). Hai 5 tentativi.");

 while (!haIndovinato)
        {
            Console.WriteLine("Inserisci il tuo numero: ");
            int numeroUtente;
            if (int.TryParse(Console.ReadLine(), out numeroUtente))
            {
                tentativi++;
                
                if (numeroUtente < 1 || numeroUtente > 100)
                {
                    Console.WriteLine("Per favore, inserisci un numero valido tra 1 e 100.");
                    continue;
                }

                if (numeroUtente == numeroDaIndovinare)
                {
                    haIndovinato = true;
                    Console.WriteLine($"Congratulazioni! Hai indovinato il numero {numeroDaIndovinare}.");
                }
                else if (numeroUtente < numeroDaIndovinare)
                {
                    Console.WriteLine("Il numero è più alto.");
                }
                else
                {
                    Console.WriteLine("Il numero è più basso.");
                }
            }
            else
            {
                Console.WriteLine("Input non valido. Inserisci un numero.");
            }
        }

        punteggio -= (tentativi - 1) * puntiPenalizzati; 

        if (punteggio < 0) punteggio = 0; 

        Console.WriteLine($"Hai effettuato {tentativi} tentativi. Il tuo punteggio finale è: {punteggio}");
        
    

           


