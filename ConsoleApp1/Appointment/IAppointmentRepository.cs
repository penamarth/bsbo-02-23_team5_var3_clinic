using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public interface IAppointmentRepository
    {
        Appointment findById(string id);
        Patient findByPatientId(string patientId);
        Doctor findByDoctroId(string doctroId);
        List<Appointment> findByStatus(string status);
        bool save(Appointment appointment);
        bool update(Appointment appointment);
        bool delete(string id);
        bool existsById(string id);
    }
}
