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

namespace Chat
{
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Employee user = new Employee()
            {
                IdDepartment = 1,
                Name = tbName.Text,
                Username = tbLogin.Text,
                Password = DataAccess.HashPassword(tbPassword.Password)
            };
            Connection.Entity.Employee.Add(user);
            Connection.Entity.SaveChanges();
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
