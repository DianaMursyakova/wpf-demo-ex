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

namespace TravelAgency
{
    /// <summary>
    /// Логика взаимодействия для TourList.xaml
    /// </summary>
    public partial class TourList : Page
    {

        public TourList()
        {
            InitializeComponent();

            var allTypes = RussiaTravelEntities.Context.Type.ToList();
            allTypes.Insert(0, new Type { Name = "Все типы" });
            CBoxType.ItemsSource = allTypes;
            CBoxType.SelectedIndex = 0;

            ChBoxActual.IsChecked = true;

            UpdateTours();
        }

        private void UpdateTours()
        {
            var currentTours = RussiaTravelEntities.Context.Tour.ToList();
            
            if(CBoxType.SelectedIndex != 0)
            {
                currentTours = currentTours.Where(tour => tour.Type.Contains(CBoxType.SelectedItem as Type)).ToList();
            }

            currentTours = currentTours.Where(tour => tour.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if(ChBoxActual.IsChecked.Value == true)
            {
                currentTours = currentTours.Where(tour => tour.IsActual == true).ToList();
            }

            LViewTours.ItemsSource = currentTours.OrderBy(tour => tour.TicketCount).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ChBoxActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}
