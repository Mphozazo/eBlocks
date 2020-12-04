using eBlocks.Assessment.Models;
using eBlocks.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace eBlocks.Assessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Base<Product, ProductRepo>
    {
        public ProductController(ProductRepo productRepository) : base(productRepository)
        {
        }
    }
}