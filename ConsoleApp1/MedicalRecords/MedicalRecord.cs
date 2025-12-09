using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public class MedicalRecord
    {
        private uint id;
        private uint patientid;
        protected List<Visit> data;
        private readonly DateTime createdAt;
        private readonly DateTime lastchange;
    }
}
