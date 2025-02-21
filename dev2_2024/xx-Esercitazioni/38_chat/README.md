# I comandi di rete

```csharp
using System.Net.Sockets; // using che da la funzionalità per la comunicazione in rete
using System.Text; // using che da le funzionalità per la gestione delle stringhe che vengono inviate e ricevute

public class Client
{
    private TcpClient client; // Oggetto che rappresenta un client TCP
    private NetworkStream stream; // Oggetto che rappresenta un stream NetworkStream
    // metodo per stabilire la connessione con il server
    public void StartClient(string serverIP, int port) // gli argomenti sono l'indirizzo IP del server e la porta su cui il server è in ascolto
    {
        try
        {
            client = new TcpClient(serverIP, port); //TcpClient è la classe che rappresenta un client TCP cioe un client che si connette a un server tramite il protocollo TCP
            stream = client.GetStream(); // GetStream restituisce un oggetto NetworkStream che rappresenta il flusso di dati tra il client e il server
            Console.WriteLine("Connesso al server.");
            
            // Avvia in thread separato per ricevere i messaggi dal server
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.Start(); // Avvia il thread per ricevere i messaggi dal server

            SendMessages(); // Invia i messaggi al server usa il metodo SendMessages per inviare i messaggi al server
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore di connessione:{ex.Message}");
        }

        
    }

    private void SendMessages()
    {
        try
        {
            string messageToSend;

            while (!string.IsNullOrEmpty(messageToSend = Console.ReadLine()))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(messageToSend);
                stream.Write(buffer, 0, buffer.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore nell'ivio del messaggio: {ex.Message}");
        }
        finally
        {
            CloseConnection();
        }
    }

    private void ReceiveMessages()
    {
        byte[] buffer = new byte[1024];

        try
        {
            int byteCount;
            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, byteCount);
                Console.WriteLine($"Messaggio ricevuto dal server: {message}");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Connessione al server interrotta.");
        }
        finally
        {
            CloseConnection();
        }
    }

    private void CloseConnection()
    {
        if (client != null)
        {
            client.Close();
            Console.WriteLine("Connessione chiusa.");
        }
    }

    public static void Main(string[] args)
    {
        Client client = new Client(); // Crea un'istanza della classe Client in modo da poter chiamare il metodo StartClient
        Console.WriteLine("Inserisci l'IP del server:"); // Chiede all'utente di inserire l'IP del server
        string serverIP = Console.ReadLine();
        client.StartClient(serverIP, 3000); // Avvia il client con l'IP del server e la porta 3000
    }
}
```