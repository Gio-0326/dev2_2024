// FUNZIONI
// una funzione è un blocco di codice che esegue un compito specifico
// ci sono funzioni che elaborano i dati ma non restituiscono alcun valore
// ci sono funzioni che restituiscono un valore

// una funzione è composta da:
// - nome
// - parametri

// un esempio di funzione che non restituisce alcun valore (void)
// void NomeFunzione(parametri)
// {
//    codice
// }
// blocco di codice esterno alla funzione che la chiama
// MODIFICATORI
// le funzioni hanno anche dei modificatori di accesso come public e private che ne limitano la visibilità
// una funzione public può essere chiamata da qualsiasi parte del programma
// una funzione private può essere chiamata solo all'interno del codice della classe in cui è definita

// quindi una funzione completa di modificatore di accesso potrebbe essere così:
// public void NomeFunzione(parametri)
// {
//    codice
// }
// blocco di codice esterno alla funzione che la chiama

// esempio di funzione void che stampa un messaggio
void StampaMessaggio() // devo mettere il modificatore public
{
    Console.WriteLine("funzione void");
}
StampaMessaggio(); // utilizzo della funzione

// esempio di funzione void che stampa un messaggio con parametro
void StampaMessaggioConParametro(string messaggio)
{
    Console.WriteLine(messaggio);
}

StampaMessaggioConParametro("funzione void con parametro");// utilizzo della funzione
// esempio di funzione che stampa un messaggio con più parametri
void StampaMessaggioConPiuParametri(string messaggio1, string messaggio2)
{
    Console.WriteLine($"{messaggio1} {messaggio2}");
}
StampaMessaggioConPiuParametri("funzione void con", "piu parametri"); // utilizzo della funzione

// esempio di funzione che restituisce un valore
// una funzione che restituisce un valore deve specificare il tipo di quel valore al posto di void
// poiche prende due interi come parametri e restituisce la somma, il tipo di ritorno e int anziche void
int Somma(int a, int b)
{
    return a + b;
}
int risultato = Somma(2, 3); // utilizzo della funzione
Console.WriteLine(risultato); // stampa 5

// esempio di funzione che restituisce una stringa
string Saluta(string nome)
{
    return $"Ciao {nome}!"; // restituisce una stringa con il nome passato come parametro
}
string saluto = Saluta("studente"); // utilizzo della funzione
Console.WriteLine(saluto); // stampa Ciao studente

// esempio di funzione che restituisce un booleano
bool ParolaPari(string parola)
{
    return parola.Length % 2 == 0; // restituisce true se la lunghezza della parola e un intero pari, false altrimenti
}
bool risultatoPari = ParolaPari("cane"); // utilizzo della funzione
Console.WriteLine(risultatoPari); // stampa true
