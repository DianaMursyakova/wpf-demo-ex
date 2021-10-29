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
    public partial class HotelDeleteWindow : Window
    {
        public HotelDeleteWindow()
        {
            InitializeComponent();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_hotelTitle.Text.Length == 0 || TextBox_hotelTitle.Text == "")
            {
                Label_Error.Visibility = Visibility.Visible;
                return;
            }
                
            this.Close();
        }
    }
}
