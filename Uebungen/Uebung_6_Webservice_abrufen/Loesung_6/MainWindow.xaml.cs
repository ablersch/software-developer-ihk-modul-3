using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace Uebung_Webservice_abrufen
{
    // http://api.tvmaze.com/search/shows?q=how
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// API aufrufen
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private Result CallAPI(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string response = httpClient.GetStringAsync(new Uri(url)).Result;
                    var resultList = JsonConvert.DeserializeObject<List<Result>>(response);
                    return resultList?[0];
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            // Alternative
            //var client = new WebClient();
            //var response = client.DownloadString(url);
            //return JsonConvert.DeserializeObject<BookItem>(response);
        }

        // GUI Werte setzen. Manuell oder per Binding
        private void SetGuiValues(Result result)
        {
            if (result != null)
            {
                DataContext = result;
            }
        }

        /// <summary>
        ///  Umschalten von Reset und Suche
        /// </summary>
        private void EnableToogle()
        {
            btnReset.IsEnabled = !btnReset.IsEnabled;
            btnSearch.IsEnabled = !btnSearch.IsEnabled;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxSuche.Text))
            {
                Result result = CallAPI("http://api.tvmaze.com/search/shows?q=" + tbxSuche.Text);
                if (result != null)
                {
                    SetGuiValues(result);
                    gridDetails.Visibility = Visibility.Visible;
                    EnableToogle();
                }
                else
                {
                    MessageBox.Show("Keine Serie gefunden.");
                }
            }
            else
            {
                MessageBox.Show("Keine Serie eingegeben.");
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            gridDetails.Visibility = Visibility.Collapsed;
            EnableToogle();
        }
    }
}
