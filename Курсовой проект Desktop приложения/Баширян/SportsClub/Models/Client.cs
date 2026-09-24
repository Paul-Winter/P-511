using System;
using System.Collections.Generic;

namespace SportsClub.Models
{
    public class Client
    {
       public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Login { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public decimal TotalSpent { get; set; } = 0;
       public int DiscountPercent { get; set; } = 0;

        public List<Subscription> Subscriptions { get; set; } = new();
        public List<Visit> Visits { get; set; } = new();
        //запускается ток с dotnet run
    }
}
