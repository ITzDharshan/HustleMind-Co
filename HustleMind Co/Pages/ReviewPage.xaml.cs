using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HustleMind_Co.DB;
using HustleMind_Co_.Models;
using Microsoft.Data.SqlClient;

namespace HustleMind_Co_.Pages
{
    public partial class ReviewPage : Page
    {
        public ReviewPage()
        {
            InitializeComponent();
            LoadReviews(); // Load existing reviews into the DataGrid
        }

        // Event handler to add a new review
        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            // Ensure a rating is selected
            ComboBoxItem selectedRatingItem = cmbRating.SelectedItem as ComboBoxItem;
            if (selectedRatingItem == null)
            {
                MessagePopup errorPopup = new MessagePopup("Please select a rating.", "Validation Error", showCancelButton: false);
                errorPopup.ShowDialog();
                return;
            }

            Review newReview = new Review
            {
                CustomerId = Convert.ToInt32(txtCustomerId.Text.Trim()),
                Rating = Convert.ToInt32(selectedRatingItem.Content.ToString().Trim()),
                Content = txtContent.Text.Trim()
            };

            // Validate the inputs
            if (newReview.CustomerId <= 0 || newReview.Rating < 1 || newReview.Rating > 5 || string.IsNullOrWhiteSpace(newReview.Content))
            {
                MessagePopup errorPopup = new MessagePopup("Please fill in all required fields.", "Validation Error", showCancelButton: false);
                errorPopup.ShowDialog();
                return;
            }

            try
            {
                // Prepare the SQL insert query
                string insertQuery = @"INSERT INTO Reviews (CustomerId, Content, Rating) VALUES (@CustomerId, @Content, @Rating)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@CustomerId", newReview.CustomerId),
            new SqlParameter("@Content", newReview.Content),
            new SqlParameter("@Rating", newReview.Rating)
                };

                // Execute the query
                int rowsAffected = DBHelper.ExecuteNonQuery(insertQuery, parameters);

                if (rowsAffected > 0)
                {
                    MessagePopup successPopup = new MessagePopup("Review added successfully!", "Success", showCancelButton: false);
                    successPopup.ShowDialog();
                    ClearForm();
                    LoadReviews();
                }
                else
                {
                    MessagePopup errorPopup = new MessagePopup("Failed to add review.", "Error", showCancelButton: false);
                    errorPopup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessagePopup errorPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }

        // Load existing reviews from the database
        private void LoadReviews()
        {
            try
            {
                string selectQuery = @"SELECT ReviewId, CustomerId, Rating, Content FROM Reviews";
                ReviewDataGrid.ItemsSource = DBHelper.ExecuteQuery(selectQuery).DefaultView;
            }
            catch (Exception ex)
            {
                MessagePopup errorPopup = new MessagePopup($"Failed to load reviews:\n{ex.Message}", "Error", showCancelButton: false);
                errorPopup.ShowDialog();
            }
        }

        // Clear form fields
        private void ClearForm()
        {
            txtCustomerId.Text = "";
            txtContent.Text = "";
            cmbRating.SelectedIndex = -1;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var selectedReview = ReviewDataGrid.SelectedItem as DataRowView;

            if (selectedReview != null)
            {
                int reviewId = Convert.ToInt32(selectedReview["ReviewId"]);

                // Get updated values from the form
                int updatedCustomerId;
                int updatedRating;
                string updatedContent = txtContent.Text.Trim();

                if (!int.TryParse(txtCustomerId.Text.Trim(), out updatedCustomerId) ||
                    !int.TryParse(cmbRating.Text.Trim(), out updatedRating) ||
                    string.IsNullOrWhiteSpace(updatedContent))
                {
                    MessagePopup validationPopup = new MessagePopup("Please enter valid data in all fields.", "Validation Error", showCancelButton: false);
                    validationPopup.ShowDialog();
                    return;
                }

                try
                {
                    string updateQuery = @"UPDATE Reviews 
                                   SET CustomerId = @CustomerId, Content = @Content, Rating = @Rating 
                                   WHERE ReviewId = @ReviewId";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@CustomerId", updatedCustomerId),
                new SqlParameter("@Content", updatedContent),
                new SqlParameter("@Rating", updatedRating),
                new SqlParameter("@ReviewId", reviewId)
                    };

                    int rowsAffected = DBHelper.ExecuteNonQuery(updateQuery, parameters);

                    if (rowsAffected > 0)
                    {
                        MessagePopup successPopup = new MessagePopup("Review updated successfully!", "Success", showCancelButton: false);
                        successPopup.ShowDialog();
                        LoadReviews();
                        ClearForm();
                    }
                    else
                    {
                        MessagePopup errorPopup = new MessagePopup("Failed to update review.", "Error", showCancelButton: false);
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
                MessagePopup noSelectionPopup = new MessagePopup("Please select a review to edit.", "No Selection", showCancelButton: false);
                noSelectionPopup.ShowDialog();
            }
        }

        // Event handler for Delete review
        private void DeleteReview_Click(object sender, RoutedEventArgs e)
        {
            var selectedReview = ReviewDataGrid.SelectedItem as DataRowView;

            if (selectedReview != null)
            {
                int reviewId = Convert.ToInt32(selectedReview["ReviewId"]);

                // Show a custom confirmation popup
                MessagePopup confirmPopup = new MessagePopup("Are you sure you want to delete this review?", "Delete Review", showCancelButton: true);
                bool? result = confirmPopup.ShowDialog();

                if (result == true) // The user confirmed deletion
                {
                    try
                    {
                        string deleteQuery = @"DELETE FROM Reviews WHERE ReviewId = @ReviewId";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@ReviewId", reviewId)
                        };

                        int rowsAffected = DBHelper.ExecuteNonQuery(deleteQuery, parameters);

                        if (rowsAffected > 0)
                        {
                            MessagePopup successPopup = new MessagePopup("Review deleted successfully!", "Success", showCancelButton: false);
                            successPopup.ShowDialog();
                            LoadReviews();
                        }
                        else
                        {
                            MessagePopup errorPopup = new MessagePopup("Failed to delete review.", "Error", showCancelButton: false);
                            errorPopup.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessagePopup errorPopup = new MessagePopup($"An error occurred:\n{ex.Message}", "Error", showCancelButton: false);
                        errorPopup.ShowDialog();
                    }
                }
            }
            else
            {
                MessagePopup noSelectionPopup = new MessagePopup("Please select a review to delete.", "No Selection", showCancelButton: false);
                noSelectionPopup.ShowDialog();
            }
        }

        // Event handler for Edit review
        private void EditReview_Click(object sender, RoutedEventArgs e)
        {
            var selectedReview = ReviewDataGrid.SelectedItem as DataRowView;

            if (selectedReview != null)
            {
                int reviewId = Convert.ToInt32(selectedReview["ReviewId"]);
                int customerId = Convert.ToInt32(selectedReview["CustomerId"]);
                int rating = Convert.ToInt32(selectedReview["Rating"]);
                string content = selectedReview["Content"].ToString();

                // Populate the form with the selected review's data
                txtCustomerId.Text = customerId.ToString();
                cmbRating.SelectedIndex = rating - 1; // Rating is 1 to 5, so adjust the ComboBox index
                txtContent.Text = content;
            }
            else
            {
                // Show a warning popup if no review is selected
                MessagePopup noSelectionPopup = new MessagePopup("Please select a review to edit.", "No Selection", showCancelButton: false);
                noSelectionPopup.ShowDialog();
            }
        }

        // Navigation Event Handlers
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
