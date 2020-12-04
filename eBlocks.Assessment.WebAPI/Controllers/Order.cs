using eBlocks.Assessment.Models;
using eBlocks.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace eBlocks.Assessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Base<OrderDetails, OrderDetailRepo>
    {
        public OrderController(OrderDetailRepo orderRepository) : base(orderRepository)
        {
        }
    }
}