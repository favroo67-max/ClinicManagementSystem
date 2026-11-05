using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ClinicManagementSystem.Database;
using ClinicManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace ClinicManagementSystem.DAL
{
    /// <summary>
    /// Data Access Layer for Doctors, powered by portable local SQLite.
    /// </summary>
    public class DoctorDAL
    {
        // ── Get All ───────────────────────────────────────────────────────────
        public List<Doctor> GetAll()
        {
            var list = new List<Doctor>();
            string sql = @"SELECT DoctorID, FullName, Specialty, Phone, Email,
                                  WorkingDays, ConsultationFee, IsActive, CreatedAt
                           FROM   Doctors
                           WHERE  IsActive = 1
                           ORDER  BY FullName COLLATE NOCASE ASC;";
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(sql);
                foreach (DataRow row in dt.Rows)
                    list.Add(MapRow(row));
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading doctors: " + ex.Message, ex);
            }
            return list;
        }

        public Task<List<Doctor>> GetAllAsync() => Task.Run(() => GetAll());

        // ── Search ────────────────────────────────────────────────────────────
        public List<Doctor> Search(string keyword, string filterSpecialty = null)
        {
            var list = new List<Doctor>();
            string sql = @"SELECT DoctorID, FullName, Specialty, Phone, Email,
                                  WorkingDays, ConsultationFee, IsActive, CreatedAt
                           FROM   Doctors
                           WHERE  IsActive = 1
                             AND  (@keyword IS NULL OR FullName LIKE @keyword
                                   OR Specialty LIKE @keyword OR Phone LIKE @keyword)
                             AND  (@specialty IS NULL OR Specialty = @specialty)
                           ORDER  BY FullName COLLATE NOCASE ASC;";
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(sql, cmd =>
                {
                    cmd.Parameters.AddWithValue("@keyword",
                        string.IsNullOrWhiteSpace(keyword) ? (object)DBNull.Value : $"%{keyword}%");
                    cmd.Parameters.AddWithValue("@specialty",
                        string.IsNullOrWhiteSpace(filterSpecialty) ? (object)DBNull.Value : filterSpecialty);
                });
                foreach (DataRow row in dt.Rows)
                    list.Add(MapRow(row));
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching doctors: " + ex.Message, ex);
            }
            return list;
        }

        public Task<List<Doctor>> SearchAsync(string keyword, string filterSpecialty = null)
            => Task.Run(() => Search(keyword, filterSpecialty));

        // ── Get By ID ─────────────────────────────────────────────────────────
        public Doctor GetById(int doctorId)
        {
            string sql = @"SELECT DoctorID, FullName, Specialty, Phone, Email,
                                  WorkingDays, ConsultationFee, IsActive, CreatedAt
                           FROM   Doctors WHERE DoctorID = @id;";
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(sql,
                    cmd => cmd.Parameters.AddWithValue("@id", doctorId));
                return dt.Rows.Count > 0 ? MapRow(dt.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching doctor: " + ex.Message, ex);
            }
        }

        // ── Insert ────────────────────────────────────────────────────────────
        public int Insert(Doctor doctor)
        {
            string sql = @"INSERT INTO Doctors
                               (FullName, Specialty, Phone, Email, WorkingDays, ConsultationFee)
                           VALUES
                               (@name, @specialty, @phone, @email, @days, @fee);
                           SELECT last_insert_rowid();";
            try
            {
                object result = DatabaseHelper.ExecuteScalar(sql, cmd =>
                {
                    cmd.Parameters.AddWithValue("@name",      doctor.FullName ?? "");
                    cmd.Parameters.AddWithValue("@specialty", doctor.Specialty ?? "");
                    cmd.Parameters.AddWithValue("@phone",     doctor.Phone ?? "");
                    cmd.Parameters.AddWithValue("@email",     doctor.Email ?? "");
                    cmd.Parameters.AddWithValue("@days",      doctor.WorkingDays ?? "");
                    cmd.Parameters.AddWithValue("@fee",       (double)doctor.ConsultationFee);
                });
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting doctor: " + ex.Message, ex);
            }
        }

        // ── Update ────────────────────────────────────────────────────────────
        public void Update(Doctor doctor)
        {
            string sql = @"UPDATE Doctors SET
                               FullName        = @name,
                               Specialty       = @specialty,
                               Phone           = @phone,
                               Email           = @email,
                               WorkingDays     = @days,
                               ConsultationFee = @fee
                           WHERE DoctorID = @id;";
            try
            {
                DatabaseHelper.ExecuteNonQuery(sql, cmd =>
                {
                    cmd.Parameters.AddWithValue("@name",      doctor.FullName ?? "");
                    cmd.Parameters.AddWithValue("@specialty", doctor.Specialty ?? "");
                    cmd.Parameters.AddWithValue("@phone",     doctor.Phone ?? "");
                    cmd.Parameters.AddWithValue("@email",     doctor.Email ?? "");
                    cmd.Parameters.AddWithValue("@days",      doctor.WorkingDays ?? "");
                    cmd.Parameters.AddWithValue("@fee",       (double)doctor.ConsultationFee);
                    cmd.Parameters.AddWithValue("@id",        doctor.DoctorID);
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating doctor: " + ex.Message, ex);
            }
        }

        // ── Soft Delete ───────────────────────────────────────────────────────
        public void Delete(int doctorId)
        {
            string sql = "UPDATE Doctors SET IsActive = 0 WHERE DoctorID = @id;";
            try
            {
                DatabaseHelper.ExecuteNonQuery(sql,
                    cmd => cmd.Parameters.AddWithValue("@id", doctorId));
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting doctor: " + ex.Message, ex);
            }
        }

        // ── Get Distinct Specialties ──────────────────────────────────────────
        public List<string> GetSpecialties()
        {
            var list = new List<string>();
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(
                    "SELECT DISTINCT Specialty FROM Doctors WHERE IsActive=1 ORDER BY Specialty;");
                foreach (DataRow row in dt.Rows)
                    list.Add(row[0].ToString());
            }
            catch { /* non-critical */ }
            return list;
        }

        // ── Duplicate Email Check ─────────────────────────────────────────────
        public bool EmailExists(string email, int excludeId = 0)
        {
            object result = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM Doctors WHERE Email=@email AND DoctorID<>@id AND IsActive=1;",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id",    excludeId);
                });
            return Convert.ToInt32(result) > 0;
        }

        // ── Row Mapper ────────────────────────────────────────────────────────
        private Doctor MapRow(DataRow row) => new Doctor
        {
            DoctorID        = Convert.ToInt32(row["DoctorID"]),
            FullName        = row["FullName"].ToString(),
            Specialty       = row["Specialty"].ToString(),
            Phone           = row["Phone"].ToString(),
            Email           = row["Email"].ToString(),
            WorkingDays     = row["WorkingDays"].ToString(),
            ConsultationFee = Convert.ToDecimal(row["ConsultationFee"]),
            IsActive        = Convert.ToInt32(row["IsActive"]) == 1,
            CreatedAt       = Convert.ToDateTime(row["CreatedAt"])
        };
    }
}
