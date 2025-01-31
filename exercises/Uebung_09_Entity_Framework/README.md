# Übung 9 - Entity Framework

## Teil 1 - Eine Tabelle erstellen

1. Erstellen Sie eine neue Konsolenanwendung die uns für die Übung "Bücherfilter" eine Datenbank bereitstellt.

2. Implementiere ein Datenmodell `Book` mit den folgenden Eigenschaften:
* `Id` (int, Primärschlüssel)
* `Title` (string, max. 100 Zeichen)
* `Author` (string, max. 50 Zeichen)
* `Year` (int)

3. Erstelle eine `DbContext`-Klasse (`LibraryDbContext`) und konfiguriere die Datenbankverbindung mit "SQL Server Express LocalDB".

4. Die Tabelle `Book` soll mit einer Migration in der Datenbank angelegt werden.

## Teil 2 - Daten in die Tabelle einfügen

Folgende Daten in die Tabelle einfügen.

```csharp
new Book { Title = "Der Hobbit", Author = "J.R.R. Tolkien", Year = 1937 },
new Book { Title = "1984", Author = "George Orwell", Year = 1949 },
new Book { Title = "Die unendliche Geschichte", Author = "Michael Ende", Year = 1979 },
```

## Teil 3 - Daten aus der Tabelle lesen

Schreibe eine Methode, die alle Bücher in der Konsole ausgibt. Verwende dafür `LINQ`-Abfragen.

Erweitere die Methode, um nur Bücher eines bestimmten Autors zu finden (z. B. George Orwell).

## Teil 4 - Daten aktualisieren

Schreibe eine Methode, die das Erscheinungsjahr eines Buches aktualisiert.