using System;

namespace SportsClub.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime VisitDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

    public Client? Client { get; set; }
    public Subscription? Subscription { get; set; }
    }
}
