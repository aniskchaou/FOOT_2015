using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using User.DirectShow;
using System.ComponentModel;
using System.Data;



namespace football
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string equipe1 = "";
        public static string equipe2 = "";
        string url = null;

        public MainWindow()
        {
            InitializeComponent();
            rDataGrid();
            Joueur j = new Joueur();
            j.liste_de_joueur();
        }

        private void rDataGrid()
        {

            Matche matA = new Matche();
            dataMatche.ItemsSource = matA.afficher().AsDataView();
        }


        private void _ouvrir(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "video (*.mp4; *.avi)|*.mp4; *.avi";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                // Open the selected file to read.
                System.IO.Stream fileStream = openFileDialog1.OpenFile();


                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    // Read the first line from the file and write it the textbox.
                    // tbResults.Text = reader.ReadLine();
                    Lecteur.Source = new Uri(openFileDialog1.FileName);

                    extraire_equipe(openFileDialog1.FileName);

                    Lecteur.Play();
                }
                url = openFileDialog1.FileName;

                fileStream.Close();
            }
        }

        private void extraire_equipe(string purl)
        {
            string url = purl;
            Uri uri = new Uri(url);
            if (uri.IsFile)
            {
                string filename = System.IO.Path.GetFileNameWithoutExtension(uri.LocalPath);

                string[] str = filename.Split('-');
                //MessageBox.Show(str[0] + str[1]);

                MainWindow.equipe1 = str[0];
                MainWindow.equipe2 = str[1];
            }

        }

        private void _arreter(object sender, RoutedEventArgs e)
        {
            Lecteur.Pause();
        }

        private void _lire(object sender, RoutedEventArgs e)
        {
            Lecteur.Play();
        }

        private void _interrompre(object sender, RoutedEventArgs e)
        {
            Lecteur.Stop();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            Matche mat = new Matche(1, DateTime.Parse(Date.Text), url, Stade.Text);
            mat.ajouter();
            rDataGrid();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void _exporter_smil(object sender, RoutedEventArgs e)
        {
            Export exp = new Export();


            string fichier_sortie = Microsoft.VisualBasic.Interaction.InputBox("donner le fichier de sortie *.smil", "fichier d'exportation", "nom_fichier.smil", -1, -1);
            string chemin = Microsoft.VisualBasic.Interaction.InputBox("donner  le chemin de sortie ", "chemin d'exportation", "d:\\projet_football", -1, -1);

            exp.filename = fichier_sortie;
            exp.pathStringsmil = chemin;


            exp.exportation();

        }

        private void convertirenimages(object sender, RoutedEventArgs e)
        {
            FrameGrabber fg = new FrameGrabber(url);

            string output = "D:\\projet_football";

            if (fg != null)
            {

                foreach (FrameGrabber.Frame f in fg)
                {
                    using (f)
                    {
                        // (Bitmap)f.Image.Clone();

                        System.IO.Directory.CreateDirectory(output);
                        f.Image.Save(System.IO.Path.Combine(output, "frame" + f.FrameIndex + ".png"), System.Drawing.Imaging.ImageFormat.Png);

                    }

                    if (fg == null)
                    {
                        return;
                    }
                }
            }


        }

    }

}
