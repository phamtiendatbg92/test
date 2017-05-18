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
using testdb.Utility;
using testdb.View;
using testdb.ViewModel;
namespace testdb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ScoreView scoreView = new ScoreView();
        DbOperView dbOperView = new DbOperView();
        public MainWindow()
        {
            InitializeComponent();
            ScoreViewModel scoreVM = new ScoreViewModel(DataBase.GetAllCty());
            scoreView.DataContext = scoreVM;
            //List<congty> test = DataBase.GetAllCty();
            //for (int i = 0; i < test.Count; i++)
            //{
            //    Console.WriteLine("========================{0} == {1}", test[i].mack, test[i].tencty);
            //}

        }

        private void ShowScore_Button_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(scoreView);
        }
        private void DabaBaseOperation_Button_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(dbOperView);
        }
    }
}
