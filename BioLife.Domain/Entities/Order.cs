using BioLife.Domain.Common;
using System;

namespace BioLife.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
