
    actor Пациент
    participant UI
    participant HospitalController
    participant ExternalAuthentication
    participant Gosuslugi
    participant MedicalRecords
    participant MedicalRecord
    participant IMedicalRecordRepository
    participant Patient
    participant IPatientRepository

    Пациент->>UI: 1. Открывает приложение
    UI->>Пациент: 2. Показывает начальный экран (displayHomeScreen)
    Пациент->>UI: 3. Нажимает "Зарегистрироваться" (handleButtonClick)
    UI->>Пациент: 4. Предлагает выбрать способ регистрации (displayRegistrationScreen)
    Пациент->>UI: 5. Выбирает "Госуслуги" (handleButtonClick)
    UI->>HospitalController: 6. Обрабатывает запрос на регистрацию
    HospitalController->>ExternalAuthentication: 7. authorizeViaGosuslugi()
    ExternalAuthentication->>Gosuslugi: 8. registrate()
    Gosuslugi->>Пациент: 8. Переход в сервис
    Пациент->>Gosuslugi: 9. Проходит проверку
    Gosuslugi->>ExternalAuthentication: getUserData()
    ExternalAuthentication->>HospitalController: 10. Получает данные пациента
    HospitalController->>MedicalRecords: 11. createRecord()
    MedicalRecords->>MedicalRecord: 12. Создает медицинскую карту пациента
    MedicalRecords->>IMedicalRecordRepository: 15. save(record: MedicalRecord)
    MedicalRecords->>Patient: 13. Создает профиль пациента (addPatient)
    MedicalRecords->>IPatientRepository: 16. save(patient: Patient)
    MedicalRecords->>HospitalController: Успех
    HospitalController->>UI: 17. Отправляет уведомление (notifyObservers)
    UI->>Пациент: 18. Получает уведомление (update)
    UI->>Пациент: 19. Переводит в раздел "Профиль" (displayPersonalAccount)
    UI->>Пациент: 20. Показывает сообщение и предлагает заполнить мед. данные
    Пациент->>UI: 21. Вводит медицинские данные
    UI->>HospitalController: 22. updateMedicalData()
    HospitalController->>MedicalRecords: 22. updateData(patientId, data)
    MedicalRecords->>Patient: 23. enterMedicalData(data)
    Patient->>MedicalRecord: Сохраняет обновленные данные
    MedicalRecord->>IMedicalRecordRepository: 24. update(record: MedicalRecord)
    MedicalRecords->>HospitalController: Успех
    HospitalController->>Пациент: 25. Процесс регистрации завершен
