using System.ComponentModel;
using System.Windows;

namespace Formular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string result;

        public MainWindow()
        {
            InitializeComponent();

            // Setze den DataContext auf das Fenster
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public User User { get; set; } = new User();

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnShowButtonClick(object sender, RoutedEventArgs e)
        {
            // Zeige die Benutzerdaten an
            if (string.IsNullOrWhiteSpace(User.Name) || User.Age == 0)
            {
                Result = "Bitte füllen Sie alle Felder aus.";
            }
            else
            {
                Result = $"Name: {User.Name}, Alter: {User.Age}";
            }
        }
    }
}