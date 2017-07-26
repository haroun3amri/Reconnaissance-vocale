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
using System.Windows.Threading;
using System.Speech.Recognition;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using Google.Cloud.Speech;
using Google.Cloud.Speech.V1;
using Google.Apis.Auth.OAuth2;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using FilterLibNative;
using FilterLib;
using MLApp;


namespace RecoVacale
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        private MediaPlayer mediaPlayer = new MediaPlayer();
        public RecognitionConfig.Types.AudioEncoding Encoding { get; set; }


        


        public MainWindow()
        {
            InitializeComponent();

        }
        //********************************Rederiger vers Base de donnée**************

        private void click_DB(object sender, RoutedEventArgs e)
        {
           

            DataBase win2 = new DataBase();

            win2.Show();
        }

        //*****************************Methode d'insertion d'une piste audio dans SQL Server
        private void AjoutAudio(string SafeFileName , string FileName , byte[] stream)
        {
            string ConString = "Data Source=(localdb)\\Projects;Initial Catalog=RecoVocale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand com = new SqlCommand("insert into noisy(FileName, FilePath, fldvoice) values(@Filename, @FilePath, @voice)", con);
            State.Text = "Saving sequence ... ";

            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.ShowDialog();

            //byte[] stream = File.ReadAllBytes(fileDialog.FileName);
            if (stream.Length > 0)
            {
                com.Parameters.AddWithValue("@Filename", SafeFileName);
                com.Parameters.AddWithValue("@FilePath", FileName);
                com.Parameters.AddWithValue("@voice", stream);
                con.Open();
                int result = com.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Ajout de la piste audio dans la base de donnée Archive avec succée !");
                con.Close();
            }


            
        }

        //*****************************Methode de controle d'uplade dpuis la base e
        private void FromDB_Click(object sender , RoutedEventArgs e)
        {
            DataBase win2 = new DataBase();

            win2.Show();
        }

        private void FromDB_Filted_Click(object sender, RoutedEventArgs e)
        {
            DataBase_Filtred win2 = new DataBase_Filtred();

            win2.Show();
        }
        //******************************Méthode de controle de upload**********************

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var sre = new SpeechRecognitionEngine();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".wav";
            dlg.Filter = "Audio documents (.wav)|*.wav";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                mediaPlayer.Open(new Uri(dlg.FileName));
                //------------------
                string SafeFileName = dlg.SafeFileName;
                string filename = dlg.FileName;
                byte[] stream = File.ReadAllBytes(dlg.FileName);
                AjoutAudio(SafeFileName, filename, stream);
                //-------------Appliation du filtre----
                State.Text = "Filring Sequence ... ";
                // Create the MATLAB instance 
                MLApp.MLApp matlab = new MLApp.MLApp();

                // Change to the directory where the function is located 
                matlab.Execute(@"cd C:\Users\Haroun3amri\Documents");
                
                // Define the output 
                object result2 = null;

                // Call the MATLAB function myfunc
                matlab.Feval("filtre", 1, out result2, filename);
                //matlab.Feval("myfunc", 2, out result2, 3.14, 42.0, "world");
                object[] res = result2 as object[];

                MessageBox.Show("Filtrage piste audio avec succée !");




                //-----------------Ajout a la base des piste filtrées
                string ConString = "Data Source=(localdb)\\Projects;Initial Catalog=RecoVocale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con2 = new SqlConnection(ConString);
                SqlCommand com2 = new SqlCommand("insert into filtred(FileName, FilePath, fldvoice) values(@Filename, @FilePath, @voice)", con2);
                State.Text = "Saving sequence ... ";

                //OpenFileDialog fileDialog = new OpenFileDialog();
                //fileDialog.ShowDialog();

                //byte[] stream = File.ReadAllBytes(fileDialog.FileName);
                if (stream.Length > 0)
                {
                    string FilePath2 = "C:\\Users\\Haroun3amri\\Documents\\";
                    string FileName2 = "result.wav";
                    com2.Parameters.AddWithValue("@Filename", FileName2);
                    com2.Parameters.AddWithValue("@FilePath", FilePath2);
                    com2.Parameters.AddWithValue("@voice", stream);
                    con2.Open();
                    int result3 = com2.ExecuteNonQuery();
                    if (result3 > 0)
                        MessageBox.Show("Ajout de la piste audio dans la base de donnée filtée avec succée !");
                    con2.Close();
                }
                FileNameTextBox.Text = filename;
                sre.SetInputToWaveFile(filename);
                sre.LoadGrammar(new DictationGrammar());
                //sre.RecognizeAsync(RecognizeMode.Multiple);
              
                State.Text = "Sequence Recognition ... ";
                sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
               sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
                sre.EndSilenceTimeout = new TimeSpan(100000000);
                sre.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);
                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    try
                    {
                        var recText = sre.Recognize();
                        sb.Append(recText.Text);
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                
                Screen.AppendText(sb.ToString());
                State.Text = "Done ... ";

            }


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        //***************************************Methode de controle de Timer du Player************************
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                if( ! Duration.Automatic.HasTimeSpan)
                lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "No file selected...";
        }
        //***************************Méthode de Play de MediaPlayer ********************************************
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
            
        }
        //******************************Méthode de pause de MediaPlayer*******************************************
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }
        //******************************Méthode de Stop de MediaPlayer********************************************
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
        //************************ Méthode pour la recherche d'une sequence par text *****************************
        private void SearchSequence(object sender , RoutedEventArgs  e)
        {
            string lookedFor = LookedFor.Text;
            
            TextRange textRange = new TextRange(
        Screen.Document.ContentStart,
        Screen.Document.ContentEnd
    );
            TextRange textRange2 = new TextRange(
        Screen2.Document.ContentStart,
        Screen2.Document.ContentEnd
    );

            TextRange textRange3 = new TextRange(
        Screen3.Document.ContentStart,
        Screen3.Document.ContentEnd
    );


            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            string Reconized = textRange.Text;
            if(Reconized.Contains(lookedFor))
            {
                textRange2.Text=lookedFor;
                textRange3.Text=Regex.Matches(Reconized, lookedFor).Count.ToString();
            }
            else
            {
                textRange2.Text = "Non trouvé" ;
                textRange3.Text = "0";

            }
        }

       
        //************************************Implementing Google recongnition API *************
        private void googleAPI(object sender, EventArgs e )
        {
            
      
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();


            dlg.DefaultExt = ".wav";
            dlg.Filter = "Audio documents (.wav)|*.wav";

            Nullable<bool> result = dlg.ShowDialog();
            mediaPlayer.Open(new Uri(dlg.FileName));
            string filename = dlg.FileName;
            FileNameTextBox.Text = filename;



            var speech = SpeechClient.Create();
                var response = speech.Recognize(new RecognitionConfig()
                {
                    //Encoding = encoding,
                    //SampleRateHertz = bitRate,
                    LanguageCode = "fr",
                }, RecognitionAudio.FromFile(filename));
                foreach (var result2 in response.Results)
                {
                    foreach (var alternative in result2.Alternatives)
                    {
                        //Console.WriteLine(alternative.Transcript);
                    Screen.AppendText(alternative.Transcript.ToString());
                }
                }
                
        }





        //*******************************************************************************









    }
}
