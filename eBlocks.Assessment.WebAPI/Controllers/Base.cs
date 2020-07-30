using System;
using Microsoft.AspNetCore.Mvc;
using eBlocks.Assessment.Models.Interface;
using eBlocks.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace eBlocks.Assessment.WebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public abstract class Base<TEntity, TRepository> : ControllerBase
     where TEntity : class, IEntity
     where TRepository : IRepository<TEntity>
    {
        public Base(TRepository repository)
        {
            Repository = repository;
        }

        public TRepository Repository { get; set; }

        // <summary>
        // Get a list of all data.
        // </summary>
        // <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> GetTask()
        {
            try
            {
                var results = await Repository.GetAll();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
        // <summary>
        // Get a data based on the reference Id
        // </summary>
        // <param name = "id" > Reference Id</param>
        // <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TEntity>>> Get(string id)
        {
            try
            {
                return Ok(await Repository.FindById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // <summary>
        // Delete the reference Id item
        // </summary>
        // <param name = "id" > Reference Id</param>
        // <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TEntity>>> Delete(string id)
        {
            try
            {
                return Ok(await Repository.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // <summary>
        // Insert new Data.
        // </summary>
        // <param name = "data" > Data to be Added</param>
        // <returns></returns>
        [HttpPost]
        public async Task<ActionResult<bool>> Post(TEntity data)
        {
            try
            {
                await Repository.Add(data);
                return Ok(true);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // <summary>
        // Update the current item.
        // </summary>
        // <param name = "data" > Updated Data</param>
        // <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put([FromBody] TEntity data)
        {
            try
            {
                await Repository.Update(data);
                return Ok(true);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
