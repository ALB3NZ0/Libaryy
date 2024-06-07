using LibraryJson;
using System;
using System.Net.NetworkInformation;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using Path = System.IO.Path;

namespace Libary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Der_Click(object sender, RoutedEventArgs e)
        {
            string text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonbpatH = Path.Combine(text, "SUI.json");
            string seria = Json.DeserilizeFromFile<string>(jsonbpatH);
            if (!string.IsNullOrEmpty(seria))
            {
                lbx.Items.Add(seria);
            }
        }

        private void Ser_Click(object sender, RoutedEventArgs e)
        {
            string test = Vod.Text;
            string syi = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonbpatH = Path.Combine(syi, "SUI.json");
            Json.SerializeToFile(test, jsonbpatH);

            Vod.Text = "";
        }

        private void Aze_Click(object sender, RoutedEventArgs e)
        {
            App.Language = "Azerbaidjan";
        }

        private void Rus_Click(object sender, RoutedEventArgs e)
        {
            App.Language = "Russian";

        }
    }
}
