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
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            tbUsername.Text = Properties.Settings.Default.login;
            tbPassword.Password = Properties.Settings.Default.password;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var user = DataAccess.GetEmployees().Where(a=>a.Username == tbUsername.Text && a.Password == tbPassword.Password).FirstOrDefault();
            if (user != null)
            {
                if (cbRemember.IsChecked == true)
                {
                    Properties.Settings.Default.login = tbUsername.Text;
                    Properties.Settings.Default.password = tbPassword.Password;
                }
                else
                {
                    Properties.Settings.Default.password = String.Empty;
                    Properties.Settings.Default.login = String.Empty;
                }
                Properties.Settings.Default.Save();
                MainWindow.CurrentUser = user;
                NavigationService.Navigate(new MainChatPage());
            }
            else
                MessageBox.Show("Invalid login or password");
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
