using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Purchase_Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly BookDbContext context;

        public PurchaseRepository(BookDbContext context)
        {
            this.context = context;
        }
        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            try
            {
                if(purchase == null)
                {
                    return null;
                }
                await context.Purchases.AddAsync(purchase);
                await context.SaveChangesAsync();
                return purchase;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Purchase?> DeletePurchaseById(int purchaseId)
        {
            try
            {
                var purchase = context.Purchases.Include(a=> a.PurchaseDetails).FirstOrDefault(a => a.PurchaseId == purchaseId);
                if (purchase == null)
                {
                    return null;
                }
                context.PurchaseDetails.RemoveRange(purchase.PurchaseDetails);

                context.Purchases.Remove(purchase);
                await context.SaveChangesAsync();
                return purchase;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Purchase?> GetPurchaseById(int purchaseId)
        {
            try
            {
                var purchase = await context.Purchases.Include(a=> a.PurchaseDetails).FirstOrDefaultAsync(p => p.PurchaseId == purchaseId);
                if (purchase == null)
                {
                    return null;
                }
                return purchase;

            }catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<Purchase>> GettAllPurchase()
        {
            var purchases=await context.Purchases.ToListAsync();
            return purchases;
        }

        public async Task<Purchase?> UpdatePurchaseById(int purchaseId, Purchase purchase)
        {
            try
            {
                var resPurchases = await context.Purchases.FirstOrDefaultAsync(a => a.PurchaseId == purchaseId);
                if (resPurchases == null)
                {
                    return null;
                }
                resPurchases.VendorId = purchase.VendorId;
                resPurchases.SalesTax = purchase.SalesTax;
                resPurchases.DiscountPercent = purchase.DiscountPercent;
                resPurchases.DiscountAmount = purchase.DiscountAmount;
                resPurchases.InvoiceNumber = purchase.InvoiceNumber;
                resPurchases.InvoiceAmount = purchase.InvoiceAmount;
                resPurchases.InvoiceUrl = purchase.InvoiceUrl;
                resPurchases.PurchaseDetails= purchase.PurchaseDetails;

                await context.SaveChangesAsync();
                return resPurchases;

            }catch(Exception ex) {
                return null;
            }


        }
    }
}
