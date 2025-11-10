@startuml
title Регистрация пациента и создание медицинской карты

actor "Пациент" as Patient
participant "UI" as UI
participant "HospitalController" as HC
participant "ExternalAuthentication" as EA
participant "MedicalRecords" as MR
participant "Patient" as P
participant "IDatabase" as DB

activate Patient
Patient -> UI: Запускает приложение
activate UI
UI --> Patient: Отображает начальный экран

Patient -> UI: Нажимает "Зарегистрироваться"
UI -> HC: registerPatient()
activate HC

HC -> EA: authorizeViaGosuslugi()
activate EA
EA --> HC: Перенаправление на Госуслуги
HC --> UI: Перенаправление
UI --> Patient: Переход к Госуслугам

Patient -> EA: Проходит аутентификацию
activate EA
EA -> EA: Ввод логина/пароля
EA --> Patient: Подтверждение прав
EA -> EA: getUserData()
EA --> HC: Токен + данные пользователя
deactivate EA

HC -> P: new Patient(данные)
activate P
P --> HC: Объект пациента
deactivate P

HC -> MR: createMedicalRecord()
activate MR
MR -> MR: createRecord()
MR -> MR: linkToPatient(patient)
MR -> DB: executeQuery(INSERT)
activate DB
DB --> MR: ID записи
deactivate DB
MR --> HC: Медицинская карта создана
deactivate MR

HC -> DB: commit()
activate DB
DB --> HC: Транзакция подтверждена
deactivate DB

HC --> UI: Успешная регистрация
deactivate HC

UI --> Patient: Перенаправление в личный кабинет
UI --> Patient: Запрос медицинских данных

Patient -> UI: Вводит медицинские данные
UI -> HC: updateMedicalData(данные)
activate HC
HC -> MR: updateData()
activate MR
MR -> DB: executeQuery(UPDATE)
activate DB
DB --> MR: Данные обновлены
deactivate DB
MR --> HC: Медицинские данные сохранены
deactivate MR
HC --> UI: Данные обновлены
deactivate HC

UI --> Patient: Уведомление об успехе
deactivate UI
deactivate Patient

@enduml
