using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static string HashPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var a in hash)
                stringBuilder.Append(a.ToString("X2"));

            return stringBuilder.ToString();
        }
    }
}
