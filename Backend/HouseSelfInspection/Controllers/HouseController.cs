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

        readonly InspectionContext context;

        public HouseController(InspectionContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HouseModel>> Get()
        {
            return context.Houses;
            //return new HouseModel[] {
            //    new HouseModel(){ House_Number= "24", Street = "Aberfeldy Avenue", Suburb = "Edwardstown", State = "South Australia", Postal_Code ="5039" },
            //    new HouseModel(){ House_Number= "6", Street = "Winton Avenue", Suburb = "Broadview", State = "South Australia", Postal_Code ="5048" },
            //    new HouseModel(){ House_Number= "99", Street = "Barramundi Drive", Suburb = "Hallett Cove", State = "South Australia", Postal_Code ="5158" },
            //    new HouseModel(){  House_Number= "9/850", Street = "Pascoe Vale Road", Suburb = "Glenroy", State = "Victoria", Postal_Code ="3046" }
            //};
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HouseModel model)
        {
            context.Houses.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HouseModel model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
            
        }



    }
}