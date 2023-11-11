using StripsClientWPFReeksView.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace StripsClientWPFReeksView
{
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;
        private string path;
        static HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:5044/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            path = "/api/Strips/reeks/";
            stripService = new StripServiceClient(client);
        }

        private async void GetReeksButton_Click(object sender, RoutedEventArgs e)
        {
            ReeksDTO reeks = await stripService.GetReeks(path + ReeksIdTextBox.Text);

            NaamTextBox.Text = reeks.Name;
            AantalTextBox.Text = reeks.strips.Count.ToString();

            if (reeks.strips.Any())
            {
                
                reeks.strips[0].nr = -1;

                
                for (int i = 1; i < reeks.strips.Count; i++)
                {
                    reeks.strips[i].nr = i;
                }
            }

            StripsDataGrid.ItemsSource = reeks.strips;
        }
    }

    public class NumberToDashConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value is int && (int)value == -1)
            {
                return "-";
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value != null && value.ToString() == "-")
            {
                return -1;
            }
            if (int.TryParse(value.ToString(), out int result))
            {
                return result;
            }
            return 0; 
        }
    }
}
