using System;

namespace HustleMind_Co_.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Mobile { get; set; }
        public required string Password { get; set; }
    }
}
