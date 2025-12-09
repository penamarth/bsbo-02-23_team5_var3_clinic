using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HospitalDemo
{
    public class Appointment
    {
        private string id;
        private string patientId;
        private string doctorId;
        private DateTime DateTime;
        private bool status;
        private string appointmentType;
        private string notes;

        public Appointment() { }


        public void create()
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"create()\"");
        }

        public void confirm()
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"confirm()\"");
        }

        public void cancel(string reason)
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"cancel()\"");
        }

        public void reschedule()
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"reschedule()\"");
        }

        public void start()
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"start()\"");
        }

        public void complete()
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"complete()\"");
        }

        public void getStatus()
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"getStatus()\"");
        }

        public void setStatus(string status)
        {
            Console.WriteLine("Класс \"Appointment\" вызвал метод \"setStatus()\"");
        }
    }
}
