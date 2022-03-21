using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.CarOffers.ToListAsync();
            offers.First().DiscountPercentage = 0.15m;
            return Ok(offers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
    }
}