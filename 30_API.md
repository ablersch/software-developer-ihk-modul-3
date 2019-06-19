# API

Über API zu REST Webservices


<!-- .slide: class="left" -->
## Was ist eine API

API (Application Programming Interface)

* Schnittstelle zur Anwendungsprogrammierung.

* Kommunikationen und Datenaustausch zwischen Programmen.

* Eine Anwendung stellt eine API bereit um dritt Programmen zu ermöglicht darauf zuzugreifen.

    * Schnittstelle für andere Programme und Entwickler.

    * Ein Programm kann die Funktionen eines anderen Programms nutzen
        bzw. einbinden.

* Dies kann ein Webservice, ein SDK oder eine Kernel API sein.


<!-- .slide: class="left" -->
## Was ist ein Webservice

Ein Webservice (Web-API) ermöglicht eine reine Computer-zu-Computer-Kommunikation.

* Ein Webservice ist eine Art API welcher meist über http oder https funktioniert.

* Er bietet einen Dienst über ein Netzwerk an.

* Ein Webservice bietet einen automatisierten Datenaustausch und Nutzung von Funktionalitäten an.

* Der Austausch von Daten und Funktionalität erfolgt unabhängig von der Programmiersprache bzw. Hardware und kann somit in unterschiedlichen Systemen integriert werden.


<!-- .slide: class="left" -->
### Warum Webservices

* Webservices arbeiten mit einer servicebasierten Modellarchitektur.

* Ist von der Anwendungslogik getrennt.

* Webservices verwenden ein textbasiertes Protokoll, das alle Anwendungen verstehen können.

* Sind nicht auf spezielle Protokolle angewiesen.


<!-- .slide: class="left" -->
## Servicebasierte Architektur

![servicebasierte Architektur](images/webservicemodel.png)


<!-- .slide: class="left" -->
## verschiedene Implementierungen

Es gibt verschiedene Implementierungen eines Webservices

* SOAP (Simple Object Access Protocol)

    * Kann Nachrichten über HTTP aber auch über SMTP usw übertragen

    * Nutzt XML

    * WCF (Windows Communication Foundation)

* REST (Representational State Transfer)

    * An HTTP angelehnt

    * Operationen wie GET, PUT, POST, DELETE

* RPC (Remote Procedure Call)

    * Entfernte Funktionsaufrufe (Interprozesskommunikation)


<!-- .slide: class="left" -->
## REST Webservice abfragen

```csharp
using (var httpClient = new HttpClient()) {
    try {
        string response = httpClient.GetStringAsync(new Uri(url)).Result;
        return JsonConvert.DeserializeObject<BookItem>(response);
    } catch (Exception e)
    {
        return null;
    }
}
```

```csharp
public string GetReleases(string url)
{
        var client = new WebClient();
        var response = client.DownloadString(url);
        return response;
}
```