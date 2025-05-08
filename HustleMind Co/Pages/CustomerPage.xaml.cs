using HustleMind_Co.DB;
using HustleMind_Co_.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HustleMind_Co_.Pages
{
    public partial class CustomerPage : Page
    {
        private int? editingCustomerId = null;

        public CustomerPage()
        {
            InitializeComponent();
            LoadCustomers();
        }

        // Load all customers into the DataGrid
        private void LoadCustomers()
        {
            try
            {
                string query = "SELECT CustomerId, Name, Mobile, NICNumber, Address FROM Customers";
                CustomerDataGrid.ItemsSource = DBHelper.ExecuteQuery(query).DefaultView;
            }
            catch (Exception ex)
            {
                // Show error popup using MessagePopup
                MessagePopup errorPopup = new MessagePopup($"Failed to load customers:\n{ex.Message}", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }

        // Clear the input form
        private void ClearForm()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtNIC.Clear();
            txtAddress.Clear();
            editingCustomerId = null;
        }

        // Add new customer
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs()) return;

            var newCustomer = new Customer
            {
                Name = txtName.Text.Trim(),
                Mobile = txtMobile.Text.Trim(),
                NICNumber = txtNIC.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            string insertQuery = @"INSERT INTO Customers (Name, Mobile, NICNumber, Address)
                           VALUES (@Name, @Mobile, @NICNumber, @Address)";

            SqlParameter[] parameters = {
                new SqlParameter("@Name", newCustomer.Name),
                new SqlParameter("@Mobile", newCustomer.Mobile),
                new SqlParameter("@NICNumber", newCustomer.NICNumber),
                new SqlParameter("@Address", newCustomer.Address)
    };

            try
            {
                int result = DBHelper.ExecuteNonQuery(insertQuery, parameters);
                if (result > 0)
                {
                    // Show success popup
                    MessagePopup successPopup = new MessagePopup("Customer added successfully!", "Success");
                    successPopup.ShowDialog();
                    LoadCustomers();
                    ClearForm();
                }
                else
                {
                    // Show error popup
                    MessagePopup errorPopup = new MessagePopup("Failed to add customer.", "Error");
                    errorPopup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Show error popup for exceptions
                MessagePopup errorPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error");
                errorPopup.ShowDialog();
            }
        }

        // Load selected customer to form for editing
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is DataRowView selected)
            {
                editingCustomerId = Convert.ToInt32(selected["CustomerId"]);
                txtName.Text = selected["Name"].ToString();
                txtMobile.Text = selected["Mobile"].ToString();
                txtNIC.Text = selected["NICNumber"].ToString();
                txtAddress.Text = selected["Address"].ToString();
            }
            else
            {
                // Show warning popup
                MessagePopup warningPopup = new MessagePopup("Please select a customer to edit.", "Warning");
                warningPopup.ShowDialog();
            }
        }


        // Save changes to existing customer
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (editingCustomerId == null)
            {
                // Show warning popup when no customer is selected for update
                MessagePopup warningPopup = new MessagePopup("No customer selected to update.", "Warning");
                warningPopup.ShowDialog();
                return;
            }

            if (!ValidateInputs()) return;

            string updateQuery = @"UPDATE Customers SET Name = @Name, Mobile = @Mobile, NICNumber = @NICNumber, Address = @Address
                           WHERE CustomerId = @CustomerId";

            SqlParameter[] parameters = {
                new SqlParameter("@Name", txtName.Text.Trim()),
                new SqlParameter("@Mobile", txtMobile.Text.Trim()),
                new SqlParameter("@NICNumber", txtNIC.Text.Trim()),
                new SqlParameter("@Address", txtAddress.Text.Trim()),
                new SqlParameter("@CustomerId", editingCustomerId)
    };

            try
            {
                int result = DBHelper.ExecuteNonQuery(updateQuery, parameters);
                if (result > 0)
                {
                    // Show success popup when customer is updated
                    MessagePopup successPopup = new MessagePopup("Customer updated successfully!", "Success");
                    successPopup.ShowDialog();
                    LoadCustomers();
                    ClearForm();
                }
                else
                {
                    // Show error popup when update fails
                    MessagePopup errorPopup = new MessagePopup("Update failed.", "Error");
                    errorPopup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Show error popup for exceptions
                MessagePopup errorPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error");
                errorPopup.ShowDialog();
            }
        }

        // Delete selected customer
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a customer is selected in the DataGrid
            if (CustomerDataGrid.SelectedItem is not DataRowView selected)
            {
                // Show a warning popup if no customer is selected
                MessagePopup errorPopup = new MessagePopup("Please select a customer to delete.", "Warning", showCancelButton: false);
                errorPopup.ShowDialog();
                return;
            }

            int customerId = Convert.ToInt32(selected["CustomerId"]);

            // Show a custom confirmation popup
            MessagePopup confirmPopup = new MessagePopup("Are you sure you want to delete this customer?", "Warning", showCancelButton: true);
            bool? result = confirmPopup.ShowDialog();  // Get the dialog result

            // Only proceed with deletion if the user clicked OK (DialogResult is true)
            if (result == true) // The user clicked OK
            {
                string deleteQuery = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
                SqlParameter[] parameters = { new SqlParameter("@CustomerId", customerId) };

                try
                {
                    // Execute the delete query
                    int deleteResult = DBHelper.ExecuteNonQuery(deleteQuery, parameters);  // Use a different variable name
                    if (deleteResult > 0)
                    {
                        // Show success popup if deletion was successful
                        MessagePopup successPopup = new MessagePopup("Customer deleted successfully.", "Success", showCancelButton: false);
                        successPopup.ShowDialog();
                        LoadCustomers();  // Reload customers list
                        ClearForm();  // Clear the form fields
                    }
                    else
                    {
                        // Show error popup if deletion failed
                        MessagePopup errorPopup = new MessagePopup("Deletion failed.", "Error", showCancelButton: false);
                        errorPopup.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    // Show error popup in case of exception
                    MessagePopup errorPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error", showCancelButton: false);
                    errorPopup.ShowDialog();
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtMobile.Text) ||
                string.IsNullOrWhiteSpace(txtNIC.Text))
            {
                // Show error popup using MessagePopup
                MessagePopup errorPopup = new MessagePopup("Please fill in all required fields (Name, Mobile, NICNumber).", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
                return false;
            }
            return true;
        }

        // Navigation Handlers
        private void OnDashboardClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new DashboardPage());
        }

        private void OnCustomersClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new CustomerPage());
        }

        private void OnProjectsClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new ProjectPage());
        }

        private void OnPaymentsClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new PaymentPage());
        }

        private void OnReviewsClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new ReviewPage());
        }

        private void OnLogoutClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new LoginPage());
        }
    }
}
