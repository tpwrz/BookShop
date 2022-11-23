using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    public partial class UsersView
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Adress { get; set; }
        public string? Telephone { get; set; }
        public string Email { get; set; } = null!;
        public string? Username { get; set; }
        public string StatusName { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
    }
}
