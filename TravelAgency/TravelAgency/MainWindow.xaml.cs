using System;
using System.Collections.Generic;
using System.IO;
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
        public MainWindow()
        {
            InitializeComponent();
            
            PageRouter.Instance.MainFrame = MainFrame;
            PageRouter.Instance.ChangePage(new TourList());
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Mark\Desktop\ДЭ\import\Туры.txt");
            var images = Directory.GetFiles(@"C:\Users\Mark\Desktop\ДЭ\import\Туры фото");

            foreach(var line in fileData)
            {
                var data = line.Split('\t');
                var tempTour = new Tour()
                {
                    Name = data[0].Replace("\"", ""),
                    TicketCount = int.Parse(data[2]),
                    Price = decimal.Parse(data[3]),
                    IsActual = (data[4] == "0") ? false : true
                };

                foreach(var tourType in data[5].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = RussiaTravelEntities.Context.Type.ToList().FirstOrDefault(p => p.Name == tourType);
                    if(currentType != null)
                    {
                        tempTour.Type.Add(currentType);
                    }
                }

                try
                {
                    tempTour.ImagePreview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Name)));


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                RussiaTravelEntities.Context.Tour.Add(tempTour);
                RussiaTravelEntities.Context.SaveChanges();
            }
        }

        private void MenuItem_HotelTabel_Click(object sender, RoutedEventArgs e)
        {
            PageRouter.Instance.ChangePage(new HotelsTable());
        }

        private void MenuItem_TourList_Click(object sender, RoutedEventArgs e)
        {
            PageRouter.Instance.ChangePage(new TourList());
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            PageRouter.Instance.GoBack();
        }
    }
}
