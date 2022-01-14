using HouseSelfInspection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSelfInspection.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InspectionController : Controller
    {

        private readonly ApplicationContext context;

        public InspectionController(ApplicationContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<InspectionModel>> Get()
        {
            try
            {
                return context.Inspections;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InspectionModel model)
        {
            try
            {
                context.Inspections.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InspectionModel model)
        {
            try
            {
                if(id != model.InspectionId)
                {
                    return BadRequest();
                }
                else
                {
                    context.Entry(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return Ok(model);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                context.Inspections.Remove(context.Inspections.Find(id));
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        private InspectionModel[] inspectionList = new InspectionModel[]

        {
            new InspectionModel
            {
                InspectionId = 1, TenantId = 1, Inspection_date = new DateTime(), Inspection_status = "", HouseId = 1
            },
            new InspectionModel
            {
                InspectionId = 2, TenantId = 1, Inspection_date = new DateTime(), Inspection_status = "", HouseId = 3
            },
            new InspectionModel
            {
                InspectionId = 3, TenantId = 2, Inspection_date = new DateTime(), Inspection_status = "", HouseId = 3
            },
            new InspectionModel
            {
                InspectionId = 4, TenantId = 2, Inspection_date = new DateTime(), Inspection_status = "", HouseId = 4,
            },
            new InspectionModel
            {
                InspectionId = 5, TenantId = 2, Inspection_date = new DateTime(), Inspection_status = "", HouseId = 5
            }

         };

    }
    


}

