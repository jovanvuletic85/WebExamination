using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebExamination.Models
{
    public class PatientContext:DbContext
    {
        public PatientContext():base("DefaultConnection")
        {

        }
        public DbSet<Patient> Patients { get; set; }
    }
}