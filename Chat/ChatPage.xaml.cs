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
    public partial class ChatPage : Window
    {
        public Chatroom CurrentChatroom { get; set; }
        public ChatPage(Chatroom selectedChatroom)
        {
            InitializeComponent();
            if (selectedChatroom != null)
                CurrentChatroom = selectedChatroom;
            Title = $"Topic: {CurrentChatroom.Topic}";
            lvMessages.ItemsSource = Connection.Entity.ChatMessage.ToList().Where(a => a.Chatroom == selectedChatroom).OrderBy(a => a.Date);
            lvEmployees.ItemsSource = DataAccess.GetEmployeeChatrooms().Where(a => a.Chatroom == selectedChatroom).Select(a=>a.Employee);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbInputMessage.Text))
            {
                ChatMessage chat = new ChatMessage()
                {
                    Chatroom = CurrentChatroom,
                    Date = DateTime.Now,
                    Employee = MainWindow.CurrentUser,
                    Message = tbInputMessage.Text
                };
                Connection.Entity.ChatMessage.Add(chat);
                Connection.Entity.SaveChanges();
                lvMessages.ItemsSource = Connection.Entity.ChatMessage.ToList().Where(a => a.Chatroom == CurrentChatroom).OrderBy(a => a.Date);
                tbInputMessage.Text = String.Empty;
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }

        private void btnLeaveChatroom_Click(object sender, RoutedEventArgs e)
        {
            var chatroom = DataAccess.GetEmployeeChatrooms().Where(a => a.Chatroom == CurrentChatroom && a.Employee == MainWindow.CurrentUser).FirstOrDefault();
            if (chatroom != null)
            {
                if (MessageBox.Show("Вы точно хотите покинуть эту комнату?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Connection.Entity.EmployeeChatroom.Remove(chatroom);
                    Connection.Entity.SaveChanges();
                    Close();
                }
            }
        }

        private void btnChangeTopic_Click(object sender, RoutedEventArgs e)
        {
            ChangeTopicPage win = new ChangeTopicPage(CurrentChatroom);
            win.Show();
            win.Closed += (a, eventarg) =>
            {
                Title = $"Topic: {CurrentChatroom.Topic}";
            };
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
