using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public class Visit
    {
        private string id;
        private string appointmentId;
        private string patientId;
        private string doctorId;
        private DateTime dateTime;
        private string diagnosis;
        private string symptoms;
        private string treatment;
        private string[] prescriptions;

        public Visit() { }
        public Visit CreateFromAppointment(Appointment appointment) 
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"CreateFromAppointment()\"");
            return new Visit();
        }



        public void AddDiagnosis(string diagnosis)
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"AddDiagnosis()\"");
        }

        public void AddPrescription(string prescription)
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"AddPrescription()\"");
        }

        public bool UpdateSymptoms(string symptoms) 
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"UpdateSymptoms()\"");
            return true;
        }

        public bool UpdateTreatment(string treatment)
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"UpdateTreatment()\"");
            return true;
        }

        public void SaveVisit()
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"SaveVisit()\"");
        }

        public string GetDiagnosis() 
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"GetDiagnosis()\"");
            return "";
        }

        public List<string> GetPrescriptions()
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"GetPrescriptions()\"");
            return new List<string>();
        }

        public string GetId()
        {
            return id;
        }
    }
}
