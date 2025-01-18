using System.Windows;

namespace Formular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = User;
        }

        public User User { get; set; } = new User();

        private void OnShowButtonClick(object sender, RoutedEventArgs e)
        {
            // Zeige die Benutzerdaten an
            if (string.IsNullOrWhiteSpace(User.Name) || User.Age == 0)
            {
                User.Result = "Bitte füllen Sie alle Felder aus.";
            }
            else
            {
                User.Result = $"Name: {User.Name}, Alter: {User.Age}";
            }
        }
    }
}