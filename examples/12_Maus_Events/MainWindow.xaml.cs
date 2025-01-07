using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Maus_Events;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
        // alle Kind Elemente in diesem Layout entfernen
        //gridLayout.Children.Clear();

        // Nur Elemente vom Typ Linien löschen
        List<Line> lines = gridLayout.Children.OfType<Line>().ToList();
        foreach (var line in lines)
        {
            gridLayout.Children.Remove(line);
        }
    }

    private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
    {
        Line line = new Line();
        Line line2 = new Line();

        // Farbe festlegen je nachdem ob Links- oder Rechtsklick
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            line.Stroke = Brushes.Red;
            line2.Stroke = Brushes.Red;
        }
        else // Rechtsklick
        {
            line.Stroke = Brushes.Green;
            line2.Stroke = Brushes.Green;
        }

        // Start -> Endpunkt X Achse
        line.X1 = e.GetPosition(gridLayout).X - 10;
        line.Y1 = e.GetPosition(gridLayout).Y;
        line.X2 = e.GetPosition(gridLayout).X + 10;
        line.Y2 = e.GetPosition(gridLayout).Y;

        // Start -> Endpunkt Y Achse
        line2.X1 = e.GetPosition(gridLayout).X;
        line2.Y1 = e.GetPosition(gridLayout).Y - 10;
        line2.X2 = e.GetPosition(gridLayout).X;
        line2.Y2 = e.GetPosition(gridLayout).Y + 10;

        // Controls dem Layoutcontainer hinzufügen
        gridLayout.Children.Add(line);
        gridLayout.Children.Add(line2);
    }

    private void Grid_MouseMove_1(object sender, MouseEventArgs e)
    {
        // Beinhaltet x und y
        Point mausPosition = e.GetPosition(this);
        lblX.Content = mausPosition.X;
        lblY.Content = mausPosition.Y;
    }
}