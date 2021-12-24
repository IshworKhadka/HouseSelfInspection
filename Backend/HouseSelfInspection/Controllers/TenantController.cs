using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseSelfInspection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseSelfInspection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        readonly ApplicationContext context;
        private UserManager<ApplicationUser> _userManager;

        public TenantController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public TenantController(ApplicationContext context)
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
            try
            {
                context.Tenants.Add(model);

                var loginModel = new LoginModel()
                {
                    username = model.Username,
                    password = model.Password,
                    isAdmin = false
                };

                var applicationUser = new ApplicationUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FullName = model.Name
                };


                context.Login.Add(loginModel);
                var result = _userManager.CreateAsync(applicationUser, model.Password);
                await context.SaveChangesAsync();
                return Ok(result);

            }
            catch (Exception ex)
            {

                throw ex;
            }
           

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