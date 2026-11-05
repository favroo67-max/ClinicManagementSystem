using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.DAL;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Forms
{
    public partial class FrmPatients : Form
    {
        private readonly PatientDAL _dal = new PatientDAL();
        private List<Patient> _patients = new List<Patient>();
        private int _editingPatientId = 0;
        private bool _isEditing = false;

        public FrmPatients()
        {
            InitializeComponent();
        }

        private async void FrmPatients_Load(object sender, EventArgs e)
        {
            cmbGender.SelectedIndex = 0;
            cmbFilterGender.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Today.AddYears(-25);
            await LoadPatientsAsync();
        }

        // ── Task 6: Multithreading / Async Loading ────────────────────────────
        private async Task LoadPatientsAsync()
        {
            SetLoading(true, "Loading patients...");
            try
            {
                _patients = await _dal.GetAllAsync();
                BindGrid(_patients);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients from database:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void BindGrid(List<Patient> list)
        {
            dgvPatients.Rows.Clear();
            foreach (var p in list)
            {
                dgvPatients.Rows.Add(
                    p.PatientID,
                    p.FullName,
                    p.Gender,
                    p.DateOfBirth.ToString("yyyy-MM-dd"),
                    p.Age,
                    p.Phone,
                    p.Address,
                    string.IsNullOrEmpty(p.MedicalHistoryNotes) ? "None" : p.MedicalHistoryNotes
                );
            }
            lblCount.Text = $"Total Patients: {list.Count}";
        }

        // ── Search & Filter ───────────────────────────────────────────────────
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await TriggerSearchAsync();
        }

        private async void cmbFilterGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            await TriggerSearchAsync();
        }

        private async Task TriggerSearchAsync()
        {
            string keyword = txtSearch.Text.Trim();
            string gender = cmbFilterGender.SelectedIndex > 0
                ? cmbFilterGender.SelectedItem.ToString()
                : null;

            SetLoading(true, "Searching patients...");
            try
            {
                _patients = await _dal.SearchAsync(keyword, gender);
                BindGrid(_patients);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error:\n" + ex.Message, "Search Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterGender.SelectedIndex = 0;
            await LoadPatientsAsync();
        }

        // ── Grid Selection & Form Population ──────────────────────────────────
        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null || dgvPatients.CurrentRow.Index < 0)
                return;

            DataGridViewRow row = dgvPatients.CurrentRow;
            if (row.Cells["colID"].Value == null) return;

            _editingPatientId = Convert.ToInt32(row.Cells["colID"].Value);
            txtName.Text = row.Cells["colName"].Value?.ToString() ?? "";

            string gender = row.Cells["colGender"].Value?.ToString() ?? "Male";
            int gIdx = cmbGender.FindStringExact(gender);
            if (gIdx >= 0) cmbGender.SelectedIndex = gIdx;

            if (DateTime.TryParse(row.Cells["colDOB"].Value?.ToString(), out DateTime dob))
            {
                if (dob <= dtpDOB.MaxDate && dob >= dtpDOB.MinDate)
                    dtpDOB.Value = dob;
            }

            txtPhone.Text = row.Cells["colPhone"].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells["colAddress"].Value?.ToString() ?? "";

            string notes = row.Cells["colNotes"].Value?.ToString() ?? "";
            txtNotes.Text = notes == "None" ? "" : notes;

            _isEditing = true;
            lblFormTitle.Text = "✏ Edit Patient Record";
            btnSave.Text = "Update Patient";
            btnDelete.Enabled = true;
            errorProvider.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _editingPatientId = 0;
            _isEditing = false;
            txtName.Clear();
            cmbGender.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Today.AddYears(-25);
            txtPhone.Clear();
            txtAddress.Clear();
            txtNotes.Clear();
            lblFormTitle.Text = "➕ Register New Patient";
            btnSave.Text = "Save Patient";
            btnDelete.Enabled = false;
            errorProvider.Clear();
            dgvPatients.ClearSelection();
            txtName.Focus();
        }

        // ── Validation (Egyptian Mobile Formats & Requirements) ────────────────
        private bool ValidateForm()
        {
            bool isValid = true;
            errorProvider.Clear();

            // Name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Patient Full Name is required.");
                isValid = false;
            }
            else if (txtName.Text.Trim().Length < 3)
            {
                errorProvider.SetError(txtName, "Name must be at least 3 characters.");
                isValid = false;
            }

            // Gender
            if (cmbGender.SelectedIndex < 0)
            {
                errorProvider.SetError(cmbGender, "Please select a gender.");
                isValid = false;
            }

            // Date of Birth
            if (dtpDOB.Value.Date >= DateTime.Today)
            {
                errorProvider.SetError(dtpDOB, "Date of birth must be in the past.");
                isValid = false;
            }
            else if (dtpDOB.Value.Date < DateTime.Today.AddYears(-125))
            {
                errorProvider.SetError(dtpDOB, "Please enter a realistic date of birth.");
                isValid = false;
            }

            // Phone: Accepts Egyptian 11-digit numbers (010, 011, 012, 015) or standard 10-15 digits
            string phone = txtPhone.Text.Trim().Replace(" ", "").Replace("-", "");
            if (string.IsNullOrWhiteSpace(phone))
            {
                errorProvider.SetError(txtPhone, "Phone number is required.");
                isValid = false;
            }
            else if (!Regex.IsMatch(phone, @"^(01[0125][0-9]{8}|\+?201[0125][0-9]{8}|[0-9]{10,15})$"))
            {
                errorProvider.SetError(txtPhone, "Enter a valid Egyptian mobile number (e.g. 01012345678 or 11 digits).");
                isValid = false;
            }

            // Address
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, "Address / City is required (e.g. 6th of October / Giza / Cairo).");
                isValid = false;
            }

            return isValid;
        }

        // ── Save (Create / Update) ─────────────────────────────────────────────
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string phone = txtPhone.Text.Trim();

            // Phone uniqueness check
            try
            {
                bool exists = await Task.Run(() => _dal.PhoneExists(phone, _editingPatientId));
                if (exists)
                {
                    errorProvider.SetError(txtPhone, "This phone number is already registered for another patient.");
                    MessageBox.Show("Another patient is already registered with this phone number.",
                        "Duplicate Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phone validation error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Patient patient = new Patient
            {
                PatientID = _editingPatientId,
                FullName = txtName.Text.Trim(),
                Gender = cmbGender.SelectedItem.ToString(),
                DateOfBirth = dtpDOB.Value.Date,
                Phone = phone,
                Address = txtAddress.Text.Trim(),
                MedicalHistoryNotes = string.IsNullOrWhiteSpace(txtNotes.Text)
                    ? null
                    : txtNotes.Text.Trim()
            };

            btnSave.Enabled = false;
            SetLoading(true, _isEditing ? "Updating patient..." : "Saving patient...");

            try
            {
                if (_isEditing)
                {
                    await Task.Run(() => _dal.Update(patient));
                    MessageBox.Show("Patient record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await Task.Run(() => _dal.Insert(patient));
                    MessageBox.Show("Patient registered successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadPatientsAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save patient:\n" + ex.Message, "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                SetLoading(false);
            }
        }

        // ── Delete ─────────────────────────────────────────────────────────────
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_editingPatientId == 0) return;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete patient record for '{txtName.Text}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            SetLoading(true, "Deleting patient...");
            btnDelete.Enabled = false;

            try
            {
                await Task.Run(() => _dal.Delete(_editingPatientId));
                MessageBox.Show("Patient record deleted successfully.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPatientsAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete patient:\n" + ex.Message, "Delete Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadPatientsAsync();
        }

        private void SetLoading(bool isLoading, string status = "")
        {
            progressBar.Visible = isLoading;
            lblLoadingStatus.Visible = isLoading;
            lblLoadingStatus.Text = status;
        }
    }
}
