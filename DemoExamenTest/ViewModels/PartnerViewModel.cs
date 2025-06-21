using DemoExamenTest.Models;
using DemoExamenTest.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoExamenTest.ViewModels;

public class PartnerViewModel
{
    private readonly PartnerDbContext _context;

    public PartnerViewModel(PartnerDbContext context)
    {
        _context = context;
    }

    public List<PartnerModelView> GetPartners()
    {
        return _context.Partners
            .Include(p => p.PartnerType)
            .Include(p => p.Products)
            .ThenInclude(pi => pi.ProductInfo)
            .ThenInclude(pt => pt.ProductType)
            .Select(p => new PartnerModelView
                {
                    Id = p.Id,
                    Name = p.Name,
                    Director = p.Director,
                    Email = p.Email,
                    Phone = p.Phone,
                    Address = p.Address,
                    Inn = p.Inn,
                    Rating = p.Rating,
                    PartnerTypeName = p.PartnerType.Name,
                    Products = p.Products.ToList(),
                    Discount = CalculateDiscount(p.Products),
                })
            .ToList();
    }

    public List<PartnerType> GetPartnerTypes()
    {
        return _context.PartnerTypes.ToList();
    }

    public List<SaleHistoryModelView> GetSaleHistory()
    {
        return _context.Products
            .Include(p => p.ProductInfo)
            .Include(p => p.Partner)
            .Select(p => new SaleHistoryModelView
            {
                ProductInfo = p.ProductInfo.Name,
                Quantity = p.Quantity,
                SaleDate = p.SaleDate,
                TotalSale = p.Quantity * p.ProductInfo.MinCost
            })
            .ToList();
    }

    public void AddPartner(Partner partner)
    {
        _context.Partners.Add(partner);
        _context.SaveChanges();
    }

    public static decimal CalculateDiscount(ICollection<Product> products)
    {
        decimal totalSales = products.Sum(pr => pr.Quantity * pr.ProductInfo.MinCost);
        return totalSales > 300000000 ? 15 : totalSales > 100000000 ? 10 : totalSales > 50000000 ? 5 : 0;
    }

    public PartnerModelView GetPartnerById(int id)
    {
        return GetPartners().FirstOrDefault(p => p.Id == id)?? new PartnerModelView();
    }

    public int GetPartnerTypeId(string partnerType)
    {
        return _context.PartnerTypes.FirstOrDefault(p => p.Name == partnerType).Id;
    }

    public void EditPartner(PartnerModelView model)
    {
        var partner = _context.Partners.FirstOrDefault(p => p.Id == model.Id);
        
        if (partner == null) return;
        
        var partnerTypeId = _context.PartnerTypes.FirstOrDefault(p => p.Name == model.PartnerTypeName).Id;

        if (partnerTypeId == null) 
            partnerTypeId = partner.PartnerTypeId;
        
        partner.Name = model.Name;
        partner.Director = model.Director;
        partner.Email = model.Email;
        partner.Phone = model.Phone;
        partner.Address = model.Address;
        partner.Inn = model.Inn;
        partner.Rating = model.Rating;
        partner.PartnerTypeId = partnerTypeId;
        
        _context.SaveChanges();
    }
}