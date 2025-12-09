using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public class MedicalRecords
    {
        private IDatabase database;
        private List<Patient> patients = new List<Patient>();
        private List<Visit> visits = new List<Visit>();
        private IPatientRepository patientRepository;
        private IMedicalRecordRepository medicalRecordRepository;

        public MedicalRecords()
        {
        }

        public void CreateRecord()
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"CreateRecord()\"");
        }

        public void AddPatient()
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"AddPatient()\"");
        }

        public void UpdateData()
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"UpdateData()\"");
        }

        public void GetHistory()
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"GetHistory()\"");
        }

        public void LinkToPatient()
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"LinkToPatient()\"");
        }

        public void AddVisit(Visit visit)
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"AddVisit()\"");
            visits.Add(visit);
        }

        public List<Visit> GetPatientVisits(string patientId)
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"GetPatientVisits()\"");
            return visits;
        }

        public Visit GetVisitById(string visitId)
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"GetVisitById()\"");
            return new Visit();
        }
    }
}
    