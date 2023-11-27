using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Customer_Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer?> UpdateCustomer(int customerId,Customer customer);
        Task<Customer?> DeleteCustomer(int customerId);
        
    }
}
