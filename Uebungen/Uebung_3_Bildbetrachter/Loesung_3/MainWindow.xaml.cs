using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Uebung_Bildbetrachter
{
    public partial class MainWindow : Window
    {
        // alle Bilder
        private string[] images;
        // Index des aktuellen Bild
        private int currentImage = 0;
        // Timer
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            OpenLoadDialog();
            LoadImage();
            this.Activate();
        }

        /// <summary>
        ///  Bild laden
        /// </summary>
        private void LoadImage()
        {
            if (images != null && images.Length > 0)
            {
                imgViewer.Source = new BitmapImage(GetImageUri());
                CheckButtonState();
                UpdateImageProgress();
            }
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

                // Dialog
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                dialog.Description = "Einen Ordner wählen welcher Bilder enthält.";
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                // Alternative mit NuGet
                //var dialog = new CommonOpenFileDialog();
                //dialog.IsFolderPicker = true;
                //CommonFileDialogResult result = dialog.ShowDialog();

                LoadFolderAndImages(dialog.SelectedPath);

                if (images == null || images.Length == 0)
                {
                    msgResult = MessageBox.Show("Es wurden keine Bilder in diesem Pfad gefunden. Ordner erneut auswählen?", "Keine Bilder gefunden", MessageBoxButton.YesNo, MessageBoxImage.Information);
                }
            } while (msgResult == MessageBoxResult.Yes);

            CheckButtonState();
        }

        /// <summary>
        /// Alle Bilder des Pfads laden
        /// </summary>
        /// <param name="folderPath">Ordnerpfad</param>
        private void LoadFolderAndImages(string folderPath)
        {
            lblPath.Content = folderPath;

            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                images = Directory.GetFiles(folderPath, "*.jpg", SearchOption.TopDirectoryOnly);
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            currentImage++;
            CheckButtonState();
            SetImageViewerSource();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {  
            currentImage--;
            CheckButtonState();
            SetImageViewerSource();
        }

        /// <summary>
        ///  Die URI des aktuellen Bildes zurückgeben
        /// </summary>
        /// <returns>URI des aktuellen Bilds</returns>
        private Uri GetImageUri()
        {
            return new Uri(images[currentImage]);
        }

        private void SetImageViewerSource()
        {
            // Prüfen ob es im Arraybereich liegt
            if (currentImage >= 0 && currentImage < images.Length)
            {
                imgViewer.Source = new BitmapImage(GetImageUri());
                UpdateImageProgress();
            }
        }

        /// <summary>
        /// Die Vor/Zurück Buttons je nach Stand (Bilder vorhanden, Erstes Bild, Letztes Bild) 
        /// aktivieren oder deaktivieren
        /// </summary>
        private void CheckButtonState()
        {
            if (images != null)
            {
                if (currentImage <= 0) btnBack.IsEnabled = false;
                else btnBack.IsEnabled = true;

                if (currentImage >= images.Length - 1) btnNext.IsEnabled = false;
                else btnNext.IsEnabled = true;

                btnDiashow.IsEnabled = true;
            }
            else
            {
                // keine Bilder geladen
                btnBack.IsEnabled = false;
                btnNext.IsEnabled = false;
                btnDiashow.IsEnabled = false;
                lblImageProgress.Content = "Keine Bilder im Pfad!";
            }
        }

        /// <summary>
        /// Anzeigen des aktuellen geladene Bilds (Bild 1 von XX)
        /// </summary>
        private void UpdateImageProgress()
        {
            lblImageProgress.Content = "Bild " + currentImage + 1 + " von " + images.Length;
        }

        private void btnDiashow_Click(object sender, RoutedEventArgs e)
        {
            if (btnDiashow.Content.ToString() == "Start")
            {
                btnDiashow.Content = "Stop";
                btnBack.IsEnabled = false;
                btnNext.IsEnabled = false;
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
            else
            {
                btnDiashow.Content = "Start";
                btnBack.IsEnabled = true;
                btnNext.IsEnabled = true;
                dispatcherTimer.Stop();
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (images.Length > currentImage)
            {
                LoadImage();
                btnBack.IsEnabled = false;
                btnNext.IsEnabled = false;
                currentImage++;
            }
            else
            {
                currentImage = 0;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnChangePath_Click(object sender, RoutedEventArgs e)
        {
            OpenLoadDialog();
            currentImage = 0;
            LoadImage();
        }
    }
}
