using System;

namespace ObourHospital.API.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        
        public int? PatientID { get; set; }
        
        public int? DoctorID { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        
        // علاقات Navigation
        public Patient Patient { get; set; }
        
        public Doctor Doctor { get; set; }
    }
}