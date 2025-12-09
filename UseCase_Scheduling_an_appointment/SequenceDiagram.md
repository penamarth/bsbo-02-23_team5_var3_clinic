@startuml
title Запись на прием к врачу
actor "Пациент" as Patient
participant "UI" as UI
participant "HospitalController" as HC
participant "Schedule" as S
participant "Doctor" as D
activate Patient
Patient -> UI: Входит в приложение и выбирает "Записаться"
activate UI
UI -> HC: getDoctorsAndSpecializations()
activate HC
HC -> D: getAllSpecialists()
activate D
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
S --> HC: Свободные слоты
deactivate S
HC -> S: getPatientAppointments(patientId)
activate S
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