﻿// CONDIZIONI
// le principali istruzioni di controllo sono:
// - if
// - else
// - else if
// switch

// pulisce la console
Console.Clear();
// ESEMPIO DI IF
// se una condizione viene soddisfatta esegue un blocco di codice
int v = 10;
if (v < 5)
{
    Console.WriteLine("v e maggiore di 5");
}

// ESEMPIO DI IF ELSE 
// se una condizione viene soddisfatta esegue un blocco di codice altrimenti ne esegue un altro
int w = 1;
if (w < 5)
{
    Console.WriteLine("w e maggiore di 5");
}
else
{
    Console.WriteLine("w e minore o uguale a 5");
}

// ESEMPIO DI IF ELSE IF
// se una condizione viene soddisfatta esegue un blocco di codice altrimenti un altro altrimenti un altro se nessuna
int x = 10;
if (x > 5)
{
    Console.WriteLine("x e maggiore di 5");
}
else if (x == 5)
{
    Console.WriteLine("x e uguale a 5");
}
else
{
    Console.WriteLine("x e minore di 5");
}
// else if va messo tra if e else perche se messo dopo else non verrebbe mai eseguito

// ESEMPIO DI SWITCH
// esegue un blocco di codice in base al valore di una variabile
int y = 10;
switch (y)
{
    case 5:
    Console.WriteLine("y e uguale a 5");
    break; // break serve per uscire dallo switch
    case 10:
    Console.WriteLine("y e uguale a 10");
    break;
    default:
    Console.WriteLine("y non e ne 5 ne 10");
    break;
}
// esempio di switch con stringhe

// esempio di switch con bool
