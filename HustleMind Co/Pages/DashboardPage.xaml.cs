using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;
using HustleMind_Co.DB;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Data.SqlClient;
using HustleMind_Co_.Models;

namespace HustleMind_Co_.Pages
{
    public partial class DashboardPage : Page
    {
        public SeriesCollection IncomeSeriesCollection { get; set; }
        public string[] IncomeLabels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public SeriesCollection ProjectStatusSeries { get; set; }
        public List<Review> RecentReviews { get; set; }

        public DashboardPage()
        {
            InitializeComponent();
            LoadDashboardData();
            LoadIncomeChart();
            LoadProjectStatusChart();
            LoadRecentReviews();
            SetGreetingText();

            DataContext = this; // Set once after all data is loaded
        }

        private void LoadDashboardData()
        {
            try
            {
                txtTotalCustomers.Text = GetScalarValue("SELECT COUNT(*) FROM Customers");
                txtTotalProjects.Text = GetScalarValue("SELECT COUNT(*) FROM Projects");

                string income = GetScalarValue("SELECT ISNULL(SUM(Amount), 0) FROM Payments WHERE PaymentStatus = 'Paid'");
                txtTotalIncome.Text = decimal.TryParse(income, out decimal totalIncome)
                    ? $"{totalIncome:N2}"
                    : "0.00";

                txtPendingReviews.Text = GetScalarValue("SELECT COUNT(*) FROM Reviews");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading dashboard data: " + ex.Message);
            }
        }

        private string GetScalarValue(string query)
        {
            try
            {
                DataTable dt = DBHelper.ExecuteQuery(query, null);
                return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "0";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                return "0";
            }
        }

        private string GetLoggedInUserName()
        {
            try
            {
                int userId = GetLoggedInUserId();
                var parameters = new[] { new SqlParameter("@UserId", userId) };
                var dt = DBHelper.ExecuteQuery("SELECT UserName FROM Users WHERE UserId = @UserId", parameters);

                return dt.Rows.Count > 0 ? dt.Rows[0]["UserName"].ToString() : "User";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user name: " + ex.Message);
                return "User";
            }
        }

        private int GetLoggedInUserId()
        {
            return 1; // Replace with actual login session logic
        }

        private void SetGreetingText()
        {
            string greeting;
            int hour = DateTime.Now.Hour;

            greeting = hour switch
            {
                < 12 => "Good Morning!",
                < 18 => "Good Afternoon!",
                _ => "Good Evening!"
            };

            GreetingText.Text = $"{greeting} {GetLoggedInUserName()}!";
        }

        private void LoadIncomeChart()
        {
            try
            {
                string query = @"
                    SELECT FORMAT(PaymentDate, 'MMM') AS Month, SUM(Amount) AS Total
                    FROM Payments
                    WHERE PaymentDate >= DATEADD(MONTH, -5, GETDATE())
                    GROUP BY FORMAT(PaymentDate, 'MMM'), MONTH(PaymentDate)
                    ORDER BY MONTH(PaymentDate)";

                DataTable dt = DBHelper.ExecuteQuery(query, null);

                var values = new ChartValues<decimal>();
                var labels = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    labels.Add(row["Month"].ToString());
                    values.Add(Convert.ToDecimal(row["Total"]));
                }

                IncomeSeriesCollection = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Income",
                        Values = values
                    }
                };

                IncomeLabels = labels.ToArray();
                Formatter = value => "LKR " + value.ToString("N2", new CultureInfo("si-LK"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading income chart: " + ex.Message);
            }
        }

        private void LoadProjectStatusChart()
        {
            try
            {
                string query = "SELECT Status, COUNT(*) AS Count FROM Projects GROUP BY Status";
                DataTable dt = DBHelper.ExecuteQuery(query, null);

                ProjectStatusSeries = new SeriesCollection();

                foreach (DataRow row in dt.Rows)
                {
                    ProjectStatusSeries.Add(new PieSeries
                    {
                        Title = row["Status"].ToString(),
                        Values = new ChartValues<int> { Convert.ToInt32(row["Count"]) },
                        DataLabels = true
                    });
                }

                ProjectPieChart.Series = ProjectStatusSeries;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading project status chart: " + ex.Message);
            }
        }

        private void LoadRecentReviews()
        {
            try
            {
                string query = "SELECT TOP 3 ReviewId, CustomerId, Content, Rating FROM Reviews ORDER BY ReviewId DESC";
                DataTable dt = DBHelper.ExecuteQuery(query, null);

                RecentReviews = new List<Review>();

                foreach (DataRow row in dt.Rows)
                {
                    var review = new Review
                    {
                        ReviewId = Convert.ToInt32(row["ReviewId"]),
                        CustomerId = Convert.ToInt32(row["CustomerId"]),
                        Content = row["Content"].ToString(),
                        Rating = Convert.ToInt32(row["Rating"]),
                        CustomerName = "Customer " + row["CustomerId"]
                    };

                    switch (review.Rating)
                    {
                        case >= 4:
                            review.BackgroundColor = "#E3F2FD";
                            review.BorderColor = "#4F83CC";
                            break;
                        case 3:
                            review.BackgroundColor = "#F1F8E9";
                            review.BorderColor = "#8BC34A";
                            break;
                        default:
                            review.BackgroundColor = "#FFEBEE";
                            review.BorderColor = "#F44336";
                            break;
                    }

                    RecentReviews.Add(review);
                }

                ReviewsStackPanel.DataContext = this;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading reviews: " + ex.Message);
            }
        }

        // Navigation Methods
        private void OnDashboardClick(object sender, MouseButtonEventArgs e) => NavigationService?.Navigate(new DashboardPage());
        private void OnCustomersClick(object sender, MouseButtonEventArgs e) => NavigationService?.Navigate(new CustomerPage());
        private void OnProjectsClick(object sender, MouseButtonEventArgs e) => NavigationService?.Navigate(new ProjectPage());
        private void OnPaymentsClick(object sender, MouseButtonEventArgs e) => NavigationService?.Navigate(new PaymentPage());
        private void OnReviewsClick(object sender, MouseButtonEventArgs e) => NavigationService?.Navigate(new ReviewPage());
        private void OnLogoutClick(object sender, MouseButtonEventArgs e) => NavigationService?.Navigate(new LoginPage());
    }
}
