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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page currentPage;
        Page prevPage;
        public MainWindow()
        {
            InitializeComponent();
            ChangePage(new TourList());
        }

        private void ChangePage(Page page)
        {
            prevPage = currentPage;
            currentPage = page;
            MainFrame.Navigate(currentPage);
        }
        private void MenuItem_HotelTabel_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(new HotelsTable());
        }

        private void MenuItem_TourList_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(new TourList());
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(prevPage);
        }
    }
}
