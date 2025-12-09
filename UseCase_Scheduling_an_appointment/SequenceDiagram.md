@startuml
title Запись на прием к врачу
actor "Пациент" as Patient
participant "UI" as UI
participant "HospitalController" as HC
participant "Schedule" as S
participant "Doctor" as D
participant "IDoctorRepository" as IDR
participant "Appointment" as A
participant "IAppointmentRepository" as IAR
activate Patient
Patient -> UI: Входит в приложение и выбирает "Записаться"
activate UI
UI -> HC: getDoctorsAndSpecializations()
activate HC
HC -> D: getAllSpecialists()
activate D
D -> IDR: findAll()
activate IDR
D -> IDR: findAllSpecializations()
IDR --> D: Список врачей
IDR --> D: Список специализаций
deactivate IDR
D --> HC: Список докторов и специализаций
deactivate D
HC --> UI: Врачи и специализации
deactivate HC
UI --> Patient: Отображает экран выбора врача/специализации
Patient -> UI: Выбирает специализацию/врача
UI -> HC: scheduleAppointment(выбор)
activate HC
HC -> S: getFreeSlots(doctorId)
activate S
S -> A: getFreeSlots(doctorId)
activate A
A -> IAR: getFreeSlots(doctorId)
activate IAR
IAR --> A: Свободные слоты
deactivate IAR
A --> S: Свободные слоты
deactivate A
S --> HC: Свободные слоты
deactivate S
HC -> S: getPatientAppointments(patientId)
activate S
S -> A: getPatientAppointments(patientId)
activate A
A -> IAR: getPatientAppointments(patientId)
activate IAR
IAR --> A: Записи пациента
deactivate IAR
A --> S: Записи пациента
deactivate A
S --> HC: Записи пациента
deactivate S
HC --> UI: Данные слотов
deactivate HC
UI --> Patient: Отображает слоты
Patient -> UI: Выбирает слот
UI -> HC: confirmAppointment(слот)
activate HC
HC -> S: confirmAppointment()
activate S
S -> D: updateSchedule(занять слот)
activate D
D --> S: Расписание обновлено
deactivate D
S --> HC: Запись подтверждена
deactivate S
HC -> HC: notifyObservers("Запись создана")
HC --> UI: Успех
deactivate HC
UI --> Patient: Подтверждение записи
deactivate UI
deactivate Patient
@enduml