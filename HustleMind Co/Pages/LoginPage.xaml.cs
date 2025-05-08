using HustleMind_Co.DB;
using HustleMind_Co_;  // Import the namespace of the MessagePopup class
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HustleMind_Co_.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = isPasswordVisible ? txtVisiblePassword.Text : txtPassword.Password;
            string hashedPassword = HashPassword(password);

            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
            var parameters = new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter("@UserName", username),
                new Microsoft.Data.SqlClient.SqlParameter("@Password", hashedPassword)
            };

            DataTable dt = DBHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                // Show success popup
                MessagePopup successPopup = new MessagePopup("Login successful!", "Success");
                successPopup.ShowDialog();
                this.NavigationService.Navigate(new DashboardPage());
            }
            else
            {
                // Show error popup
                MessagePopup errorPopup = new MessagePopup("Invalid username or password.", "Error");
                errorPopup.ShowDialog();
            }
        }

        private bool isPasswordVisible = false;

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

        private void GoToRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }

        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            ForgotWindow forgotWindow = new ForgotWindow();
            forgotWindow.Show();
        }

    }
}
