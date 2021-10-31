using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TravelAgency
{
    /// <summary>
    /// Логика взаимодействия для HotelEditor.xaml
    /// </summary>
    public partial class HotelEditorPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public HotelEditorPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                _currentHotel = selectedHotel;

            DataContext = _currentHotel;
            CBoxCountry.ItemsSource = RussiaTravelEntities.Context.Country.ToList();
        }

        private void Button_confirm_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentHotel.Name))
                errors.AppendLine("Укажите название отеля");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errors.AppendLine("Количество звезд - число от 1 до 5");
            if (_currentHotel.Country == null)
                errors.AppendLine("Укажите страну");

            if (errors.Length != 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentHotel.Id == 0)
                RussiaTravelEntities.Context.Hotel.Add(_currentHotel);

            try
            {
                RussiaTravelEntities.Context.SaveChanges();
                MessageBox.Show($"Информация сохранена");
                PageRouter.Instance.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка во время сохранения:\n{ex.Message}");
            }

        }
    }
}
