using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IDatabase db;

            var controller = new HospitalController();
            var ui = new UI(controller);

            // Подписываем наблюдателей
            controller.AddObserver(ui);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите Use Case для демонстрации:");
                Console.WriteLine("1 - Проведение приема пациента врачом");
                Console.WriteLine("2 - Регистрация пациента и создание медкарты");
                Console.WriteLine("3 - Запись на прием к врачу");
                Console.WriteLine("4 - Выдача справок и направлений");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Проведение приема пациента
                        ui.HandleButtonClick("startAppointment");
                        ui.HandleButtonClick("updateMedicalData");
                        ui.HandleButtonClick("completeAppointment");
                        break;

                    case "2":
                        // Регистрация пациента и создание медкарты
                        ui.HandleButtonClick("registerPatient");
                        ui.HandleButtonClick("updateMedicalData");
                        break;

                    case "3":
                        // Запись на прием
                        ui.HandleButtonClick("scheduleAppointment");
                        break;

                    case "4":
                        // Выдача справок и направлений
                        Console.WriteLine("1 - Выдача справки");
                        Console.WriteLine("2 - Выдача направления");
                        var sub = Console.ReadLine();
                        if (sub == "1")
                        {
                            ui.HandleButtonClick("updateMedicalData");
                            ui.HandleButtonClick("requestCertificate");
                        }
                        else if (sub == "2")
                        {
                            ui.HandleButtonClick("updateMedicalData");
                            ui.HandleButtonClick("generateReferral");
                        }
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }
    }
}
