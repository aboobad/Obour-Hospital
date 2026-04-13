using System.Collections.Generic;

namespace ObourHospital.API.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        
        public string Name { get; set; }
        
        // الرقم القومي - يجب أن يكون فريداً
        public string NationalID { get; set; }
        
        public System.DateTime DateOfBirth { get; set; }
        
        public string Phone { get; set; }
        
        // علاقة Navigation مع المواعيد
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}