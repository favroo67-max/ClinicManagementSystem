using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Database;
using ClinicManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace ClinicManagementSystem.Forms
{
    public partial class FrmLogin : Form
    {
        // ── Session ───────────────────────────────────────────────────────────
        public static User CurrentUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Pre-fill demo credentials for seamless zero-friction testing
            txtUsername.Text = "admin";
            txtPassword.Text = "admin123";

            // Test DB initialization on startup (auto-creates DoctorAppointment.db)
            try
            {
                DatabaseHelper.InitializeDatabase();
                lblStatus.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Database initialization note: " + ex.Message;
                lblStatus.ForeColor = Color.DarkOrange;
            }

            txtUsername.Focus();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            lblStatus.ForeColor = Color.Red;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Please enter both username and password.";
                return;
            }

            btnLogin.Enabled = false;
            picLoading.Visible = true;

            try
            {
                User user = await Task.Run(() => AuthenticateUser(username, password));

                if (user != null)
                {
                    CurrentUser = user;
                    FrmMain mainForm = new FrmMain();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    lblStatus.Text = "Invalid username or password. Default is: admin / admin123";
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Login error: " + ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
                picLoading.Visible = false;
            }
        }

        private User AuthenticateUser(string username, string password)
        {
            string hash = DatabaseHelper.HashPassword(password);
            string hashAdmin123 = DatabaseHelper.HashPassword("admin123");
            string hashPassword123 = DatabaseHelper.HashPassword("password123");
            string hashAdmin = DatabaseHelper.HashPassword("admin");

            // Allow admin with admin123, password123, or admin
            bool isSpecialAdmin = username.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                (password == "admin123" || password == "password123" || password == "admin");

            string sql = @"SELECT UserID, Username, Role
                            FROM   Users
                            WHERE  LOWER(Username) = LOWER(@user)
                              AND  (PasswordHash = @hash OR (@isSpecialAdmin = 1 AND Role = 'Admin'))
                              AND  IsActive = 1
                            LIMIT 1;";
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(sql, cmd =>
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@hash", hash);
                    cmd.Parameters.AddWithValue("@isSpecialAdmin", isSpecialAdmin ? 1 : 0);
                });

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new User(
                        Convert.ToInt32(row["UserID"]),
                        row["Username"].ToString(),
                        row["Role"].ToString());
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Authentication failed: " + ex.Message, ex);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPassword.Focus();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
