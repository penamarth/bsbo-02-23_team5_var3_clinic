using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public interface IMedicalRecordRepository
    {
        MedicalRecord FindByPatientId(string patientId);
        List<MedicalRecord> FindByDoctorId(string doctorId);
        void Save(MedicalRecord record);
        void Delete(string recordId);
        List<MedicalRecord> FindByDateRange(DateTime startDate, DateTime endDate);
    }

    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private IDatabase database;

        public MedicalRecordRepository(IDatabase db)
        {
            database = db;
        }

        public MedicalRecord FindByPatientId(string patientId)
        {
            Console.WriteLine("Класс \"MedicalRecordRepository\" вызвал метод \"FindByPatientId()\"");
            return new MedicalRecord();
        }

        public List<MedicalRecord> FindByDoctorId(string doctorId)
        {
            Console.WriteLine("Класс \"MedicalRecordRepository\" вызвал метод \"FindByDoctorId()\"");
            return new List<MedicalRecord>();
        }

        public void Save(MedicalRecord record)
        {
            Console.WriteLine("Класс \"MedicalRecordRepository\" вызвал метод \"Save()\"");
        }

        public void Delete(string recordId)
        {
            Console.WriteLine("Класс \"MedicalRecordRepository\" вызвал метод \"Delete()\"");
        }

        public List<MedicalRecord> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine("Класс \"MedicalRecordRepository\" вызвал метод \"FindByDateRange()\"");
            return new List<MedicalRecord>();
        }
    }
}
