-- Schema.sql for SQL Server

CREATE TABLE Clinics (
    ClinicID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255)
);

CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Specialty NVARCHAR(100),
    ClinicID INT,
    FOREIGN KEY (ClinicID) REFERENCES Clinics(ClinicID)
);

CREATE TABLE Patients (
    PatientID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    DateOfBirth DATE,
    Phone NVARCHAR(15)
);

CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY IDENTITY,
    PatientID INT,
    DoctorID INT,
    AppointmentDate DATETIME NOT NULL,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);