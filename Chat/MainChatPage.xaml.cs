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

namespace Chat
{
    public partial class MainChatPage : Page
    {
        public MainChatPage()
        {
            InitializeComponent();
            tbName.Text = MainWindow.CurrentUser.Name;
            lvChats.ItemsSource = DataAccess.GetEmployeeChatrooms().Where(a=>a.IdEmployee == MainWindow.CurrentUser.Id).Select(a=>a.Chatroom);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnFinder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FinderEmployeePage(null));
        }

        private void lvChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = lvChats.SelectedItem as Chatroom;
            NavigationService.Navigate(new ChatPage(a));
        }
    }
}
