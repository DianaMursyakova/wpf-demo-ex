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
using System.Windows.Shapes;

namespace TravelAgency
{
    /// <summary>
    /// Логика взаимодействия для HotelDeleteWindow.xaml
    /// </summary>
    public partial class HotelDeletionPage : Page
    {
        private Hotel _currentHotel;
        public HotelDeletionPage(Hotel hotel)
        {
            InitializeComponent();
            _currentHotel = hotel;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrEmpty(TBName.Text))
                errors.Append("Введите название отеля");
            if (TBName.Text != _currentHotel.Name)
                errors.Append("Неверное название отеля");
            
            if(errors.Length != 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(MessageBox.Show($"Вы точно хотите удалить запись об отеле {_currentHotel.Name}", "Удаление отеля", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    RussiaTravelEntities.Context.Hotel.Remove(_currentHotel);
                    RussiaTravelEntities.Context.SaveChanges();

                    MessageBox.Show("Отель успешно удален");
                    PageRouter.Instance.GoBack();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Во время удаления отеля произошла ошибка:\n{ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            
        }
    }
}
