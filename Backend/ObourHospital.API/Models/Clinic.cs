using System.Collections.Generic;

namespace ObourHospital.API.Models
{
    public class Clinic
    {
        public int ClinicID { get; set; }
        
        public string Name { get; set; }
        
        public string Location { get; set; }
        
        // علاقة Navigation مع الأطباء
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}