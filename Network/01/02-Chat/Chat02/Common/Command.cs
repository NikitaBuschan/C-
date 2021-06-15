using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Command
    {
        Login,      // Войти в чат
        Logout,     // Выйти из чата
        Message,    // Послать сообщение всем клиентам чата
        List,       // Получить от сервера текущий список клиентов в чате
        Null        // Ничего не делать
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //    }
    //}
}
