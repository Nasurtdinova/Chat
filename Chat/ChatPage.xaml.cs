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
    public partial class ChatPage : Page
    {
        public Chatroom CurrentChatroom { get; set; }
        public ChatPage(Chatroom selectedChatroom)
        {
            InitializeComponent();
            if (selectedChatroom != null)
                CurrentChatroom = selectedChatroom;
            lvMessages.ItemsSource = Connection.Entity.ChatMessage.ToList().Where(a => a.Chatroom == selectedChatroom).OrderBy(a => a.Date);
            lvEmployees.ItemsSource = DataAccess.GetEmployeeChatrooms().Where(a => a.Chatroom == selectedChatroom).Select(a=>a.Employee);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FinderEmployeePage(CurrentChatroom));
        }
    }
}
