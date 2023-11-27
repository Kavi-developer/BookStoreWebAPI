using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Vendor_Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly BookDbContext context;

        public VendorRepository(BookDbContext context)
        {
            this.context = context;
        }
        public async Task<Vendor> AddVendor(Vendor vendor)
        {
            try
            {
                if (vendor == null)
                {
                    return null;
                }
                await context.Vendors.AddAsync(vendor);
                await context.SaveChangesAsync();
                return vendor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Vendor> DeleteVendor(int vendorId)
        {
            try
            {
                var vendor = await context.Vendors.FirstOrDefaultAsync(a => a.VendorId == vendorId);
                if (vendor == null)
                {
                    return null;
                }
                context.Vendors.Remove(vendor);
                await context.SaveChangesAsync();
                return vendor;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<List<Vendor>> GetAllVendor()
        {
            return context.Vendors.ToListAsync();
        }

        public async Task<Vendor> GetVendorById(int vendorId)
        {
            try
            {
                var vendor = await context.Vendors.FirstOrDefaultAsync(a => a.VendorId == vendorId);
                if (vendor == null)
                {
                    return null;
                }
                return vendor;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Vendor> UpdateVendor(int vendorId, Vendor vendor)
        {
            try
            {
                var resVendor = await context.Vendors.FirstOrDefaultAsync(a => a.VendorId == vendorId);
                if (resVendor == null)
                {
                    return null;
                }
                resVendor.VendorName = vendor.VendorName;
                resVendor.ContactId= vendor.ContactId;
                resVendor.Contact = vendor.Contact;
             
                await context.SaveChangesAsync();
                return resVendor;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
