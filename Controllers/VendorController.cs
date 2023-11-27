using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Menu_Repository;
using BooksStoreWebAPI.Repository.Vendor_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepository vendorRepository;

        public VendorController(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddVendor([FromBody] Vendor vendor)
        {
            var result = await vendorRepository.AddVendor(vendor);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{vendorId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateVendor([FromRoute] int vendorId, [FromBody] Vendor vendor)
        {
            var result = await vendorRepository.UpdateVendor(vendorId, vendor);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendor()
        {
            var result = await vendorRepository.GetAllVendor();
            return Ok(result);

        }

        [HttpGet]
        [Route("{vendorId}")]
        public async Task<IActionResult> GetVendorById([FromRoute] int vendorId)
        {
            var result = await vendorRepository.GetVendorById(vendorId);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{vendorId}")]
        public async Task<IActionResult> DeleteVendor([FromRoute] int vendorId)
        {
            var result = await vendorRepository.DeleteVendor(vendorId);
            if (result == null)
            {
                return BadRequest("No Results Found");
            }

            return Ok(result);

        }
    }

}
