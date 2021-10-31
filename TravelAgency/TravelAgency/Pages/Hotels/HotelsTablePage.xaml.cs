using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для HotelsTable.xaml
    /// </summary>
    public partial class HotelsTable : Page
    {
        public HotelsTable()
        {
            InitializeComponent();



        }
        private void UpdateHotels()
        {
            RussiaTravelEntities.Context.ChangeTracker.Entries().ToList().ForEach(hotel => hotel.Reload());
            DGridHotels.ItemsSource = RussiaTravelEntities.Context.Hotel.ToList();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Page page = new HotelDeletionPage((sender as Button).DataContext as Hotel);
            PageRouter.Instance.ChangePage(page);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Page page = new HotelEditorPage(null);
            PageRouter.Instance.ChangePage(page);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Page page = new HotelEditorPage((sender as Button).DataContext as Hotel);
            PageRouter.Instance.ChangePage(page);
        }

        private void CBoxHotelCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UpdateHotels();
            }
        }
    }
}
