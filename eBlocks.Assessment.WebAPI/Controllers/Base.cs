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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TEntity>>> Get(string id)
        {
            try
            {
                var _results = await Repository.FindById(id);
                if (_results is null)
                    return StatusCode(StatusCodes.Status404NotFound ,$"{id} Not found .");
                else 
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet("ByName")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TEntity>>> ByName(string name)
        {
            try
            {
                var _results = await Repository.FindByName(name);
                if (_results is null)
                    return StatusCode(StatusCodes.Status404NotFound, $"{name} not found.");
                else
                    return Ok(_results);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
