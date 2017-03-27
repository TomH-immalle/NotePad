using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using FileHelpers;

namespace Notepad__verbeterd_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persoon> personen = new List<Persoon>();

        public MainWindow()
        {
            InitializeComponent();


            parseDataGrid.ItemsSource = personen; 

        }

        private void exitItem_Click(object sender, RoutedEventArgs e)
        {
           var button = MessageBox.Show("Ben je zeker dat je Notepad (verbeterd) wilt afsluiten?","Afsluiten", MessageBoxButton.YesNo);
            if (button == MessageBoxResult.Yes)
            {
                Close();
            }
        
        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string startdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.InitialDirectory = startdir;
            fileDialog.Filter = "Document Files |*.txt;";
            if (fileDialog.ShowDialog() == true)
            {
                fileContents.Text = File.ReadAllText(fileDialog.FileName);
            }
            
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveDialog.Filter = "Document Files |*.txt;";
            if (saveDialog.ShowDialog() == true)
            {
                string bestand = fileContents.Text;
                File.WriteAllText(saveDialog.FileName, bestand + ".txt");
            }

        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit is een eenvoudigere versie van Notepad++.", "About", MessageBoxButton.OK);
        }

        class mens
        {
            public string Voornaam { get; internal set; }
            public string Achternaam { get; internal set; }
            public DateTime GeboorteDatum { get; internal set; }

        }
        private void ParseItem_Click(object sender, RoutedEventArgs e)
        {

            var engine = new FileHelperEngine<Persoon>();
            personen.Add(
            new Persoon() { Voornaam = "Willy", Achternaam = "Janssens", GeboorteDatum = new DateTime(1990, 1, 2) });
            personen.Add(
            new Persoon() { Voornaam = "Jan", Achternaam = "Peeters", GeboorteDatum = new DateTime(1990, 1, 2) });
            personen.Add(
            new Persoon() { Voornaam = "Piet", Achternaam = "Herthogs", GeboorteDatum = new DateTime(1990, 1, 2) });
            engine.WriteFile(@"D:\5ITN\Tom\personen.csv", personen);

            engine.ReadFile(@"D:\5ITN\Tom\personen.csv");
          


            parseDataGrid.ItemsSource = personen;
        }

        private void ShowPersonen_Click(object sender, RoutedEventArgs e)
        {
            string s = "";

            foreach (var p in personen)
            {
                s += p.ToString();
                s += Environment.NewLine;
            }

            MessageBox.Show(s);
        }
    }
}
