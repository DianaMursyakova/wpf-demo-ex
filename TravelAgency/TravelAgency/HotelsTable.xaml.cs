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
        private class Hotel
        {
            public string Title { get; set; }
            public string Stars { get; set; }
            public string Country { get; set; }
            public string ToursCount { get; set; }
        }
        private ObservableCollection<Hotel> _hotels = new ObservableCollection<Hotel>();

        public HotelsTable()
        {
            InitializeComponent();
            HotelsDataGrid.ItemsSource = _hotels;


            _hotels.Add(new Hotel() { Title = "Гостиница Татарстан", Stars = "4", Country = "Россия", ToursCount = "10" });
        }
    }
}
