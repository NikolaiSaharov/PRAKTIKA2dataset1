using System.Windows;
using System.Data;
using PRAKTIKA_1._2.DataSet1TableAdapters; 
using System;
using AVIACASSA2;

namespace PRAKTIKA_1._2
{
    public partial class TicketsWindow : Window
    {
        TicketsTableAdapter ticketsAdapter = new TicketsTableAdapter(); 

        public TicketsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            TicketsDataGrid.ItemsSource = ticketsAdapter.GetData(); 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new MainWindow();
            previousWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var previousWindow = new PassengersWindow();
            previousWindow.Show();
            this.Close();
        }

        private void AddTicketButton_Click(object sender, RoutedEventArgs e)
        {
            string SeatNumber = SeatNumberTextBox.Text;
            string Class = ClassTextBox.Text;
            string Price = PriceTextBox.Text;
            


            ticketsAdapter.InsertQuery(SeatNumber, Class, Price);

            RefreshDataGrid();
        }

        private void UpdateTicketButton_Click(object sender, RoutedEventArgs e)
        {
            if (TicketsDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = TicketsDataGrid.SelectedItem as DataRowView;
                int ticketsId = (int)selectedRow.Row["TicketsId"];

                string SeatNumber = SeatNumberTextBoxIzm.Text;
                string Class = ClassTextBoxIzm.Text;
                string Price = PriceTextBoxIzm.Text;


                string originalSeatNumber = (string)selectedRow.Row["SeatNumber"];
                string originalClass = (string)selectedRow.Row["Class"];
                string originalPrice = (string)selectedRow.Row["Price"];
                

                ticketsAdapter.UpdateQuery(SeatNumber, Class, Convert.ToDecimal(Price), ticketsId, originalSeatNumber, originalClass, Convert.ToDecimal(originalPrice));
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для изменения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTicketButton_Click(object sender, RoutedEventArgs e)
        {
            if (TicketsDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = TicketsDataGrid.SelectedItem as DataRowView;
                int ticketsId = (int)selectedRow.Row["TicketsId"];


                string originalSeatNumber = (string)selectedRow.Row["SeatNumber"];
                string originalClass = (string)selectedRow.Row["Class"];
                string originalPrice = (string)selectedRow.Row["Price"];

                ticketsAdapter.DeleteQuery(ticketsId, originalSeatNumber, originalClass, Convert.ToDecimal(originalPrice));
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}