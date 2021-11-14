using ApiAndEntityFramework.Api.Persistence;
using ApiAndEntityFramework.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAndEntityFramework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarContext context;

        public CarsController(CarContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return Ok( await context.Cars.ToListAsync() );
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCarById(int id) {
            return Ok( await context.Cars.Where(c=>c.Id==id).FirstOrDefaultAsync() );
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car car) 
        {

            if (car is null) return BadRequest();

            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();

            return Ok(car);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id) 
        {
            //var result = (await GetCarById(id)) as OkObjectResult.Value;
            var result = await context.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (result is null) return BadRequest();
            context.Cars.Remove(result);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> UpdateCar(int id, Car car) 
        {
            try
            {

            }
            catch (Exception)
            {
                return
                throw;
            }
        }


    }
}
