using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;
using System.Data;

namespace RecoVacale
{
    /// <summary>
    /// Interaction logic for MainWindow_DataGrid_Operations.xaml
    /// </summary>
    public partial class DataBase: Window
    {
        RecoVocaleEntities objContext;
        private MediaPlayer mediaPlayer = new MediaPlayer();

        bool isUpdateMode = false;

        noisy objEmpToEdit = null;

        public DataBase()
        {
            InitializeComponent();
            
        }
        //******************************************************************
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            objContext = new RecoVocaleEntities();
            dgEmp.ItemsSource = objContext.noisies.ToList();
        }

        private void dgEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objEmpToEdit = dgEmp.SelectedItem as noisy;
        }
        //******************************************************************
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            isUpdateMode = true;
            dgEmp.Columns[2].IsReadOnly = false;
            dgEmp.Columns[3].IsReadOnly = false;
        }
         //*****************************************************************
        private void dgEmp_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            objContext.SaveChanges();
            MessageBox.Show("The Current row updation is complete..");
        }

        //******************************************************************
        private void PlaySeq(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri(objEmpToEdit.FilePath));
            mediaPlayer.Play();
        }
        private void StopSeq(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
        private void PauseSeq(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }



        //*************************************************************
        private void dgEmp_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (isUpdateMode) //The Row is  edited
            {
                noisy TempEmp = (from emp in objContext.noisies
                                    where emp.Id == objEmpToEdit.Id
                                    select emp).First();


                FrameworkElement element_1 = dgEmp.Columns[2].GetCellContent(e.Row);
                if (element_1.GetType() == typeof(TextBox))
                {
                    var FName = ((TextBox)element_1).Text;
                    objEmpToEdit.FileName = FName;
                }
                FrameworkElement element_2 = dgEmp.Columns[3].GetCellContent(e.Row);
                if (element_2.GetType() == typeof(TextBox))
                {
                    var FPath = ((TextBox)element_2).Text;
                    objEmpToEdit.FilePath = FPath;
                }
                FrameworkElement element_3 = dgEmp.Columns[4].GetCellContent(e.Row);
                if (element_3.GetType() == typeof(TextBox))
                {
                    var FVoice = ((TextBox)element_3).Text;
                    objEmpToEdit.FilePath = FVoice;
                }
            }

        }
        //***********************************************************
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (objEmpToEdit == null)
            {
                MessageBox.Show("Cannot delete the blank Entry");
            }
            else
            {
                //objContext.Database.Delete(dgEmp.SelectedItem);
                objContext.SaveChanges();
                MessageBox.Show("Record Deleted..");
            }
        }

        //*********************************************************






    }
}
