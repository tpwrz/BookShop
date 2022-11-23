using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    public partial class BooksOrdersUsersView
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public string ShippingAdr { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string OrderstatusName { get; set; } = null!;
        public decimal OrderPrice { get; set; }
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Telephone { get; set; }
        public string Email { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public string GenreName { get; set; } = null!;
        public string LanguageName { get; set; } = null!;
        public decimal Price { get; set; }
        public string CurrencyName { get; set; } = null!;
    }
}
