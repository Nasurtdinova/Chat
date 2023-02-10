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
    public partial class FinderEmployeePage : Window
    {
        public Chatroom CurrentChatroom { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }

        public FinderEmployeePage(Chatroom selectedChatroom)
        {
            InitializeComponent();
            if (selectedChatroom != null)
                CurrentChatroom = selectedChatroom;
            Employees = new List<Employee>();
            Departments = Connection.Entity.Department.ToList();
            lvDepartments.ItemsSource = Connection.Entity.Department.ToList();
        }

        private void cbIsTrue_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            Employees = new List<Employee>();

            foreach (var department in Departments)
            {
                if (department.IsTrue)
                    Employees.AddRange(department.Employee);
            }
            Employees = Employees.Where(a => a.Name.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            lvEmployees.ItemsSource = Employees;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentChatroom != null)
            {
                var a = lvEmployees.SelectedItem as Employee;
                if (DataAccess.GetEmployeeChatrooms().Where(b => b.Employee == a && b.Chatroom == CurrentChatroom).Count() == 0)
                {
                    EmployeeChatroom empl = new EmployeeChatroom()
                    {
                        Chatroom = CurrentChatroom,
                        Employee = a
                    };
                    Connection.Entity.EmployeeChatroom.Add(empl);
                    Connection.Entity.SaveChanges();
                    Close();
                }
                else
                    MessageBox.Show("Этот пользователь уже существует в этом чате");
            }
        }
    }
}
