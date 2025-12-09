using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public interface IPatientRepository
    {
        Patient findById(string id);
        List<Patient> findAll();
        bool save(Patient patient);
        bool update(Patient patient);
        bool delete(string id);
        bool existsById(string id);
        Patient findByInsurancePolicy(string policyNumber);
    }
}
