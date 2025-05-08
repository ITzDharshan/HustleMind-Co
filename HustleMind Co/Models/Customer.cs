using System;

namespace HustleMind_Co_.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string Mobile { get; set; }
        public required string NICNumber { get; set; }
        public required string Address { get; set; }
    }
}
