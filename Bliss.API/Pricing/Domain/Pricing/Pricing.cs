// Domain/Pricing/Pricing.cs
using System;
using Bliss.API.Domain.Specialists;

namespace Bliss.API.Domain.Pricing
{
    public class Pricing
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public object Service { get; set; }
        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
        public double BasePrice { get; set; }
        public double DiscountPrice { get; set; }
        public string Currency { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Constructor
        public Pricing(int serviceId, int specialistId, double basePrice, double discountPrice, string currency, DateTime validFrom, DateTime validTo)
        {
            ServiceId = serviceId;
            SpecialistId = specialistId;
            BasePrice = basePrice;
            DiscountPrice = discountPrice;
            Currency = currency;
            ValidFrom = validFrom;
            ValidTo = validTo;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}