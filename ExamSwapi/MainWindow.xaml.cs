using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamSwapi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private Dictionary<int, List<Person>> cacheDictionary = new Dictionary<int, List<Person>>();
        public MainWindow()
        {
            InitializeComponent();

        }
        private void GetInfo(int pageTB)
        {
            try
            {
                if (!cacheDictionary.ContainsKey(pageTB))
                {
                    using (WebClient Wc = new WebClient())
                    {
                        var json = Wc.DownloadString($"https://swapi.co/api/people/?page={pageTB}");
                        var result = JsonConvert.DeserializeObject<RootObject>(json);
                        var people = result.results.ToList<Person>();
                        cacheDictionary.Add(pageTB, people);
                        peopelelist.ItemsSource = people;
                    }
                }
                else
                {
                    peopelelist.ItemsSource = cacheDictionary.GetValueOrDefault(pageTB);
                }
            }
            catch (Exception)
            {
                ErrorPage();
            }
            
        }
        private void LoadPage(object sender, RoutedEventArgs e)
        {
            int num;
            Int32.TryParse(pageTB.Text, out num);
            if (num != 0)
            {
                GetInfo(num);
                return;
            }
            ErrorPage();
        }
        private static void ErrorPage()
        {
            MessageBox.Show("Error:неверная страница всего их - 9");
        }
        private static readonly Regex _regex = new Regex("[^0-9.-]+");      
        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextPreviewInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
