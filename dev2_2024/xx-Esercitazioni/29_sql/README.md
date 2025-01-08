sqlite3 database.db
.open database.db
CREATE TABLE prodotti (id INTEGER, nome TEXT);
INSERT INTO prodotti (id, nome) VALUES (1, 'mela'), (2, 'pera');
SELECT * FROM prodotti;
SELECT * FROM prodotti ORDER BY nome DESC;
SELECT * FROM prodotti ORDER BY nome ASC;
UPDATE prodotti SET prezzo = 1.50 WHERE nome = 'banane';
CREATE TABLE categoria (id INTEGER PRIMARY KEY, nome TEXT NOT NULL);
.tables
categoria prodotti
INSERT INTO categoria (nome) VALUES ('frutta');
DELETE FROM categoria WHERE nome = 'verdura';
ALTER TABLE prodotti ADD COLUMN id_categoria;
.mode table - SELECT * FROM prodotti;
.mode column
.mode html
.mode markdown
.mode json
.mode excel
ALTER TABLE prodotti DROP COLUMN id_categoria;
CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, disponibile BOOLEAN, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
.schema prodotti
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
.schema categorie

