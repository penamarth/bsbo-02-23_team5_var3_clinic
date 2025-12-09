using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public class PatientRepository : IPatientRepository
    {
        public PatientRepository() { }

        public Patient findById(string id) 
        {
            Console.WriteLine("Класс \"PatientRepository\" вызвал метод \"FindById()\"");
            return new Patient();
        }

        public List<Patient> findAll()
        {
            Console.WriteLine("Класс \"PatientRepository\" вызвал метод \"FindAll()\"");
            return new List<Patient>();
        }

        public bool save(Patient patient) 
        {
            Console.WriteLine("Класс \"PatientRepository\" вызвал метод \"save()\"");
            return true;
        }

        public bool update(Patient patient)
        {
            Console.WriteLine("Класс \"PatientRepository\" вызвал метод \"update()\"");
            return true;
        }
        public bool delete (string id)
        {
            Console.WriteLine("Класс \"PatientRepository\" вызвал метод \"delete()\"");
            return true;
        }

        public bool existsById(string id)
        {
            Console.WriteLine("Класс \"PatientRepository\" вызвал метод \"existsById()\"");
            return true;
        }

        public Patient findByInsurancePolicy(string policyNumber)
        {
            Console.WriteLine("Класс \"PatientRepository\" вызвал метод \"findByInsurancePolicy()\"");
            return new Patient();
        }
    }
}
