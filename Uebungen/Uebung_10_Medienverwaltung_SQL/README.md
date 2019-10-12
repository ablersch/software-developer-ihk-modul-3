# Übung 10 - Medienveraltung

Ändern Sie die Anwendung so ab damit die Medien in einer SQL Datenbank gespeichert werden.

Es sind am gesamten Programm kleiner Anpassungen notwendig damit die Anwendung weiterhin läuft. Ansonsten soll die Grundfunktion der Anwendung gleich bleiben.


## Connection String

`Data Source=PC-DOZ-602\SQLEXPRESS; Initial Catalog=SoftwareDeveloper; User Id=softwaredeveloper; Password = 123test;`

## Datenbankspalten

![Datenbankspalten](Spalten.png)

## SQL Statements

### Hinzufügen

`INSERT INTO Medien VALUES(@Sig,@Titel,@Eigenschaft,@Typ,@Leihstatus)`

### Prüfen ob die Signatur bereits vorhanden ist

`SELECT count(1) FROM Medien WHERE Signatur = '" + key + "'"`

### Alle Medien abrufen

`SELECT * FROM Medien`

### Ein bestimmtes Element abrufen

`SELECT * FROM Medien WHERE Signatur='" + key + "'"`

### Ein Element löschen

`DELETE Medien WHERE Signatur = '" + key + "'"`

### Den Leihstatus bei einem bestimmten Element ändern

`UPDATE Medien SET Leihstatus ='" + leihstatus.ToString() + "' WHERE Signatur='" + key + "'"`
