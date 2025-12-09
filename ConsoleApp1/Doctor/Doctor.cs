using System;
using System.Collections.Generic;


namespace HospitalDemo
{
    public class Doctor : IObserver
    {
        private string id;
        private string fullName;
        private string specialization;
        private string licenceNumber;
        private Schedule schedule;

        public Doctor()
        {
        }


        public void ConductAppointment()
        {
            Console.WriteLine("Класс \"Doctor\" вызвал метод \"ConductAppointment()\"");
        }

        public void UpdateSchedule()
        {
            
        }

        public void Update(string message)
        {
            Console.WriteLine($"Класс \"Doctor\" получил уведомление через метод \"Update()\": {message}");
        }

        public List<Appointment> GetSchedule(DateTime startDate, DateTime endDate) 
        {
            Console.WriteLine("Класс \"Doctor\" вызвал метод \"GetSchedule()\"");
            return new List<Appointment>();
        }
    }
}
