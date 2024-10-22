// METODI ARRAY
//  un metodo e un blocco di codice che esegue un azione
// solitamente i metodi restituiscono un valore
// solitamente sono definiti come array.metodo()
/*
I principali metodi per manipolare sono:
- Length
- Copy
- Clear
- Reverse
- Sort
- IndexOf
*/


Console.Clear();


// ESEMPIO DI METODO LENGTH
// da la lunghezza di un array
int[] array = { 1, 2, 3, 4, 5 }; // dichiara e inizializza un array di interi
Console.WriteLine(array.Length); // stampa la lunghezza dell array

// ESEMPIO DI METODO COPY
// copia un array in un altro array
int[] array1 = { 1, 2, 3, 4, 5 }; // dichiara e inizializza un array di interi
int[] array2 = new int[array1.Length]; // dichiara e inizializza un array di interi con la stessa lunghezza
array1.CopyTo(array2, 0); // cpia array1 in array2 0 significa da dove inizia a copiare
Console.WriteLine(string.Join(", ", array2)); // stampa array2
                                              // .Join unisce gli elementi di un array in una stringa separati da una virgola

// ESEMPIO DI METODO CLEAR
// cancella gli elementi di un array
int[] array3 = { 1, 2, 3, 4, 5 }; //
Array.Clear(array3, 0, array3.Length);
Console.WriteLine(string.Join(",", array3));

// ESEMPIO DI METODO REVERSE
// invertire gli elementi di un array
int[] array4 = { 1, 2, 3, 4, 5 }; 
Array.Reverse(array4);
Console.WriteLine(string.Join(",", array4));

// ESEMPIO DI METODO SORT
// ordina gli elementi di un array
int[] array5 = { 5, 3, 1, 4, 2 };
Array.Sort(array5); // ordina gli elementi di array5
Console.WriteLine(string.Join(",", array5)); // stampa array5

// ESEMPIO DI METODO INDEXOF
// restituisce l indice di un elemento di un array
int[] array6 = { 1, 2, 3, 4 , 5 }; // dichiara e inizializza un array di interi
Console.WriteLine(Array.IndexOf(array6, 3)); // stampa l indice di 3 in array6 (2) se non ce restituisce -1 