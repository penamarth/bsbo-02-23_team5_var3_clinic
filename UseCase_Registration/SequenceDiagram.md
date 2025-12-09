sequenceDiagram
    actor Пациент
    participant UI
    participant HospitalController
    participant ExternalAuthentication
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
    ExternalAuthentication->>Пациент: 8. Переходит в сервис Госуслуг
    Пациент->>ExternalAuthentication: 9. Проходит проверку в Госуслугах
    ExternalAuthentication->>HospitalController: 10. Получает данные пациента из Госуслуг
    HospitalController->>MedicalRecords: 11. Начинает процесс создания медицинской карты
    MedicalRecords->>MedicalRecord: 12. Создает медицинскую карту пациента
    MedicalRecords->>Patient: 13. Создает профиль пациента
    Patient-->>MedicalRecords: 14. Профиль привязан к карте
    MedicalRecords->>IMedicalRecordRepository: 15. Сохраняет данные карты в хранилище
    MedicalRecords->>IPatientRepository: 16. Сохраняет профиль пациента в хранилище
    HospitalController->>UI: 17. Отправляет уведомление об успешной регистрации
    UI->>Пациент: 18. Получает уведомление о завершении регистрации
    UI->>Пациент: 19. Переводит в раздел "Профиль"
    UI->>Пациент: 20. Показывает сообщение об успехе и предлагает заполнить мед. данные
    Пациент->>UI: 21. Вводит медицинские данные
    UI->>HospitalController: 22. Обновляет медицинскую карту
    HospitalController->>MedicalRecords: 22. Обновляет медицинскую карту
    MedicalRecords->>MedicalRecord: 23. Сохраняет обновленные данные
    MedicalRecords->>IMedicalRecordRepository: 24. Сохраняет карту в хранилище
    HospitalController->>Пациент: 25. Процесс регистрации завершен
