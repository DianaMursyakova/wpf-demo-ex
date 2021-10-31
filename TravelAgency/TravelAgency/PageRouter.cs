using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TravelAgency
{
    class PageRouter
    {
        private static PageRouter _instance;
        private Frame _mainFrame;
        private Page _currentPage;
        private Page _prevPage;
        private Stack<Page> pages = new Stack<Page>();

        public static PageRouter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PageRouter();
                return _instance;
            }
        }
        public Frame MainFrame { get { return _mainFrame; } set { _mainFrame = value; } }

        public void ChangePage(Page page)
        {
            if (page == _currentPage)
                return;
            _prevPage = _currentPage;
            _currentPage = page;

            MainFrame.Navigate(page);
        }
        public void GoBack()
        {

            MainFrame.Navigate(_prevPage);
        }
    }
}
