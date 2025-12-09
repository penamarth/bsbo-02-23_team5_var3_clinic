@startuml

package "ExternalAuthentication <<Aggregate>>" {
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
    
    ExternalAuthentication --> Gosuslugi
    ExternalAuthentication --> Max
    ExternalAuthentication --> VKId
}

package "Doctor <<Aggregate>>" {
    class Doctor {
        -id: String
        -fullName: String
        -specialization: String
        -licenseNumber: String
        -contactInfo: String
        +conductAppointment(appointment: Appointment)
        +updateSchedule()
        +update(message: String)
        +getSchedule(startDate: Date, endDate: Date): List<Appointment>
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
    
    Doctor --> IDoctorRepository
}

package "MedicalRecords <<Aggregate>>" {
    class Patient {
        -id: String
        -fullName: String
        -dateOfBirth: Date
        -insurancePolicy: String
        -passport: String
        -contactInfo: String
        +enterMedicalData(data: Map<String, Object>): boolean
        +update(message: String)
        +getMedicalHistory(): List<Visit>
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
    
    class MedicalRecords {
        -patientRepository: IPatientRepository
        -medicalRecordRepository: IMedicalRecordRepository
        +createRecord(patient: Patient): boolean
        +addPatient(map): boolen
        +updateData(patientId: int, data: Map<String, Object>): boolean
        +getHistory(patientId: int): List<Visit>
        +addVisit(visit: Visit, patientid: int): boolean
        +getPatient(patientId: int)
        +getPatientVisits(patientId: int): List<Visit>
        +getVisitById(visitId: int): Visit
    }
    
    interface IMedicalRecordRepository {
        +findByPatientId(patientId: String): MedicalRecord
        +findByDoctorId(doctorId: String): List<MedicalRecord>
        +save(record: MedicalRecord): boolean
        +update(record: MedicalRecord): boolean
        +delete(recordId: String): boolean
        +findByDateRange(startDate: Date, endDate: Date): List<MedicalRecord>
    }
    
    class MedicalRecord {
        -id: int
        -patientId: int
        -data: List<Visit>
        -createdAt: DateTime
        -lastchange: DateTime
    }
    
    MedicalRecords --> Patient
    MedicalRecords --> IPatientRepository
    MedicalRecords --> IMedicalRecordRepository
    IMedicalRecordRepository --> MedicalRecord
    Patient --> IPatientRepository
}

package "Appointment <<Aggregate>>" {
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
        +complete(): Visit
        +getStatus(): AppointmentStatus
        +setStatus(status: AppointmentStatus): boolean
    }

    interface IAppointmentRepository {
        +findById(id: String): Appointment
        +findByPatientId(patientId: String): List<Appointment>
        +findByDoctorId(doctorId: String): List<Appointment>
        +findByStatus(status: AppointmentStatus): List<Appointment>
        +save(appointment: Appointment): boolean
        +update(appointment: Appointment): boolean
        +delete(id: String): boolean
        +existsById(id: String): boolean
    }
    
    class AppointmentRepository implements IAppointmentRepository {
        +findById(id: String): Appointment
        +findByPatientId(patientId: String): List<Appointment>
        +findByDoctorId(doctorId: String): List<Appointment>
        +findByDoctorIdPatientId(doctorId: int, patientId: int): List<Appointment>
        +findByStatus(status: AppointmentStatus): List<Appointment>
        +save(appointment: Appointment): boolean
        +update(appointment: Appointment): boolean
        +delete(id: String): boolean
        +existsById(id: String): boolean
    }
    
    Appointment --> IAppointmentRepository
}

package "Visit <<Aggregate>>" {
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
        +saveVisit(): boolean
        +getDiagnosis(): String
        +getPrescriptions(): List<String>
    }
}

package "Schedule <<Aggregate>>" {
    class Schedule {
        -doctorRepository: IDoctorRepository
        +addAppointment(patientId: String, doctorId: String, dateTime: DateTime): Appointment
        +checkAvailability(doctorId: String, dateTime: DateTime): boolean
        +getFreeSlots(doctorId: String, date: Date): List<DateTime>
        +showSchedule(doctorId: String): List<Appointment>
        +selectDoctor(specialization: String): List<Doctor>
        +confirmAppointment(appointmentId: String): boolean
        +cancelAppointment(appointmentId: String, reason: String): boolean
        +completeAppointment(appointmentId: String): Visit
        +getAppointmentById(appointmentId: String): Appointment
        +getDoctorAppointments(doctorId: String): List<Appointment>
        +getPatientAppointments(patientId: String): List<Appointment>
    }
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
    +authenticateUser()
    +registrateUser()
    +createMedicalRecord()
    +updateMedicalData()
    +scheduleAppointment(patientId: String, doctorId: String, dateTime: DateTime): Appointment
    +requestCertificate()
    +generateReferral()
    +showHistory(patientId: String): List<Visit>
    +startAppointment(appointmentId: String): boolean
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

MedicalRecords o-- Visit
MedicalRecords --> Appointment

Doctor --> Schedule
Schedule o-- Appointment
Doctor --> Appointment
Appointment --> Visit

@enduml
