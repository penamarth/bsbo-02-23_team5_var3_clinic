using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    public interface IDoctorRepository
    {
        Doctor findById(string id);
        List<Doctor> findAll();
        bool save(Doctor doctor);
        bool update(Doctor doctor);
        bool delete(string id);
        bool existsById(string id);
        Patient findBySpecialization(string specialization);
    }
}
