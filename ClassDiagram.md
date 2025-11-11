@startuml

class UI {
    +displayHomeScreen()
    +displayRegistrationScreen()
    +displayLoginScreen()
    +displayPersonalAccount()
    +handleButtonClick()
    +update(message: String)
}

class HospitalController {
    -database: IDatabase
    -observers: List<IObserver>
    +authenticateUser()
    +registerPatient()
    +createMedicalRecord()
    +updateMedicalData()
    +scheduleAppointment()
    +requestCertificate()
    +generateReferral()
    +showHistory()
    +startAppointment()
    +completeAppointment()
    +addDiagnosis()
    +validateDoctorCredentials()
    +createDoctorAccount()
    +assignSpecialization()
    +setupWorkSchedule()
    +addObserver(observer: IObserver)
    +removeObserver(observer: IObserver)
    +notifyObservers(message: String)
}

interface IExternalAuthentication {
    -database: IDatabase
    +authorizeViaGosuslugi()
    +authorizeViaMAX()
    +authorizeViaVKID()
    +getUserData()
    
}
class Gosuslugi {
    -id: String
    -fullName: String
    +registrate()
    +getUserData()
}
class Max {
    -id: String
    -fullName: String
    +registrate()
    +getUserData()
}
class VKId {
    -id: String
    -fullName: String
    +registrate()
    +getUserData()
}

class Patient {
    -id: String
    -fullName: String
    -dateOfBirth: Date
    -insurancePolicy: String
    -passport: String
    +enterMedicalData()
    +scheduleAppointment()
    +update(message: String)
}

class Doctor {
    -id: String
    -fullName: String
    -specialization: String
    +conductAppointment()
    +updateSchedule()
    +update(message: String)
}

class Visit {
    -id: String
    -patientId: String
    -doctorId: String
    -dateTime: DateTime
    -diagnosis: String
    -symptoms: String
    -treatment: String
    -prescriptions: String[]
    -visitType: String
    +addDiagnosis(diagnosis: String)
    +addPrescription(prescription: String)
    +completeVisit()
}

interface IDatabase {
    +connect()
    +executeQuery(query: String, params: Array): Result
    +close()
    +beginTransaction()
    +commit()
    +rollback()
}

class MedicalRecords {
    -database: IDatabase
    -patients: Patient[]
    -visits: Visit[]
    +createRecord()
    +updateData()
    +getHistory()
    +linkToPatient()
    +addVisit(visit: Visit)
    +getPatientVisits(patientId: String): Visit[]
    +getVisitById(visitId: String): Visit
}

class Schedule {
    -database: IDatabase
    +addAppointment()
    +checkAvailability()
    +updateDoctorSchedule()
    +getFreeSlots()
    +showSchedule()
    +selectDoctor()
    +confirmAppointment()
    +cancelAppointment()
}

class PostgreSQLDatabase implements IDatabase {
    +connect()
    +executeQuery(query: String, params: Array): Result
    +close()
    +beginTransaction()
    +commit()
    +rollback()
    +backup()
}

class SQLiteDatabase implements IDatabase {
    +connect()
    +executeQuery(query: String, params: Array): Result
    +close()
    +beginTransaction()
    +commit()
    +rollback()
    +compact()
}

interface IObserver {
    +update(message: String)
}

interface IObservable {
    +addObserver(observer: IObserver)
    +removeObserver(observer: IObserver)
    +notifyObservers(message: String)
}

UI --> HospitalController

HospitalController --> IExternalAuthentication
HospitalController --> MedicalRecords
HospitalController --> Schedule
HospitalController --> Patient
HospitalController --> Doctor
HospitalController --> Visit

MedicalRecords o-- Patient 
MedicalRecords o-- Visit 

HospitalController ..|> IObservable
Patient ..|> IObserver
Doctor ..|> IObserver

IExternalAuthentication --> Gosuslugi
IExternalAuthentication --> Max
IExternalAuthentication --> VKId

Schedule --> IDatabase
HospitalController --> IDatabase
IExternalAuthentication --> IDatabase
MedicalRecords --> IDatabase

@enduml
