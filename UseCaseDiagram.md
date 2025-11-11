@startuml
left to right direction
actor "Пациент" as Patient
actor "Врач" as Doctor

rectangle "Больница" {
    usecase "Запись на прием" as UC1
    usecase "Процесс приема\n(начало/конец)" as UC2
    usecase "Выдача справок\nи направлений" as UC3
    usecase "Регистрация" as UC4
}

actor "Медкарты" as DB1
actor "Расписание" as DB2


Patient --> UC1
Patient --> UC4
Doctor --> UC2
Doctor --> UC3
Doctor --> UC4

UC1 --> DB1
UC1 --> DB2
UC2 --> DB1
UC3 --> DB1
UC3 --> DB2
UC4 --> DB1

@enduml
