# Übung 1 - Umrechnung

Erstellen Sie eine WPF Anwendung zum Umrechnen von Celsius in Fahrenheit und umgekehrt.

Vergeben Sie für die verwendeten Elemente sprechende Namen, wie z.B. btnExit für den Exit-Button. Die Höhe der Grad soll in einem Textfeld eingegeben werden können. Stellen Sie dem Textfeld ein Label voran, so dass klar hervorgeht um was es sich handelt.
Das Ergebnis der Berechnung soll in einem readonly Textfeld zentriert dargestellt werden. Der Text des Ergebnisses soll dabei die Eigenschaft fett haben.
Verwenden Sie zur Berechnung zwei Buttons (achten Sie auf passende Namen). Die Texte sind **Celsius zu Fahrenheit** und **Fahrenheit zu Celsius**. Hinterlegen Sie für die Buttons ein „Click“ Event, indem Sie die Berechnungen durchführen.

**Die Umrechnungsformeln lauten:**
```csharp
TempF2C = ((TempF – 32) * 5) / 9
TempC2F = (TempF * 9 / 5) + 32
```

Überprüfen Sie zusätzlich, ob in dem Eingabefeld etwas eingegeben wurde und ob die Eingabe korrekt war. Runden Sie, wenn nötig, die Ergebnisse auf 2 Nachkommastellen (`Math.Round()`).

## Beispiel

![Beispiel Maske](Bild1.png)

![Beispiel Maske](Bild2.png)