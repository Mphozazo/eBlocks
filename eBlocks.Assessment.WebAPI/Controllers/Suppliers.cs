using eBlocks.Assessment.Models;
using eBlocks.Core.Interfaces;
using eBlocks.Core.Repo.Mongodb;
using eBlocks.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace eBlocks.Assessment.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    ///  Supplier API 
    /// </summary>
    public class SupplierController : Base<Supplier,SupplierRepo>
    {
        public SupplierController(SupplierRepo supplierRepository) : base (supplierRepository)
        { 

        }

    }
}
