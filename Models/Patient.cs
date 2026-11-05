using System;

namespace ClinicManagementSystem.Models
{
    /// <summary>
    /// Represents a Patient registered in the clinic.
    /// Inherits common identity fields from Person.
    /// </summary>
    public class Patient : Person
    {
        // ── Properties ────────────────────────────────────────────────────────
        public int      PatientID           { get; set; }
        public string   Gender              { get; set; }
        public DateTime DateOfBirth         { get; set; }
        public string   Address             { get; set; }
        public string   MedicalHistoryNotes { get; set; }

        // ── Computed Properties ───────────────────────────────────────────────
        public int Age => CalculateAge(DateOfBirth);

        // ── Constructors ──────────────────────────────────────────────────────
        public Patient() { }

        public Patient(int patientId, string fullName, string gender,
                       DateTime dateOfBirth, string phone, string address,
                       string medicalHistoryNotes = null)
            : base(fullName, phone, null)   // Patients don't have Email in this schema
        {
            PatientID           = patientId;
            Gender              = gender;
            DateOfBirth         = dateOfBirth;
            Address             = address;
            MedicalHistoryNotes = medicalHistoryNotes;
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private static int CalculateAge(DateTime dob)
        {
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        public override string GetSummary()
            => $"{FullName} | {Gender} | Age: {Age} | {Phone}";

        public override string ToString() => $"{FullName} (ID: {PatientID})";
    }
}
