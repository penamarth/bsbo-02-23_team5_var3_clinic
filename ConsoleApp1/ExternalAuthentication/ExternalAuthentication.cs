using ConsoleApp1.ExternalAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public class ExternalAuthentication
    {
        private readonly Gosuslugi _gosuslugi = new Gosuslugi();
        private readonly Max _max = new Max();
        private readonly VKId _vkId = new VKId();

        public ExternalAuthentication()
        {
        }

        public void AuthorizeViaGosuslugi()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"AuthorizeViaGosuslugi()\"");
            _gosuslugi.Registrate();
            _gosuslugi.GetUserData();
        }

        public void AuthorizeViaMAX()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"AuthorizeViaMAX()\"");
            _max.Registrate();
            _max.GetUserData();
        }

        public void AuthorizeViaVKID()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"AuthorizeViaVKID()\"");
            _vkId.Registrate();
            _vkId.GetUserData();
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"GetUserData()\"");
        }
    }
}
