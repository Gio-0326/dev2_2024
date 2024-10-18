// CICLI
/*
I principali tipi di cicli sono:
- for
- while
- do while
- foreach
*/

// pulisce la console
Console.Clear();
// ESEMPIO DI FOR
// esegue un blocco di codice un numero di volte definito
for (int i = 0; i <= 10; i++) // i e una variabile di controllo che parte da 0 e finisce a 10
{
    Console.WriteLine(i); // stampa i che e il valore della variabile di controllo
}

// ESEMPIO DI WHILE
// esegue un blocco di codice finche una condizione e vera
int j = 0; // j e una variabile di controllo
while (j <= 10) // finche j e minore o uguale a 10
{
    Console.WriteLine(j); // stampa j
    j++; // incrementa j
}

// ESEMPIO DI DO WHILE CON TRUE
// esegue un blocco di codice almeno una volta e poi finche una condizione e vera
while (true) // finche vero
{}

// ALTRO ESEMPIO DI DO WHILE
int numero = 10; //


// ESEMPIO DI FOREACH
// esegue un blocco di codice per ogni elemento di una collezione come un array o una lista
// esempio che stampa il nome di ogni elemento di un array
string[] nomi = { "mario", "luigi", "peach" }; // array di stringhe
foreach (string nome in nomi) // per ogni stringa di nomi
// nome e una variabilie di controllo che contiene il valore dell elemento corrente
// nomi e l array di stringhe
{
    Console.WriteLine(nome); // stampa la stringa
}