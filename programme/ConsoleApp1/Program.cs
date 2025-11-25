using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    // ================== Database =====================

    public interface IDatabase
    {
        void Connect();
        void ExecuteQuery(string query, object[] parameters);
        void Close();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }

    public class PostgreSQLDatabase : IDatabase
    {
        public void BeginTransaction()
        {
            Console.WriteLine("Класс \"PostgreSQLDatabase\" вызвал метод \"BeginTransaction()\"");
        }

        public void Close()
        {
            Console.WriteLine("Класс \"PostgreSQLDatabase\" вызвал метод \"Close()\"");
        }

        public void Commit()
        {
            Console.WriteLine("Класс \"PostgreSQLDatabase\" вызвал метод \"Commit()\"");
        }

        public void Connect()
        {
            Console.WriteLine("Класс \"PostgreSQLDatabase\" вызвал метод \"Connect()\"");
        }

        public void ExecuteQuery(string query, object[] parameters)
        {
            Console.WriteLine($"Класс \"PostgreSQLDatabase\" вызвал метод \"ExecuteQuery()\" с запросом \"{query}\"");
        }

        public void Rollback()
        {
            Console.WriteLine("Класс \"PostgreSQLDatabase\" вызвал метод \"Rollback()\"");
        }
    }

    public class SQLiteDatabase : IDatabase
    {
        public void BeginTransaction()
        {
            Console.WriteLine("Класс \"SQLiteDatabase\" вызвал метод \"BeginTransaction()\"");
        }

        public void Close()
        {
            Console.WriteLine("Класс \"SQLiteDatabase\" вызвал метод \"Close()\"");
        }

        public void Commit()
        {
            Console.WriteLine("Класс \"SQLiteDatabase\" вызвал метод \"Commit()\"");
        }

        public void Connect()
        {
            Console.WriteLine("Класс \"SQLiteDatabase\" вызвал метод \"Connect()\"");
        }

        public void ExecuteQuery(string query, object[] parameters)
        {
            Console.WriteLine($"Класс \"SQLiteDatabase\" вызвал метод \"ExecuteQuery()\" с запросом \"{query}\"");
        }

        public void Rollback()
        {
            Console.WriteLine("Класс \"SQLiteDatabase\" вызвал метод \"Rollback()\"");
        }

        public void Compact()
        {
            Console.WriteLine("Класс \"SQLiteDatabase\" вызвал метод \"Compact()\"");
        }
    }

    // ================ Observer Pattern =================

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

    // ================= Authentication ==================

    public interface IExternalAuthentication
    {
        void AuthorizeViaGosuslugi();
        void AuthorizeViaMAX();
        void AuthorizeViaVKID();
        void GetUserData();
    }

    public class Gosuslugi
    {
        private string id;
        private string fullName;

        public void Registrate()
        {
            Console.WriteLine("Класс \"Gosuslugi\" вызвал метод \"Registrate()\"");
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"Gosuslugi\" вызвал метод \"GetUserData()\"");
        }
    }

    public class Max
    {
        private string id;
        private string fullName;

        public void Registrate()
        {
            Console.WriteLine("Класс \"Max\" вызвал метод \"Registrate()\"");
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"Max\" вызвал метод \"GetUserData()\"");
        }
    }

    public class VKId
    {
        private string id;
        private string fullName;

        public void Registrate()
        {
            Console.WriteLine("Класс \"VKId\" вызвал метод \"Registrate()\"");
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"VKId\" вызвал метод \"GetUserData()\"");
        }
    }

    /// <summary>
    /// Простая реализация внешней аутентификации, которая внутри вызывает конкретные сервисы.
    /// </summary>
    public class ExternalAuthentication : IExternalAuthentication
    {
        private readonly IDatabase _database;
        private readonly Gosuslugi _gosuslugi = new Gosuslugi();
        private readonly Max _max = new Max();
        private readonly VKId _vkId = new VKId();

        public ExternalAuthentication(IDatabase database)
        {
            _database = database;
        }

        public void AuthorizeViaGosuslugi()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"AuthorizeViaGosuslugi()\"");
            _gosuslugi.Registrate();
            _gosuslugi.GetUserData();
        }

        public void AuthorizeViaMAX()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"AuthorizeViaMAX()\"");
            _max.Registrate();
            _max.GetUserData();
        }

        public void AuthorizeViaVKID()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"AuthorizeViaVKID()\"");
            _vkId.Registrate();
            _vkId.GetUserData();
        }

        public void GetUserData()
        {
            Console.WriteLine("Класс \"ExternalAuthentication\" вызвал метод \"GetUserData()\"");
        }
    }

    // =================== Medical =======================

    public class Visit
    {
        private string id;
        private string patientId;
        private string doctorId;
        private DateTime dateTime;
        private string diagnosis;
        private string symptoms;
        private string treatment;
        private string[] prescriptions;
        private string visitType;

        public void AddDiagnosis(string diagnosis)
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"AddDiagnosis()\"");
        }

        public void AddPrescription(string prescription)
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"AddPrescription()\"");
        }

        public void CompleteVisit()
        {
            Console.WriteLine("Класс \"Visit\" вызвал метод \"CompleteVisit()\"");
        }

        public string GetId()
        {
            return id;
        }
    }

    public class MedicalRecords
    {
        private IDatabase database;
        private List<Patient> patients = new List<Patient>();
        private List<Visit> visits = new List<Visit>();

        public MedicalRecords(IDatabase db)
        {
            database = db;
        }

        public void CreateRecord()
        {
            Console.WriteLine("Класс \"MedicalRecords\" вызвал метод \"CreateRecord()\"");
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

    // Заглушечные типы для репозитория (в диаграмме MedicalRecord/MedicalRecordRepository)
    public class MedicalRecord { }

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

    // ================= User Management =================

    public class Patient : IObserver
    {
        private string id;
        private string fullName;
        private DateTime dateOfBirth;
        private string insurancePolicy;
        private string passport;

        public Patient(string id, string fullName)
        {
            this.id = id;
            this.fullName = fullName;
        }

        public string GetId() => id;

        public void EnterMedicalData()
        {
            Console.WriteLine("Класс \"Patient\" вызвал метод \"EnterMedicalData()\"");
        }

        public void ScheduleAppointment()
        {
            Console.WriteLine("Класс \"Patient\" вызвал метод \"ScheduleAppointment()\"");
        }

        public void Update(string message)
        {
            Console.WriteLine($"Класс \"Patient\" получил уведомление через метод \"Update()\": {message}");
        }
    }

    public class Doctor : IObserver
    {
        private string id;
        private string fullName;
        private string specialization;
        private Schedule schedule;

        public Doctor(string id, string fullName, string specialization, Schedule schedule)
        {
            this.id = id;
            this.fullName = fullName;
            this.specialization = specialization;
            this.schedule = schedule;
        }

        public string GetId() => id;
        public string GetSpecialization() => specialization;

        public void ConductAppointment()
        {
            Console.WriteLine("Класс \"Doctor\" вызвал метод \"ConductAppointment()\"");
        }

        public void UpdateSchedule()
        {
            Console.WriteLine("Класс \"Doctor\" вызвал метод \"UpdateSchedule()\"");
        }

        public void Update(string message)
        {
            Console.WriteLine($"Класс \"Doctor\" получил уведомление через метод \"Update()\": {message}");
        }
    }

    public class Schedule
    {
        private IDatabase database;

        public Schedule(IDatabase db)
        {
            database = db;
        }

        public void AddAppointment()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"AddAppointment()\"");
        }

        public void CheckAvailability()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"CheckAvailability()\"");
            database.ExecuteQuery("SELECT ... FROM schedule WHERE ...", Array.Empty<object>());
        }

        public void UpdateDoctorSchedule()
        {
            Console.WriteLine("Класс \"Schedule\" вызвал метод \"UpdateDoctorSchedule()\"");
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

        public Visit CreateVisitForAppointment(Patient patient, Doctor doctor, DateTime dateTime)
        {
            Console.WriteLine("Класс \"Schedule\" создает объект \"Visit\" для записи на прием");
            return new Visit();
        }
    }

    // =================== UI ============================

    public class UI : IObserver
    {
        private HospitalController controller;

        public UI(HospitalController controller)
        {
            this.controller = controller;
        }

        public void DisplayHomeScreen()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayHomeScreen()\"");
        }

        public void DisplayRegistrationScreen()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayRegistrationScreen()\"");
        }

        public void DisplayLoginScreen()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayLoginScreen()\"");
        }

        public void DisplayPersonalAccount()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayPersonalAccount()\"");
        }

        public void HandleButtonClick(string action)
        {
            Console.WriteLine($"Класс \"UI\" вызвал метод \"HandleButtonClick()\" с действием \"{action}\"");

            // Здесь просто маршрутизируем к нужным методам контроллера,
            // чтобы показать связи для юзкейсов.
            switch (action)
            {
                case "registerPatient":
                    controller.RegisterPatient();
                    break;
                case "updateMedicalData":
                    controller.UpdateMedicalData();
                    break;
                case "requestCertificate":
                    controller.RequestCertificate();
                    break;
                case "generateReferral":
                    controller.GenerateReferral();
                    break;
                case "scheduleAppointment":
                    controller.ScheduleAppointmentUseCase();
                    break;
                case "startAppointment":
                    controller.StartAppointment();
                    break;
                case "completeAppointment":
                    controller.CompleteAppointment();
                    break;
                case "cancel":
                    controller.NotifyObservers("Операция отменена");
                    break;
                default:
                    Console.WriteLine("Неизвестное действие UI");
                    break;
            }
        }

        public void Update(string message)
        {
            Console.WriteLine($"Класс \"UI\" получил уведомление через метод \"Update()\": {message}");
        }
    }

    // ================= HospitalController ==============

    public class HospitalController : IObservable
    {
        private readonly IDatabase database;
        private readonly MedicalRecords medicalRecords;
        private readonly Schedule schedule;
        private readonly List<IObserver> observers = new List<IObserver>();
        private readonly IExternalAuthentication externalAuth;
        private readonly Patient demoPatient;
        private readonly Doctor demoDoctor;
        private Visit currentVisit;

        public HospitalController(IDatabase db)
        {
            database = db;
            medicalRecords = new MedicalRecords(db);
            schedule = new Schedule(db);
            externalAuth = new ExternalAuthentication(db);

            // Примитивные объекты для демонстрации
            demoPatient = new Patient("p1", "Иванов Иван");
            demoDoctor = new Doctor("d1", "Петров Петр", "Терапевт", schedule);
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
            database.ExecuteQuery("INSERT INTO medical_records ...", Array.Empty<object>());
        }

        public void UpdateMedicalData()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"UpdateMedicalData()\"");
            medicalRecords.UpdateData();
            database.ExecuteQuery("UPDATE medical_records ...", Array.Empty<object>());
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
            database.BeginTransaction();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"MedicalRecords.AddVisit()\"");
            var visit = new Visit();
            medicalRecords.AddVisit(visit);

            Console.WriteLine("Класс \"HospitalController\" вызывает \"NotifyObservers()\" для Patient и UI");
            NotifyObservers("Справка выдана");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"IDatabase.Commit()\"");
            database.Commit();
        }

        public void GenerateReferral()
        {
            Console.WriteLine("Класс \"HospitalController\" вызвал метод \"GenerateReferral()\"");
            Console.WriteLine("Класс \"HospitalController\" вызывает \"Schedule.CheckAvailability()\" и \"Schedule.GetFreeSlots()\"");
            schedule.CheckAvailability();
            schedule.GetFreeSlots();

            Console.WriteLine("Класс \"HospitalController\" создает объект \"Visit\" с типом \"referral\" через Schedule.CreateVisitForAppointment()");
            var visit = schedule.CreateVisitForAppointment(demoPatient, demoDoctor, DateTime.Now);
            visit.CompleteVisit();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"NotifyObservers()\" для Patient, Doctor и UI");
            NotifyObservers("Направление выдано");

            Console.WriteLine("Класс \"HospitalController\" вызывает \"MedicalRecords.AddVisit()\" и \"IDatabase.ExecuteQuery()\"");
            medicalRecords.AddVisit(visit);
            database.ExecuteQuery("INSERT INTO visits ...", Array.Empty<object>());
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
            medicalRecords.GetPatientVisits(demoPatient.GetId());

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
            currentVisit.CompleteVisit();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"MedicalRecords.AddVisit()\"");
            medicalRecords.AddVisit(currentVisit);

            Console.WriteLine("Класс \"HospitalController\" вызывает \"Schedule.UpdateDoctorSchedule()\"");
            schedule.UpdateDoctorSchedule();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"IDatabase.Commit()\"");
            database.Commit();

            Console.WriteLine("Класс \"HospitalController\" вызывает \"NotifyObservers()\" для пациента");
            NotifyObservers("Прием завершен");
        }

        // ===== Специальный метод для демонстрации Use Case "Запись на прием" =====
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
            var visit = schedule.CreateVisitForAppointment(demoPatient, demoDoctor, DateTime.Now);
            database.ExecuteQuery("INSERT INTO visits ...", Array.Empty<object>());

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

    // =================== Program (меню) =================

    internal class Program
    {
        private static void Main(string[] args)
        {
            IDatabase db = new PostgreSQLDatabase();
            db.Connect();

            var controller = new HospitalController(db);
            var ui = new UI(controller);

            // Подписываем наблюдателей
            controller.AddObserver(ui);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите Use Case для демонстрации:");
                Console.WriteLine("1 - Проведение приема пациента врачом");
                Console.WriteLine("2 - Регистрация пациента и создание медкарты");
                Console.WriteLine("3 - Запись на прием к врачу");
                Console.WriteLine("4 - Выдача справок и направлений");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Проведение приема пациента
                        ui.HandleButtonClick("startAppointment");
                        ui.HandleButtonClick("updateMedicalData");
                        ui.HandleButtonClick("completeAppointment");
                        break;

                    case "2":
                        // Регистрация пациента и создание медкарты
                        ui.HandleButtonClick("registerPatient");
                        ui.HandleButtonClick("updateMedicalData");
                        break;

                    case "3":
                        // Запись на прием
                        ui.HandleButtonClick("scheduleAppointment");
                        break;

                    case "4":
                        // Выдача справок и направлений
                        Console.WriteLine("1 - Выдача справки");
                        Console.WriteLine("2 - Выдача направления");
                        var sub = Console.ReadLine();
                        if (sub == "1")
                        {
                            ui.HandleButtonClick("updateMedicalData");
                            ui.HandleButtonClick("requestCertificate");
                        }
                        else if (sub == "2")
                        {
                            ui.HandleButtonClick("updateMedicalData");
                            ui.HandleButtonClick("generateReferral");
                        }
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }

            db.Close();
        }
    }
}
