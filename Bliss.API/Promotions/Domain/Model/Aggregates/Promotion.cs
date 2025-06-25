using Bliss.API.Promotions.Domain.Model.Commands;

namespace Bliss.API.Promotions.Domain.Model.Aggregates;

public partial class Promotion
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal DiscountPercentage { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string PromoCode { get; set; } = string.Empty;
    public int MaxUses { get; set; }
    public int CurrentUses { get; set; }
    public string MinRequirements { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int CompanyServiceId { get; set; }

    public Promotion() { }

    public Promotion(CreatePromotionCommand command)
    {
        Title = command.Title;
        Description = command.Description;
        DiscountPercentage = command.DiscountPercentage;
        DiscountAmount = command.DiscountAmount;
        StartDate = command.StartDate;
        EndDate = command.EndDate;
        PromoCode = command.PromoCode;
        MaxUses = command.MaxUses;
        CurrentUses = 0; // Initialize to 0
        MinRequirements = command.MinRequirements;
        CompanyId = command.CompanyId;
        CompanyServiceId = command.CompanyServiceId;
    }
}

/*
id
title
description
discount_percenta
discount_amount
start_date
end_date
promo_code
max_uses
current_uses
min_requeriments

created_at
updated_at

companies_id
company_services_id


*/