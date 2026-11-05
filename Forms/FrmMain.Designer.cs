namespace ClinicManagementSystem.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblSidebarBrand = new System.Windows.Forms.Label();
            this.lblSidebarBrandSub = new System.Windows.Forms.Label();
            this.pnlBrandDivider = new System.Windows.Forms.Panel();
            this.lblNavSectionCore = new System.Windows.Forms.Label();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavDoctors = new System.Windows.Forms.Button();
            this.btnNavPatients = new System.Windows.Forms.Button();
            this.lblNavSectionPhase2 = new System.Windows.Forms.Label();
            this.btnNavAppointments = new System.Windows.Forms.Button();
            this.btnNavQueue = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderClinic = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblUserBadge = new System.Windows.Forms.Label();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlDashboardHome = new System.Windows.Forms.Panel();
            this.lblDashGreeting = new System.Windows.Forms.Label();
            this.lblDashSubGreeting = new System.Windows.Forms.Label();
            this.pnlCardDoctors = new System.Windows.Forms.Panel();
            this.lblCardDocIcon = new System.Windows.Forms.Label();
            this.lblCardDocTitle = new System.Windows.Forms.Label();
            this.lblCardDocDesc = new System.Windows.Forms.Label();
            this.btnCardDoctors = new System.Windows.Forms.Button();
            this.pnlCardPatients = new System.Windows.Forms.Panel();
            this.lblCardPatIcon = new System.Windows.Forms.Label();
            this.lblCardPatTitle = new System.Windows.Forms.Label();
            this.lblCardPatDesc = new System.Windows.Forms.Label();
            this.btnCardPatients = new System.Windows.Forms.Button();
            this.pnlCardPhase2Info = new System.Windows.Forms.Panel();
            this.lblPhase2CardTitle = new System.Windows.Forms.Label();
            this.lblPhase2CardDesc = new System.Windows.Forms.Label();
            this.pnlPhase2Notice = new System.Windows.Forms.Panel();
            this.lblPhase2NoticeIcon = new System.Windows.Forms.Label();
            this.lblPhase2Title = new System.Windows.Forms.Label();
            this.lblPhase2Desc = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.pnlDashboardHome.SuspendLayout();
            this.pnlCardDoctors.SuspendLayout();
            this.pnlCardPatients.SuspendLayout();
            this.pnlCardPhase2Info.SuspendLayout();
            this.pnlPhase2Notice.SuspendLayout();
            this.SuspendLayout();

            // ── Sidebar Panel ─────────────────────────────────────────────────
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 230;
            this.pnlSidebar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSidebarBrand,
                this.lblSidebarBrandSub,
                this.pnlBrandDivider,
                this.lblNavSectionCore,
                this.btnNavDashboard,
                this.btnNavDoctors,
                this.btnNavPatients,
                this.lblNavSectionPhase2,
                this.btnNavAppointments,
                this.btnNavQueue,
                this.btnNavReports,
                this.btnLogout
            });

            // Brand
            this.lblSidebarBrand.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblSidebarBrand.ForeColor = System.Drawing.Color.White;
            this.lblSidebarBrand.Location = new System.Drawing.Point(0, 16);
            this.lblSidebarBrand.Size = new System.Drawing.Size(230, 28);
            this.lblSidebarBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSidebarBrand.Text = "🏥 Doctor Appointments";

            this.lblSidebarBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSidebarBrandSub.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblSidebarBrandSub.Location = new System.Drawing.Point(0, 44);
            this.lblSidebarBrandSub.Size = new System.Drawing.Size(230, 16);
            this.lblSidebarBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSidebarBrandSub.Text = "Doctor Appointment System v1.0";

            this.pnlBrandDivider.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlBrandDivider.Location = new System.Drawing.Point(18, 68);
            this.pnlBrandDivider.Size = new System.Drawing.Size(194, 1);

            int btnY = 82;

            // Section 1 Header: Core Modules
            this.lblNavSectionCore.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblNavSectionCore.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblNavSectionCore.Location = new System.Drawing.Point(18, btnY);
            this.lblNavSectionCore.Size = new System.Drawing.Size(194, 16);
            this.lblNavSectionCore.Text = "PHASE 1 - CORE MODULES";
            btnY += 20;

            System.Action<System.Windows.Forms.Button, string, int, bool> setupNav = (btn, text, yPos, isP2) => {
                btn.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
                btn.ForeColor = isP2 ? System.Drawing.Color.FromArgb(189, 195, 199) : System.Drawing.Color.White;
                btn.Location = new System.Drawing.Point(0, yPos);
                btn.Size = new System.Drawing.Size(230, 42);
                btn.Text = text;
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            };

            setupNav(this.btnNavDashboard, "📊  Dashboard Overview", btnY, false);
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            btnY += 44;

            setupNav(this.btnNavDoctors, "👨‍⚕️  Doctors Directory", btnY, false);
            this.btnNavDoctors.Click += new System.EventHandler(this.btnNavDoctors_Click);
            btnY += 44;

            setupNav(this.btnNavPatients, "🧑  Patients Registry", btnY, false);
            this.btnNavPatients.Click += new System.EventHandler(this.btnNavPatients_Click);
            btnY += 56;

            // Section 2 Header: Phase 2 Placeholders
            this.lblNavSectionPhase2.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblNavSectionPhase2.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblNavSectionPhase2.Location = new System.Drawing.Point(18, btnY);
            this.lblNavSectionPhase2.Size = new System.Drawing.Size(194, 16);
            this.lblNavSectionPhase2.Text = "PHASE 2 (NEXT 50%)";
            btnY += 20;

            setupNav(this.btnNavAppointments, "📅  Appointments  [P2]", btnY, true);
            this.btnNavAppointments.Click += new System.EventHandler(this.btnNavAppointments_Click);
            btnY += 44;

            setupNav(this.btnNavQueue, "⏱  Waiting Queue  [P2]", btnY, true);
            this.btnNavQueue.Click += new System.EventHandler(this.btnNavQueue_Click);
            btnY += 44;

            setupNav(this.btnNavReports, "📈  Reports & Stats  [P2]", btnY, true);
            this.btnNavReports.Click += new System.EventHandler(this.btnNavReports_Click);

            // Logout Button
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(18, 590);
            this.btnLogout.Size = new System.Drawing.Size(194, 38);
            this.btnLogout.Text = "🚪  Log Out";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ── Header Panel ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 55;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblHeaderClinic,
                this.lblCurrentDate,
                this.lblClock,
                this.lblUserBadge
            });

            this.lblHeaderClinic.AutoSize = true;
            this.lblHeaderClinic.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderClinic.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblHeaderClinic.Location = new System.Drawing.Point(18, 16);
            this.lblHeaderClinic.Text = "CS312 - Doctor Appointment System";

            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.lblClock.Location = new System.Drawing.Point(620, 18);
            this.lblClock.Size = new System.Drawing.Size(95, 20);
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCurrentDate.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCurrentDate.Location = new System.Drawing.Point(430, 18);
            this.lblCurrentDate.Size = new System.Drawing.Size(180, 20);
            this.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblUserBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserBadge.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.lblUserBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserBadge.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblUserBadge.Location = new System.Drawing.Point(730, 12);
            this.lblUserBadge.Size = new System.Drawing.Size(180, 30);
            this.lblUserBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Main Content Container ────────────────────────────────────────
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Controls.Add(this.pnlDashboardHome);

            // ── Dashboard Home Panel ──────────────────────────────────────────
            this.pnlDashboardHome.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlDashboardHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboardHome.Padding = new System.Windows.Forms.Padding(30, 25, 30, 25);
            this.pnlDashboardHome.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDashGreeting,
                this.lblDashSubGreeting,
                this.pnlCardDoctors,
                this.pnlCardPatients,
                this.pnlCardPhase2Info
            });

            this.lblDashGreeting.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDashGreeting.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblDashGreeting.Location = new System.Drawing.Point(30, 25);
            this.lblDashGreeting.Size = new System.Drawing.Size(650, 36);
            this.lblDashGreeting.Text = "Welcome to Doctor Appointment System";

            this.lblDashSubGreeting.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDashSubGreeting.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblDashSubGreeting.Location = new System.Drawing.Point(32, 63);
            this.lblDashSubGreeting.Size = new System.Drawing.Size(700, 24);
            this.lblDashSubGreeting.Text = "Phase 1: Core Foundation, Portable Database, Authentication, Doctors, and Patients modules are ready.";

            // Card 1: Doctors Shortcut
            this.pnlCardDoctors.BackColor = System.Drawing.Color.White;
            this.pnlCardDoctors.Location = new System.Drawing.Point(34, 105);
            this.pnlCardDoctors.Size = new System.Drawing.Size(300, 180);
            this.pnlCardDoctors.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCardDocIcon,
                this.lblCardDocTitle,
                this.lblCardDocDesc,
                this.btnCardDoctors
            });

            this.lblCardDocIcon.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.lblCardDocIcon.Location = new System.Drawing.Point(16, 12);
            this.lblCardDocIcon.Size = new System.Drawing.Size(55, 50);
            this.lblCardDocIcon.Text = "👨‍⚕️";

            this.lblCardDocTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCardDocTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblCardDocTitle.Location = new System.Drawing.Point(75, 18);
            this.lblCardDocTitle.Size = new System.Drawing.Size(200, 26);
            this.lblCardDocTitle.Text = "Doctors Module";

            this.lblCardDocDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCardDocDesc.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCardDocDesc.Location = new System.Drawing.Point(20, 70);
            this.lblCardDocDesc.Size = new System.Drawing.Size(260, 48);
            this.lblCardDocDesc.Text = "Manage doctor profiles, specialties, contact info, working days, and consultation fees.";

            this.btnCardDoctors.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.btnCardDoctors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardDoctors.FlatAppearance.BorderSize = 0;
            this.btnCardDoctors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCardDoctors.ForeColor = System.Drawing.Color.White;
            this.btnCardDoctors.Location = new System.Drawing.Point(20, 126);
            this.btnCardDoctors.Size = new System.Drawing.Size(260, 34);
            this.btnCardDoctors.Text = "Open Doctors Management →";
            this.btnCardDoctors.Click += new System.EventHandler(this.btnCardDoctors_Click);

            // Card 2: Patients Shortcut
            this.pnlCardPatients.BackColor = System.Drawing.Color.White;
            this.pnlCardPatients.Location = new System.Drawing.Point(360, 105);
            this.pnlCardPatients.Size = new System.Drawing.Size(300, 180);
            this.pnlCardPatients.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCardPatIcon,
                this.lblCardPatTitle,
                this.lblCardPatDesc,
                this.btnCardPatients
            });

            this.lblCardPatIcon.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.lblCardPatIcon.Location = new System.Drawing.Point(16, 12);
            this.lblCardPatIcon.Size = new System.Drawing.Size(55, 50);
            this.lblCardPatIcon.Text = "🧑";

            this.lblCardPatTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCardPatTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblCardPatTitle.Location = new System.Drawing.Point(75, 18);
            this.lblCardPatTitle.Size = new System.Drawing.Size(200, 26);
            this.lblCardPatTitle.Text = "Patients Module";

            this.lblCardPatDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCardPatDesc.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCardPatDesc.Location = new System.Drawing.Point(20, 70);
            this.lblCardPatDesc.Size = new System.Drawing.Size(260, 48);
            this.lblCardPatDesc.Text = "Register patients, manage contact details, view computed age, and update medical history notes.";

            this.btnCardPatients.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnCardPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardPatients.FlatAppearance.BorderSize = 0;
            this.btnCardPatients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCardPatients.ForeColor = System.Drawing.Color.White;
            this.btnCardPatients.Location = new System.Drawing.Point(20, 126);
            this.btnCardPatients.Size = new System.Drawing.Size(260, 34);
            this.btnCardPatients.Text = "Open Patients Registry →";
            this.btnCardPatients.Click += new System.EventHandler(this.btnCardPatients_Click);

            // Card 3: Phase 2 Roadmap & Scope
            this.pnlCardPhase2Info.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlCardPhase2Info.Location = new System.Drawing.Point(34, 305);
            this.pnlCardPhase2Info.Size = new System.Drawing.Size(626, 120);
            this.pnlCardPhase2Info.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPhase2CardTitle,
                this.lblPhase2CardDesc
            });

            this.lblPhase2CardTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPhase2CardTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblPhase2CardTitle.Location = new System.Drawing.Point(18, 14);
            this.lblPhase2CardTitle.Size = new System.Drawing.Size(590, 22);
            this.lblPhase2CardTitle.Text = "📌 Phase 2 Scope Boundary (The Other 50%)";

            this.lblPhase2CardDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhase2CardDesc.ForeColor = System.Drawing.Color.FromArgb(100, 110, 120);
            this.lblPhase2CardDesc.Location = new System.Drawing.Point(18, 40);
            this.lblPhase2CardDesc.Size = new System.Drawing.Size(590, 68);
            this.lblPhase2CardDesc.Text = "To maintain an exact 50% division of work, Appointments Booking, Waiting Room Queue Tracker, GDI+ Graphics, Statistical Charts, and Client-Server Socket Notifications are designated for Phase 2.\nThe Database table schema for Appointments is already provisioned!";

            // ── Phase 2 Notice Placeholder Screen ─────────────────────────────
            this.pnlPhase2Notice.BackColor = System.Drawing.Color.White;
            this.pnlPhase2Notice.Padding = new System.Windows.Forms.Padding(40);
            this.pnlPhase2Notice.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPhase2NoticeIcon,
                this.lblPhase2Title,
                this.lblPhase2Desc
            });

            this.lblPhase2NoticeIcon.Font = new System.Drawing.Font("Segoe UI", 48F);
            this.lblPhase2NoticeIcon.Location = new System.Drawing.Point(40, 60);
            this.lblPhase2NoticeIcon.Size = new System.Drawing.Size(100, 90);
            this.lblPhase2NoticeIcon.Text = "🔒";

            this.lblPhase2Title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPhase2Title.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblPhase2Title.Location = new System.Drawing.Point(40, 160);
            this.lblPhase2Title.Size = new System.Drawing.Size(650, 40);
            this.lblPhase2Title.Text = "Module Reserved for Phase 2";

            this.lblPhase2Desc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPhase2Desc.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblPhase2Desc.Location = new System.Drawing.Point(40, 215);
            this.lblPhase2Desc.Size = new System.Drawing.Size(650, 120);

            // Timer
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // ── FrmMain ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 650);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor Appointment System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlDashboardHome.ResumeLayout(false);
            this.pnlCardDoctors.ResumeLayout(false);
            this.pnlCardPatients.ResumeLayout(false);
            this.pnlCardPhase2Info.ResumeLayout(false);
            this.pnlPhase2Notice.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarBrand;
        private System.Windows.Forms.Label lblSidebarBrandSub;
        private System.Windows.Forms.Panel pnlBrandDivider;
        private System.Windows.Forms.Label lblNavSectionCore;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavDoctors;
        private System.Windows.Forms.Button btnNavPatients;
        private System.Windows.Forms.Label lblNavSectionPhase2;
        private System.Windows.Forms.Button btnNavAppointments;
        private System.Windows.Forms.Button btnNavQueue;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderClinic;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblUserBadge;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlDashboardHome;
        private System.Windows.Forms.Label lblDashGreeting;
        private System.Windows.Forms.Label lblDashSubGreeting;
        private System.Windows.Forms.Panel pnlCardDoctors;
        private System.Windows.Forms.Label lblCardDocIcon;
        private System.Windows.Forms.Label lblCardDocTitle;
        private System.Windows.Forms.Label lblCardDocDesc;
        private System.Windows.Forms.Button btnCardDoctors;
        private System.Windows.Forms.Panel pnlCardPatients;
        private System.Windows.Forms.Label lblCardPatIcon;
        private System.Windows.Forms.Label lblCardPatTitle;
        private System.Windows.Forms.Label lblCardPatDesc;
        private System.Windows.Forms.Button btnCardPatients;
        private System.Windows.Forms.Panel pnlCardPhase2Info;
        private System.Windows.Forms.Label lblPhase2CardTitle;
        private System.Windows.Forms.Label lblPhase2CardDesc;
        private System.Windows.Forms.Panel pnlPhase2Notice;
        private System.Windows.Forms.Label lblPhase2NoticeIcon;
        private System.Windows.Forms.Label lblPhase2Title;
        private System.Windows.Forms.Label lblPhase2Desc;
        private System.Windows.Forms.Timer timerClock;
    }
}
