using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Sales_Repository
{
    public interface ISalesRepository    {
        Task<List<Sale>> GetAllSales();

        Task<Sale?> GetSaleById(int saleId);

        Task<Sale> AddSale(Sale sale);

        Task<Sale?> UpdateSaleById(int saleId, Sale sale);

        Task<Sale?> DeleteSaleById(int saleId);
    }
}
