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
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        readonly InspectionContext context;

        public TenantController(InspectionContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TenantModel>> Get()
        {
            return context.Tenants;
        
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TenantModel model)
        {
            context.Tenants.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TenantModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }

    }
}