using System;

namespace ClinicManagementSystem.Models
{
    /// <summary>
    /// Represents an Appointment record.
    /// The table is created in Phase 1; UI forms will be built in Phase 2.
    /// </summary>
    public class Appointment
    {
        // ── Properties ────────────────────────────────────────────────────────
        public int      AppointmentID   { get; set; }
        public int      PatientID       { get; set; }
        public int      DoctorID        { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string   TimeSlot        { get; set; }
        public string   Status          { get; set; } = "Scheduled";
        public string   Notes           { get; set; }
        public DateTime CreatedAt       { get; set; } = DateTime.Now;

        // ── Navigation (populated by DAL joins) ───────────────────────────────
        public string PatientName { get; set; }
        public string DoctorName  { get; set; }

        // ── Constructors ──────────────────────────────────────────────────────
        public Appointment() { }

        public Appointment(int patientId, int doctorId,
                           DateTime appointmentDate, string timeSlot)
        {
            PatientID       = patientId;
            DoctorID        = doctorId;
            AppointmentDate = appointmentDate;
            TimeSlot        = timeSlot;
        }

        public override string ToString() =>
            $"Appt #{AppointmentID} | {PatientName} -> Dr. {DoctorName} | {AppointmentDate:d} {TimeSlot} | {Status}";
    }
}
