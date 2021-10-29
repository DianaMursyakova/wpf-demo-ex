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
    /// Логика взаимодействия для HotelEditor.xaml
    /// </summary>
    public partial class HotelEditor : Window
    {
        public HotelEditor()
        {
            InitializeComponent();
        }

        private void Button_confirm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
