@startuml
title Регистрация пациента и создание медицинской карты

actor "Пациент" as Patient
participant "UI" as UI
participant "HospitalController" as HC
participant "IExternalAuthentication" as IEA
participant "Gosuslugi" as GS
participant "MedicalRecords" as MR
participant "Patient" as P
participant "IMedicalRecordRepository" as IMRRepo

|||
activate Patient
Patient -> UI: 1. Запускает приложение
activate UI
UI --> Patient: 2. Показывает начальный экран\n(кнопки Войти/Зарегистрироваться)

Patient -> UI: 3. Нажимает "Зарегистрироваться"
UI -> HC: 4. showRegistrationOptions()
activate HC
HC --> UI: Способы регистрации
UI --> Patient: 4. Предлагает выбрать способ\n(Госуслуги, MAX, ВК, Обычная)

Patient -> UI: 5. Выбирает "Госуслуги"
UI -> HC: registerViaGosuslugi()
HC -> HC: beginTransaction()
HC -> IEA: authorizeViaGosuslugi()
activate IEA
IEA -> GS: redirectToAuth()
activate GS
GS --> IEA: Перенаправление
IEA --> HC: Требуется аутентификация
HC --> UI: Перенаправление на сервис
UI --> Patient: 8. Переход к Госуслугам

Patient -> GS: 9. Проходит аутентификацию
GS -> GS: Ввод логина/пароля
GS --> Patient: Подтверждение прав
GS -> IEA: getUserData()
IEA --> HC: 10. Токен + данные пользователя
deactivate GS
deactivate IEA

HC -> MR: 13. createMedicalRecord()
activate MR
MR -> MR: 13. createRecord()
MR -> IMRRepo: save(medicalRecord)
activate IMRRepo
IMRRepo --> MR: Подтверждение
deactivate IMRRepo
MR --> HC: 16. Медицинская карта создана
deactivate MR

HC -> P: 12. new Patient(данные)
activate P
P --> HC: Объект пациента
HC -> P: attach() \n// Patient как IObserver
P --> HC: Подтверждение
deactivate P

HC -> MR: 14. linkPatientToMedicalRecord(patient)
activate MR
MR -> IMRRepo: updateMedicalRecordWithPatient()
activate IMRRepo
IMRRepo --> MR: Подтверждение
deactivate IMRRepo
MR --> HC: 16. Пациент привязан к карте
deactivate MR

HC -> HC: notifyObservers()\n// Patient уведомлен
HC --> UI: 17. Успешная регистрация
deactivate HC

UI --> Patient: 18. Уведомление о завершении\n19. Перенаправление в ЛК\n20. Запрос мед. данных

deactivate UI
deactivate Patient
@enduml
