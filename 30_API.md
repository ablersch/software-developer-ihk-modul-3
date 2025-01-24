# API

Über API zu REST Webservices

---

<!-- .slide: class="left" -->
## Was ist eine API

API (Application Programming Interface)

* Schnittstelle zwischen verschiedenen Anwendungen für Kommunikationen und Datenaustausch.
* APIs sind nicht unbedingt an das Web gebunden.
* Eine Anwendung kann eine API bereitstellen um dritt Programmen zu ermöglichen darauf zuzugreifen.
    * Schnittstelle für andere Anwendungen und Entwickler.
    * Die Funktionen (Businesslogik) einer anderen Anwendung nutzen bzw. einbinden.

**Zum Beispiel**:

* Webservice
* SDK (Software Development Kit) oder Softwarebibliotheken (z. B.`Math`)
* Kernel-API

---

<!-- .slide: class="left" -->
## Was ist ein Webservice

Ein Webservice (Web-API) ermöglicht eine reine Computer-zu-Computer-Kommunikation.

* Ein Webservice ist ein spezieller Typ von API, der über das Web (HTTP/HTTPS) verfügbar ist.
* Er stellt Daten oder Funktionen über das Internet oder ein Netzwerk zur Verfügung.
* Der Austausch von Daten und Funktionalität erfolgt unabhängig von der Programmiersprache bzw. Hardware und kann somit in unterschiedlichen Systemen integriert werden.

Note:
* Web-Shop-System welches Artikel über Webservices abruft.
* Wetter-App welche Wetterdaten von einem externen Service abruft.
* Kamera hat Web-API um diese von dritt Programmen steuern zu lassen.

---

<!-- .slide: class="left" -->
### Warum Webservices

* Webservices arbeiten mit einer servicebasierten Modellarchitektur (siehe Schaubild).
* UI von der Anwendungslogik trennen.
* Webservices verwenden ein textbasiertes Protokoll, das alle Anwendungen verstehen können.
* Nicht auf spezielle Protokolle angewiesen (meist HTTPS).
* Können mit anderen Systemen kommunizieren ohne diese extra anpassen zu müssen.
* Verbessern und vereinfachen den Informationsfluss zwischen Anwendungen.

Note: 
* Jede Anwendung kann eine andere Programmiersprache haben oder auf anderem OS laufen.
* Wiederverwendbarkeit

---

<!-- .slide: class="left" -->
## Servicebasierte Architektur

![servicebasierte Architektur](Images/webservicemodel.png)

Note: 
* Anwendung kann den Service aufrufen/beenden, je nach Bedarf. 
* Benötigt nur die URL für den Aufruf. 
* Was im Service gemacht wird ist eine Blackbox

---

<!-- .slide: class="left" -->
## verschiedene Implementierungen

Es gibt verschiedene Implementierungen eines Webservices

|   | Beschreibung                                                   | Datenformat     | Protokolle        | Verwendung                       |
|--------------|---------------------------------------------------------------|-----------------|------------------|----------------------------------|
| **SOAP**     | Strenges Protokoll und umfangreiche Standards | XML             | HTTP, SMTP, etc. | Unternehmensanwendungen, hohe Sicherheit |
| **REST**     | Architekturstil, nutzt HTTP und einfache Datenformate (JSON, XML) | JSON, XML       | HTTP/HTTPS       | Webanwendungen, mobile Apps      |
| **gRPC**     | RPC mit HTTP/2 und Protobuf für Performance   | Protobuf        | HTTP/2           | Microservices, interne Systeme   |
| **GraphQL**  | Abfragesprache, bei der der Client die Datenanforderungen bestimmt | JSON         | HTTP/HTTPS       | Flexible APIs, Datenabfragen     |


Note: 
* SOAP = Simple Object Access Protocol 
* REST = Representational State Transfer
* gRPC = Google Remote Procedure Call 
* GraphQL = Graph Query Language

---

<!-- .slide: class="left" -->
## REST Webservice abfragen

* per Browser [TV Maze API](https://api.tvmaze.com/singlesearch/shows?q=NCIS)

* Per REST-Client
  * [Postman](https://www.postman.com/)
  * [Insomnia](https://insomnia.rest/)
  * [Thunder Client](https://www.thunderclient.com/) (VS Code Erweiterung)

---

<!-- .slide: class="left" -->
### REST Webservice abfragen

```csharp []
public Account GetAccount(string url)
{
  using var httpClient = new HttpClient();
  try
  {
    // GET Anfrage an den Endpunkt senden und Ergebnis abrufen.
    var response = httpClient.GetAsync(url).Result;

    // Sicherstellen, dass die Anfrage erfolgreich war.
    response.EnsureSuccessStatusCode();

    // Inhalt der Antwort als String lesen.
    var responseBody = response.Content.ReadAsStringAsync().Result;

    // JSON-String als Objekt deserialisieren
    return JsonSerializer.Deserialize<Account>(responseBody);
  }
  catch (Exception e)
  {
    return null;
  }
}
```

Note:
* `EnsureSuccessStatusCode():` Wirft eine `Exception` wenn die Abfrage kein Success Status Code geliefert hat.

---

<!-- .slide: class="left" -->
### Daten umwandeln

REST-Webservice liefern Ergebnisse als JSON oder XML. Deshalb müssen die Daten in Objekte umgewandelt (deserialisiert) werden.

```csharp []
// Klasse Account kann über Tools automatisch aus dem JSON-String generiert werden
public class Account
{
  public string Email { get; set; }
  public bool Active { get; set; }
  public DateTime CreatedDate { get; set; }
  public IList<string> Roles { get; set; }
}

// JSON-String, z.B. Abfrage Ergebnis eines Webservice
string json = @"
{
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User', 'Admin'
  ]
}";

// JSON-String wird in ein Objekt der Klasse Account umgewandelt
Account account = JsonConvert.DeserializeObject<Account>(json);
```

Note:
* In **VS** zeigen mit Beispiel: "31_StarWars_API" 
  * Console mit `HttpClient` Star Wars API abrufen. 
  * [Json2CSharp](https://json2csharp.com/) 
  * Deserialisierung des Ergebnis
* **ÜBUNG** Webservice abrufen

---

<!-- .slide: class="left" -->
## REST Webservice erstellen

Ein API Projekt besteht normalerweise aus einer Sammlung an Controllern die je Controller mehrere Endpunkte bereitstellen. 

Z. B. EmployeeController: aufrufbar über `http://localhost/item`.

Die Controller stellen einige oder alle CRUD-Operationen bereit: Create, Read, Update, Delete.

Je nach Ergebnis liefert jede Controller-Methode einen [HTTP Status Code ](https://docs.microsoft.com/de-de/dotnet/api/system.net.httpstatuscode) zurück der anzeigt ob die Aktion erfolgreich war oder warum nicht.

weitere Informationen: [Status Code Map](https://www.talend.com/http-status-map)

---

<!-- .slide: class="left" -->
### Create (POST)

* **Zweck**: Erstellen einer neuen Ressource.
* **HTTP-Method**: `POST`
* **Rückgabewert**: `Created` oder `CreatedAtAction` mit der URL der erstellten Ressource und optional dem erstellten Objekt.
* **Beispiel**:

```csharp
[HttpPost]
public ActionResult<Item> CreateItem([FromBody] Item item)
{
  var createdItem = itemService.CreateItem(item);
  return Created();
}
```

---

<!-- .slide: class="left" -->
### Read (GET)

* **Zweck**: Abrufen einer oder mehrerer Ressourcen.
* **HTTP-Method**: `GET`
* **Rückgabewert**: `Ok` mit der Ressource oder einer Liste von Ressourcen.
* **Beispiel**:

```csharp
[HttpGet("{id}")]
public ActionResult<Item> GetItem(int id)
{
  var item = itemService.GetItem(id);
  if (item == null)
  {
    return NotFound($"Id '{id}' nicht gefunden.");
  }
  return Ok(item);
}
```

---

<!-- .slide: class="left" -->
### Update (PUT)

* **Zweck**: Aktualisieren einer bestehenden Ressource.
* **HTTP-Method**: `PUT`
* **Rückgabewert**: `NoContent` (wenn erfolgreich, ohne Rückgabeinhalt) oder `Ok` (mit der aktualisierten Ressource).
* **Beispiel**:

```csharp
[HttpPut("{id}")]
public ActionResult<Item> UpdateItem(int id, [FromBody] Item item)
{
  if (id != item.Id) 
  {
    return BadRequest();
  }
  
  var updatedItem = itemService.UpdateItem(item);
  if (updatedItem == null)
  {
    return NotFound();
  }
  return Ok(updatedItem);
}
```

---

<!-- .slide: class="left" -->
### Delete (DELETE)

* **Zweck**: Löschen einer Ressource.
* **HTTP-Method**: `DELETE`
* **Rückgabewert**: `NoContent` (wenn erfolgreich) oder `NotFound`, wenn die Ressource nicht gefunden wurde.
* **Beispiel**:

```csharp
[HttpDelete("{id}")]
public ActionResult DeleteItem(int id)
{
  var success = itemService.DeleteItem(id);
  if (!success) 
  {
      return NotFound();
  }
  return NoContent();
}
```

Note:
**VS** zeigen neues API Projekt erstellen anhand "32_API_erstellen"
  * eigenen Controller
  * Swagger (Swashbuckle von NuGet)

**ÜBUNG** Webservice erstellen
