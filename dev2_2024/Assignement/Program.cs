Random random = new Random(); // Random e la classe che genera numeri casuali
// new e il costruttore della classe Random che istanzia un oggetto Random
// random e l oggetto Random che possiamo utilizzare
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100
// viene generato un intervallo semi aperto tra 1 e 101 quindi che comprende il numero iniziale (1) ma esclude il numero finale (101)
// il metodo Next genera un numero casuale compreso tra il valore minimo incluso e il valore massimo escluso.

// verifico che il mondo next abbia generato il numero casuale stampandolo
// Console.WriteLine(numeroDaIndovinare);

// messaggio di inserimento numero
Console.Clear();
Console.WriteLine("Indovina il numero (tra 1 e 100);");

// dichiaro una variabile alla quale dopo associero il valore inserito dall utente
int numeroInserito;

// assegno alla variabile il valore inserito dall utente
numeroInserito = 0; // converto il valore inserito dall utente in un intero perche Console.ReadLine restituisce una stringa
// in alternativa al To Int32 posso usare il metodo Parse
// int numeroInserito = int.Parse(Console.ReadLine());
// oppure se voglio farlo in un unica istruzione
// int numeroInserito = Convert.ToInt32(Console.ReadLine());

// verifico che il numero inserito sia uguale al numero da indovinare
while (numeroInserito != numeroDaIndovinare)
{
    numeroInserito = Convert.ToInt32(Console.ReadLine());

if (numeroInserito < numeroDaIndovinare)
{
    // se il numero inserito e uguale al numero da indovinare stampo il messaggio di congratulazioni
    Console.WriteLine("Il numero da indovinare e maggiore.");

}
else
{
    // se il numero inserito non e uguale al numero da indovinare stampo il messaggio di errore
    Console.WriteLine("il numero da indovinare e minore");
    // stampo il numero da indovinare
    Console.WriteLine($"Il numero da indovinare era: {numeroDaIndovinare}");
}
Console.WriteLine("Riprova:");
}

Console.WriteLine("Hai indovinato! Il numero da indovinare era:" + numeroDaIndovinare); 