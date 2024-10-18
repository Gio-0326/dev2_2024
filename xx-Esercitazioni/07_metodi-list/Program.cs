// METODI LISTA
/*
i metodi disponibili per manipolare le liste sono:
- Count
- Add
- AddRange
- Clear
- Contains
- IndexOf
- Remove
- RemoveAt
- Sort
- ToArray
- TrimExcess
*/

Console.Clear();

// ESEMPIO DI METODO COUNT
// restituisce il numero di elementi di una lista
List<int> lista1 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
Console.WriteLine(lista1.Count); // stampa il  numero di elementi di lista1

// ESEMPIO DI METODO ADD
// aggiunge un elemnto alla fine di una lista 
List<int> lista2 = new List<int> { 1, 2, 3, 4, 5 };
lista2.Add(6);
Console.WriteLine(string.Join(", ", lista2));

// ESEMPIO DI METODO ADDRANGE
// aggiunge una collezione alla fine di una lista
List<int> lista3 = new List<int> { 1, 2, 3, 4, 5 };
List<int> lista4 = new List<int> { 6, 7, 8, 9, 10 };
lista3.AddRange(lista4);

// ESEMPIO DI METODO CLEAR
// cancella gli elementi di una lista
List<int> lista5 = new List<int>{ 1, 2, 3, 4, 5 };
lista5.Clear();
// posso cancellare un elemento specifico con lista5.Remove(3) che cancella il primo 3 trovarto
lista5.Remove(3); // cancella il primo 3 trovato
Console.WriteLine(string.Join(",", lista5));

// ESEMPIO DI METODO CONTAINS
// restituisce true se una lista contiene un elemento
List<int> lista6 = new List<int> {1, 2, 3, 4, 5 };
Console.WriteLine(lista6.Contains(3));

// ESEMPIO DI METODO INDEXOF
// restituisce l indice di un elemento di una lista 
List<int> lista7 = new List<int> { 1, 2, 3, 4, 5 };
Console.WriteLine(lista7.IndexOf(3));

// ESEMPIO DI METODO REMOVE
// cancella la prima occorenza di un elemento di una lista
List<int> lista8 = new List<int> { 1, 2, 3, 4, 5 };
lista8.Remove(3);
Console.WriteLine(string.Join(",", lista8));

// ESEMPIO DI METODO REMOVEAT

List<int> lista9 = new List<int> { 1, 2, 3, 4, 5 };
lista9.RemoveAt(2);
Console.WriteLine(string.Join(",", lista9));

// ESEMPIO DI METODO SORT
// ordina gli elementi di una lista
List<int> lista10 = new List<int> { 5, 3, 1, 4, 2 };
lista10.Sort();
Console.WriteLine(string.Join(",", lista10));

// ESEMPIO DI METODO TOARRAY
// restituisce un array a partire da una lista 
List<int> lista11 = new List<int> { 1, 2, 3, 4, 5 };
int[] array = lista11.ToArray(); // converte lista11 in un array
Console.WriteLine(string.Join(",", array)); // stampa array

// ESEMPIIO DI METODO TRIMEXCESS
// riduce la capacita di una lista al numero di elementi presenti
List<int> lista12 = new List<int> { 1, 2, 3, 4, 5 }; // dichiara e inizializza una lista di interi
lista12.TrimExcess(); // riduce la capacita di lista12 al numero di elementi presenti
Console.WriteLine(lista12.Capacity); // stampa la capacita di lista12