using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;

namespace Bildbetrachter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Index des aktuellen Bildes.
    private int currentImageIndex = 0;

    // Timer für die Diashow.
    private DispatcherTimer diashowTimer = new DispatcherTimer();

    // alle Bilder
    private List<string> images = [];

    public MainWindow()
    {
        InitializeComponent();

        OpenLoadDialog();
        LoadImage();
        Activate();
    }

    private void btnBack_Click(object sender, RoutedEventArgs e)
    {
        currentImageIndex--;
        CheckButtonState();
        SetImageViewerSource();
    }

    private void btnChangePath_Click(object sender, RoutedEventArgs e)
    {
        OpenLoadDialog();
        currentImageIndex = 0;
        LoadImage();
    }

    private void btnDiashow_Click(object sender, RoutedEventArgs e)
    {
        if (btnDiashow.Content.ToString() == "Start")
        {
            btnDiashow.Content = "Stop";
            SetNextBackButtonEnabled(false);
            diashowTimer.Tick += diashowTimer_Tick;
            diashowTimer.Interval = TimeSpan.FromSeconds(1);
            diashowTimer.Start();
        }
        else
        {
            btnDiashow.Content = "Start";
            SetNextBackButtonEnabled(true);
            diashowTimer.Stop();
        }
    }

    private void btnNext_Click(object sender, RoutedEventArgs e)
    {
        currentImageIndex++;
        CheckButtonState();
        SetImageViewerSource();
    }

    /// <summary>
    /// Die Vor/Zurück Buttons je nach Stand (Bilder vorhanden, erstes Bild, letztes Bild)
    /// aktivieren oder deaktivieren
    /// </summary>
    private void CheckButtonState()
    {
        if (images.Count > 0)
        {
            btnBack.IsEnabled = currentImageIndex > 0;
            btnNext.IsEnabled = currentImageIndex < images.Count - 1;
            btnDiashow.IsEnabled = true;
        }
        // keine Bilder geladen
        else
        {
            SetNextBackButtonEnabled(false);
            btnDiashow.IsEnabled = false;
            lblImageProgress.Content = "Keine Bilder im Pfad!";
        }
    }

    private void diashowTimer_Tick(object sender, EventArgs e)
    {
        if (images.Count > currentImageIndex)
        {
            LoadImage();
            SetNextBackButtonEnabled(false);
            currentImageIndex++;
        }
        // Beginne von vorne.
        else
        {
            currentImageIndex = 0;
        }
    }

    /// <summary>
    ///  Die URI des aktuellen Bildes zurückgeben.
    /// </summary>
    /// <returns>URI des aktuellen Bildes.</returns>
    private Uri GetImageUri()
    {
        return new Uri(images[currentImageIndex]);
    }

    /// <summary>
    /// Alle Bilder des Pfads laden.
    /// </summary>
    /// <param name="folderPath">Ordnerpfad</param>
    private void LoadFolderAndImages(string folderPath)
    {
        lblPath.Content = folderPath;

        if (!string.IsNullOrWhiteSpace(folderPath))
        {
            images = Directory.GetFiles(folderPath, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
        }
    }

    /// <summary>
    /// Bild laden.
    /// </summary>
    private void LoadImage()
    {
        if (images.Count > 0)
        {
            imgViewer.Source = new BitmapImage(GetImageUri());
            CheckButtonState();
            UpdateImageProgress();
        }
    }

    private void MenuItem_Click_1(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Orderauswahldialog
    /// </summary>
    private void OpenLoadDialog()
    {
        MessageBoxResult msgResult = MessageBoxResult.No;
        // Wenn keine Bilder im Pfad gefunden wurden, erneut den Dialog einblenden
        do
        {
            // Wert zurücksetzen
            msgResult = MessageBoxResult.No;

            var folderDialog = new OpenFolderDialog
            {
                Title = "Einen Ordner wählen welcher Bilder enthält."
            };

            if (folderDialog.ShowDialog() == true)
            {
                LoadFolderAndImages(folderDialog.FolderName);
            }

            if (images.Count == 0)
            {
                msgResult = MessageBox.Show("Es wurden keine Bilder in diesem Pfad gefunden. Ordner erneut auswählen?", "Keine Bilder gefunden", MessageBoxButton.YesNo, MessageBoxImage.Information);
            }
        } while (msgResult == MessageBoxResult.Yes);

        CheckButtonState();
    }

    private void SetImageViewerSource()
    {
        // Prüfen ob Index im Arraybereich liegt
        if (currentImageIndex >= 0 && currentImageIndex < images.Count)
        {
            imgViewer.Source = new BitmapImage(GetImageUri());
            UpdateImageProgress();
        }
    }

    private void SetNextBackButtonEnabled(bool enabled)
    {
        btnBack.IsEnabled = enabled;
        btnNext.IsEnabled = enabled;
    }

    /// <summary>
    /// Anzeigen des aktuell geladene Bilds (Bild 1 von XX)
    /// </summary>
    private void UpdateImageProgress()
    {
        lblImageProgress.Content = $"Bild {currentImageIndex + 1} von {images.Count}";
    }
}