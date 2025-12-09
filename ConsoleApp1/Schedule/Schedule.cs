using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public class Schedule
    {
        private IDatabase database;
        private IDoctorRepository doctorRepository;

        public Schedule()
        {
        }

        public void AddAppointment()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"AddAppointment()\"");
        }

        public void CheckAvailability()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"CheckAvailability()\"");
        }

        public void GetFreeSlots()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"GetFreeSlots()\"");
        }

        public void ShowSchedule()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"ShowSchedule()\"");
        }

        public void SelectDoctor()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"SelectDoctor()\"");
        }

        public void ConfirmAppointment()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"ConfirmAppointment()\"");
        }

        public void CancelAppointment()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"CancelAppointment()\"");
        }

        public Appointment GetAppointmentById(string id)
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"GetAppointmentById()\"");
            return new Appointment();
        }

        public List<Appointment> GetDoctorAppointments(string doctorId) 
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"GetDoctorAppointments()\"");
            return new List<Appointment>();
        }

        public List<Appointment> GetPatientAppointments(string patientId)
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"GetPatietnAppointments()\"");
            return new List<Appointment>();
        }
    }
}
