using System;
using System.Windows.Forms;
using ClinicManagementSystem.Database;
using ClinicManagementSystem.Forms;

namespace ClinicManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ensure local SQLite database and seed data are initialized with zero configuration
            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning during database initialization: " + ex.Message,
                    "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new FrmLogin());
        }
    }
}
