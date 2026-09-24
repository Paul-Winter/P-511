using System;
using System.Collections.Generic;

namespace SportsClub.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(1);

    public int? MaxVisits { get; set; }
    public int UsedVisits { get; set; } = 0;

        public bool IsActive { get; set; } = true;
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public Client? Client { get; set; }
        public List<Visit> Visits { get; set; } = new();
    }
}