using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseSelfInspection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseSelfInspection.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : Controller
    {

        readonly ApplicationContext context;

        public HouseController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HouseModel>> Get()
        {
            try
            {
                return context.Houses;
                //return new HouseModel[] {
                //    new HouseModel(){ House_Number= "24", Street = "Aberfeldy Avenue", Suburb = "Edwardstown", State = "South Australia", Postal_Code ="5039" },
                //    new HouseModel(){ House_Number= "6", Street = "Winton Avenue", Suburb = "Broadview", State = "South Australia", Postal_Code ="5048" },
                //    new HouseModel(){ House_Number= "99", Street = "Barramundi Drive", Suburb = "Hallett Cove", State = "South Australia", Postal_Code ="5158" },
                //    new HouseModel(){  House_Number= "9/850", Street = "Pascoe Vale Road", Suburb = "Glenroy", State = "Victoria", Postal_Code ="3046" }
                //};

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("{id}")]
        public HouseModel Get(int id)
        {
            try
            {
                return context.Houses.Find(id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HouseModel model)
        {
            try
            {
                context.Houses.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HouseModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return BadRequest();
                }

                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }



    }
}