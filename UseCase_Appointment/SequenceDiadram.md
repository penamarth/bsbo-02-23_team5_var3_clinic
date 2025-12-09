@startuml
actor Врач
participant "UI" as UI
participant "HospitalController" as HC
participant "Schedule" as S
participant "AppointmentRepository" as AR
participant "Appointment" as A
participant "MedicalRecords" as MR
participant "PatientRepository" as PR
participant "Patient" as P
participant "Visit" as V
participant "MedicalRecord" as MRec
participant "IMedicalRecordRepository" as IMR

Врач -> UI: Открывает раздел расписания
UI -> HC: getTodaySchedule(doctorId)
HC -> S: getDoctorAppointments(doctorId)
S -> AR: findByDoctorId(doctorId)
AR --> S: List<Appointment>
S --> HC: List<Appointment>
HC --> UI: List<Appointment>
UI -> Врач: Отображает список приемов

Врач -> UI: Выбирает пациента
UI -> HC: startAppointment(appointmentId)
HC -> S: getAppointmentById(appointmentId)
S -> AR: findById(appointmentId)
AR --> S: Appointment
S --> HC: Appointment
HC -> MR: getPatient(patientId)
MR -> PR: findById(patientId)
PR --> MR: Patient
MR --> HC: Patient
HC -> A: start()
A --> V: createFromAppointment(appointment)
V --> HC: Visit
HC --> UI: Карточка приема с данными пациента

Врач -> UI: Вносит жалобы и показатели
UI -> HC: updateSymptoms(symptoms)
HC -> V: updateSymptoms(symptoms)

Врач -> UI: Нажимает "Добавить диагноз"
UI -> Врач: Запрашивает диагноз
Врач -> UI: Вписывает диагноз
UI -> HC: addDiagnosis(diagnosis)
HC -> V: addDiagnosis(diagnosis)

Врач -> UI: Добавляет назначения
UI -> HC: addPrescription(prescription)
HC -> V: addPrescription(prescription)

Врач -> UI: Нажимает "Завершить прием"
UI -> HC: completeAppointment(appointmentId)
HC -> V: saveVisit()
V --> HC: boolean
HC -> A: complete()
A --> HC: Visit
HC -> MR: addVisit(visit, patientId)
MR -> IMR: save(record)
IMR --> MR: boolean
MR -> P: enterMedicalData(data)
P --> MR: boolean
MR --> HC: boolean
HC -> P: update(message)
@enduml
