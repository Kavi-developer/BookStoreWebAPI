using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Customer_Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookDbContext context;

        public CustomerRepository(BookDbContext context)
        {
            this.context = context;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return null;
                }
                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Customer?> DeleteCustomer(int customerId)
        {

            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(a => a.CustomerId == customerId);
                if (customer == null)
                {
                    return null;
                }
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
                return customer;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(a => a.CustomerId == id);
                if (customer == null)
                {
                    return null;
                }
                return customer;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Customer?> UpdateCustomer(int customerId, Customer customer)
        {
            try
            {
                var resCustomer = await context.Customers.FirstOrDefaultAsync(a => a.CustomerId == customerId);
                if (resCustomer == null)
                {
                    return null;
                }
                resCustomer.CustomerName = customer.CustomerName;
                resCustomer.ContactId= customer.ContactId;
                resCustomer.Contact = customer.Contact;

                await context.SaveChangesAsync();
                return resCustomer;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
