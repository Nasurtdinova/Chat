using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public static class DataAccess
    {
        public static List<Employee> GetEmployees()
        {
            return Connection.Entity.Employee.ToList();
        }

        public static List<ChatMessage> GetChatMessages()
        {
            return Connection.Entity.ChatMessage.ToList();
        }

        public static List<EmployeeChatroom> GetEmployeeChatrooms()
        {
            return Connection.Entity.EmployeeChatroom.ToList();
        }

        public static List<Chatroom> GetChatRooms()
        {
            return Connection.Entity.Chatroom.ToList();
        }
    }
}
