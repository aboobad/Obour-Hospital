using System.Collections.Generic;

namespace ObourHospital.API.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        
        public string Name { get; set; }
        
        public string Specialty { get; set; }
        
        public int? ClinicID { get; set; }
        
        // علاقات Navigation
        public Clinic Clinic { get; set; }
        
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}