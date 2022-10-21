﻿namespace APC.DAL.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public string Email { get; set; }
        public string? ObjectIdentifier { get; set; }
    }
}
