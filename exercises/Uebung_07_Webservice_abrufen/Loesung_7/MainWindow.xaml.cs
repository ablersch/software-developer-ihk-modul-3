using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace REST_Webservice_abrufen;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
        gridDetails.Visibility = Visibility.Collapsed;
        EnableToogle();
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(tbxSuche.Text))
        {
            var results = CallAPI($"https://swapi.dev/api/people?search={tbxSuche.Text}");
            if (results.Count > 0)
            {
                DataContext = results.Results.First();
                gridDetails.Visibility = Visibility.Visible;
                EnableToogle();
            }
            else
            {
                MessageBox.Show("Keine Charaktere gefunden.", "Nichts gefunden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        else
        {
            MessageBox.Show("Kein Name zum suchen eingegeben.", "Kein Suchparameter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }

    /// <summary>
    /// API aufrufen
    /// </summary>
    private Result CallAPI(string url)
    {
        Result result = null;
        using var httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync(url).Result;

        // Bei erfolgreicher Anfrage
        if (response.IsSuccessStatusCode)
        {
            // Inhalt der Antwort als String lesen
            string responseBody = response.Content.ReadAsStringAsync().Result;
            result = JsonSerializer.Deserialize<Result>(responseBody);
        }

        return result ?? new Result();
    }

    /// <summary>
    /// Aktivieren oder deaktivieren von Reset, Suche und Suchfeld.
    /// </summary>
    private void EnableToogle()
    {
        btnReset.IsEnabled = !btnReset.IsEnabled;
        btnSearch.IsEnabled = !btnSearch.IsEnabled;
        tbxSuche.IsEnabled = !tbxSuche.IsEnabled;
    }
}