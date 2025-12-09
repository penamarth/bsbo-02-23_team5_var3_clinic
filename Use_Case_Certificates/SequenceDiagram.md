@startuml
title Диаграмма последовательностей для выдачи справок и направлений

actor Врач as "Врач (Пользователь)"
participant UI
participant HospitalController
participant ExternalAuthentication
participant MedicalRecords
participant Schedule
participant Doctor
participant Patient
participant Appointment
participant Visit
participant IMedicalRecordRepository as MedRepo
participant IPatientRepository as PatRepo
participant IAppointmentRepository as AppRepo
participant IDoctorRepository as DocRepo

note over HospitalController: Предполагаем выполнение предусловий: Врач аутентифицирован, Пациент в системе и т.д.

== Основной сценарий: Выдача справок ==

group Выдача справок
Врач -> UI: Запустить приложение и перейти в раздел приема
UI -> HospitalController: authenticateUser()
HospitalController -> ExternalAuthentication: authorizeViaGosuslugi() или аналогичный
ExternalAuthentication --> HospitalController: getUserData()
HospitalController --> UI: Отобразить успешный вход

UI -> HospitalController: showHistory(patientId)
HospitalController -> MedicalRecords: getHistory(patientId)
MedicalRecords -> MedRepo: findByPatientId(patientId)
MedRepo --> MedicalRecords: MedicalRecord
MedicalRecords -> MedicalRecords: getPatientVisits(patientId)
MedicalRecords --> HospitalController: List<Visit>
HospitalController --> UI: Отобразить данные пациента

Врач -> UI: Ввести новые детали
UI -> HospitalController: updateMedicalData()
HospitalController -> MedicalRecords: updateData(patientId, data)
MedicalRecords -> MedRepo: update(record)
MedRepo --> MedicalRecords: boolean
MedicalRecords --> HospitalController: boolean
HospitalController --> UI: Подтверждение

alt Данные некорректны (A1)
HospitalController -> MedicalRecords: Проверка согласованности данных (через update)
MedicalRecords --> HospitalController: False (несоответствия)
HospitalController --> UI: Показать алерт об ошибке
Врач -> UI: Повторно ввести исправленные данные
UI -> HospitalController: updateMedicalData() снова
else Нормально
end

Врач -> UI: Выбрать "Выдать справку"
UI -> HospitalController: requestCertificate()
alt Не авторизован (A2)
HospitalController -> ExternalAuthentication: Проверка статуса
ExternalAuthentication --> HospitalController: Истекло
HospitalController --> UI: Переключить на экран входа
Врач -> UI: Ввести учетные данные
UI -> HospitalController: authenticateUser()
HospitalController -> ExternalAuthentication: authorize
ExternalAuthentication --> HospitalController: OK
else Авторизован
end
HospitalController -> MedicalRecords: Анализ истории для типов справок
MedicalRecords -> MedRepo: findByPatientId и фильтр
MedRepo --> MedicalRecords: Записи
MedicalRecords --> HospitalController: Список типов справок
HospitalController --> UI: Отобразить типы

Врач -> UI: Выбрать тип и запросить детали
UI -> HospitalController: Получить детали
HospitalController -> MedicalRecords: getVisitById(visitId)
MedicalRecords -> MedRepo: findById или аналогичный
MedRepo --> MedicalRecords: Visit
MedicalRecords --> HospitalController: Детали визита
HospitalController --> UI: Отобразить детали

Врач -> UI: Редактировать и подтвердить
alt Отмена (A3)
Врач -> UI: Отменить
UI -> HospitalController: cancel (например, через notify)
HospitalController -> HospitalController: notifyObservers("отменено")
HospitalController --> UI: Вернуться к основному виду
else Продолжить
UI -> HospitalController: Сгенерировать справку (часть requestCertificate)
HospitalController -> MedicalRecords: addVisit(visit, patientId) // Предполагая справку как часть визита
MedicalRecords -> Visit: addDiagnosis и т.д. для справки
Visit -> Visit: updateTreatment или notes для справки
Visit -> MedicalRecords: saveVisit()
MedicalRecords -> MedRepo: save(record)
MedRepo --> MedicalRecords: boolean
MedicalRecords --> HospitalController: boolean
end

HospitalController -> HospitalController: notifyObservers("справка выдана")
HospitalController --> UI: Показать подтверждение
note over Patient: Пациент обновлен через observer
Patient -> Patient: update(сообщение)
end

== Основной сценарий: Выдача направлений ==

group Выдача направлений
Врач -> UI: Выбрать прием
UI -> HospitalController: scheduleAppointment() или startAppointment
HospitalController -> Schedule: selectDoctor(specialization)
Schedule -> DocRepo: findBySpecialization(specialization)
DocRepo --> Schedule: List<Doctor>
Schedule --> HospitalController: List<Doctor>
HospitalController --> UI: Отобразить специальности/докторов

Врач -> UI: Ввести новые данные
UI -> HospitalController: updateMedicalData()
... аналогично выше, с альтернативами для A1, A2 ...

Врач -> UI: Выбрать "Выдать направление"
UI -> HospitalController: generateReferral()
alt Не авторизован (A2)
... аналогично ...
else
end
HospitalController -> Schedule: showSchedule(doctorId)
Schedule -> AppRepo: findByDoctorId(doctorId)
AppRepo --> Schedule: List<Appointment>
Schedule --> HospitalController: Расписание
HospitalController --> UI: Отобразить слоты

Врач -> UI: Выбрать и добавить причину
UI -> HospitalController: scheduleAppointment(patientId, doctorId, dateTime)
HospitalController -> Schedule: addAppointment(patientId, doctorId, dateTime)
Schedule -> Schedule: checkAvailability(doctorId, dateTime)
Schedule -> AppRepo: findByDoctorId и проверить
AppRepo --> Schedule: boolean
alt Нет слотов (A4)
Schedule --> HospitalController: Нет слотов, альтернативы
HospitalController --> UI: Показать предупреждение
HospitalController -> HospitalController: Откат
UI -> HospitalController: Вернуться к выбору
HospitalController -> Schedule: selectDoctor снова
else Слоты доступны
Schedule -> Appointment: create()
Appointment -> Appointment: setStatus
Appointment -> AppRepo: save(appointment)
AppRepo --> Appointment: boolean
Appointment --> Schedule: Appointment
Schedule --> HospitalController: Appointment
end

HospitalController -> Doctor: updateSchedule() // Если нужно
Doctor -> Schedule: getDoctorAppointments(doctorId)
Schedule --> Doctor: List<Appointment>
Doctor --> HospitalController: Обновлено

HospitalController -> MedicalRecords: addVisit или update для заметки направления
MedicalRecords -> MedRepo: update
MedRepo --> MedicalRecords: boolean
MedicalRecords --> HospitalController: boolean

HospitalController -> HospitalController: notifyObservers("направление выдано")
HospitalController --> UI: Подтверждение
note over Patient, Doctor: Обновлено через observers
end

== Постусловия ==
note over MedicalRecords: Карта обновлена
note over Schedule: Расписание обновлено
note over HospitalController: Уведомления отправлены через observers
note over UI: При ошибках - откат

@enduml
