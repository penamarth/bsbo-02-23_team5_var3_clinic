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
    UI->>Пациент: 2. Показывает начальный экран с "Войти" и "Зарегистрироваться"
    Пациент->>UI: 3. Нажимает "Зарегистрироваться"
    UI->>Пациент: 4. Предлагает выбрать способ регистрации
    Пациент->>UI: 5. Выбирает "Госуслуги"
    UI->>HospitalController: 6. Обрабатывает запрос на регистрацию
    HospitalController->>ExternalAuthentication: 7. Начинает регистрацию через сервис
    ExternalAuthentication->>Gosuslugi: 8. Переходит в сервис Госуслуг
    Gosuslugi->>Пациент: 8. Переходит в сервис Госуслуг
    Пациент->>Gosuslugi: 9. Проходит проверку в Госуслугах
    Gosuslugi->>ExternalAuthentication: Успех
    ExternalAuthentication->>HospitalController: 10. Получает данные пациента из Госуслуг
    HospitalController->>MedicalRecords: 11. Начинает процесс создания медицинской карты
    MedicalRecords->>MedicalRecord: 12. Создает медицинскую карту пациента
    MedicalRecord->>IMedicalRecordRepository: Сохраняет данные карты в хранилище
    MedicalRecords->>Patient: 13. Создает профиль пациента
    Patient-->>MedicalRecords: 14. Профиль привязан к карте
    MedicalRecords->>IPatientRepository: 16. Сохраняет профиль пациента в хранилище
    MedicalRecords->>HospitalController: Успех
    HospitalController->>UI: 17. Отправляет уведомление об успешной регистрации
    UI->>Пациент: 18. Получает уведомление о завершении регистрации
    UI->>Пациент: 19. Переводит в раздел "Профиль"
    UI->>Пациент: 20. Показывает сообщение об успехе и предлагает заполнить мед. данные
    Пациент->>UI: 21. Вводит медицинские данные
    UI->>HospitalController: 22. Обновляет медицинскую карту
    HospitalController->>MedicalRecords: 22. Обновляет медицинскую карту
    MedicalRecords->>MedicalRecord: 23. Сохраняет обновленные данные
    MedicalRecord->>IMedicalRecordRepository: 24. Сохраняет карту в хранилище
    MedicalRecords->>HospitalController: Успех
    HospitalController->>Пациент: 25. Процесс регистрации завершен
