using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Vendor_Repository
{
    public interface IVendorRepository
    {
       Task<List<Vendor>> GetAllVendor();
        Task<Vendor> GetVendorById(int vendorId);
        Task<Vendor> AddVendor(Vendor vendor);
        Task<Vendor> UpdateVendor(int vendorId,Vendor vendor);   
        Task<Vendor> DeleteVendor(int vendorId);
    }
}
