// I metodi di files

// Creare un file
string path = @"test.txt";
File.Create(path).Close();

// Scrivere su un file
File.WriteAllText(path, "Hello, World!");

// Leggere da un file
string content = File.ReadAllText(path);
// stampo il contenuto del file
Console.WriteLine(content);

// Copiare un file
string path2 = @"test2.txt";
File.Copy(path, path2);

// Rinominare un file
string path3 = @"test3.txt";
File.Move(path2, path3);

// Eliminare un file
File.Delete(path3);

// Creare una directory
string dir = @"test";
Directory.CreateDirectory(dir); 

// Eliminare una directory
Directory.Delete(dir);

// Creare un file temporaneo
string tempfile = Path.GetTempFileName();
Console.WriteLine(tempfile);

// Creare un file temporaneo in una directory specifica
// Path.Combine unisce i path in questo caso aggiunge "temp" alla directory temporanea
string tempDir = Path.Combine(Path.GetTempPath(), "temp");
Directory.CreateDirectory(tempDir);