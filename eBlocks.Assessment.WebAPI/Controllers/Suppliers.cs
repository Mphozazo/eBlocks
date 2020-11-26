using eBlocks.Assessment.Models;
using eBlocks.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using eBlocks.Assessment.Models.Interface;
using System;
using Microsoft.AspNetCore.Http;

namespace eBlocks.Assessment.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Base<Supplier, SupplierRepo>
    {
        public SupplierController(SupplierRepo supplierRepository) : base(supplierRepository)
        {
           
        }

    }

}
