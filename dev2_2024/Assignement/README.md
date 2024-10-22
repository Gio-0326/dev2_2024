# INDOVINA NUMERO

## Obiettivo

L'obiettivo di questa applicazione e di indovinare un **numero casuale** generato dal computer.

> Passaggi:

1. Il computer genera un numero casuale tra 1 e 100.
2. L'utente inserisce un numero.
3. Il computer confronta il numero inserito con quello generato.
4. Se il numero inserito é uguale a quello generato, l'utente ha indovinato.
5. Altrimenti, il computer fornisce un suggerimento (maggiore e minore) e l'utente può inserire un nuovo numero.
6. Il gioco termina quando l'utente indovina il numero o quando raggiunge il numero massimo di tentativi.

> **Esempio di codice:**

## Versione 1

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
// new e il costruttore della classe Random che istanzia un oggetto Random
// random e l oggetto Random che possiamo utilizzare
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100
// viene generato un intervallo semi aperto tra 1 e 101 quindi che comprende il numero iniziale (1) ma esclude il numero finale (101)
// il metodo Next genera un numero casuale compreso tra il valore minimo incluso e il valore massimo escluso.

// verifico che il mondo next abbia generato il numero casuale stampandolo
// Console.WriteLine(numeroDaIndovinare);

// messaggio di inserimento numero
Console.Write("Indovina il numero (tra 1 e 100);");

// dichiaro una variabile alla quale dopo associero il valore inserito dall utente
int numeroInserito;

// assegno alla variabile il valore inserito dall utente
numeroInserito = Convert.ToInt32(Console.ReadLine()); // converto il valore inserito dall utente in un intero perche Console.ReadLine restituisce una stringa
// in alternativa al To Int32 posso usare il metodo Parse
// int numeroInserito = int.Parse(Console.ReadLine());
// oppure se voglio farlo in un unica istruzione
// int numeroInserito = Convert.ToInt32(Console.ReadLine());

// verifico che il numero inserito sia uguale al numero da indovinare
if (numeroInserito == numeroDaIndovinare)
{
    // se il numero inserito e uguale al numero da indovinare stampo il messaggio di congratulazioni
    Console.WriteLine("Complimenti! Hai indovinato il numero.");

}
else
{
    // se il numero inserito non e uguale al numero da indovinare stampo il messaggio di errore
    Console.WriteLine("Mi dispiace! Non hai indovinato il numero");
    // stampo il numero da indovinare
    Console.WriteLine($"Il numero da indovinare era: {numeroDaIndovinare}");
}
```

## Versione 2

**Obiettivo:**
Modifica il programma precedente per fornire all'utente suggerimenti dopo ogni tentativo, indicando se il numero da indovinare è maggiore o minore di quello inserito.

**Istruzioni**

* Usa un ciclo while per permettere all'utente di continuare a tentare finchè non indovina.
* Dopo ogni tentativo errato, indica se il numero da indovinare è maggiore o minore di quello inserito.
* Quando l'utente indovina, esci dal ciclo e stampa un messaggio di congratulazioni.

> **Esempio di codice:**

## Versione 2

```csharp
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
}
Console.WriteLine("Riprova:");
}

Console.WriteLine("Hai indovinato! Il numero da indovinare era:" + numeroDaIndovinare); 
```

## Versione 3

**Obiettivo:**
Imposta un numero massimo di tentativi (ad esempio, 5). Se 

**Esempio di codice**

```csharp
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

```



## Versione 4

**Obiettivo**
Assegna un punteggio all'utente in base al numero di tentativi utilizzati. Più tentativi impiega, minore sarà il punteggio.

**Istruzioni:**

* Inizia con un punteggio massimo (ad esempio, 100 punti).
* Ad ogni tentativo fallito, sottrai un certo numero di punti (ad esempio, 20 punti).
* Alla fine del gioco, mostra il punteggio all'utente.

**Esempio di codice:**

```csharp

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
```
