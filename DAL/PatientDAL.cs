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
    /// Data Access Layer for Patients, powered by portable local SQLite.
    /// </summary>
    public class PatientDAL
    {
        // ── Get All ───────────────────────────────────────────────────────────
        public List<Patient> GetAll()
        {
            var list = new List<Patient>();
            string sql = @"SELECT PatientID, FullName, Gender, DateOfBirth, Phone,
                                  Address, MedicalHistoryNotes, IsActive, CreatedAt
                           FROM   Patients
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
                throw new Exception("Error loading patients: " + ex.Message, ex);
            }
            return list;
        }

        public Task<List<Patient>> GetAllAsync() => Task.Run(() => GetAll());

        // ── Search ────────────────────────────────────────────────────────────
        public List<Patient> Search(string keyword, string filterGender = null)
        {
            var list = new List<Patient>();
            string sql = @"SELECT PatientID, FullName, Gender, DateOfBirth, Phone,
                                  Address, MedicalHistoryNotes, IsActive, CreatedAt
                           FROM   Patients
                           WHERE  IsActive = 1
                             AND  (@keyword IS NULL OR FullName LIKE @keyword
                                   OR Phone LIKE @keyword OR Address LIKE @keyword)
                             AND  (@gender  IS NULL OR Gender = @gender)
                           ORDER  BY FullName COLLATE NOCASE ASC;";
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(sql, cmd =>
                {
                    cmd.Parameters.AddWithValue("@keyword",
                        string.IsNullOrWhiteSpace(keyword) ? (object)DBNull.Value : $"%{keyword}%");
                    cmd.Parameters.AddWithValue("@gender",
                        string.IsNullOrWhiteSpace(filterGender) ? (object)DBNull.Value : filterGender);
                });
                foreach (DataRow row in dt.Rows)
                    list.Add(MapRow(row));
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching patients: " + ex.Message, ex);
            }
            return list;
        }

        public Task<List<Patient>> SearchAsync(string keyword, string filterGender = null)
            => Task.Run(() => Search(keyword, filterGender));

        // ── Get By ID ─────────────────────────────────────────────────────────
        public Patient GetById(int patientId)
        {
            string sql = @"SELECT PatientID, FullName, Gender, DateOfBirth, Phone,
                                  Address, MedicalHistoryNotes, IsActive, CreatedAt
                           FROM   Patients WHERE PatientID = @id;";
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(sql,
                    cmd => cmd.Parameters.AddWithValue("@id", patientId));
                return dt.Rows.Count > 0 ? MapRow(dt.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching patient: " + ex.Message, ex);
            }
        }

        // ── Insert ────────────────────────────────────────────────────────────
        public int Insert(Patient patient)
        {
            string sql = @"INSERT INTO Patients
                               (FullName, Gender, DateOfBirth, Phone, Address, MedicalHistoryNotes)
                           VALUES
                               (@name, @gender, @dob, @phone, @address, @notes);
                           SELECT last_insert_rowid();";
            try
            {
                object result = DatabaseHelper.ExecuteScalar(sql, cmd =>
                {
                    cmd.Parameters.AddWithValue("@name",    patient.FullName ?? "");
                    cmd.Parameters.AddWithValue("@gender",  patient.Gender ?? "Other");
                    cmd.Parameters.AddWithValue("@dob",     patient.DateOfBirth.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@phone",   patient.Phone ?? "");
                    cmd.Parameters.AddWithValue("@address", patient.Address ?? "");
                    cmd.Parameters.AddWithValue("@notes",
                        string.IsNullOrWhiteSpace(patient.MedicalHistoryNotes) ? (object)DBNull.Value : patient.MedicalHistoryNotes);
                });
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting patient: " + ex.Message, ex);
            }
        }

        // ── Update ────────────────────────────────────────────────────
        public void Update(Patient patient)
        {
            string sql = @"UPDATE Patients SET
                               FullName            = @name,
                               Gender              = @gender,
                               DateOfBirth         = @dob,
                               Phone               = @phone,
                               Address             = @address,
                               MedicalHistoryNotes = @notes
                           WHERE PatientID = @id;";
            try
            {
                DatabaseHelper.ExecuteNonQuery(sql, cmd =>
                {
                    cmd.Parameters.AddWithValue("@name",    patient.FullName ?? "");
                    cmd.Parameters.AddWithValue("@gender",  patient.Gender ?? "Other");
                    cmd.Parameters.AddWithValue("@dob",     patient.DateOfBirth.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@phone",   patient.Phone ?? "");
                    cmd.Parameters.AddWithValue("@address", patient.Address ?? "");
                    cmd.Parameters.AddWithValue("@notes",
                        string.IsNullOrWhiteSpace(patient.MedicalHistoryNotes) ? (object)DBNull.Value : patient.MedicalHistoryNotes);
                    cmd.Parameters.AddWithValue("@id",      patient.PatientID);
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating patient: " + ex.Message, ex);
            }
        }

        // ── Soft Delete ───────────────────────────────────────────────────────
        public void Delete(int patientId)
        {
            string sql = "UPDATE Patients SET IsActive = 0 WHERE PatientID = @id;";
            try
            {
                DatabaseHelper.ExecuteNonQuery(sql,
                    cmd => cmd.Parameters.AddWithValue("@id", patientId));
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting patient: " + ex.Message, ex);
            }
        }

        // ── Duplicate Phone Check ─────────────────────────────────────────────
        public bool PhoneExists(string phone, int excludeId = 0)
        {
            object result = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM Patients WHERE Phone=@phone AND PatientID<>@id AND IsActive=1;",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@phone", phone ?? "");
                    cmd.Parameters.AddWithValue("@id",    excludeId);
                });
            return Convert.ToInt32(result) > 0;
        }

        // ── Get Count ─────────────────────────────────────────────────────────
        public int GetCount()
        {
            object result = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM Patients WHERE IsActive=1;");
            return Convert.ToInt32(result);
        }

        // ── Row Mapper ────────────────────────────────────────────────────────
        private Patient MapRow(DataRow row) => new Patient
        {
            PatientID           = Convert.ToInt32(row["PatientID"]),
            FullName            = row["FullName"].ToString(),
            Gender              = row["Gender"].ToString(),
            DateOfBirth         = Convert.ToDateTime(row["DateOfBirth"]),
            Phone               = row["Phone"].ToString(),
            Address             = row["Address"].ToString(),
            MedicalHistoryNotes = row["MedicalHistoryNotes"] == DBNull.Value
                                    ? null
                                    : row["MedicalHistoryNotes"].ToString(),
            IsActive            = Convert.ToInt32(row["IsActive"]) == 1,
            CreatedAt           = Convert.ToDateTime(row["CreatedAt"])
        };
    }
}
