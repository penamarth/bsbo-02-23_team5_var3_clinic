@startuml

class UI {
    +displayHomeScreen()
    +displayRegistrationScreen()
    +displayLoginScreen()
    +displayPersonalAccount()
    +handleButtonClick()
}

class HospitalController {
    -database: IDatabase
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
}

class ExternalAuthentication {
    -database: IDatabase
    +authorizeViaGosuslugi()
    +authorizeViaMAX()
    +authorizeViaVKID()
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
}

class Doctor {
    -id: String
    -fullName: String
    -specialization: String
    +conductAppointment()
    +updateSchedule()
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

UI --> HospitalController

HospitalController --> ExternalAuthentication
HospitalController --> MedicalRecords
HospitalController --> Schedule
HospitalController --> Patient
HospitalController --> Doctor
HospitalController --> Visit

MedicalRecords o-- Patient 
MedicalRecords o-- Visit 


Schedule --> IDatabase
Schedule --> Doctor
Schedule --> Patient

HospitalController --> IDatabase
ExternalAuthentication --> IDatabase
MedicalRecords --> IDatabase

@enduml
