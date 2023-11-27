using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Sales_Repository
{
    public class SalesRepository : ISalesRepository
    {
        private readonly BookDbContext context;

        public SalesRepository(BookDbContext context)
        {
            this.context = context;
        }
        public async Task<Sale> AddSale(Sale sale)
        {
            try
            {
                if (sale == null)
                {
                    return null;
                }
                await context.Sales.AddAsync(sale);
                await context.SaveChangesAsync();
                return sale;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Sale?> DeleteSaleById(int saleId)
        {
            try
            {
                var sale = context.Sales.Include(a=> a.SaleDetails).FirstOrDefault(a => a.SaleId == saleId);
                if (sale == null)
                {
                    return null;
                }
                context.SaleDetails.RemoveRange(sale.SaleDetails);

                context.Sales.Remove(sale);
                await context.SaveChangesAsync();
                return sale;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Sale>> GetAllSales()
        {
           return await context.Sales.ToListAsync();
        }

        public async Task<Sale?> GetSaleById(int saleId)
        {
            try
            {
                var sale = await context.Sales.Include(a => a.SaleDetails).FirstOrDefaultAsync(p => p.SaleId == saleId);
                if (sale == null)
                {
                    return null;
                }
                return sale;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Sale?> UpdateSaleById(int saleId, Sale sale)
        {
            try
            {
                var resSales = await context.Sales.FirstOrDefaultAsync(a => a.SaleId == saleId);
                if (resSales == null)
                {
                    return null;
                }
                resSales.CustomerId = sale.CustomerId;
                resSales.SalesTax=sale.SalesTax;
                resSales.DiscountPercent = sale.DiscountPercent;
                resSales.DiscountAmount = sale.DiscountAmount;
                resSales.InvoiceAmount= sale.InvoiceAmount;
                resSales.SaleDetails= sale.SaleDetails;

                await context.SaveChangesAsync();
                return resSales;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
