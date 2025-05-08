namespace HustleMind_Co_.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int CustomerId { get; set; }
        public required string Content { get; set; }
        public int Rating { get; set; }
        public string CustomerName { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }

        public Review()
        {
            // Default colors for background and border
            BackgroundColor = "#E3F2FD"; // Light Blue
            BorderColor = "#4F83CC"; // Blue
        }
    }
}
