using System.Diagnostics;
using System.Windows;

namespace Uebung_AppStarter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Process process;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (rdbCmd.IsChecked == true)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                // Pfad welcher geöffnet werden soll
                startInfo.WorkingDirectory = "c:\\Users";
                process = Process.Start(startInfo);
            }

            if (rdbPaint.IsChecked == true)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "c:\\windows\\system32\\mspaint.exe";
                // Bild welches beim Start mit geladen werden soll
                startInfo.Arguments = @"C:\Users\lbcbla2\Pictures\Screenshots\Screenshot.png";
                process = Process.Start(startInfo);
            }

            if (rdbPaint.IsChecked == true || rdbCmd.IsChecked == true)
            {
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;
                grpRadio.IsEnabled = false;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (process != null)
            {
                // prüfen ob Prozess überhaupt noch läuft
                if (process.HasExited != true)
                {
                    process.CloseMainWindow();
                }
                process = null;
            }

            btnStart.IsEnabled = true;
            grpRadio.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
