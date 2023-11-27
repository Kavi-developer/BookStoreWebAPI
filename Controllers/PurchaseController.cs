using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Purchase_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPurchases()
        {
            var allPurchases=await purchaseRepository.GettAllPurchase();
            return Ok(allPurchases);
        }

        [HttpGet]
        [Route("{PurchaseId}")]
        public async Task<IActionResult> GetPurchaseById([FromRoute]int PurchaseId)
        {
            var purchase =await purchaseRepository.GetPurchaseById(PurchaseId);
            if(purchase == null)
            {
                return BadRequest();
            }
            return Ok(purchase);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> addPurchases([FromBody] Purchase purchase)
        {
            var result =await purchaseRepository.AddPurchase(purchase);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        [HttpPut]
        [Route("{PurchaseId}")]
        [ValidateModel]
        public async Task<IActionResult> updatePurchases([FromRoute]int PurchaseId, [FromBody] Purchase purchase)
        {
            var result=await purchaseRepository.UpdatePurchaseById(PurchaseId,purchase);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{PurchaseId}")]
        public async Task<IActionResult> DeletePurchase([FromRoute]int PurchaseId)
        {
            var result=await purchaseRepository.DeletePurchaseById(PurchaseId);

            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


    }
}
