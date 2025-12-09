using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public class DoctorRepository
    {
        public DoctorRepository() { }
        public Doctor findById(string id)
        {
            Console.WriteLine("Класс \"DoctorRepository\" вызвал метод \"FindById()\"");
            return new Doctor();
        }

        public List<Doctor> findAll()
        {
            Console.WriteLine("Класс \"DoctorRepository\" вызвал метод \"FindAll()\"");
            return new List<Doctor>();
        }

        public bool save(Doctor doctor)
        {
            Console.WriteLine("Класс \"DoctorRepository\" вызвал метод \"save()\"");
            return true;
        }

        public bool update(Doctor doctor)
        {
            Console.WriteLine("Класс \"DoctorRepository\" вызвал метод \"update()\"");
            return true;
        }
        public bool delete(string id)
        {
            Console.WriteLine("Класс \"DoctorRepository\" вызвал метод \"delete()\"");
            return true;
        }

        public bool existsById(string id)
        {
            Console.WriteLine("Класс \"DoctorRepository\" вызвал метод \"existsById()\"");
            return true;
        }

        public Doctor findBySpecialization(string policyNumber)
        {
            Console.WriteLine("Класс \"DoctorRepository\" вызвал метод \"findBySpecialization()\"");
            return new Doctor();
        }
    }
}
