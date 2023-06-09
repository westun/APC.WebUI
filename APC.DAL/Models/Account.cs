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
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        public ICollection<AccountProduct> AccountProduct { get; set; } = new List<AccountProduct>();
    }
}
