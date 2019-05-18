using System_kadr.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace System_kadr.Database
{
    public class System_kadr : DbContext
    {
        public DbSet<MKUser> Users { get; set; }
        public DbSet<MKDoctor> Doctors { get; set; }
        public DbSet<MKPatient> Patients { get; set; }
        public DbSet<MKSpecialization> Specializations { get; set; }
        public DbSet<MKExamination> Examinations { get; set; }
        public DbSet<MKDoctorExamination> DoctorExaminations { get; set; }
        public DbSet<MKAppointment> Appointments { get; set; }

        public System_kadr() : base("DefaultConnection")
        {
        }
    }
}