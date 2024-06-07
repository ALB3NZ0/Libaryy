using System;
using System.IO;
using System.Windows;

namespace Libary
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string language;

        public static string Language
        {
            get { return language; }
            set
            {
                try
                {
                    language = value;
                    var t = new ResourceDictionary { Source = new Uri($"/LibaryLanguage;component/Language/{value}.xaml", UriKind.Relative) };

                    if (Current.Resources.MergedDictionaries.Count > 1)
                    {
                        Current.Resources.MergedDictionaries.RemoveAt(0);
                    }
                    Current.Resources.MergedDictionaries.Insert(0, t);

                    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    File.WriteAllText($"{desktop}\\language.txt", value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось установить словарь ресурсов для языка: {ex.Message}");
                }
            }
        }

        public App()
        {
            InitializeComponent();
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\language.txt"))
            {
                Language = File.ReadAllText($"{desktop}\\language.txt");
            }
        }
    }
}
