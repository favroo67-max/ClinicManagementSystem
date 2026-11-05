using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Forms
{
    public partial class FrmMain : Form
    {
        private Form _activeChildForm = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            User user = FrmLogin.CurrentUser;
            if (user != null)
            {
                lblUserBadge.Text = $"👤 {user.Username} ({user.Role})";
            }
            else
            {
                lblUserBadge.Text = "👤 User (Admin)";
            }

            lblCurrentDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            timerClock.Start();

            // Default view: Dashboard home
            ShowDashboardHome();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        // ── Child Form Hosting ────────────────────────────────────────────────
        private void OpenChildForm(Form childForm, Button navBtn)
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Close();
                _activeChildForm.Dispose();
                _activeChildForm = null;
            }

            pnlMainContainer.Controls.Clear();
            HighlightNavButton(navBtn);

            _activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(childForm);
            pnlMainContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ShowDashboardHome()
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Close();
                _activeChildForm.Dispose();
                _activeChildForm = null;
            }

            pnlMainContainer.Controls.Clear();
            pnlMainContainer.Controls.Add(pnlDashboardHome);
            pnlDashboardHome.Dock = DockStyle.Fill;
            pnlDashboardHome.BringToFront();

            HighlightNavButton(btnNavDashboard);
        }

        private void HighlightNavButton(Button activeBtn)
        {
            Color normalBack = Color.FromArgb(44, 62, 80);
            Color activeBack = Color.FromArgb(22, 160, 133);

            Button[] navButtons = {
                btnNavDashboard, btnNavDoctors, btnNavPatients,
                btnNavAppointments, btnNavQueue, btnNavReports
            };

            foreach (var b in navButtons)
            {
                if (b == null) continue;
                if (b == activeBtn)
                {
                    b.BackColor = activeBack;
                    b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else
                {
                    b.BackColor = normalBack;
                    b.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }
            }
        }

        // ── Navigation Clicks ─────────────────────────────────────────────────
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboardHome();
        }

        private void btnNavDoctors_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDoctors(), btnNavDoctors);
        }

        private void btnNavPatients_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmPatients(), btnNavPatients);
        }

        // ── Phase 2 Placeholders ──────────────────────────────────────────────
        private void btnNavAppointments_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavAppointments);
            ShowPhase2Notice(
                "Appointments Booking & Cancellation",
                "This module will handle scheduling time slots, checking doctor availability, and cancelling appointments."
            );
        }

        private void btnNavQueue_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavQueue);
            ShowPhase2Notice(
                "Waiting Room Queue Tracker",
                "This module will manage live patient queues in the waiting room and track consultation states."
            );
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavReports);
            ShowPhase2Notice(
                "Reports & Statistical Charts",
                "This module will generate monthly/annual appointment analytics, patient demographics, and financial summaries."
            );
        }

        private void ShowPhase2Notice(string featureName, string description)
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Close();
                _activeChildForm.Dispose();
                _activeChildForm = null;
            }

            pnlMainContainer.Controls.Clear();
            pnlPhase2Notice.Dock = DockStyle.Fill;
            lblPhase2Title.Text = $"🔒 {featureName}";
            lblPhase2Desc.Text = description + "\n\n⚠️ As per the specification, this feature is strictly OUT OF SCOPE for Phase 1 and will be built in Phase 2.";
            pnlMainContainer.Controls.Add(pnlPhase2Notice);
            pnlPhase2Notice.BringToFront();
        }

        // ── Dashboard Quick Shortcuts ─────────────────────────────────────────
        private void btnCardDoctors_Click(object sender, EventArgs e)
        {
            btnNavDoctors_Click(sender, e);
        }

        private void btnCardPatients_Click(object sender, EventArgs e)
        {
            btnNavPatients_Click(sender, e);
        }

        // ── Logout & Exit ─────────────────────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Are you sure you want to log out of Doctor Appointment System?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Hide();
                FrmLogin login = new FrmLogin();
                login.Show();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
