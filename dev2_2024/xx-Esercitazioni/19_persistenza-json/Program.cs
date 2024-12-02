// GESTIONE FILES JSON

using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json; // libreria per gestire i file json

// LETTURA DI UN FILE 

/*
{
    "nome": "nome1",
    "cognome": "cognome1",
    "eta": 20
}
*/

string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
string json = File.ReadAllText(path); // legge il file

// ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON

dynamic obj = JsonConvert.DeserializeObject(json); // deserializza il file
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}"); // stampa il file

// ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON CON PIU LIVELLI

/*

{
    "nome": "nome1",
    "cognome": "cognome1",
    "eta": 20,
    "indirizzo": {
        "via":"via roma",
        "città":"roma"
    }
}
*/

string path2 = @"test2.json"; // in questo caso il file e nella stessa cartella del programma
string json2 = File.ReadAllText(path2); // legge il file

// ESEMPIO DI DESERIALIZZAZIONE DI UN FILE JSON CON PIU LIVELLI
dynamic obj2 = JsonConvert.DeserializeObject(json2);
Console.WriteLine("");
/*

{
    "nome": "nome1",
    "cognome": "cognome1",
    "eta": 20,
    "indirizzo": {
        "via":"via Roma 10",
        "città":"Roma",
        "CAP": "00100"
    },
    "numeriditelefono": [
        {"tipo": "casa", "numero": "1234-5678"},
        {"tipo": "ufficio", "numero": "8765-4321"}
    ],
    "lingueparlate": ["italiano", "inglese", "spagnolo"],
    "sposato": false,
    "patente": null
}
*/

string path3 = @"test3.json";
string json3 = File.ReadAllText(path3);

dynamic obj3 = JsonConvert.DeserializeObject(json3);

// stampa il file
Console.WriteLine($"nome: {obj3.nome} eta: {obj3.eta} impiegato: {obj3.impiegato} via: {obj3.indirizzo.via} citta: {obj3.indirizzo.citta} CAP: {obj.indirizzo.CAP}");   
// stampo i numeri di telefono (tramite indice) 
Console.WriteLine($"tipo: {obj3.numeriditelefono[0].tipo} numero: {obj3.numeriditelefono[0].numero}");
// stampo le lingue parlate (tramite indice)
Console.WriteLine($"lingua: {obj3.lingueparlate[0]}");
// stampo se e sposato
Console.WriteLine($"sposato: {obj3.sposato}");
// stampo se ha la patente
Console.WriteLine($"patente: {obj3.patente}");