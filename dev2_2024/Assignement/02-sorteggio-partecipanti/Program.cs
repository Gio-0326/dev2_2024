List<string> partecipanti = new List<string> {"Giorgio" , "Tamer" , "Anita" , "Sofia" , "Ivan" , "Felipe" , "Andrea" , "Diego"};
int totalePartecipanti = partecipanti.Count;

Console.WriteLine("Inserisci il numero di squadre");
int numeroSquadre = int.Parse(Console.ReadLine());

Console.WriteLine("Inserisci il numero di partecipanti per squadra");
int numeropartecipanti = int.Parse(Console.ReadLine());

Random random = new Random();
int indice = random.Next(0, 8);

string partecipanteSorteggiato = partecipanti[indice];
