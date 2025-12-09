using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public class UI : IObserver
    {
        private HospitalController controller;

        public UI(HospitalController controller)
        {
            this.controller = controller;
        }

        public void DisplayHomeScreen()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayHomeScreen()\"");
        }

        public void DisplayRegistrationScreen()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayRegistrationScreen()\"");
        }

        public void DisplayLoginScreen()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayLoginScreen()\"");
        }

        public void DisplayPersonalAccount()
        {
            Console.WriteLine("Класс \"UI\" вызвал метод \"DisplayPersonalAccount()\"");
        }

        public void HandleButtonClick(string action)
        {
            Console.WriteLine($"Класс \"UI\" вызвал метод \"HandleButtonClick()\" с действием \"{action}\"");

            // Здесь просто маршрутизируем к нужным методам контроллера,
            // чтобы показать связи для юзкейсов.
            switch (action)
            {
                case "registerPatient":
                    controller.RegisterPatient();
                    break;
                case "updateMedicalData":
                    controller.UpdateMedicalData();
                    break;
                case "requestCertificate":
                    controller.RequestCertificate();
                    break;
                case "generateReferral":
                    controller.GenerateReferral();
                    break;
                case "scheduleAppointment":
                    controller.ScheduleAppointmentUseCase();
                    break;
                case "startAppointment":
                    controller.StartAppointment();
                    break;
                case "completeAppointment":
                    controller.CompleteAppointment();
                    break;
                case "cancel":
                    controller.NotifyObservers("Операция отменена");
                    break;
                default:
                    Console.WriteLine("Неизвестное действие UI");
                    break;
            }
        }

        public void Update(string message)
        {
            Console.WriteLine($"Класс \"UI\" получил уведомление через метод \"Update()\": {message}");
        }
    }
}
