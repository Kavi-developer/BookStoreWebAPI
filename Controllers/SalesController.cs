using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Purchase_Repository;
using BooksStoreWebAPI.Repository.Sales_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository salesRepository;

        public SalesController(ISalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var allSales = await salesRepository.GetAllSales();
            return Ok(allSales);
        }

        [HttpGet]
        [Route("{SaleId}")]
        public async Task<IActionResult> GetSaleById([FromRoute] int SaleId)
        {
            var sale = await salesRepository.GetSaleById(SaleId);
            if (sale == null)
            {
                return BadRequest();
            }
            return Ok(sale);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddSale([FromBody] Sale sale)
        {
            var result = await salesRepository.AddSale(sale);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        [HttpPut]
        [Route("{SaleId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateSale([FromRoute] int SaleId, [FromBody] Sale sale)
        {
            var result = await salesRepository.UpdateSaleById(SaleId, sale);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{SaleId}")]
        public async Task<IActionResult> DeletePurchase([FromRoute] int SaleId)
        {
            var result = await salesRepository.DeleteSaleById(SaleId);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
