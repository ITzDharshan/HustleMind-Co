using HustleMind_Co.DB;
using HustleMind_Co_.Models;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using System.Windows.Input;
using System.IO;


namespace HustleMind_Co_.Pages
{
    /// <summary>
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        public PaymentPage()
        {
            InitializeComponent();
            LoadPayments(); // Load existing payments into the DataGrid
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            Payment newPayment = new Payment
            {
                ProjectId = int.Parse(txtProjectId.Text.Trim()),
                PaymentType = cmbPaymentType.Text.Trim(),
                Amount = decimal.Parse(txtAmount.Text.Trim()),
                PaymentDate = dpPaymentDate.SelectedDate.Value,
                PaymentStatus = cmbPaymentStatus.Text.Trim(),
                PaymentMethod = cmbPaymentMethod.Text.Trim(),
                FilePath = txtFileName.Text.Trim()
            };

            if (newPayment.ProjectId <= 0 || string.IsNullOrWhiteSpace(newPayment.PaymentStatus) || newPayment.Amount <= 0)
            {
                // Show error popup for validation
                MessagePopup errorPopup = new MessagePopup("Please fill in all required fields.", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
                return;
            }

            try
            {
                string insertQuery = @"INSERT INTO Payments (ProjectId, PaymentType, Amount, PaymentDate, PaymentStatus, PaymentMethod, FilePath)
                               VALUES (@ProjectId, @PaymentType, @Amount, @PaymentDate, @PaymentStatus, @PaymentMethod, @FilePath)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProjectId", newPayment.ProjectId),
                    new SqlParameter("@PaymentType", newPayment.PaymentType),
                    new SqlParameter("@Amount", newPayment.Amount),
                    new SqlParameter("@PaymentDate", newPayment.PaymentDate),
                    new SqlParameter("@PaymentStatus", newPayment.PaymentStatus),
                    new SqlParameter("@PaymentMethod", newPayment.PaymentMethod),
                    new SqlParameter("@FilePath", newPayment.FilePath)
                };

                int rowsAffected = DBHelper.ExecuteNonQuery(insertQuery, parameters);

                if (rowsAffected > 0)
                {
                    // Show success popup when payment is added successfully
                    MessagePopup successPopup = new MessagePopup("Payment added successfully!", "Success", showCancelButton: false);
                    successPopup.ShowDialog();
                    ClearForm();
                    LoadPayments();
                }
                else
                {
                    // Show error popup when payment addition fails
                    MessagePopup errorPopup = new MessagePopup("Failed to add payment.", "Error", showCancelButton: false);
                    errorPopup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Show error popup for any exceptions
                MessagePopup errorPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }


        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Get selected payment
            var selectedPayment = PaymentDataGrid.SelectedItem as DataRowView;

            if (selectedPayment != null)
            {
                // Mapping the selected payment data to the Payment model
                var payment = new Payment
                {
                    PaymentId = Convert.ToInt32(selectedPayment["PaymentId"]),
                    ProjectId = Convert.ToInt32(selectedPayment["ProjectId"]),
                    PaymentType = cmbPaymentType.Text.Trim(),
                    Amount = decimal.Parse(txtAmount.Text.Trim()),
                    PaymentDate = dpPaymentDate.SelectedDate.Value,
                    PaymentStatus = cmbPaymentStatus.Text.Trim(),
                    PaymentMethod = cmbPaymentMethod.Text.Trim(),
                    FilePath = txtFileName.Text.Trim()
                };

                // Validation
                if (payment.Amount <= 0 || string.IsNullOrWhiteSpace(payment.PaymentStatus))
                {
                    // Show validation error popup
                    MessagePopup errorPopup = new MessagePopup("Please fill in all required fields.", "Validation Error", showCancelButton: false);
                    errorPopup.ShowDialog();
                    return;
                }

                try
                {
                    string updateQuery = @"UPDATE Payments
                                           SET ProjectId = @ProjectId, PaymentType = @PaymentType, Amount = @Amount, PaymentDate = @PaymentDate, PaymentStatus = @PaymentStatus, PaymentMethod = @PaymentMethod, FilePath = @FilePath
                                           WHERE PaymentId = @PaymentId";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@ProjectId", payment.ProjectId),
                        new SqlParameter("@PaymentType", payment.PaymentType),
                        new SqlParameter("@Amount", payment.Amount),
                        new SqlParameter("@PaymentDate", payment.PaymentDate),
                        new SqlParameter("@PaymentStatus", payment.PaymentStatus),
                        new SqlParameter("@PaymentMethod", payment.PaymentMethod),
                        new SqlParameter("@FilePath", payment.FilePath),
                        new SqlParameter("@PaymentId", payment.PaymentId)
                    };

                    int rowsAffected = DBHelper.ExecuteNonQuery(updateQuery, parameters);

                    if (rowsAffected > 0)
                    {
                        // Show success popup
                        MessagePopup successPopup = new MessagePopup("Payment updated successfully!", "Success", showCancelButton: false);
                        successPopup.ShowDialog();
                        LoadPayments();
                        ClearForm();
                    }
                    else
                    {
                        // Show error popup when update fails
                        MessagePopup errorPopup = new MessagePopup("Failed to update payment.", "Error", showCancelButton: false);
                        errorPopup.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    // Show error popup for exception
                    MessagePopup errorPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error", showCancelButton: false);
                    errorPopup.ShowDialog();
                }
            }
            else
            {
                // Show validation error if no payment is selected
                MessagePopup errorPopup = new MessagePopup("Please select a payment to edit.", "No Selection", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPayment = PaymentDataGrid.SelectedItem as DataRowView;

            if (selectedPayment != null)
            {
                txtProjectId.Text = selectedPayment["ProjectId"].ToString();
                cmbPaymentType.Text = selectedPayment["PaymentType"].ToString();
                txtAmount.Text = selectedPayment["Amount"].ToString();
                dpPaymentDate.SelectedDate = Convert.ToDateTime(selectedPayment["PaymentDate"]);
                cmbPaymentStatus.Text = selectedPayment["PaymentStatus"].ToString();
                cmbPaymentMethod.Text = selectedPayment["PaymentMethod"].ToString();
                txtFileName.Text = selectedPayment["FilePath"].ToString();
            }
            else
            {
                // Show validation error popup
                MessagePopup errorPopup = new MessagePopup("Please select a payment to edit.", "No Selection", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a payment is selected in the DataGrid
            var selectedPayment = PaymentDataGrid.SelectedItem as DataRowView;

            if (selectedPayment == null)
            {
                // Show a warning popup if no payment is selected
                MessagePopup errorPopup = new MessagePopup("Please select a payment to delete.", "Warning", showCancelButton: false);
                errorPopup.ShowDialog();
                return;
            }

            int paymentId = Convert.ToInt32(selectedPayment["PaymentId"]);

            // Show a custom confirmation popup
            MessagePopup confirmPopup = new MessagePopup("Are you sure you want to delete this payment?", "Warning", showCancelButton: true);
            bool? result = confirmPopup.ShowDialog();  // Get the dialog result

            // Only proceed with deletion if the user clicked OK (DialogResult is true)
            if (result == true) // The user clicked OK
            {
                string deleteQuery = "DELETE FROM Payments WHERE PaymentId = @PaymentId";
                SqlParameter[] parameters = { new SqlParameter("@PaymentId", paymentId) };

                try
                {
                    // Execute the delete query
                    int deleteResult = DBHelper.ExecuteNonQuery(deleteQuery, parameters);
                    if (deleteResult > 0)
                    {
                        // Show success popup if deletion was successful
                        MessagePopup successPopup = new MessagePopup("Payment deleted successfully.", "Success", showCancelButton: false);
                        successPopup.ShowDialog();
                        LoadPayments();  // Reload the payments list
                        ClearForm();  // Clear the form fields
                    }
                    else
                    {
                        // Show error popup if deletion failed
                        MessagePopup errorPopup = new MessagePopup("Failed to delete payment.", "Error", showCancelButton: false);
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

        private void LoadPayments()
        {
            try
            {
                string selectQuery = @"SELECT PaymentId, ProjectId, PaymentType, Amount, PaymentDate, PaymentStatus, PaymentMethod, FilePath FROM Payments";
                PaymentDataGrid.ItemsSource = DBHelper.ExecuteQuery(selectQuery).DefaultView;
            }
            catch (Exception ex)
            {
                // Show error popup in case of exception
                MessagePopup errorPopup = new MessagePopup($"An error occurred while loading payments:\n{ex.Message}", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }

        private void ClearForm()
        {
            txtProjectId.Text = "";
            cmbPaymentType.Text = "";
            txtAmount.Text = "";
            dpPaymentDate.SelectedDate = null;
            cmbPaymentStatus.Text = "";
            cmbPaymentMethod.Text = "";
            txtFileName.Text = "";
        }

        private void BrowseFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Allow all file types: PDF, DOC, DOCX, JPG, JPEG, PNG, etc.
            dlg.DefaultExt = "*.*";
            dlg.Filter = "All Files (*.*)|*.*|PDF Files (*.pdf)|*.pdf|Word Documents (*.doc, *.docx)|*.doc;*.docx|Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string fileName = dlg.FileName;
                txtFileName.Text = fileName;
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPayment = PaymentDataGrid.SelectedItem as DataRowView;

            if (selectedPayment != null)
            {
                string sourceFilePath = selectedPayment["FilePath"].ToString();

                // Show a popup message about the source file path
                MessagePopup infoPopup = new MessagePopup($"Trying to copy from: {sourceFilePath}", "Information", showCancelButton: false);
                infoPopup.ShowDialog();

                if (File.Exists(sourceFilePath))
                {
                    string destinationPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                        Path.GetFileName(sourceFilePath));

                    // Show a popup message about the destination path
                    MessagePopup infoPopupDestination = new MessagePopup($"Will copy to: {destinationPath}", "Information", showCancelButton: false);
                    infoPopupDestination.ShowDialog();

                    try
                    {
                        File.Copy(sourceFilePath, destinationPath, true);

                        // Success popup message
                        MessagePopup successPopup = new MessagePopup("File downloaded successfully to Desktop!", "Download", showCancelButton: false);
                        successPopup.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        // Error popup message in case of exception
                        MessagePopup errorPopup = new MessagePopup($"An error occurred while downloading the file:\n{ex.Message}", "Error", showCancelButton: false);
                        errorPopup.ShowDialog();
                    }
                }
                else
                {
                    // Error popup message if file is not found
                    MessagePopup errorPopup = new MessagePopup("Source file not found!", "Error", showCancelButton: false);
                    errorPopup.ShowDialog();
                }
            }
        }


        private void OnDashboardClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new DashboardPage());
        }

        private void OnCustomersClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CustomerPage());
        }

        private void OnProjectsClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProjectPage());
        }

        private void OnPaymentsClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PaymentPage());
        }

        private void OnReviewsClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ReviewPage());
        }

        private void OnLogoutClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
