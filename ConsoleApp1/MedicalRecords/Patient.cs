using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public class Patient : IObserver
    {
        private string id;
        private string fullName;
        private DateTime dateOfBirth;
        private string insurancePolicy;
        private string passport;

        public Patient()
        {
        }

        public void EnterMedicalData()
        {
            Console.WriteLine("Класс \"Patient\" вызвал метод \"EnterMedicalData()\"");
        }

        public void ScheduleAppointment()
        {
            Console.WriteLine("Класс \"Patient\" вызвал метод \"ScheduleAppointment()\"");
        }

        public void Update(string message)
        {
            Console.WriteLine($"Класс \"Patient\" получил уведомление через метод \"Update()\": {message}");
        }
    }
}
