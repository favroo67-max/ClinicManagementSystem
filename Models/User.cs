using System;

namespace ClinicManagementSystem.Models
{
    /// <summary>
    /// Represents an authenticated system user (Admin, Receptionist, or Doctor).
    /// </summary>
    public class User
    {
        // ── Properties ────────────────────────────────────────────────────────
        public int      UserID       { get; set; }
        public string   Username     { get; set; }
        public string   PasswordHash { get; set; }
        public string   Role         { get; set; }
        public bool     IsActive     { get; set; } = true;
        public DateTime CreatedAt    { get; set; } = DateTime.Now;

        // ── Constructors ──────────────────────────────────────────────────────
        public User() { }

        public User(int userId, string username, string role)
        {
            UserID   = userId;
            Username = username;
            Role     = role;
        }

        // ── Role Helpers ──────────────────────────────────────────────────────
        public bool IsAdmin        => Role == "Admin";
        public bool IsReceptionist => Role == "Receptionist";
        public bool IsDoctor       => Role == "Doctor";

        public override string ToString() => $"{Username} ({Role})";
    }
}
