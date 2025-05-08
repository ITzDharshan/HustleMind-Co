using HustleMind_Co.DB;
using HustleMind_Co_; // Import the namespace of the MessagePopup class
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HustleMind_Co_
{
    public partial class ForgotWindow : Window
    {
        public ForgotWindow()
        {
            InitializeComponent();
        }

        // Toggle New Password visibility
        private void btnToggleNewPassword_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewPassword.Visibility == Visibility.Visible)
            {
                txtNewPassword.Visibility = Visibility.Collapsed;
                txtVisibleNewPassword.Visibility = Visibility.Visible;
                txtVisibleNewPassword.Text = txtNewPassword.Password;
            }
            else
            {
                txtNewPassword.Visibility = Visibility.Visible;
                txtVisibleNewPassword.Visibility = Visibility.Collapsed;
            }
        }

        // Toggle Confirm Password visibility
        private void btnToggleConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            if (txtConfirmPassword.Visibility == Visibility.Visible)
            {
                txtConfirmPassword.Visibility = Visibility.Collapsed;
                txtVisibleConfirmPassword.Visibility = Visibility.Visible;
                txtVisibleConfirmPassword.Text = txtConfirmPassword.Password;
            }
            else
            {
                txtConfirmPassword.Visibility = Visibility.Visible;
                txtVisibleConfirmPassword.Visibility = Visibility.Collapsed;
            }
        }

        // Handle the Submit button click (you can add your logic here)
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string mobile = txtMobileNumber.Text.Trim();
            string newPassword = txtNewPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (newPassword != confirmPassword)
            {
                MessagePopup errorPopup = new MessagePopup("Passwords do not match, please try again.", "Error");
                errorPopup.ShowDialog();
                return;
            }

            string hashedNewPassword = HashPassword(newPassword);

            // Corrected: Use actual column name "Mobile"
            string query = "SELECT * FROM Users WHERE Mobile = @Mobile";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Mobile", mobile)
            };

            DataTable dt = DBHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                string updateQuery = "UPDATE Users SET Password = @Password WHERE Mobile = @Mobile";
                var updateParameters = new SqlParameter[]
                {
                    new SqlParameter("@Password", hashedNewPassword),
                    new SqlParameter("@Mobile", mobile) // Make sure the name matches
                };

                int rowsAffected = DBHelper.ExecuteNonQuery(updateQuery, updateParameters);

                if (rowsAffected > 0)
                {
                    MessagePopup successPopup = new MessagePopup("Password has been successfully reset!", "Success");
                    successPopup.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessagePopup errorPopup = new MessagePopup("Password update failed. Please try again.", "Error");
                    errorPopup.ShowDialog();
                }
            }
            else
            {
                MessagePopup errorPopup = new MessagePopup("Mobile number not found, please try again.", "Error");
                errorPopup.ShowDialog();
            }
        }

        // Password hashing method
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
