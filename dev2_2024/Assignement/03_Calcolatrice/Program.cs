// Chiedi all'utente di inserire due numeri
Console.WriteLine("Inserisci due numeri");
double numeroUtente = int.Parse(Console.ReadLine());
double numeroUtente1 = int.Parse(Console.ReadLine());
// Chiedi all'utente di selezionare un operatore matematico
Console.Write("Scegli l'operatore (+, -, *, /): ");
string operatore = Console.ReadLine();
// Esegui l'operazione selezionata
 double risultato = 0;

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
             risultato = numeroUtente / numeroUtente1;
        }

        // Stampa il risultato
        Console.WriteLine($"Il risultato di {numeroUtente} {operatore} {numeroUtente1} è: {risultato}");
    
