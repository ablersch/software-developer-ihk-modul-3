# Webservice abrufen

Erstellen Sie eine WPF Anwendung welche Daten zu einer TV Serie anzeigt. Als Parameter wird ein Suchwort benötigt womit nach einer Serie gesucht werden kann.

[Api Beschreibung](https://www.tvmaze.com/api)

http://api.tvmaze.com/search/shows?q=how

## Daten

Es sollen folgende Daten zu einer Serie angezeigt werden

* Name
* Type
* Sprache
* Status der Serie
* Bild
* Sender wo die Serie ausgestrahlt wurde

## Hinweis

Der Webservice liefert einen JSON String zurück. Dieser muss [Deserialisiert](https://www.newtonsoft.com/json/help/html/DeserializeObject.htm) werden. D.h. wieder zurück in ein Objekt umgewandelt werden.
Dazu ist ein Objekt nötig welches die Daten aufnehmen kann.

## Erweiterung

Zuerst den klassischen Weg ohne Datenbindung benutzen. Danach umstellen auf WPF mit Datenbindung.