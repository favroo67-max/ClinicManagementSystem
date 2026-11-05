using System;

namespace ClinicManagementSystem.Models
{
    /// <summary>
    /// Abstract base class representing a person in the clinic system.
    /// Provides common properties shared by Doctor and Patient.
    /// </summary>
    public abstract class Person
    {
        // ── Properties ────────────────────────────────────────────────────────
        public string   FullName  { get; set; }
        public string   Phone     { get; set; }
        public string   Email     { get; set; }
        public bool     IsActive  { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // ── Constructors ──────────────────────────────────────────────────────
        protected Person() { }

        protected Person(string fullName, string phone, string email)
        {
            FullName = fullName;
            Phone    = phone;
            Email    = email;
        }

        // ── Virtual Methods ───────────────────────────────────────────────────
        /// <summary>Returns a display-friendly summary of the person.</summary>
        public virtual string GetSummary()
            => $"{FullName} | {Phone} | {Email}";

        public override string ToString() => FullName ?? "Unknown";
    }
}
