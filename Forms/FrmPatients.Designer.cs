namespace ClinicManagementSystem.Forms
{
    partial class FrmPatients
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
            this.cmbFilterGender = new System.Windows.Forms.ComboBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
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
            this.lblLoadingStatus.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lblLoadingStatus.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
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
                this.cmbFilterGender,
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
            this.lblPageTitle.Text = "🧑 Patients Registry";

            // lblSearchLabel
            this.lblSearchLabel.AutoSize = true;
            this.lblSearchLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSearchLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSearchLabel.Location = new System.Drawing.Point(215, 8);
            this.lblSearchLabel.Text = "Search by Name or Phone:";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(218, 26);
            this.txtSearch.Size = new System.Drawing.Size(185, 25);
            this.txtSearch.PlaceholderText = "Search name or phone...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblFilterLabel
            this.lblFilterLabel.AutoSize = true;
            this.lblFilterLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFilterLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblFilterLabel.Location = new System.Drawing.Point(413, 8);
            this.lblFilterLabel.Text = "Filter by Gender:";

            // cmbFilterGender
            this.cmbFilterGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterGender.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFilterGender.Items.AddRange(new object[] { "All Genders", "Male", "Female", "Other" });
            this.cmbFilterGender.Location = new System.Drawing.Point(415, 26);
            this.cmbFilterGender.Size = new System.Drawing.Size(125, 25);
            this.cmbFilterGender.SelectedIndexChanged += new System.EventHandler(this.cmbFilterGender_SelectedIndexChanged);

            // btnClearSearch
            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnClearSearch.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnClearSearch.Location = new System.Drawing.Point(548, 25);
            this.btnClearSearch.Size = new System.Drawing.Size(58, 27);
            this.btnClearSearch.Text = "Reset";
            this.btnClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);

            // btnNew
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(614, 24);
            this.btnNew.Size = new System.Drawing.Size(115, 29);
            this.btnNew.Text = "+ Add Patient";
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(735, 24);
            this.btnRefresh.Size = new System.Drawing.Size(80, 29);
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lblCount
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblCount.Location = new System.Drawing.Point(825, 28);
            this.lblCount.Size = new System.Drawing.Size(165, 20);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Text = "Total Patients: 0";

            // ── dgvPatients ───────────────────────────────────────────────────
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;

            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatients.ColumnHeadersHeight = 36;
            this.dgvPatients.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.dgvPatients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatients.RowTemplate.Height = 30;
            this.dgvPatients.SelectionChanged += new System.EventHandler(this.dgvPatients_SelectionChanged);

            // Columns
            this.colID.Name = "colID";
            this.colID.HeaderText = "ID";
            this.colID.FillWeight = 20;
            this.colID.Visible = false;

            this.colName.Name = "colName";
            this.colName.HeaderText = "Full Name";
            this.colName.FillWeight = 120;

            this.colGender.Name = "colGender";
            this.colGender.HeaderText = "Gender";
            this.colGender.FillWeight = 55;

            this.colDOB.Name = "colDOB";
            this.colDOB.HeaderText = "Date of Birth";
            this.colDOB.FillWeight = 75;

            this.colAge.Name = "colAge";
            this.colAge.HeaderText = "Age";
            this.colAge.FillWeight = 40;

            this.colPhone.Name = "colPhone";
            this.colPhone.HeaderText = "Phone";
            this.colPhone.FillWeight = 90;

            this.colAddress.Name = "colAddress";
            this.colAddress.HeaderText = "Address";
            this.colAddress.FillWeight = 110;

            this.colNotes.Name = "colNotes";
            this.colNotes.HeaderText = "Medical Notes";
            this.colNotes.FillWeight = 120;

            this.dgvPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colName, this.colGender, this.colDOB, this.colAge, this.colPhone, this.colAddress, this.colNotes
            });

            // ── pnlForm (CRUD Side Editor) ────────────────────────────────────
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlForm.Width = 330;
            this.pnlForm.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pnlForm.AutoScroll = true;

            // Form Title
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblFormTitle.Location = new System.Drawing.Point(18, 12);
            this.lblFormTitle.Size = new System.Drawing.Size(290, 28);
            this.lblFormTitle.Text = "➕ Register New Patient";

            int y = 46;

            // Name
            this.lblName.Text = "Patient Full Name *";
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblName.Location = new System.Drawing.Point(18, y);
            this.lblName.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtName.Location = new System.Drawing.Point(18, y);
            this.txtName.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Gender
            this.lblGender.Text = "Gender *";
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblGender.Location = new System.Drawing.Point(18, y);
            this.lblGender.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            this.cmbGender.Location = new System.Drawing.Point(18, y);
            this.cmbGender.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Date of Birth
            this.lblDOB.Text = "Date of Birth *";
            this.lblDOB.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDOB.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblDOB.Location = new System.Drawing.Point(18, y);
            this.lblDOB.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.dtpDOB.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.MaxDate = System.DateTime.Today;
            this.dtpDOB.Location = new System.Drawing.Point(18, y);
            this.dtpDOB.Size = new System.Drawing.Size(280, 25);
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

            // Address
            this.lblAddress.Text = "Address / City *";
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblAddress.Location = new System.Drawing.Point(18, y);
            this.lblAddress.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAddress.Location = new System.Drawing.Point(18, y);
            this.txtAddress.Size = new System.Drawing.Size(280, 25);
            y += 34;

            // Medical Notes
            this.lblNotes.Text = "Medical History Notes (Optional)";
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblNotes.Location = new System.Drawing.Point(18, y);
            this.lblNotes.Size = new System.Drawing.Size(290, 18);
            y += 20;

            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNotes.Location = new System.Drawing.Point(18, y);
            this.txtNotes.Size = new System.Drawing.Size(280, 55);
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            y += 65;

            // Save Button
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(18, y);
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.Text = "Save Patient";
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
                this.lblGender, this.cmbGender,
                this.lblDOB, this.dtpDOB,
                this.lblPhone, this.txtPhone,
                this.lblAddress, this.txtAddress,
                this.lblNotes, this.txtNotes,
                this.btnSave, this.btnDelete, this.btnCancel
            });

            // ── FrmPatients ───────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblLoadingStatus);
            this.Controls.Add(this.progressBar);
            this.Name = "FrmPatients";
            this.Text = "Patients Management";
            this.Load += new System.EventHandler(this.FrmPatients_Load);

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbFilterGender;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
    }
}
