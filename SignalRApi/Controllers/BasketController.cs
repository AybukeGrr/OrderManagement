using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccesssLayer.Concrete;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("GetBasketByMenuTableNumber")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            return Ok(_basketService.TGetBasketByMenuTableNumber(id));
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                MenuTableID = z.MenuTableID,
                Count = z.Count,
                Price = z.Price,
                ProductID = z.ProductID,
                ProductName = z.Product.ProductName,
                TotalPrice = z.TotalPrice,
            }).ToList();
            return Ok(values);
        }
    }
}
