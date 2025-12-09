using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public class VKId
    {
        private string id;
        private string fullName;

        public void Registrate()
        {
            Console.WriteLine("Класс \"VKId\" вызвал метод \"Registrate()\"");
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"VKId\" вызвал метод \"GetUserData()\"");
        }
    }
}
