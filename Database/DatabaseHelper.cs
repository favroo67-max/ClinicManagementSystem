using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;

namespace ClinicManagementSystem.Database
{
    /// <summary>
    /// Centralized database helper powered by local SQLite (DoctorAppointment.db).
    /// Fully localized for Misr University for Science & Technology (MUST), Egypt.
    /// Automatically initializes and auto-refreshes seed data to Egyptian records.
    /// </summary>
    public static class DatabaseHelper
    {
        private static readonly string DbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DoctorAppointment.db");
        private static readonly string ConnectionString = $"Data Source={DbFilePath};";
        private static bool _isInitialized = false;
        private static readonly object _initLock = new object();

        public static string ConnString => ConnectionString;
        public static string DatabasePath => DbFilePath;

        public static void InitializeDatabase()
        {
            if (_isInitialized) return;

            lock (_initLock)
            {
                if (_isInitialized) return;

                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();

                    // 1. Create Tables
                    string ddl = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            PasswordHash TEXT NOT NULL,
                            Role TEXT NOT NULL CHECK (Role IN ('Admin', 'Receptionist', 'Doctor')),
                            IsActive INTEGER NOT NULL DEFAULT 1,
                            CreatedAt TEXT NOT NULL DEFAULT (datetime('now','localtime'))
                        );

                        CREATE TABLE IF NOT EXISTS Doctors (
                            DoctorID INTEGER PRIMARY KEY AUTOINCREMENT,
                            FullName TEXT NOT NULL,
                            Specialty TEXT NOT NULL,
                            Phone TEXT NOT NULL,
                            Email TEXT NOT NULL UNIQUE,
                            WorkingDays TEXT NOT NULL,
                            ConsultationFee REAL NOT NULL,
                            IsActive INTEGER NOT NULL DEFAULT 1,
                            CreatedAt TEXT NOT NULL DEFAULT (datetime('now','localtime'))
                        );

                        CREATE TABLE IF NOT EXISTS Patients (
                            PatientID INTEGER PRIMARY KEY AUTOINCREMENT,
                            FullName TEXT NOT NULL,
                            Gender TEXT NOT NULL CHECK (Gender IN ('Male', 'Female', 'Other')),
                            DateOfBirth TEXT NOT NULL,
                            Phone TEXT NOT NULL,
                            Address TEXT NOT NULL,
                            MedicalHistoryNotes TEXT NULL,
                            IsActive INTEGER NOT NULL DEFAULT 1,
                            CreatedAt TEXT NOT NULL DEFAULT (datetime('now','localtime'))
                        );

                        CREATE TABLE IF NOT EXISTS Appointments (
                            AppointmentID INTEGER PRIMARY KEY AUTOINCREMENT,
                            PatientID INTEGER NOT NULL REFERENCES Patients(PatientID),
                            DoctorID INTEGER NOT NULL REFERENCES Doctors(DoctorID),
                            AppointmentDate TEXT NOT NULL,
                            TimeSlot TEXT NOT NULL,
                            Status TEXT NOT NULL DEFAULT 'Scheduled' CHECK (Status IN ('Scheduled','Waiting','Completed','Cancelled')),
                            Notes TEXT NULL,
                            CreatedAt TEXT NOT NULL DEFAULT (datetime('now','localtime'))
                        );
                    ";

                    using (var cmd = new SqliteCommand(ddl, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Migration Check: Detect old Saudi seed data and purge it for clean Egypt re-seed
                    bool needsEgyptMigration = false;
                    using (var cmdCheckOld = new SqliteCommand("SELECT COUNT(1) FROM Patients WHERE Address LIKE '%Riyadh%' OR Phone LIKE '05%';", conn))
                    {
                        long oldSaudiPatients = (long)cmdCheckOld.ExecuteScalar();
                        if (oldSaudiPatients > 0) needsEgyptMigration = true;
                    }
                    using (var cmdCheckDoc = new SqliteCommand("SELECT COUNT(1) FROM Doctors WHERE Phone LIKE '05%';", conn))
                    {
                        long oldSaudiDocs = (long)cmdCheckDoc.ExecuteScalar();
                        if (oldSaudiDocs > 0) needsEgyptMigration = true;
                    }

                    if (needsEgyptMigration)
                    {
                        using (var cmdPurge = new SqliteCommand("DELETE FROM Doctors; DELETE FROM Patients;", conn))
                        {
                            cmdPurge.ExecuteNonQuery();
                        }
                    }

                    // 3. Seed Users if empty
                    using (var cmdCheck = new SqliteCommand("SELECT COUNT(1) FROM Users;", conn))
                    {
                        long userCount = (long)cmdCheck.ExecuteScalar();
                        if (userCount == 0)
                        {
                            string hashAdmin123 = HashPassword("admin123");
                            string hashPassword123 = HashPassword("password123");

                            string seedUsers = @"
                                INSERT INTO Users (Username, PasswordHash, Role) VALUES
                                ('admin', @hashAdmin123, 'Admin'),
                                ('admin_alt', @hashPassword123, 'Admin'),
                                ('receptionist', @hashPassword123, 'Receptionist'),
                                ('doctor1', @hashPassword123, 'Doctor');
                            ";

                            using (var cmdSeed = new SqliteCommand(seedUsers, conn))
                            {
                                cmdSeed.Parameters.AddWithValue("@hashAdmin123", hashAdmin123);
                                cmdSeed.Parameters.AddWithValue("@hashPassword123", hashPassword123);
                                cmdSeed.ExecuteNonQuery();
                            }
                        }
                    }

                    // 4. Seed Doctors with Egyptian Data (Misr University MUST Clinic)
                    using (var cmdCheck = new SqliteCommand("SELECT COUNT(1) FROM Doctors;", conn))
                    {
                        long docCount = (long)cmdCheck.ExecuteScalar();
                        if (docCount == 0)
                        {
                            string seedDoctors = @"
                                INSERT INTO Doctors (FullName, Specialty, Phone, Email, WorkingDays, ConsultationFee) VALUES
                                ('Dr. Tarek El-Gendy', 'Cardiology', '01001122334', 't.elgendy@mustclinic.eg', 'Sun, Tue, Thu', 500.00),
                                ('Dr. Heba Abdelaziz', 'Pediatrics', '01112233445', 'h.abdelaziz@mustclinic.eg', 'Sat, Mon, Wed', 350.00),
                                ('Dr. Karim El-Shazly', 'Orthopedics', '01223344556', 'k.elshazly@mustclinic.eg', 'Sun, Mon, Wed', 450.00),
                                ('Dr. Mariam Farouk', 'Dermatology', '01554433221', 'm.farouk@mustclinic.eg', 'Sat, Tue, Thu', 400.00),
                                ('Dr. Hossam Badawy', 'Internal Medicine', '01066778899', 'h.badawy@mustclinic.eg', 'Daily except Fri', 300.00);
                            ";
                            using (var cmdSeed = new SqliteCommand(seedDoctors, conn))
                            {
                                cmdSeed.ExecuteNonQuery();
                            }
                        }
                    }

                    // 5. Seed Patients with Egyptian Data (Cairo / Giza / 6th of October)
                    using (var cmdCheck = new SqliteCommand("SELECT COUNT(1) FROM Patients;", conn))
                    {
                        long patCount = (long)cmdCheck.ExecuteScalar();
                        if (patCount == 0)
                        {
                            string seedPatients = @"
                                INSERT INTO Patients (FullName, Gender, DateOfBirth, Phone, Address, MedicalHistoryNotes) VALUES
                                ('Ahmed Mahmoud El-Sayed', 'Male', '1985-03-15', '01012345678', 'Al-Motamayez District, 6th of October City', 'Hypertension, regular medication'),
                                ('Nourhan Tarek Ibrahim', 'Female', '1992-07-22', '01123456789', 'Sheikh Zayed City, District 4, Giza', 'No known allergies'),
                                ('Mohamed Abdelrahman Ali', 'Male', '1965-09-12', '01234567890', 'Dokki, Mossadak St, Giza', 'Knee arthroscopy (2020)'),
                                ('Sara Khaled Mostafa', 'Female', '2001-05-30', '01551234567', 'Nasr City, Makram Ebeid St, Cairo', 'Seasonal asthma'),
                                ('Youssef Adel Hassan', 'Male', '1978-11-08', '01098765432', 'Maadi, Road 9, Cairo', 'Type 2 Diabetes'),
                                ('Mona Hany Soliman', 'Female', '1990-01-25', '01187654321', 'Heliopolis, El-Merghany St, Cairo', 'Routine checkup, healthy'),
                                ('Omar Sherif Mansour', 'Male', '2010-06-18', '01276543210', 'First Settlement, New Cairo', 'Childhood vaccinations current');
                            ";
                            using (var cmdSeed = new SqliteCommand(seedPatients, conn))
                            {
                                cmdSeed.ExecuteNonQuery();
                            }
                        }
                    }
                }

                _isInitialized = true;
            }
        }

        public static SqliteConnection GetConnection()
        {
            InitializeDatabase();
            var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                InitializeDatabase();
                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public static string HashPassword(string plainText)
        {
            if (plainText == null) plainText = string.Empty;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public static int ExecuteNonQuery(string sql, Action<SqliteCommand> paramSetup = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqliteCommand(sql, conn))
            {
                paramSetup?.Invoke(cmd);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, Action<SqliteCommand> paramSetup = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqliteCommand(sql, conn))
            {
                paramSetup?.Invoke(cmd);
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable GetDataTable(string sql, Action<SqliteCommand> paramSetup = null)
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new SqliteCommand(sql, conn))
            {
                paramSetup?.Invoke(cmd);
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
    }
}
