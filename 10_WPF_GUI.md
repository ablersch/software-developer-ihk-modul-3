# WPF GUI

GUI erstellen mit WPF


<!-- .slide: class="left" -->
## GUI

* Mit Einführung des .Net Frameworks ist die Windows Forms API mit dabei.

* Seid .Net 3.0 steht WPF (Windows Presentation Foundation) zur Verfügung.

* WinForms wird nicht mehr weiterentwickelt, ist aber noch Bestandteil des .Net Frameworks.

* Neue Anwendungen sollten mit WPF erstellt werden.


<!-- .slide: class="left" -->
## WPF

* WPF ist ein Grafik-Framework (Teil des .Net Frameworks 3.0)

* Möglichkeit 2D und 3D Grafiken mit Unterstützung von Direct3D anzuzeigen (Grafikkarte wird für die Berechnung benutzt Performancegewinn)

* Präsentations- und Geschäftslogik (Code) wird getrennt

* [XAML](https://docs.microsoft.com/de-de/dotnet/framework/wpf/advanced/xaml-overview-wpf) (Extended Application Markup Language)(gespr. Xemmel)
Beschreibungssprache für Oberflächengestaltung

* XAML wird benutzt um die Oberfläche zu erstellen bzw. zu definieren (ähnlich wie bei ASP.NET Anwendungen)

Die WPF API (Application Programming Interface) stellt vordefinierte Steuerelemente (Controls) bereit um Oberflächen zu erstellen.


<!-- .slide: class="left" -->
## WPF

Die Oberflächen können mit dem Designer von Visual Studio oder auch mit anderen Anwendungen (Microsoft Expression Blend oder XAML Padx) erstellt werden. Alle Anwendungen generieren eine XAML Datei die in der Anwendung benutzt werden kann.

Änderungen an der Oberfläche können aber auch direkt in der XAML Datei gemacht werden.

![Steuerelemente direkt in XAML erstellen](Images/xaml.png)


<!-- .slide: class="left" -->
### WPF Features

![WPF Features](Images/WPFFeaturesDiagram.png)

Note:

* zeitbasierte Animationen sind direkt aus WPF möglich
* Es wird Hardware benutzt anstelle der CPU (Graka, RAM)
* Vektorbasiertes Rendering (Grafiken)
* Elemente aus der GUI können autom. Elemente aus dem Code beeinflussen (oder andersrum)
* Elemente können mit dem Fenster vergrößert werden
* Es können Templates definiert werden


<!-- .slide: class="left" -->
### WPF Projektvorlagen

* Die **WPF-Anwendung** entspricht im Wesentlichen einer herkömmlichen Windows-Anwendung. Die charakteristischen Eigenschaften gleichen denen einer WinForm-Anwendung.

* **WPF-Browseranwendungen** stellen keine eigenen Fenster bereit. Die Ausgabe erfolgt im Browser. Außerdem werden WPF-Browseranwendungen nicht auf der lokalen Maschine installiert.

* Mit der **Benutzerdefinierte WPF-Steuerelementbibliothek** (User Control) hat man die Möglichkeit, ein eigenes Steuerelement zu entwickeln. Vereinfacht gesagt, wird das neue Control dabei aus mehreren bestehenden Controls gebildet.

* Mit der **WPF-Benutzersteuerelementbibliothek** (Custom Control) hat man ebenfalls die Möglichkeit eigene Steuerelemente zu entwickeln (mehr Aufwand als User Control). Vorteil: Ein Custom Control kann durch Templates angepasst werden.


<!-- .slide: class="left" -->
### Entwurfsumgebung in Visual Studio

![Entwurfsumgebung](Images/VSEntwurfsumgebung.png)

Note: Steuerelemente, GUI Designer, XAML Editor und Eigenschaften für Controls


<!-- .slide: class="left" -->
### Bestandteile eines neuen Projekt

Das neue Projekt besteht aus vier Dateien:

* **MainWindow.xaml:** In dieser Datei steckt der XAML-Code des ersten Fensters (dort wird das Fenster beschrieben).

* **MainWindow.xaml.cs:** Darin wird der Programmcode geschrieben. Diese Datei wird auch als Code-Behind-Datei bezeichnet.

* **App.xaml:** Wird meist dazu genutzt, um Ressourcen für die gesamte Anwendung bereit zu stellen.

* **App.xaml.cs:** Code-Behind-Datei zur App.xaml


<!-- .slide: class="left" -->
### WPF Steuerelemente

[Übersicht Steuerelemente](https://docs.microsoft.com/de-de/dotnet/framework/wpf/controls/control-library)

[Steuerelemente allgemein](https://docs.microsoft.com/de-de/dotnet/framework/wpf/controls/)

* Jedes Steuerelemente ist eine Klasse.

* Man hat die Möglichkeit, Steuerelemente in XAML zu definieren oder diese später zur Laufzeit zu erstellen.

* Jedes Steuerelemente hat Eigenschaften und Methoden.

* Um ein Steuerelement anzusprechen, muss dieser Instanz (diesem Steuerelement) ein Name gegeben werden.

* Bei der Namensgebung sollten immer 2-3 Buchstaben des Steuerelementtyp als Präfix dem Namen vorangestellt werden (z.B. lblUeberschrift, btnDownload).


<!-- .slide: class="left" -->
### [MessageBox](https://docs.microsoft.com/de-de/dotnet/api/system.windows.messagebox?view=netframework-4.8)

* zeigt ein vordefiniertes Nachrichtenfenster an

* Das Nachrichtenfenster ist modal, d.h. es kann kein anderes Fenster aktiviert werden, solang bis das Nachrichtenfenster geschlossen wurde.

```csharp
MessageBox.Show("Bitte nur Zahlen eingeben", "Fehler", MessageBoxButton.YesNo, MessageBoxImage.Question);
```

```csharp
string message = "Möchten Sie die Daten speichern?";
MessageBoxResult result = MessageBox.Show(message,"Meine Anwendung", MessageBoxButton.OKCancel, MessageBoxImage.Question);

if (result == MessageBoxResult.OK)
{
  // TODO
}
```

Note: **VS** zeigen: neues Projekt, Fensterbereiche, Dateien.
Im neuen Projekt Button welcher Messagebox anzeigt und Anwendung beendet (Close(), Name Control, Event Button, Text Content Caption). Alle mit machen.

**ÜBUNG** Umrechnung


<!-- .slide: class="left" -->
## Layout

Beim Erstellen einer Benutzeroberfläche werden die Steuerelemente in einem Layout angeordnet. [Layouts](https://www.codeproject.com/Articles/30904/WPF-Layouts-A-Visual-Quick-Start):

* **Canvas:** Steuerelemente stellen ihr eigenes Layout bereit. Positionierung mit Koordinaten (x und y)

* **DockPanel:** Steuerelemente werden an den Rändern des Bereichs ausgerichtet (angedockt)

* **Grid:** Steuerelemente werden anhand von Zeilen und Spalten positioniert. Ergibt dann eine Art Tabellenstruktur

* **UniformGrid:** ähnlich einem Grid, nur dass alle Zellen die gleiche Größe haben

* **StackPanel:** Steuerelemente werden entweder vertikal oder horizontal gestapelt


<!-- .slide: class="left" -->
### Canvas

* untergeordnete Steuerelemente stellen ihr eigenes Layout bereit

* die Positionierung erfolgt über Koordinaten

![Canvas](Images/LayoutCanvas.png)


<!-- .slide: class="left" -->
### Canvas

```xml
<Canvas>
  <!-- default coordinates 0,0 from top left; like WinForms -->
  <Label Background="Red">Red 1</Label>
  <Label Canvas.Right="50" Background="LightGreen">Green 1</Label>
  <Label Canvas.Top="100" Canvas.Left="100" Background="LightBlue">Blue 1</Label>
  <Label Canvas.Bottom="166" Canvas.Right="237" Background="LightBlue">Blue 2</Label>
  <Label Canvas.Right="300" Canvas.Top="250" Background="Yellow">Yellow 1</Label>
  <Label Canvas.Right="50" Canvas.Bottom="50" Background="Orange">Orange 1</Label>
</Canvas>
```


<!-- .slide: class="left" -->
### DockPanel

* untergeordnete Steuerelemente werden an den Rändern des Bereichs ausgerichtet

* dort werden die Steuerelemente in 4 verschiedenen Regionen plaziert (top, bottom, left, right)

![DockPanel](Images/LayoutDockPanel.png)


<!-- .slide: class="left" -->
### DockPanel

```xml
<DockPanel>
  <Label DockPanel.Dock="Top" Height="100" Background="Red">Red 1</Label>
  <Label DockPanel.Dock="Left" Background="LightGreen">Green 1</Label>
  <Label DockPanel.Dock="Right" Background="LightBlue">Blue 1</Label>
  <Label DockPanel.Dock="Bottom" Background="LightBlue">Blue 2</Label>
  <Label DockPanel.Dock="Bottom" Height="50" Background="Yellow">Yellow 1</Label>
  <Label Width="100" Background="Orange">Orange 1</Label>   <!-- default is to fill -->
  <Label Background="LightGreen">Green 2</Label>
</DockPanel>
```


<!-- .slide: class="left" -->
### Grid

* untergeordnete Steuerelemente werden anhand von Zeilen und Spalten positioniert. Ähnlich einer Tabelle

* arbeitet mit statisch definierten Spalten und Zeilen

* jede Zelle kann eine spezifische Höhe und Breite erhalten

* Elemente können sich über mehrere Zellen oder Spalten hinweg erstrecken (```Span```)

Grid Beispiel 1            |  Grid Beispiel 2
:-------------------------:|:-------------------------:
![image](Images/LayoutGrid1.png)  |  ![image](Images/LayoutGrid2.png)


<!-- .slide: class="left" -->
### Grid

```xml
<!-- First screenshot -->
<Grid>
  <!-- Using default column and row configurations -->
  <Grid.ColumnDefinitions>
    <ColumnDefinition />
    <ColumnDefinition />
  </Grid.ColumnDefinitions>
  <Grid.RowDefinitions>
    <RowDefinition />
    <RowDefinition />
    <RowDefinition />
    <RowDefinition />
  </Grid.RowDefinitions>

  <Label Grid.Column="0" Grid.Row="0" Background="Red">Red 1</Label>
  <Label Grid.Column="1" Grid.Row="0" Background="LightGreen">Green 1</Label>
  <Label Grid.Column="0" Grid.Row="1" Background="LightBlue">Blue 1</Label>
  <Label Grid.Column="1" Grid.Row="1" Background="Yellow">Yellow 1</Label>
  <Label Grid.Column="0" Grid.Row="2" Background="Orange">Orange 1</Label>
</Grid>

<!-- 2nd screenshot uses ColumnSpan and RowSpan -->
<Label Grid.Column="0" Grid.Row="0" Grid.ColumnSpan="2" 

       Background="Red">Red 1</Label>
<Label Grid.Column="0" Grid.Row="1" Grid.RowSpan="3" 

       Background="LightGreen">Green 1</Label>
```

Note: **VS** zeigen Grid mit Spalten und Zeilen anlegen + Span


<!-- .slide: class="left" -->
### UniformGrid

* ähnlich wie ein Grid, nur dass alle Zellen genau gleich groß sind

![image](Images/LayoutUniformGrid1.png)

![image](Images/LayoutUniformGrid2.png)


<!-- .slide: class="left" -->
### UniformGrid

```xml
<UniformGrid>
  <Label Background="Red">Red 1</Label>
  <Label Background="LightGreen">Green 1</Label>
  <Label Background="LightBlue">Blue 1</Label>
  <Label Background="Yellow">Yellow 1</Label>
  <Label Background="Orange">Orange 1</Label>
  <Label Background="Red">Red 2</Label>
  <Label Background="LightGreen">Green 2</Label>
  <Label Background="Yellow">Yellow 2</Label>
  <Label Background="Orange">Orange 2</Label>
</UniformGrid>
```


<!-- .slide: class="left" -->
### StackPanel

* untergeordnete Steuerelemente werden entweder vertikal oder horizontal gestapelt

* Verschachtelungen sind möglich

![StackPanel](Images/LayoutStackPanel.png)


<!-- .slide: class="left" -->
### StackPanel

```xml
<StackPanel Orientation="Vertical"> <!-- Vertical is the default -->
  <Label Background="Red">Red 1</Label>
  <Label Background="LightGreen">Green 1</Label>
  <StackPanel Orientation="Horizontal">
    <Label Background="Red">Red 2</Label>
    <Label Background="LightGreen">Green 2</Label>
    <Label Background="LightBlue">Blue 2</Label>
    <Label Background="Yellow">Yellow 2</Label>
    <Label Background="Orange">Orange 2</Label>
  </StackPanel>
  <Label Background="LightBlue">Blue 1</Label>
  <Label Background="Yellow">Yellow 1</Label>
  <Label Background="Orange">Orange 1</Label>
</StackPanel>
```


<!-- .slide: class="left" -->
### WrapPanel

* Untergeordnete Steuerelemente werden der Reihenfolge nach von links nach rechts angeordnet. Wenn sich in der jeweiligen Zeile mehr Steuerelemente befinden, als der Raum zulässt, wird ein Zeilenumbruch durchgeführt.

WrapPanel horizontal            |  WrapPanel vertikal
:-------------------------:|:-------------------------:
![image](Images/LayoutWrapPanelHorizontal.png)  |  ![image](Images/LayoutWrapPanelVertical.png)


<!-- .slide: class="left" -->
### WrapPanel

```xml
<WrapPanel Orientation="Horizontal"> <!-- Horizontal is the default -->
  <Label Width="125" Background="Red">Red 1</Label>
  <Label Width="100" Background="LightGreen">Green 1</Label>
  <Label Width="125" Background="LightBlue">Blue 1</Label>
  <Label Width="50" Background="Yellow">Yellow 1</Label>
  <Label Width="150" Background="Orange">Orange 1</Label>
  <Label Width="100" Background="Red">Red 2</Label>
  <Label Width="150" Background="LightGreen">Green 2</Label>
  <Label Width="75" Background="LightBlue">Blue 2</Label>
  <Label Width="50" Background="Yellow">Yellow 2</Label>
  <Label Width="175" Background="Orange">Orange 2</Label>
</WrapPanel>
<WrapPanel Orientation="Vertical">
  <Label Height="125" Background="Red">Red 1</Label>
  <Label Height="100" Background="LightGreen">Green 1</Label>
  <Label Height="125" Background="LightBlue">Blue 1</Label>
  <Label Height="50" Background="Yellow">Yellow 1</Label>
  <Label Height="150" Background="Orange">Orange 1</Label>
  <Label Height="100" Background="Red">Red 2</Label>
  <Label Height="150" Background="LightGreen">Green 2</Label>
  <Label Height="75" Background="LightBlue">Blue 2</Label>
  <Label Height="50" Background="Yellow">Yellow 2</Label>
  <Label Height="175" Background="Orange">Orange 2</Label>
</WrapPanel>
```

Note: Layout automatisch Anpassen an Grid: Horizontal und vertikal Stretch, Breite + Höhe auf "auto" und Margins entfernen

**ÜBUNG** Taschenrechner


<!-- .slide: class="left" -->
## Ereignisse

Eine Interaktion des Anwenders mit der Oberfläche löst ein [Ereignis](https://docs.microsoft.com/de-de/dotnet/framework/wpf/advanced/events-wpf) aus.

Ist ein Ergeignishandler registriert wird dieser ausgeführt.

```csharp
// XAML Code
<Button x:Name="btnClear" Content="Löschen" Click="btnClear_Click"/>

//Code behind
private void btnClear_Click(object sender, RoutedEventArgs e)
{
  (sender as Button).IsEnabled = false;
}
```

### Parameter

1. Parameter (`object`): Referenz auf die ereignisauslösende Komponente (Cast auf das Control).

2. Parameter (z.B. `RoutedEventArgs`): Je nach Ereignis unterschiedlicher Datentyp. Stellt ereignisspezifische Daten zur Verfügung.


## Ereignisse im Code definieren
<!-- .slide: class="left" -->

Die Verknüpfung zwischen Ereignis und einem Ereignishandler kann auch im Code festgelegt werden.

```csharp
public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
    btnInfo.Click += new RoutedEventHandler(btnInfo_Click);
  }

  // Ereignishandler
  void btnInfo_Click(object sender, RoutedEventArgs e)
  {
    MessageBox.Show("Ich bin ein Eventhandler");
  }
}
```

Note: **VS** zeigen: Event von hand; Menü mit MenüItems geschachtelt; 

Directory.GetFiles(folderPath, "*.jpg", SearchOption.TopDirectoryOnly); System.Windows.Forms Verweis; 

img.Source = new BitmapImage(new Uri("c:\\..."))

+= Trägt sich für ein Event ein


<!-- .slide: class="left" -->
## DispatcherTimer Klasse

Der [DispatcherTimer](https://docs.microsoft.com/de-de/dotnet/api/system.windows.threading.dispatchertimer?view=netframework-4.8) kann Aktionen wiederholend in einem bestimmten Intervall ausführen.

```csharp
public DispatcherTimerSample()
{
  // neue Instanz erzeugen
  DispatcherTimer timer = new DispatcherTimer();
  // In welchem Intervall soll er laufen
  timer.Interval = TimeSpan.FromSeconds(1);
  // Event mit dem Eventhandler verknüpfen
  timer.Tick += timer_Tick;
  // Läuft erst wenn die Start() ausgeführt wurde. Zum beenden Stop() ausführen
  timer.Start();
}

// Eventhandler, wird bei jedem Tick Event ausgelöst
void timer_Tick(object sender, EventArgs e)
{
  // Aktuelle Uhrzeit jede Sekunde einem Label zuweisen
  lblTime.Content = DateTime.Now.ToLongTimeString();
}
```

```xml
<Grid>
  <Label Name="lblTime" HorizontalAlignment="Center" VerticalAlignment="Center" />
</Grid>
```

Note: **ÜBUNG** Bildbetrachter


<!-- .slide: class="left" -->
## [Datenbindung](https://docs.microsoft.com/de-de/dotnet/framework/wpf/data/data-binding-wpf)

* Bindungen werden zwischen zwei Elementen definiert. (Datenquelle - Datenziel).

* Im Datenziel wird eine Eigenschaft an eine Datenquelle gebunden.

* Dabei kann die Datenquelle:

    * Die Eigenschaft eines anderen Elements (z. B. eines Steuerelement) sein (Element-Bindung).

    * oder eine Datenbindung sein (C\# Objekt, Auflistung, Datenbank, XML Datei, \...)

Note: Eigenschaften mit Controls verbinden


<!-- .slide: class="left" -->
### Binding erstellen

* Ein Binding kann über den Eigenschaften Editor

* von Hand

* oder auch im Code mit der Klasse Binding erstellt werden

```xml
<TextBox x:Name="tbxValue2" Text="{Binding Path=Text, ElementName=tbxValue1}"/>
```

Note: **VS** zeigen: neues Projekt mit Textbox, Button und Elementdatenbindung. Content vom Button an Textbox binden.

Eigenschaft wird nicht aktualisiert --> !NotifyPropertyChanged bei eigenen Klassen.


<!-- .slide: class="left" -->
### Binding Klasse Eigenschaften

Beschreibt die Bindung von Datenquelle zu gebundener Komponente.

* ElementName: Gibt den Namen des Steuerelements (der GUI) an, welches als **Datenquelle** dient.

* Path: Path ist die Eigenschaft (Property (Value, Text, Content, ...)) an welche die Daten gebunden werden (optional).

* Mode: Definiert den **Bindungsmodus** zwischen GUI und Datenobjekt. Dieser kann einseitig (OneWay) oder beidseitig (TwoWay) sein.

* Source: Legt das Objekt fest, welches als Quelle der Datenbindung dient.

* UpdateSourceTrigger: Definiert, wann die Datenquelle aktualisiert werden soll (z.B. jedesmal wenn sich die die Daten ändern).


<!-- .slide: class="left" -->
### Ein Objekt binden

```csharp
Medien medien = new Medien("test", 12345);
// Datenquelle festlegen
DataContext = medien;
```

```xml
<TextBox x:Name="textBox" Text="{Binding Titel}"/>
<TextBox Text="{Binding Path=Signatur , Mode=OneWay}"/>
```

In diesem Fall ist keine explizite Angabe von `ElementName` oder ähnliches notwendig.

Note: Path ist optional

**VS** zeigen: DataContext Binding auf Eigenschaft; Maus Event; Point; Linien; Farbe; Children.Add; e.Position; e.Button; ToolbarTry -> Toolbar -> Button -> Image

**ÜBUNG** Zeichnen
