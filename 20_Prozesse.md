# Prozesse

Mit Windows Prozesse arbeiten.

---

<!-- .slide: class="left" -->
## Process Klasse

Die Klasse [Process](https://docs.microsoft.com/de-de/dotnet/api/system.diagnostics.process?view=netframework-4.8) stellt Methoden und Eigenschaften bereit um mit Prozesse zu arbeiten.

| Methode      | Beschreibung
| -------------|-------------|
| `GetProcesses()`     | gibt alle laufenden Prozesses des Betriebssystems in einem Array zurück
| `GetProcessesByName()` | gibt alle Prozesse mit dem angegebenen Namen als Array zurück
| `Start()`    | startet einen Prozess
| `CloseMainWindow()`| eine Beenden Anforderung schicken, wartet z. B. auf Benutzerbestätigung
| `Kill()`| beendet den Prozess sofort ohne auf den Prozess zu warten
| `Responding`| gibt an, ob die Benutzeroberfläche

---

<!-- .slide: class="left" -->
## Prozesse auflisten

```csharp []
public MainWindow()  {
    InitializeComponent();

    var temp = String.Format("ProcessName \t ProcessId \t StartTime\n");
    var processList = new ArrayList();

    // Alle laufenden Prozesse des aktuellen Systems abrufen
    Process[] processes = Process.GetProcesses();

    // Alle Prozesse durchlaufen und die Daten ausgeben. Es wird ein Fehler geworfen wenn auf den Prozess nicht zugegriffen werden kann
    foreach (Process process in processes) {
        try {   
            processList.Add(process.ProcessName + "\t" + process.Id +"\t"+ process.StartTime + "\n");
        }
        catch (Exception e) {
          // Kein Zugriff auf diese Prozesse
          // TODO
        }
    }
    processList.Sort();

    foreach (var element in processList) {
        temp += element;
    }
    txbProcess.Text = temp;
}
```

---

<!-- .slide: class="left" -->
## Beispiel Prozesse starten

```csharp []
// Startet Explorer in C:\
Process.Start("C:\\");
```

```csharp []
// Öffnet die txt Datei mit dem Standard Editor
Process.Start("c:\\aa.txt");
```

```csharp []
// Öffnet Google im Browser
var p = Process.Start("http://google.com/");
p.CloseMainWindow();
// Es ist besser wenn man keinen speziellen Browser festlegt!!!
// Process.Start("iexplore.exe", "http://www.google.com");
```

---

<!-- .slide: class="left" -->
## ProcessStartInfo Klasse

Möchten Sie zu einem Prozess weitere Einstellungen vornehmen, sollten Sie eine Instanz von [ProcessStartInfo](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.processstartinfo?view=netframework-4.8) verwenden. Diese Klasse speichert Informationen über den Prozess, insbesondere wie er zu starten
hat und seine Konfiguration.

| Eigenschaft      | Beschreibung
| -------------|-------------|
| `FileName`     | Name der Datei z. B. log.txt oder der Anwendung z. B. WINWORD.EXE
| `Arguments` | Startargumente (Flags) oder Dateinamen
| `CreateNoWindow`    | Prozess ohne neues Fenster starten
| `WindowStyle`| Fenster als versteckt kennzeichnen
| `WorkingDirectory`| Arbeitsverzeichnis definieren

---

<!-- .slide: class="left" -->
## Beispiel ProcessStartInfo

```csharp []
var startInfo = new ProcessStartInfo();
startInfo.FileName = "c:\\windows\\system32\\mspaint.exe";
startInfo.Arguments = "c:\\Bild.jpg";

var p = new Process();
p = Process.Start(startInfo);

Console.WriteLine("Press Key to Close");
Console.ReadKey();

// es wird eine Meldung zum Schließen an das Hauptfenster gesendet
p.CloseMainWindow();
// schließt die Anwendung sofort, ohne auf die Anwendung zu warten
// p.Kill();
```

Note: **ÜBUNG** AppStarter
MSPaint (c:\\windows\\system32\\mspaint32.exe)
