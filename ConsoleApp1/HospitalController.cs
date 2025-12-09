using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public interface IDatabase
    {
        void Connect();
        void ExecuteQuery(string query, object[] parameters);
        void Close();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }

    public interface IObserver
    {
        void Update(string message);
    }

    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string message);
    }

    public class HospitalController : IObservable
    {
        private readonly IDatabase database;
        private readonly MedicalRecords medicalRecords;
        private readonly Schedule schedule;
        private readonly Appointment appointment;
        private readonly List<IObserver> observers = new List<IObserver>();
        private readonly ExternalAuthentication externalAuth;
        private readonly Patient demoPatient;
        private readonly Doctor demoDoctor;
        private Visit currentVisit;

        public HospitalController()
        {
            medicalRecords = new MedicalRecords();
            schedule = new Schedule();
            appointment = new Appointment();
            externalAuth = new ExternalAuthentication();
            currentVisit = new Visit();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"AddObserver()\"");
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"RemoveObserver()\"");
        }

        public void NotifyObservers(string message)
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"NotifyObservers()\"");
            foreach (var obs in observers)
            {
                obs.Update(message);
            }
        }

        // ===== Общие методы (просто трассировка) =====

        public void AuthenticateUser()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"AuthenticateUser()\"");
        }

        public void RegisterPatient()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"RegisterPatient()\"");
            Console.WriteLine("Класс \"HospitalController\" создает объект \"ExternalAuthentication\" и вызывает \"AuthorizeViaGosuslugi()\"");
            externalAuth.AuthorizeViaGosuslugi();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"CreateMedicalRecord()\"");
            CreateMedicalRecord();
        }

        public void CreateMedicalRecord()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"CreateMedicalRecord()\"");
            medicalRecords.CreateRecord();
            medicalRecords.LinkToPatient();
        }

        public void UpdateMedicalData()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"UpdateMedicalData()\"");
            medicalRecords.UpdateData();
        }

        public void ScheduleAppointment()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"ScheduleAppointment()\"");
        }

        public void RequestCertificate()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"RequestCertificate()\"");
            // Для use case "Выдача справок" демонстрируем цепочку
            Console.WriteLine("Класс \"HospitalController\" вызывает \"IDatabase.BeginTransaction()\"");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"MedicalRecords.AddVisit()\"");
            var visit = new Visit();
            medicalRecords.AddVisit(visit);

            Console.WriteLine("Класс \"HospitalController\" вызывает \"NotifyObservers()\" для Patient и UI");
            NotifyObservers("Справка выдана");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"IDatabase.Commit()\"");
        }

        public void GenerateReferral()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"GenerateReferral()\"");
            Console.WriteLine("Класс \"HospitalController\" вызывает \"Schedule.CheckAvailability()\" и \"Schedule.GetFreeSlots()\"");
            schedule.CheckAvailability();
            schedule.GetFreeSlots();

            Console.WriteLine("Класс \"HospitalController\" создает объект \"Visit\" с типом \"referral\" через Schedule.CreateVisitForAppointment()");
            var visit = currentVisit.CreateFromAppointment(appointment);
            visit.SaveVisit();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"NotifyObservers()\" для Patient, Doctor и UI");
            NotifyObservers("Направление выдано");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"MedicalRecords.AddVisit()\" и \"IDatabase.ExecuteQuery()\"");
            medicalRecords.AddVisit(visit);
        }

        public void ShowHistory()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"ShowHistory()\"");
            medicalRecords.GetHistory();
        }

        public void StartAppointment()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"StartAppointment()\"");
            Console.WriteLine("Класс \"HospitalController\" вызывает \"Schedule.ShowSchedule()\"");
            schedule.ShowSchedule();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"MedicalRecords.GetPatientVisits()\"");
            medicalRecords.GetPatientVisits("");

            currentVisit = new Visit();
            Console.WriteLine("Класс \"HospitalController\" создал объект \"Visit\" для текущего приема");
        }

        public void CompleteAppointment()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"CompleteAppointment()\"");
            if (currentVisit == null)
            {
                Console.WriteLine("Текущий прием (Visit) не найден");
                return;
            }

            Console.WriteLine("Класс \"HospitalController\" вызывает \"Visit.AddDiagnosis()\" и \"Visit.AddPrescription()\"");
            currentVisit.AddDiagnosis("Диагноз из UI");
            currentVisit.AddPrescription("Рекомендация из UI");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"MedicalRecords.AddVisit()\"");
            medicalRecords.AddVisit(currentVisit);

            Console.WriteLine("Класс \"HospitalController\" вызывает \"IDatabase.Commit()\"");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"NotifyObservers()\" для пациента");
            NotifyObservers("Прием завершен");
        }

        //===== Специальный метод для демонстрации Use Case "Запись на прием" =====
        public void ScheduleAppointmentUseCase()
        {
            Console.WriteLine("=== Use Case: Запись на прием к врачу ===");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"Schedule.GetFreeSlots()\"");
            schedule.GetFreeSlots();

            Console.WriteLine("Класс \"HospitalController\" получает слоты и передает их в UI (логика UI опущена)");

            Console.WriteLine("Пациент выбирает слот, UI вызывает \"HospitalController.ScheduleAppointment()\" для подтверждения");
            ScheduleAppointment();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"Schedule.ConfirmAppointment()\"");
            schedule.ConfirmAppointment();

            Console.WriteLine("Класс \"Schedule\" создает объект \"Visit\" и добавляет запись в базу данных");
            var visit = currentVisit.CreateFromAppointment(new Appointment());

            Console.WriteLine("Класс \"HospitalController\" вызывает \"NotifyObservers()\" для пациента");
            NotifyObservers("Запись на прием подтверждена");

            Console.WriteLine("=== Конец Use Case: Запись на прием к врачу ===");
        }

        public void ValidateDoctorCredentials()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"ValidateDoctorCredentials()\"");
        }

        public void CreateDoctorAccount()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"CreateDoctorAccount()\"");
        }

        public void AssignSpecialization()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"AssignSpecialization()\"");
        }

        public void SetupWorkSchedule()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"SetupWorkSchedule()\"");
        }
    }
}
