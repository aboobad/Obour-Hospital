using Microsoft.EntityFrameworkCore;
using ObourHospital.API.Models;

namespace ObourHospital.API.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        // DbSets للجداول
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API Configuration
            
            // تكوين جدول المرضى
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientID);
                
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                
                // جعل الرقم القومي فريداً
                entity.HasIndex(e => e.NationalID)
                    .IsUnique()
                    .HasDatabaseName("IX_NationalID_Unique");
                
                entity.Property(e => e.NationalID)
                    .IsRequired()
                    .HasMaxLength(14);
                
                entity.Property(e => e.Phone)
                    .HasMaxLength(15);
            });

            // تكوين جدول العيادات
            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.ClinicID);
                
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(e => e.Location)
                    .HasMaxLength(255);
            });

            // تكوين جدول الأطباء
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorID);
                
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(e => e.Specialty)
                    .HasMaxLength(100);
                
                // علاقة الربط مع العيادات
                entity.HasOne(d => d.Clinic)
                    .WithMany(c => c.Doctors)
                    .HasForeignKey(d => d.ClinicID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // تكوين جدول المواعيد
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentID);
                
                entity.Property(e => e.AppointmentDate)
                    .IsRequired();
                
                // علاقة الربط مع المريض
                entity.HasOne(a => a.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(a => a.PatientID)
                    .OnDelete(DeleteBehavior.Cascade);
                
                // علاقة الربط مع الطبيب
                entity.HasOne(a => a.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(a => a.DoctorID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}