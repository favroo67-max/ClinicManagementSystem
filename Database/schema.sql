-- ============================================================
-- Doctor Appointment System (Project #28) - Database Schema
-- Misr University for Science & Technology (MUST)
-- Course: CS312 - Phase 1 Deliverable
-- ============================================================

-- Table: Users
CREATE TABLE IF NOT EXISTS Users (
    UserID       INTEGER PRIMARY KEY AUTOINCREMENT,
    Username     TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL,
    Role         TEXT NOT NULL CHECK (Role IN ('Admin', 'Receptionist', 'Doctor')),
    IsActive     INTEGER NOT NULL DEFAULT 1,
    CreatedAt    TEXT NOT NULL DEFAULT (datetime('now','localtime'))
);

-- Table: Doctors
CREATE TABLE IF NOT EXISTS Doctors (
    DoctorID        INTEGER PRIMARY KEY AUTOINCREMENT,
    FullName        TEXT NOT NULL,
    Specialty       TEXT NOT NULL,
    Phone           TEXT NOT NULL,
    Email           TEXT NOT NULL UNIQUE,
    WorkingDays     TEXT NOT NULL,
    ConsultationFee REAL NOT NULL,
    IsActive        INTEGER NOT NULL DEFAULT 1,
    CreatedAt       TEXT NOT NULL DEFAULT (datetime('now','localtime'))
);

-- Table: Patients
CREATE TABLE IF NOT EXISTS Patients (
    PatientID           INTEGER PRIMARY KEY AUTOINCREMENT,
    FullName            TEXT NOT NULL,
    Gender              TEXT NOT NULL CHECK (Gender IN ('Male', 'Female', 'Other')),
    DateOfBirth         TEXT NOT NULL,
    Phone               TEXT NOT NULL,
    Address             TEXT NOT NULL,
    MedicalHistoryNotes TEXT NULL,
    IsActive            INTEGER NOT NULL DEFAULT 1,
    CreatedAt           TEXT NOT NULL DEFAULT (datetime('now','localtime'))
);

-- Table: Appointments (Phase 2 schema provisioned)
CREATE TABLE IF NOT EXISTS Appointments (
    AppointmentID   INTEGER PRIMARY KEY AUTOINCREMENT,
    PatientID       INTEGER NOT NULL REFERENCES Patients(PatientID),
    DoctorID        INTEGER NOT NULL REFERENCES Doctors(DoctorID),
    AppointmentDate TEXT NOT NULL,
    TimeSlot        TEXT NOT NULL,
    Status          TEXT NOT NULL DEFAULT 'Scheduled' CHECK (Status IN ('Scheduled','Waiting','Completed','Cancelled')),
    Notes           TEXT NULL,
    CreatedAt       TEXT NOT NULL DEFAULT (datetime('now','localtime'))
);

-- ============================================================
-- Seed Data: Users
-- Passwords: 'admin123' and 'password123'
-- ============================================================
INSERT OR IGNORE INTO Users (Username, PasswordHash, Role) VALUES
('admin',        '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Admin'),
('receptionist', 'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f', 'Receptionist'),
('doctor1',      'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f', 'Doctor');

-- ============================================================
-- Seed Data: Doctors (Misr University for Science & Technology - MUST)
-- ============================================================
INSERT OR IGNORE INTO Doctors (FullName, Specialty, Phone, Email, WorkingDays, ConsultationFee) VALUES
('Dr. Tarek El-Gendy',   'Cardiology',        '01001122334', 't.elgendy@mustclinic.eg',   'Sun, Tue, Thu',      500.00),
('Dr. Heba Abdelaziz',   'Pediatrics',        '01112233445', 'h.abdelaziz@mustclinic.eg', 'Sat, Mon, Wed',      350.00),
('Dr. Karim El-Shazly',  'Orthopedics',       '01223344556', 'k.elshazly@mustclinic.eg',  'Sun, Mon, Wed',      450.00),
('Dr. Mariam Farouk',    'Dermatology',       '01554433221', 'm.farouk@mustclinic.eg',    'Sat, Tue, Thu',      400.00),
('Dr. Hossam Badawy',    'Internal Medicine', '01066778899', 'h.badawy@mustclinic.eg',    'Daily except Fri',   300.00);

-- ============================================================
-- Seed Data: Patients (Egypt - Cairo, Giza, 6th of October)
-- ============================================================
INSERT OR IGNORE INTO Patients (FullName, Gender, DateOfBirth, Phone, Address, MedicalHistoryNotes) VALUES
('Ahmed Mahmoud El-Sayed', 'Male',   '1985-03-15', '01012345678', 'Al-Motamayez District, 6th of October City', 'Hypertension, regular medication'),
('Nourhan Tarek Ibrahim',  'Female', '1992-07-22', '01123456789', 'Sheikh Zayed City, District 4, Giza',      'No known allergies'),
('Mohamed Abdelrahman Ali','Male',   '1965-09-12', '01234567890', 'Dokki, Mossadak St, Giza',                  'Knee arthroscopy (2020)'),
('Sara Khaled Mostafa',    'Female', '2001-05-30', '01551234567', 'Nasr City, Makram Ebeid St, Cairo',          'Seasonal asthma'),
('Youssef Adel Hassan',    'Male',   '1978-11-08', '01098765432', 'Maadi, Road 9, Cairo',                       'Type 2 Diabetes'),
('Mona Hany Soliman',      'Female', '1990-01-25', '01187654321', 'Heliopolis, El-Merghany St, Cairo',          'Routine checkup, healthy'),
('Omar Sherif Mansour',    'Male',   '2010-06-18', '01276543210', 'First Settlement, New Cairo',                 'Childhood vaccinations current');
