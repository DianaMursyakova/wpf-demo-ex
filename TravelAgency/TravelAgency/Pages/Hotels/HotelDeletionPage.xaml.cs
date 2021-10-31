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
        public HotelDeletionPage()
        {
            InitializeComponent();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            if (TextBox_hotelTitle.Text.Length == 0 || TextBox_hotelTitle.Text == "")
            {
                stringBuilder.Append("Введите название отеля");
                return;
            }

            PageRouter.Instance.GoBack();
        }
    }
}
