using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Uebung_Zeichenprogramm
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO Rectangle, Ellipse, Path, Raddierer
        private Point currentPoint;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Dicke der Linie von der GUI abrufen
        /// </summary>
        /// <returns></returns>
        private int GetThickness()
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)cbxThickness.SelectedValue;
            string value = comboBoxItem.Content.ToString();
            return Convert.ToInt32(value);
        }

        private SolidColorBrush GetColor(string value)
        {
            switch (value)
            {
                case "Blau":
                    return Brushes.Blue;
                case "Grün":
                    return Brushes.LawnGreen;
                case "Rot":
                    return Brushes.Red;
                case "Schwarz":
                    return Brushes.Black;
                default:
                    return Brushes.Black;
            }

            // Alternative um den String WErt in eine Farbe umzuwandeln
            // SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(value);
        }

        private void cavDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = GetColor(((ComboBoxItem)cbxColor.SelectedItem).Content.ToString());
                line.StrokeThickness = GetThickness();

                // aktueller Punkt oder Startpunkt
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;

                // neuer Punkt oder Endpunkt
                line.X2 = e.GetPosition(cavDraw).X;
                line.Y2 = e.GetPosition(cavDraw).Y;

                // Den neuen Punkt zu STartpunkt machen
                currentPoint = e.GetPosition(cavDraw);

                // Line zur GUI hinzufügen
                cavDraw.Children.Add(line);
            }

            if (e.RightButton == MouseButtonState.Pressed)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 50;
                rect.Height = 50;
                rect.Fill = Brushes.Cornsilk;
                cavDraw.Children.Add(rect);
                // einen Bereich definieren wo ein Objekt hinzugefügt werden soll
                Canvas.SetTop(rect, e.GetPosition(cavDraw).Y);
                Canvas.SetLeft(rect, e.GetPosition(cavDraw).X);
            }
        }

        /// <summary>
        /// Speichert den Startpunkt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cavDraw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(cavDraw);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // TODO Save changes!!!
            Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            cavDraw.Background = Brushes.White;
            cavDraw.Children.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)cavDraw.RenderSize.Width,
                (int)cavDraw.RenderSize.Height, 96d, 96d, PixelFormats.Default);

            rtb.Render(cavDraw);
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Image"; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "Bilder (.png)|*.png"; // Filter files by extension

            if (dlg.ShowDialog() == true)
            {
                using (var fs = File.OpenWrite(dlg.FileName))
                {
                    pngEncoder.Save(fs);
                }
                MessageBox.Show("Bild erfolgreich gespeichert","Erfolgreich",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cavDraw.Children.Clear();
        }

        private void cbxColorback_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBoxItem typeItem = (ComboBoxItem)cbxColorback.SelectedItem;
            string value = typeItem.Content.ToString();
            if (cavDraw != null)
            {
                cavDraw.Background = GetColor(value);
            }
        }
    }
}
