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
    public partial class ChangeTopicPage : Window
    {
        public Chatroom CurrentChatroom { get; set; }
        public ChangeTopicPage(Chatroom selectedChatroom)
        {
            InitializeComponent();
            if (selectedChatroom != null)
                CurrentChatroom = selectedChatroom;
        }

        private void btnoK_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbChange.Text))
            {
                if (CurrentChatroom != null)
                {
                    CurrentChatroom.Topic = tbChange.Text;
                    Connection.Entity.SaveChanges();
                    Close();
                }
                else
                {
                    Chatroom chatroom = new Chatroom()
                    {
                        Topic = tbChange.Text,
                    };
                    Connection.Entity.Chatroom.Add(chatroom);
                    Connection.Entity.SaveChanges();

                    EmployeeChatroom emplchat = new EmployeeChatroom()
                    {
                        Employee = MainWindow.CurrentUser,
                        Chatroom = chatroom
                    };
                    Connection.Entity.EmployeeChatroom.Add(emplchat);
                    Connection.Entity.SaveChanges();
                    Close();
                }
            }
        }  
    }
}
