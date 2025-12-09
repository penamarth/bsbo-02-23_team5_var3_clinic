using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public class Gosuslugi
    {
        private string id;
        private string fullName;

        public void Registrate()
        {
            Console.WriteLine("Класс \"Gosuslugi\" вызвал метод \"Registrate()\"");
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"Gosuslugi\" вызвал метод \"GetUserData()\"");
        }
    }
}
