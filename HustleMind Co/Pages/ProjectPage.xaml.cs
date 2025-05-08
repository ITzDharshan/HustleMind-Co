using HustleMind_Co.DB;
using HustleMind_Co_.Models;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Data.SqlClient;

namespace HustleMind_Co_.Pages
{
    /// <summary>
    /// Interaction logic for ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        public ProjectPage()
        {
            InitializeComponent();
            LoadProjects(); // Load existing projects into the DataGrid
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            Project newProject = new Project
            {
                CustomerId = int.Parse(txtCustomerId.Text.Trim()),
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Status = cmbStatus.Text.Trim(),
                StartDate = dpStartDate.SelectedDate.Value,
                EndDate = dpEndDate.SelectedDate.Value
            };

            // Validation Check
            if (string.IsNullOrWhiteSpace(newProject.Title) || string.IsNullOrWhiteSpace(newProject.Status))
            {
                // Show a validation error popup message
                MessagePopup validationPopup = new MessagePopup("Please fill in all required fields.", "Validation Error", showCancelButton: false);
                validationPopup.ShowDialog();
                return;
            }

            try
            {
                string insertQuery = @"INSERT INTO Projects (CustomerId, Title, Description, Status, StartDate, EndDate)
                               VALUES (@CustomerId, @Title, @Description, @Status, @StartDate, @EndDate)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", newProject.CustomerId),
                    new SqlParameter("@Title", newProject.Title),
                    new SqlParameter("@Description", newProject.Description),
                    new SqlParameter("@Status", newProject.Status),
                    new SqlParameter("@StartDate", newProject.StartDate),
                    new SqlParameter("@EndDate", newProject.EndDate)
                };

                int rowsAffected = DBHelper.ExecuteNonQuery(insertQuery, parameters);

                if (rowsAffected > 0)
                {
                    // Show success popup message
                    MessagePopup successPopup = new MessagePopup("Project added successfully!", "Success", showCancelButton: false);
                    successPopup.ShowDialog();
                    ClearForm();
                    LoadProjects();
                }
                else
                {
                    // Show error popup message if the project was not added successfully
                    MessagePopup errorPopup = new MessagePopup("Failed to add project.", "Error", showCancelButton: false);
                    errorPopup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Show error popup message if an exception occurs
                MessagePopup exceptionPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error", showCancelButton: false);
                exceptionPopup.ShowDialog();
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var selectedProject = ProjectDataGrid.SelectedItem as DataRowView;

            if (selectedProject != null)
            {
                int projectId = Convert.ToInt32(selectedProject["ProjectId"]);

                string updatedTitle = txtTitle.Text.Trim();
                string updatedDescription = txtDescription.Text.Trim();
                string updatedStatus = cmbStatus.Text.Trim();

                if (!int.TryParse(txtCustomerId.Text.Trim(), out int updatedCustomerId))
                {
                    MessagePopup customerPopup = new MessagePopup("Invalid Customer ID.", "Validation Error", showCancelButton: false);
                    customerPopup.ShowDialog();
                    return;
                }

                // Validation Check
                if (string.IsNullOrWhiteSpace(updatedTitle) || string.IsNullOrWhiteSpace(updatedStatus))
                {
                    MessagePopup validationPopup = new MessagePopup("Please fill in all required fields.", "Validation Error", showCancelButton: false);
                    validationPopup.ShowDialog();
                    return;
                }

                try
                {
                    // You can also retrieve StartDate and EndDate from inputs or DataRowView
                    DateTime updatedStartDate = Convert.ToDateTime(selectedProject["StartDate"]);
                    DateTime updatedEndDate = Convert.ToDateTime(selectedProject["EndDate"]);

                    string updateQuery = @"
                UPDATE Projects 
                SET CustomerId = @CustomerId,
                    Title = @Title,
                    Description = @Description,
                    Status = @Status,
                    StartDate = @StartDate,
                    EndDate = @EndDate
                WHERE ProjectId = @ProjectId";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", updatedCustomerId),
                        new SqlParameter("@Title", updatedTitle),
                        new SqlParameter("@Description", updatedDescription),
                        new SqlParameter("@Status", updatedStatus),
                        new SqlParameter("@StartDate", updatedStartDate),
                        new SqlParameter("@EndDate", updatedEndDate),
                        new SqlParameter("@ProjectId", projectId)
                    };

                    int rowsAffected = DBHelper.ExecuteNonQuery(updateQuery, parameters);

                    if (rowsAffected > 0)
                    {
                        MessagePopup successPopup = new MessagePopup("Project updated successfully!", "Success", showCancelButton: false);
                        successPopup.ShowDialog();
                        LoadProjects();
                        ClearForm();
                    }
                    else
                    {
                        MessagePopup errorPopup = new MessagePopup("Failed to update project.", "Error", showCancelButton: false);
                        errorPopup.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessagePopup exceptionPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error", showCancelButton: false);
                    exceptionPopup.ShowDialog();
                }
            }
            else
            {
                MessagePopup noSelectionPopup = new MessagePopup("Please select a project to edit.", "No Selection", showCancelButton: false);
                noSelectionPopup.ShowDialog();
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProject = ProjectDataGrid.SelectedItem as DataRowView;

            if (selectedProject != null)
            {
                // Populate the fields with the selected project data
                txtCustomerId.Text = selectedProject["CustomerId"].ToString();
                txtTitle.Text = selectedProject["Title"].ToString();
                txtDescription.Text = selectedProject["Description"].ToString();
                cmbStatus.Text = selectedProject["Status"].ToString();
                dpStartDate.SelectedDate = Convert.ToDateTime(selectedProject["StartDate"]);
                dpEndDate.SelectedDate = Convert.ToDateTime(selectedProject["EndDate"]);
            }
            else
            {
                // Show a custom popup message if no project is selected
                MessagePopup noSelectionPopup = new MessagePopup("Please select a project to edit.", "No Selection", showCancelButton: false);
                noSelectionPopup.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProject = ProjectDataGrid.SelectedItem as DataRowView;

            if (selectedProject != null)
            {
                int projectId = Convert.ToInt32(selectedProject["ProjectId"]);

                // Show a custom confirmation popup
                MessagePopup confirmPopup = new MessagePopup("Are you sure you want to delete this project?", "Delete Project", showCancelButton: true);
                bool? result = confirmPopup.ShowDialog();

                if (result == true)  // The user clicked OK
                {
                    try
                    {
                        string deleteQuery = @"DELETE FROM Projects WHERE ProjectId = @ProjectId";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@ProjectId", projectId)
                        };

                        int rowsAffected = DBHelper.ExecuteNonQuery(deleteQuery, parameters);

                        if (rowsAffected > 0)
                        {
                            // Show success popup if deletion was successful
                            MessagePopup successPopup = new MessagePopup("Project deleted successfully!", "Success", showCancelButton: false);
                            successPopup.ShowDialog();
                            LoadProjects();  // Reload the projects list
                            ClearForm();  // Clear the form fields
                        }
                        else
                        {
                            // Show error popup if deletion failed
                            MessagePopup errorPopup = new MessagePopup("Failed to delete project.", "Error", showCancelButton: false);
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
            else
            {
                // Show a warning popup if no project is selected
                MessagePopup noSelectionPopup = new MessagePopup("Please select a project to delete.", "No Selection", showCancelButton: false);
                noSelectionPopup.ShowDialog();
            }
        }

        private void LoadProjects()
        {
            try
            {
                string selectQuery = @"SELECT ProjectId, CustomerId, Title, Description, Status, StartDate, EndDate FROM Projects";
                ProjectDataGrid.ItemsSource = DBHelper.ExecuteQuery(selectQuery).DefaultView;
            }
            catch (Exception ex)
            {
                // Show error popup in case of exception
                MessagePopup errorPopup = new MessagePopup($"Failed to load projects:\n{ex.Message}", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }

        private void ClearForm()
        {
            txtCustomerId.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            cmbStatus.Text = "";
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;
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
