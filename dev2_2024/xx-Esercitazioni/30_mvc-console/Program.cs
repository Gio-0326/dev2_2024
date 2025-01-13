using System.Data.SQLite; // Importazione del namespace per utilizzare SQLite 

var db = new Database(); // Modello di database in modo che sia possibile utilizzare i metodi per la gestione del database
var view = new UserView(db); // Modello di vista c è db tra parantesi perche la vista deve avere accesso al database
var controller = new UserController(db, view); // Modello di conroller che deve avere accesso al database e alla vista
controller.MainMenu(); // Metodo per gestire il menu principale

