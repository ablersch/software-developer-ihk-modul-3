# API

Über API zu REST Webservices

---

<!-- .slide: class="left" -->
## Was ist eine API

API (Application Programming Interface)

* Schnittstelle zur Anwendungsprogrammierung.
* Kommunikationen und Datenaustausch zwischen Programmen.
* Eine Anwendung stellt eine API bereit um dritt Programmen zu ermöglicht darauf zuzugreifen.
    * Schnittstelle für andere Programme und Entwickler.
    * Ein Programm kann die Funktionen (Businesslogik) eines anderen Programms nutzen bzw. einbinden.
* Dies kann ein Webservice, ein SDK (Software Development Kit) oder eine Kernel API sein.

---

<!-- .slide: class="left" -->
## Was ist ein Webservice

Ein Webservice (Web-API) ermöglicht eine reine Computer-zu-Computer-Kommunikation.

* Ein Webservice ist eine Art API welcher meist über http oder https funktioniert.
* Er bietet einen Dienst über ein Netzwerk an.
* Ein Webservice bietet einen automatisierten Datenaustausch und Nutzung von Funktionalitäten an.
* Der Austausch von Daten und Funktionalität erfolgt unabhängig von der Programmiersprache bzw. Hardware und kann somit in unterschiedlichen Systemen integriert werden.

Note:
* Shopsystem welches Artikel über Webservices abruft.
* Kamera hat API um diese von dritt Programmen steuern zu lassen

---

<!-- .slide: class="left" -->
### Warum Webservices

* Webservices arbeiten mit einer servicebasierten Modellarchitektur (siehe Diagramm)
* Ist von der Anwendungslogik getrennt und beeinflusst diese nicht
* Webservices verwenden ein textbasiertes Protokoll, das alle Anwendungen verstehen können
* Sind nicht auf spezielle Protokolle angewiesen (meist HTTP)
* Können mit anderen Systemen kommunizieren ohne diese extra anpassen zu müssen (kompatibel zu machen)
* Verbessern und vereinfachen den Informationsfluss zwischen Anwendungen

Note: 
* Jede Anwendung kann eine andere Programmiersprache haben oder auf anderem OS laufen

---

<!-- .slide: class="left" -->
## Servicebasierte Architektur

![servicebasierte Architektur](Images/webservicemodel.png)

Note: 
* Application kann den Service aufrufen/beenden, je nach Bedarf. 
* Benötigt nur die URL für den Abruf. 
* Was im Service gemacht wird ist eine Blackbox

---

<!-- .slide: class="left" -->
## verschiedene Implementierungen

Es gibt verschiedene Implementierungen eines Webservices

* SOAP (Simple Object Access Protocol)
  * Kann Nachrichten über HTTP aber auch über SMTP usw. übertragen
  * Nutzt XML
  * WCF (Windows Communication Foundation)
* REST (Representational State Transfer)
  * An HTTP angelehnt
  * Operationen wie GET, PUT, POST, DELETE
* gRPC (Remote Procedure Call)
  * von Google entwickelt
  * basiert auf RPC
  * Entfernte Funktionsaufrufe (Interprozesskommunikation)
* GraphQL
  * Abfragesprache um genau die Daten abzurufen welche der Client benötigt.

Note: 
* Bsp für REST Services von Facebook, Twitter, Netflix...
TODO mehr die Unterschiede erklären.

---

<!-- .slide: class="left" -->
## REST Webservice abfragen

* per Browser [Star Wars API](https://swapi.dev/api/people/1)

* Per REST-Client
  * [Postman](https://www.postman.com/)
  * [Insomnia](https://insomnia.rest/)
  * [Thunderclient](https://www.thunderclient.com/) (VS Code Erweiterung)

---

<!-- .slide: class="left" -->
### REST Webservice abfragen mit C#

```csharp []
public BookItem GetReleases(string url)
{
  using var httpClient = new HttpClient();
  try
  {
    // GET Anfrage an den Endpunkt senden und Ergebnis abrufen.
    var response = httpClient.GetAsync(url).Result;

    // Sicherstellen, dass die Anfrage erfolgreich war.
    response.EnsureSuccessStatusCode();

    // Inhalt der Antwort als String lesen.
    string responseBody = response.Content.ReadAsStringAsync().Result;

    // JSON-String als Objekt deserialisieren
    return JsonSerializer.Deserialize<BookItem>(responseBody);
  }
  catch (Exception e)
  {
    return null;
  }
}
```

Note:
* `EnsureSuccessStatusCode():` wirft eine `Exception` wenn die Abfrage kein Success Status Code geliefert hat.

---

<!-- .slide: class="left" -->
### Daten umwandeln

REST-Webservice liefern Ergebnisse als JSON oder XML. Deshalb müssen diese Daten in Objekte umgewandelt (deserialisiert) werden.

```csharp []
// Klasse Account kann über Tools automatisch aus dem Json generiert werden
public class Account
{
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public IList<string> Roles { get; set; }
}

// JSON-String, z.B. Abfrage Ergebnis eines Webservice
string json = @"{
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ]
}";

// JSON string wird in ein Objekt der Klasse Account umgewandelt
Account account = JsonConvert.DeserializeObject<Account>(json);
```

Note:
* In **VS** zeigen mit Beispiel: "31_StarWars_API" 
  * Console mit `HttpClient` Star Wars API abrufen. 
  * [Json2CSharp](https://json2csharp.com/) 
  * Deserialisierung des Ergebnis
* **ÜBUNG** REST Webservice abfragen

---

<!-- .slide: class="left" -->
## REST Webservice erstellen

Ein API Projekt besteht normalerweise aus einer Sammlung an Controllern die je Controller mehrere Endpunkte bereitstellen.

z.B. EmployeeController: aufrufbar über `http://localhost/api/employee`

**POST** – Wird benutzt um einen neuen Mitarbeiter anzulegen

**GET** - Wird benutzt um einen oder eine Liste von Mitarbeitern abzurufen

**PUT** - Wird benutzt um einen Mitarbeiter upzudaten

**DELETE** - Wird benutzt um einen Mitarbeiter zu löschen

---

<!-- .slide: class="left" -->
## Beispiel Controller Methode

```csharp []
private static List<string> testData = new List<string>(new String[] { "Max", "Andreas", "Hans", "Eddy" });

[HttpGet]
public ActionResult<List<string>> Get()
{
    return Ok(testData);
}

[HttpDelete("{id}")]
public ActionResult Delete(int id)
{
    testData.RemoveAt(id);
    return NoContent();
}
```

Je nach Ergebnis liefert jede Controller-Methode einen [HTTP Status Code ](https://docs.microsoft.com/de-de/dotnet/api/system.net.httpstatuscode) zurück der anzeigt ob die Aktion erfolgreich war oder warum nicht.

weitere Informationen: [Status Code Map](https://www.talend.com/http-status-map)

Note:
**VS** zeigen neues API Projekt "32_API_erstellen"
  * eigenen Controller
  * Swagger (Swashbuckle von NuGet)

**ÜBUNG** Webservice erstellen; HTTP Response Message [Route("api/xxx/{id}")];
