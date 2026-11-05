namespace ClinicManagementSystem.Forms
{
    partial class FrmDoctors
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblLoadingStatus = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblSearchLabel = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterLabel = new System.Windows.Forms.Label();
            this.cmbFilterSpecialty = new System.Windows.Forms.ComboBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecialty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSpecialty = new System.Windows.Forms.Label();
            this.cmbSpecialty = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblWorkDays = new System.Windows.Forms.Label();
            this.txtWorkDays = new System.Windows.Forms.TextBox();
            this.lblFee = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            // errorProvider
            this.errorProvider.ContainerControl = this;

            // progressBar
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Height = 4;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Visible = false;

            // lblLoadingStatus
            this.lblLoadingStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoadingStatus.Height = 20;
            this.lblLoadingStatus.BackColor = System.Drawing.Color.FromArgb(230, 244, 241);
            this.lblLoadingStatus.ForeColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.lblLoadingStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblLoadingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoadingStatus.Visible = false;

            // ── pnlTop (Search & Filter Bar) ──────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 65;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12, 14, 12, 10);
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPageTitle,
                this.lblSearchLabel,
                this.txtSearch,
                this.lblFilterLabel,
                this.cmbFilterSpecialty,
                this.btnClearSearch,
                this.btnNew,
                this.btnRefresh,
                this.lblCount
            });

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblPageTitle.Location = new System.Drawing.Point(12, 18);
            this.lblPageTitle.Text = "👨‍⚕️ Doctors Directory";

            // lblSearchLabel
            this.lblSearchLabel.AutoSize = true;
            this.lblSearchLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSearchLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSearchLabel.Location = new System.Drawing.Point(215, 8);
            this.lblSearchLabel.Text = "Search by Name / Phone:";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(218, 26);
            this.txtSearch.Size = new System.Drawing.Size(180, 25);
            this.txtSearch.PlaceholderText = "Type doctor name...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblFilterLabel
            this.lblFilterLabel.AutoSize = true;
            this.lblFilterLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFilterLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblFilterLabel.Location = new System.Drawing.Point(408, 8);
            this.lblFilterLabel.Text = "Filter by Specialty:";

            // cmbFilterSpecialty
            this.cmbFilterSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterSpecialty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFilterSpecialty.Location = new System.Drawing.Point(410, 26);
            this.cmbFilterSpecialty.Size = new System.Drawing.Size(160, 25);
            this.cmbFilterSpecialty.SelectedIndexChanged += new System.EventHandler(this.cmbFilterSpecialty_SelectedIndexChanged);

            // btnClearSearch
            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnClearSearch.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnClearSearch.Location = new System.Drawing.Point(578, 25);
            this.btnClearSearch.Size = new System.Drawing.Size(60, 27);
            this.btnClearSearch.Text = "Reset";
            this.btnClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);

            // btnNew
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(650, 24);
            this.btnNew.Size = new System.Drawing.Size(110, 29);
            this.btnNew.Text = "+ Add Doctor";
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(768, 24);
            this.btnRefresh.Size = new System.Drawing.Size(80, 29);
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lblCount
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblCount.Location = new System.Drawing.Point(860, 28);
            this.lblCount.Size = new System.Drawing.Size(130, 20);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Text = "Total Doctors: 0";

            // ── dgvDoctors ────────────────────────────────────────────────────
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.AllowUserToDeleteRows = false;
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctors.MultiSelect = false;
            this.dgvDoctors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoctors.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoctors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDoctors.RowHeadersVisible = false;
            this.dgvDoctors.Dock = System.Windows.Forms.DockStyle.Fill;

            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvDoctors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoctors.ColumnHeadersHeight = 36;
            this.dgvDoctors.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.dgvDoctors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDoctors.RowTemplate.Height = 30;
            this.dgvDoctors.SelectionChanged += new System.EventHandler(this.dgvDoctors_SelectionChanged);

            // Columns
            this.colID.Name = "colID";
            this.colID.HeaderText = "ID";
            this.colID.FillWeight = 20;
            this.colID.Visible = false;

            this.colName.Name = "colName";
            this.colName.HeaderText = "Full Name";
            this.colName.FillWeight = 130;

            this.colSpecialty.Name = "colSpecialty";
            this.colSpecialty.HeaderText = "Specialty";
            this.colSpecialty.FillWeight = 110;

            this.colPhone.Name = "colPhone";
            this.colPhone.HeaderText = "Phone";
            this.colPhone.FillWeight = 90;

            this.colEmail.Name = "colEmail";
            this.colEmail.HeaderText = "Email";
            this.colEmail.FillWeight = 130;

            this.colDays.Name = "colDays";
            this.colDays.HeaderText = "Working Days";
            this.colDays.FillWeight = 120;

            this.colFee.Name = "colFee";
            this.colFee.HeaderText = "Fee (EGP)";
            this.colFee.FillWeight = 90;

            this.dgvDoctors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colName, this.colSpecialty, this.colPhone, this.colEmail, this.colDays, this.colFee
            });

            // ── pnlForm (CRUD Side Editor) ────────────────────────────────────
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlForm.Width = 330;
            this.pnlForm.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pnlForm.AutoScroll = true;

            // Form Title
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.lblFormTitle.Location = new System.Drawing.Point(18, 12);
            this.lblFormTitle.Size = new System.Drawing.Size(290, 28);
            this.lblFormTitle.Text = "➕ Add New Doctor";

            // Helper macro for form labels and fields
            int y = 46;

            // Name
            this.lblName.Text = "Doctor Full Name *";
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblName.Location = new System.Drawing.Point(18, y);
            this.lblName.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtName.Location = new System.Drawing.Point(18, y);
            this.txtName.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Specialty
            this.lblSpecialty.Text = "Specialty *";
            this.lblSpecialty.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSpecialty.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblSpecialty.Location = new System.Drawing.Point(18, y);
            this.lblSpecialty.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.cmbSpecialty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSpecialty.Location = new System.Drawing.Point(18, y);
            this.cmbSpecialty.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Phone
            this.lblPhone.Text = "Phone Number *";
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblPhone.Location = new System.Drawing.Point(18, y);
            this.lblPhone.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhone.Location = new System.Drawing.Point(18, y);
            this.txtPhone.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Email
            this.lblEmail.Text = "Email Address *";
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblEmail.Location = new System.Drawing.Point(18, y);
            this.lblEmail.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location = new System.Drawing.Point(18, y);
            this.txtEmail.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Working Days
            this.lblWorkDays.Text = "Working Days * (e.g. Sun,Tue,Thu)";
            this.lblWorkDays.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblWorkDays.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblWorkDays.Location = new System.Drawing.Point(18, y);
            this.lblWorkDays.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtWorkDays.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtWorkDays.Location = new System.Drawing.Point(18, y);
            this.txtWorkDays.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Fee
            this.lblFee.Text = "Consultation Fee (EGP) *";
            this.lblFee.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFee.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblFee.Location = new System.Drawing.Point(18, y);
            this.lblFee.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtFee.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFee.Location = new System.Drawing.Point(18, y);
            this.txtFee.Size = new System.Drawing.Size(280, 25);
            y += 42;

            // Save Button
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(18, y);
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.Text = "Save Doctor";
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Delete Button
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(164, y);
            this.btnDelete.Size = new System.Drawing.Size(65, 36);
            this.btnDelete.Text = "Delete";
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Enabled = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Cancel Button
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.btnCancel.Location = new System.Drawing.Point(234, y);
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancel.Click += new System.EventHandler(this.btnNew_Click);

            this.pnlForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFormTitle,
                this.lblName, this.txtName,
                this.lblSpecialty, this.cmbSpecialty,
                this.lblPhone, this.txtPhone,
                this.lblEmail, this.txtEmail,
                this.lblWorkDays, this.txtWorkDays,
                this.lblFee, this.txtFee,
                this.btnSave, this.btnDelete, this.btnCancel
            });

            // ── FrmDoctors ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblLoadingStatus);
            this.Controls.Add(this.progressBar);
            this.Name = "FrmDoctors";
            this.Text = "Doctors Management";
            this.Load += new System.EventHandler(this.FrmDoctors_Load);

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblLoadingStatus;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblSearchLabel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterLabel;
        private System.Windows.Forms.ComboBox cmbFilterSpecialty;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvDoctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecialty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFee;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSpecialty;
        private System.Windows.Forms.ComboBox cmbSpecialty;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblWorkDays;
        private System.Windows.Forms.TextBox txtWorkDays;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
    }
}
