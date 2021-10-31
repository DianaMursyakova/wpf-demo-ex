using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TravelAgency
{
    public partial class HotelsTable : Page
    {

        private readonly ObservableCollection<int> _elementsCounts = new ObservableCollection<int>()
        {
            10,20,30,40,50
        };

        public HotelsTable()
        {
            InitializeComponent();


            CBoxHotelCount.ItemsSource = _elementsCounts;
            CBoxHotelCount.SelectedIndex = 0;

            UpdateHotels();
        }
        private void UpdateHotels()
        {
            RussiaTravelEntities.Context.ChangeTracker.Entries().ToList().ForEach(hotel => hotel.Reload());

            var currentTours = RussiaTravelEntities.Context.Tour.ToList();


            DGridHotels.ItemsSource = currentTours;
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
