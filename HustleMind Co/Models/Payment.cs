using System;

namespace HustleMind_Co_.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ProjectId { get; set; }
        public required string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public required string PaymentStatus { get; set; }
        public required string PaymentMethod { get; set; }
        public string? FilePath { get; set; }
    }
}
