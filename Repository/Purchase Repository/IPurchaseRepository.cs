using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Purchase_Repository
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GettAllPurchase();

        Task<Purchase?> GetPurchaseById(int purchaseId);

        Task<Purchase> AddPurchase(Purchase purchase);

        Task<Purchase?> UpdatePurchaseById(int purchaseId,Purchase purchase);

        Task<Purchase?> DeletePurchaseById(int purchaseId);
    }
}
