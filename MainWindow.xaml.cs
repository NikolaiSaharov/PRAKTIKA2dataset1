using PRAKTIKA_1._2;
using System.Windows;
using PRAKTIKA_1._2.DataSet1TableAdapters;
namespace AVIACASSA2
{
    public partial class MainWindow : Window
    {
        private Window currentWindow;

        public MainWindow()
        {
            InitializeComponent();
            currentWindow = new TicketsWindow(); 
            currentWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new TicketsWindow();
            previousWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new PassengersWindow();
            previousWindow.Show();
            this.Close();
        }
    }
}