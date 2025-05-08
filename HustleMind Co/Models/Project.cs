using System;

namespace HustleMind_Co_.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int CustomerId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
