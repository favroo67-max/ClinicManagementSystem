using System;

namespace ClinicManagementSystem.Models
{
    /// <summary>
    /// Represents a Doctor in the clinic.
    /// Inherits common identity fields from Person.
    /// </summary>
    public class Doctor : Person
    {
        // ── Properties ────────────────────────────────────────────────────────
        public int     DoctorID        { get; set; }
        public string  Specialty       { get; set; }
        public string  WorkingDays     { get; set; }
        public decimal ConsultationFee { get; set; }

        // ── Constructors ──────────────────────────────────────────────────────
        public Doctor() { }

        public Doctor(int doctorId, string fullName, string specialty,
                      string phone, string email,
                      string workingDays, decimal consultationFee)
            : base(fullName, phone, email)
        {
            DoctorID        = doctorId;
            Specialty       = specialty;
            WorkingDays     = workingDays;
            ConsultationFee = consultationFee;
        }

        // ── Override ──────────────────────────────────────────────────────────
        public override string GetSummary()
            => $"Dr. {FullName} | {Specialty} | Fee: {ConsultationFee:C} | Days: {WorkingDays}";

        public override string ToString() => $"Dr. {FullName} ({Specialty})";
    }
}
