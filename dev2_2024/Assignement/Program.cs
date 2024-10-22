Random random = new Random(); 

int numeroDaIndovinare = random.Next(1, 101); 
int tentativi = 0;
int massimoTentativi = 5;
bool haIndovinato = false;
Console.Clear();
Console.WriteLine("Indovina il numero (tra 1 e 100). Hai 5 tentativi.");

 while (tentativi < massimoTentativi && !haIndovinato)
        {
            Console.WriteLine("Tentativo {0}: ", tentativi + 1);

            int numeroUtente = int.Parse(Console.ReadLine());

            tentativi++;

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
                Console.WriteLine("Complimenti! Hai indovinato il numero.");
               haIndovinato = true; 
            }

          
        }

        Console.WriteLine($"Hai esaurito il numero di tentativi! Il numero da indovinare era: {numeroDaIndovinare}");
           


