using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public class ApointmentRepository
    {
        public Appointment findById(string id) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"findById()\"");
            return new Appointment();
        }
        public Patient findByPatientId(string patientId) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"findByPatientId()\"");
            return new Patient();
        }
        public Doctor findByDoctroId(string doctroId) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"findDoctorById()\"");
            return new Doctor();
        }
        public List<Appointment> findByStatus(string status) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"findByStatus()\"");
            return new List<Appointment>();
        }
        public bool save(Appointment appointment) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"save()\"");
            return true;
        }
        public bool update(Appointment appointment) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"update()\"");
            return true;
        }
        public bool delete(string id) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"delete()\"");
            return true;
        }
        public bool existsById(string id) 
        {
            Console.WriteLine("Класс \"AppointmentRepository\" вызвал метод \"existsById()\"");
            return true;
        }
    }
}
