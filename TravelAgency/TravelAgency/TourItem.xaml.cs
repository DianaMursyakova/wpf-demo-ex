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
    /// Логика взаимодействия для TourItem.xaml
    /// </summary>
    public partial class TourItem : UserControl
    {
        public TourItem()
        {
            InitializeComponent();
        }
        public TourItem(string title, string price, bool isRelevant, string ticketCount)
        {
            InitializeComponent();
            TitleLabel.Content = title;
            PriceLabel.Content = price;


            RelevanceLabel.Content = isRelevant ? "Актуален" : "Не актуален";
            Color color = isRelevant ? Color.FromRgb(0,255,0) : Colors.Red;
            RelevanceLabel.Foreground = new SolidColorBrush(color);

            TicketCountLabel.Content = ticketCount;
        }
    }
}
