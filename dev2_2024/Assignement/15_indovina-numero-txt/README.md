# INDOVINA NUMERO CON TXT

## Obiettivo

- Implementare la persistenza del gioco indovina-numero nel txt
- Implementare una funzione che descriva l'elenco dei tentativi fatto dall'utente in un file di testo
- chiede di inserire all'utente il proprio nome e usa l'input dell'utente 

## Versione 1

Codice da aggiungere al programma:

- Lo streamwriter e lo using sono stati usati per scrivere su file di testo.
- Il vantaggio di usare lo streamwriter è che è necessario chiudere il file esplicitamente.
- Il file viene chiuso automaticamente quando il blocco using termina.
- Il blocco using può essere implementato con altre funzionalità come la lettura di file o la connessione a un database.
- In pratica serve in quelle occasioni in cui si vuole garantire che le operaizoni su un oggetto vengano eseguite correttamente e che le risorse vengano rilasciate correttamente.

```csharp
void ScriviTentativiSulFile(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
    using (StreamWriter sw = new StreamWriter($"{nomeUtente}.txt"))
    {
        foreach (var tentativoUtente in tentativiUtenti)
        {
            if (tentativiUtente.Key == nomeUtente)
            {
                sw.WriteLine($"{tentativoUtente.Key}: {string.Join(",", tentativoUtente.Value)}");
            }
        }
    }
}
```