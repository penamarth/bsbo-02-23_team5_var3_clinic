@startuml
title Проведение приема пациента врачом

actor "Врач" as Doctor
participant "UI" as UI
participant "HospitalController" as HC
participant "ScheduleSystem" as Schedule
participant "MedicalRecords" as MR
participant "Visit" as Visit

|||
activate Doctor
Doctor -> UI: 1. Открывает раздел расписания
activate UI
UI -> HC: getTodaySchedule()
activate HC
HC -> Schedule: getTodaysAppointments()
activate Schedule
Schedule --> HC: Список пациентов на сегодня
deactivate Schedule
HC --> UI: Данные расписания
deactivate HC
UI --> Doctor: 2. Показывает список пациентов

Doctor -> UI: 3. Выбирает первого пациента
UI -> HC: startAppointment(patientId)
activate HC
HC -> Schedule: getAppointmentDetails(patientId)
activate Schedule
Schedule --> HC: Информация о приеме
deactivate Schedule

HC -> MR: getPatientMedicalHistory(patientId)
activate MR
MR --> HC: Медицинская история пациента
deactivate MR

HC --> UI: 4. Карточка приема + история
deactivate HC
UI --> Doctor: Открывает карточку приема

Doctor -> UI: 5. Вносит жалобы и показатели
UI -> HC: updateVisitData(complaints, metrics)
activate HC
HC -> Visit: setComplaints(complaints)
activate Visit
Visit -> Visit: setVitalSigns(metrics)
Visit --> HC: Данные обновлены
deactivate Visit
HC --> UI: Автосохранение выполнено
deactivate HC
UI --> Doctor: Данные сохранены

Doctor -> UI: 6. Нажимает «Добавить диагноз»
UI -> HC: openDiagnosisSelection()
activate HC
HC --> UI: Данные справочника
deactivate HC
UI --> Doctor: 7. Открывает окно со справочником

Doctor -> UI: 8. Выбирает диагноз из справочника
UI -> HC: addDiagnosis(diagnosisData)
activate HC
HC -> Visit: setDiagnosis(diagnosisData)
activate Visit
Visit --> HC: Диагноз добавлен
deactivate Visit
HC --> UI: Диагноз сохранен в карточке
deactivate HC
UI --> Doctor: Диагноз добавлен в карточку

Doctor -> UI: 9. Добавляет назначения и рекомендации
UI -> HC: updateTreatmentPlan(treatmentData)
activate HC
HC -> Visit: setTreatmentPlan(treatmentData)
activate Visit
Visit --> HC: План лечения обновлен
deactivate Visit
HC --> UI: Назначения сохранены
deactivate HC
UI --> Doctor: Рекомендации добавлены

Doctor -> UI: 10. Нажимает «Завершить прием»
UI -> HC: completeAppointment()
activate HC

HC -> Visit: validateRequiredFields()
activate Visit
Visit --> HC: 11. Проверка обязательных полей\n(диагноз, назначения)
deactivate Visit

alt Все поля заполнены
  HC -> Visit: markAsCompleted()
  activate Visit
  Visit --> HC: Прием завершен
  deactivate Visit
  
  HC -> MR: updateMedicalRecord(visitData)
  activate MR
  MR --> HC: Медицинская карта обновлена
  deactivate MR
  
  HC -> Schedule: markTimeSlotAsBusy()
  activate Schedule
  Schedule --> HC: Время занято
  deactivate Schedule
  HC --> UI: Прием успешно завершен
  deactivate HC
  UI --> Doctor: 15. Прием завершен
  

deactivate UI
deactivate Doctor
@enduml

