using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using HustleMind_Co.DB;
using Microsoft.Data.SqlClient;

namespace HustleMind_Co_.Pages
{
    public partial class RegisterPage : Page
    {
        private bool isPasswordVisible = false;
        private bool isConfirmPasswordVisible = false;

        public RegisterPage()
        {
            InitializeComponent();
        }

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

        private void btnTogglePassword_Click(object sender, RoutedEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            if (isPasswordVisible)
            {
                txtVisiblePassword.Text = txtPassword.Password;
                txtVisiblePassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
                btnTogglePassword.Content = "🙈";
            }
            else
            {
                txtPassword.Password = txtVisiblePassword.Text;
                txtVisiblePassword.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
                btnTogglePassword.Content = "👁";
            }
        }

        private void btnToggleConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            isConfirmPasswordVisible = !isConfirmPasswordVisible;
            if (isConfirmPasswordVisible)
            {
                txtVisibleConfirmPassword.Text = txtConfirmPassword.Password;
                txtVisibleConfirmPassword.Visibility = Visibility.Visible;
                txtConfirmPassword.Visibility = Visibility.Collapsed;
                btnToggleConfirmPassword.Content = "🙈";
            }
            else
            {
                txtConfirmPassword.Password = txtVisibleConfirmPassword.Text;
                txtVisibleConfirmPassword.Visibility = Visibility.Collapsed;
                txtConfirmPassword.Visibility = Visibility.Visible;
                btnToggleConfirmPassword.Content = "👁";
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string mobile = txtMobileNumber.Text.Trim();
            string password = isPasswordVisible ? txtVisiblePassword.Text : txtPassword.Password;
            string confirmPassword = isConfirmPasswordVisible ? txtVisibleConfirmPassword.Text : txtConfirmPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(mobile) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessagePopup errorPopup = new MessagePopup("Please fill in all fields.", "Missing Info");
                errorPopup.ShowDialog();
                return;
            }

            if (password != confirmPassword)
            {
                MessagePopup errorPopup = new MessagePopup("Passwords do not match. Please re-enter.", "Mismatch");
                errorPopup.ShowDialog();
                return;
            }

            if (!Regex.IsMatch(mobile, @"^[0-9]{10}$"))
            {
                MessagePopup errorPopup = new MessagePopup("Enter a valid 10-digit mobile number.", "Invalid Mobile");
                errorPopup.ShowDialog();
                return;
            }

            string hashedPassword = HashPassword(password);

            try
            {
                // Check if user already exists
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName OR Mobile = @Mobile";
                SqlParameter[] checkParams = new SqlParameter[] {
            new SqlParameter("@UserName", username),
            new SqlParameter("@Mobile", mobile)
        };
                DataTable existingUser = DBHelper.ExecuteQuery(checkQuery, checkParams);
                if (existingUser.Rows.Count > 0 && Convert.ToInt32(existingUser.Rows[0][0]) > 0)
                {
                    MessagePopup errorPopup = new MessagePopup("Username or Mobile already exists!", "Duplicate");
                    errorPopup.ShowDialog();
                    return;
                }

                // Register new user
                string insertQuery = "INSERT INTO Users (UserName, Mobile, Password) VALUES (@UserName, @Mobile, @Password)";
                SqlParameter[] insertParams = new SqlParameter[] {
            new SqlParameter("@UserName", username),
            new SqlParameter("@Mobile", mobile),
            new SqlParameter("@Password", hashedPassword)
        };

                int result = DBHelper.ExecuteNonQuery(insertQuery, insertParams);
                if (result > 0)
                {
                    MessagePopup successPopup = new MessagePopup("Registration successful!", "Success");
                    successPopup.ShowDialog();
                    NavigationService.Navigate(new LoginPage());
                }
                else
                {
                    MessagePopup errorPopup = new MessagePopup("Registration failed. Please try again.", "Error");
                    errorPopup.ShowDialog();
                }
            }
            catch (SqlException sqlEx)
            {
                MessagePopup errorPopup = new MessagePopup("SQL Error: " + sqlEx.Message, "Database Error");
                errorPopup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessagePopup errorPopup = new MessagePopup("Unexpected Error: " + ex.Message, "Error");
                errorPopup.ShowDialog();
            }
        }

        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
