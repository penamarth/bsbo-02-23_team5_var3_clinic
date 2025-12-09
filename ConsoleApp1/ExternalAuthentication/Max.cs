using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ExternalAuthentication
{
    public class Max
    {
        private string id;
        private string fullName;

        public void Registrate()
        {
            Console.WriteLine("Класс \"Max\" вызвал метод \"Registrate()\"");
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"Max\" вызвал метод \"GetUserData()\"");
        }
    }
}
