@startuml
title Запись на прием к врачу
actor "Пациент" as Patient
participant "UI" as UI
participant "HospitalController" as HC
participant "Schedule" as S
participant "Doctor" as D
participant "Visit" as V
participant "IDatabase" as DB
activate Patient
Patient -> UI: Входит в приложение и выбирает "Записаться"
activate UI
UI --> Patient: Отображает экран выбора врача
Patient -> UI: Выбирает специализацию/врача
UI -> HC: scheduleAppointment(выбор)
activate HC
HC -> S: getFreeSlots(doctorId)
activate S
S -> DB: executeQuery(SELECT free slots)
activate DB
DB --> S: Список слотов
deactivate DB
S --> HC: Свободные слоты
deactivate S
HC --> UI: Данные слотов
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
S -> V: new Visit(patientId, doctorId, dateTime)
activate V
V --> S: Объект визита
deactivate V
S -> DB: executeQuery(INSERT visit)
activate DB
DB --> S: ID визита
deactivate DB
S -> DB: commit()
activate DB
DB --> S: Транзакция подтверждена
deactivate DB
S --> HC: Запись подтверждена
deactivate S
HC -> HC: notifyObservers("Запись создана")
HC --> UI: Успех
deactivate HC
UI --> Patient: Подтверждение записи
deactivate UI
deactivate Patient
@enduml