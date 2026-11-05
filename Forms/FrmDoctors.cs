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
    public partial class FrmDoctors : Form
    {
        private readonly DoctorDAL _dal = new DoctorDAL();
        private List<Doctor> _doctors = new List<Doctor>();
        private int _editingDoctorId = 0;
        private bool _isEditing = false;

        public FrmDoctors()
        {
            InitializeComponent();
        }

        private async void FrmDoctors_Load(object sender, EventArgs e)
        {
            await LoadSpecialtiesAsync();
            await LoadDoctorsAsync();
        }

        // ── Task 6: Multithreading / Async Loading ────────────────────────────
        private async Task LoadDoctorsAsync()
        {
            SetLoading(true, "Loading doctors...");
            try
            {
                _doctors = await _dal.GetAllAsync();
                BindGrid(_doctors);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors from database:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async Task LoadSpecialtiesAsync()
        {
            try
            {
                var specs = await Task.Run(() => _dal.GetSpecialties());
                cmbFilterSpecialty.Items.Clear();
                cmbFilterSpecialty.Items.Add("All Specialties");
                foreach (var s in specs)
                {
                    cmbFilterSpecialty.Items.Add(s);
                }
                cmbFilterSpecialty.SelectedIndex = 0;

                cmbSpecialty.Items.Clear();
                string[] defaults = {
                    "Cardiology", "Dermatology", "Endocrinology", "Gastroenterology",
                    "General Practice", "Gynecology", "Internal Medicine", "Neurology",
                    "Oncology", "Ophthalmology", "Orthopedics", "Pediatrics",
                    "Psychiatry", "Pulmonology", "Radiology", "Urology"
                };
                foreach (var d in defaults)
                {
                    cmbSpecialty.Items.Add(d);
                }
                foreach (var s in specs)
                {
                    if (cmbSpecialty.FindStringExact(s) < 0)
                        cmbSpecialty.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Specialty load error: " + ex.Message);
            }
        }

        private void BindGrid(List<Doctor> list)
        {
            dgvDoctors.Rows.Clear();
            foreach (var d in list)
            {
                dgvDoctors.Rows.Add(
                    d.DoctorID,
                    d.FullName,
                    d.Specialty,
                    d.Phone,
                    d.Email,
                    d.WorkingDays,
                    d.ConsultationFee.ToString("N0") + " EGP"
                );
            }
            lblCount.Text = $"Total Doctors: {list.Count}";
        }

        // ── Search & Filtering ────────────────────────────────────────────────
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await TriggerSearchAsync();
        }

        private async void cmbFilterSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            await TriggerSearchAsync();
        }

        private async Task TriggerSearchAsync()
        {
            string keyword = txtSearch.Text.Trim();
            string specialty = cmbFilterSpecialty.SelectedIndex > 0
                ? cmbFilterSpecialty.SelectedItem.ToString()
                : null;

            SetLoading(true, "Searching...");
            try
            {
                _doctors = await _dal.SearchAsync(keyword, specialty);
                BindGrid(_doctors);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed:\n" + ex.Message, "Search Error",
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
            if (cmbFilterSpecialty.Items.Count > 0)
                cmbFilterSpecialty.SelectedIndex = 0;
            await LoadDoctorsAsync();
        }

        // ── Grid Selection & Form Population ──────────────────────────────────
        private void dgvDoctors_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoctors.CurrentRow == null || dgvDoctors.CurrentRow.Index < 0)
                return;

            DataGridViewRow row = dgvDoctors.CurrentRow;
            if (row.Cells["colID"].Value == null) return;

            _editingDoctorId = Convert.ToInt32(row.Cells["colID"].Value);
            txtName.Text = row.Cells["colName"].Value?.ToString() ?? "";

            string spec = row.Cells["colSpecialty"].Value?.ToString() ?? "";
            int specIdx = cmbSpecialty.FindStringExact(spec);
            if (specIdx >= 0) cmbSpecialty.SelectedIndex = specIdx;
            else
            {
                cmbSpecialty.Items.Add(spec);
                cmbSpecialty.SelectedItem = spec;
            }

            txtPhone.Text = row.Cells["colPhone"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString() ?? "";
            txtWorkDays.Text = row.Cells["colDays"].Value?.ToString() ?? "";

            string feeRaw = row.Cells["colFee"].Value?.ToString() ?? "0";
            feeRaw = feeRaw.Replace("EGP", "").Replace("SAR", "").Replace("$", "").Replace(",", "").Trim();
            txtFee.Text = feeRaw;

            _isEditing = true;
            lblFormTitle.Text = "✏ Edit Doctor Record";
            btnSave.Text = "Update Doctor";
            btnDelete.Enabled = true;
            errorProvider.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _editingDoctorId = 0;
            _isEditing = false;
            txtName.Clear();
            cmbSpecialty.SelectedIndex = -1;
            cmbSpecialty.Text = string.Empty;
            txtPhone.Clear();
            txtEmail.Clear();
            txtWorkDays.Clear();
            txtFee.Clear();
            lblFormTitle.Text = "➕ Add New Doctor";
            btnSave.Text = "Save Doctor";
            btnDelete.Enabled = false;
            errorProvider.Clear();
            dgvDoctors.ClearSelection();
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
                errorProvider.SetError(txtName, "Full Name is required.");
                isValid = false;
            }
            else if (txtName.Text.Trim().Length < 3)
            {
                errorProvider.SetError(txtName, "Name must be at least 3 characters.");
                isValid = false;
            }

            // Specialty
            string specialty = cmbSpecialty.SelectedIndex >= 0
                ? cmbSpecialty.SelectedItem.ToString()
                : cmbSpecialty.Text.Trim();
            if (string.IsNullOrWhiteSpace(specialty))
            {
                errorProvider.SetError(cmbSpecialty, "Specialty is required.");
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
                errorProvider.SetError(txtPhone, "Please enter a valid Egyptian mobile number (e.g. 01001122334).");
                isValid = false;
            }

            // Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email address is required.");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider.SetError(txtEmail, "Invalid email address format (e.g. doctor@mustclinic.eg).");
                isValid = false;
            }

            // Working Days
            if (string.IsNullOrWhiteSpace(txtWorkDays.Text))
            {
                errorProvider.SetError(txtWorkDays, "Working Days are required (e.g. Sun, Tue, Thu).");
                isValid = false;
            }

            // Consultation Fee
            if (string.IsNullOrWhiteSpace(txtFee.Text))
            {
                errorProvider.SetError(txtFee, "Consultation Fee in EGP is required.");
                isValid = false;
            }
            else if (!decimal.TryParse(txtFee.Text.Trim(), out decimal fee) || fee < 0)
            {
                errorProvider.SetError(txtFee, "Consultation fee must be a valid positive amount in EGP.");
                isValid = false;
            }

            return isValid;
        }

        // ── Save (Create / Update) ─────────────────────────────────────────────
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string email = txtEmail.Text.Trim();
            string specialty = cmbSpecialty.SelectedIndex >= 0
                ? cmbSpecialty.SelectedItem.ToString()
                : cmbSpecialty.Text.Trim();

            // Duplicate Email check
            try
            {
                bool exists = await Task.Run(() => _dal.EmailExists(email, _editingDoctorId));
                if (exists)
                {
                    errorProvider.SetError(txtEmail, "A doctor with this email is already registered.");
                    MessageBox.Show("A doctor with this email address already exists. Please choose a different email.",
                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email validation error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Doctor doctor = new Doctor
            {
                DoctorID = _editingDoctorId,
                FullName = txtName.Text.Trim(),
                Specialty = specialty,
                Phone = txtPhone.Text.Trim(),
                Email = email,
                WorkingDays = txtWorkDays.Text.Trim(),
                ConsultationFee = decimal.Parse(txtFee.Text.Trim())
            };

            btnSave.Enabled = false;
            SetLoading(true, _isEditing ? "Updating doctor..." : "Saving doctor...");

            try
            {
                if (_isEditing)
                {
                    await Task.Run(() => _dal.Update(doctor));
                    MessageBox.Show("Doctor record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await Task.Run(() => _dal.Insert(doctor));
                    MessageBox.Show("Doctor registered successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadDoctorsAsync();
                await LoadSpecialtiesAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save doctor:\n" + ex.Message, "Save Error",
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
            if (_editingDoctorId == 0) return;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to deactivate and remove '{txtName.Text}' from active doctors?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            SetLoading(true, "Deleting doctor...");
            btnDelete.Enabled = false;

            try
            {
                await Task.Run(() => _dal.Delete(_editingDoctorId));
                MessageBox.Show("Doctor deleted successfully.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDoctorsAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete doctor:\n" + ex.Message, "Delete Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDoctorsAsync();
        }

        private void SetLoading(bool isLoading, string status = "")
        {
            progressBar.Visible = isLoading;
            lblLoadingStatus.Visible = isLoading;
            lblLoadingStatus.Text = status;
        }
    }
}
