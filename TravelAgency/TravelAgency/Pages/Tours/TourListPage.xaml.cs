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
            List<TourItem> tourItems = new List<TourItem>()
        {
            new TourItem("Воронеж", "20000", false,"47"),
            new TourItem() ,
            new TourItem(),
            new TourItem(),
            new TourItem("Горячие источники", "50000", true,"30"),
            new TourItem(),
            new TourItem(),
            new TourItem()
        };
            foreach (var tour in tourItems)
            {
                
                ToursPanel.Children.Add(tour);
            }
        }
    }
}
