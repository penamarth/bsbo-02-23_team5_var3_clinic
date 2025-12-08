@startuml

class ExternalAuthentication {
    +authorizeViaGosuslugi()
    +authorizeViaMAX()
    +authorizeViaVKID()
    +getUserData()
}
    
interface Gosuslugi {
    -id: String
    -fullName: String
    +registrate()
    +getUserData()
}
    
interface Max {
    -id: String
    -fullName: String
    +registrate()
    +getUserData()
}
    
interface VKId {
    -id: String
    -fullName: String
    +registrate()
    +getUserData()
}


interface IDoctorRepository {
    +findById(id: String): Doctor
    +findAll(): List<Doctor>
    +findBySpecialization(specialization: String): List<Doctor>
    +save(doctor: Doctor): boolean
    +update(doctor: Doctor): boolean
    +delete(id: String): boolean
    +existsById(id: String): boolean
}
    
class DoctorRepository implements IDoctorRepository {
    +findById(id: String): Doctor
    +findAll(): List<Doctor>
    +findBySpecialization(specialization: String): List<Doctor>
    +save(doctor: Doctor): boolean
    +update(doctor: Doctor): boolean
    +delete(id: String): boolean
    +existsById(id: String): boolean
}
    
interface IPatientRepository {
    +findById(id: String): Patient
    +findAll(): List<Patient>
    +save(patient: Patient): boolean
    +update(patient: Patient): boolean
    +delete(id: String): boolean
    +existsById(id: String): boolean
    +findByInsurancePolicy(policyNumber: String): Patient
}
   
class PatientRepository implements IPatientRepository {
    +findById(id: String): Patient
    +findAll(): List<Patient>
    +save(patient: Patient): boolean
    +update(patient: Patient): boolean
    +delete(id: String): boolean
    +existsById(id: String): boolean
    +findByInsurancePolicy(policyNumber: String): Patient
}
   
interface IMedicalRecordRepository {
    +findByPatientId(patientId: String): MedicalRecord
    +findByDoctorId(doctorId: String): List<MedicalRecord>
    +save(record: MedicalRecord): boolean
    +update(record: MedicalRecord): boolean
    +delete(recordId: String): boolean
    +findByDateRange(startDate: Date, endDate: Date): List<MedicalRecord>
}
  
class Doctor {
    -id: String
    -fullName: String
    -specialization: String
    -licenseNumber: String
    -contactInfo: String
    +conductAppointment(appointment: Appointment)  /'Вызывает Appointment, Visit формируется в нём, и потом в медикал рекордс'/
    +updateSchedule()
    +update(message: String)   /'Для обсервера'/
    +getSchedule(startDate: Date, endDate: Date): List<Appointment> /'Вызывает Schedule - метод getDoctorAppointments'/
}
    
class Appointment {
    -id: String
    -patientId: String
    -doctorId: String
    -dateTime: DateTime
    -status: AppointmentStatus
    -appointmentType: String
    -notes: String
    +create(): boolean
    +confirm(): boolean
    +cancel(reason: String): boolean
    +reschedule(newDateTime: DateTime): boolean
    +start(): boolean
    +complete(): Visit   /'Создаётся объект Visit, который должен передаваться в MedicalRecords'/
    +getStatus(): AppointmentStatus
    +setStatus(status: AppointmentStatus): boolean
}

interface IAppointmentRepository 
{
    +findById(id: String): Appointment
    +findByPatientId(patientId: String): List<Appointment>
    +findByDoctorId(doctorId: String): List<Appointment>
    +findByStatus(status: AppointmentStatus): List<Appointment>
    +save(appointment: Appointment): boolean
    +update(appointment: Appointment): boolean
    +delete(id: String): boolean
    +existsById(id: String): boolean
}
    
class AppointmentRepository implements IAppointmentRepository 
{
    +findById(id: String): Appointment
    +findByPatientId(patientId: String): List<Appointment>
    +findByDoctorId(doctorId: String): List<Appointment>
    +findByStatus(status: AppointmentStatus): List<Appointment>
    +save(appointment: Appointment): boolean
    +update(appointment: Appointment): boolean
    +delete(id: String): boolean
    +existsById(id: String): boolean
}
class Schedule {
    -doctorRepository: IDoctorRepository
    +addAppointment(patientId: String, doctorId: String, dateTime: DateTime): Appointment   /' Вызывает Appointment'/
    +checkAvailability(doctorId: String, dateTime: DateTime): boolean      
    +getFreeSlots(doctorId: String, date: Date): List<DateTime> /'Вызывает Appointment -> AppointmentRepository '/
    +showSchedule(doctorId: String): List<Appointment>  /'ВызываетСЯ Hospitalcontroller '/
    +selectDoctor(specialization: String): List<Doctor>
    +confirmAppointment(appointmentId: String): boolean
    +cancelAppointment(appointmentId: String, reason: String): boolean
    +completeAppointment(appointmentId: String): Visit
    +getAppointmentById(appointmentId: String): Appointment
    +getDoctorAppointments(doctorId: String): List<Appointment>
    +getPatientAppointments(patientId: String): List<Appointment>
}
    
class Patient {
    -id: String
    -fullName: String
    -dateOfBirth: Date
    -insurancePolicy: String
    -passport: String
    -contactInfo: String
    +enterMedicalData(data: Map<String, Object>): boolean  /'Заполняет внутренние поля'/
    +update(message: String)   /'Когда его зовёт обсервер'/
    +getMedicalHistory(): List<Visit>    /'Под вывод функций'/
}


class Visit {
    -id: String
    -appointmentId: String
    -patientId: String
    -doctorId: String
    -dateTime: DateTime
    -diagnosis: String
    -symptoms: String
    -treatment: String
    -prescriptions: List<String>
    +createFromAppointment(appointment: Appointment): Visit
    +addDiagnosis(diagnosis: String): boolean
    +addPrescription(prescription: String): boolean
    +updateSymptoms(symptoms: String): boolean
    +updateTreatment(treatment: String): boolean
    +completeVisit(): boolean /' Вызывает MedicalRecords'/
    +getDiagnosis(): String
    +getPrescriptions(): List<String>
}

class MedicalRecords {
    -patientRepository: IPatientRepository
    -medicalRecordRepository: IMedicalRecordRepository
    +createRecord(patient: Patient): boolean                        /' Вызывает Patient получает данные с пациента и записывает в IMedicalRecordRepository'/
    +addPatient(map ): boolen
    +updateData(patientId: int, data: Map<String, Object>): boolean /' Вызывает IMedicalRecordRepository'/
    +getHistory(patientId: int): List<Visit>                        /' Вызывает IMedicalRecordRepository'/
    +addVisit(visit: Visit, patientid: int): boolean                /' Вызывает IMedicalRecordRepository, и дописывает туда информацию с Visit'/ 
    +getPatient(patientId: int)                                     /' Вызывает Patient'/
    +getPatientVisits(patientId: int): List<Visit>                  /' Вызывает IMedicalRecordRepository'/
    +getVisitById(visitId: int): Visit                              /' Вызывает IMedicalRecordRepository'/
}
    
class MedicalRecord {
    -id: int
    -patientId: int
    -data: List<Visit>   /'Медкарты как набор совершённых Visit'/
    -createdAt: DateTime
    -lastchange: DateTime
}


interface IObserver {
    +update(message: String)
}

interface IObservable {
    +addObserver(observer: IObserver)
    +removeObserver(observer: IObserver)
    +notifyObservers(message: String)
}

class UI {
    +displayHomeScreen()
    +displayRegistrationScreen()
    +displayLoginScreen()
    +displayPersonalAccount()
    +handleButtonClick()
    +update(message: String)
}

class HospitalController {
    -observers: List<IObserver>
    +authenticateUser() /'Вызывает - ExternalAuthentication '/
    +createMedicalRecord() /'Вызывает - MedicalRecords '/
    +updateMedicalData()  /'Вызывает - MedicalRecords '/
    +scheduleAppointment(patientId: String, doctorId: String, dateTime: DateTime): Appointment /'Вызывает Schedule'/
    +requestCertificate()
    +generateReferral()
    +showHistory(patientId: String): List<Visit> /'Вызывает - MedicalRecords '/
    +startAppointment(appointmentId: String): boolean /'Вызывает - Doctor '/
    +addObserver(observer: IObserver)
    +removeObserver(observer: IObserver)
    +notifyObservers(message: String)
    +scheduleAppointment(doctorId: String, dateTime: DateTime): Appointment
    +cancelAppointment(appointmentId: String, reason: String): boolean
}


UI --> HospitalController

HospitalController --> ExternalAuthentication
HospitalController --> MedicalRecords
HospitalController --> Schedule
HospitalController --> Doctor

HospitalController ..|> IObservable
Patient ..|> IObserver
Doctor ..|> IObserver

ExternalAuthentication --> Max
ExternalAuthentication --> VKId
ExternalAuthentication --> Gosuslugi

MedicalRecords o-- Patient
MedicalRecords o-- Visit
MedicalRecords --> Appointment

Doctor --> Schedule
Schedule o-- Appointment
Doctor --> Appointment
Appointment --> Visit

Doctor --> IDoctorRepository
Patient --> IPatientRepository
MedicalRecords --> IMedicalRecordRepository
IMedicalRecordRepository --> MedicalRecord
Appointment --> IAppointmentRepository
@enduml
