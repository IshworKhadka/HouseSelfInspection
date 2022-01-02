using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

        //public TenantController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        public TenantController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TenantModel>> Get()
        {
            try
            {
                return context.Tenants;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("{id}")]
        public ActionResult<TenantModel> Get(int id)
        {
            try
            {
                return context.Tenants.Find(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TenantModel model)
        {
            try
            {
                context.Tenants.Add(model);

                //var loginModel = new LoginModel()
                //{
                //    username = model.Username,


                //    password = model.Password,
                //    isAdmin = false
                //};

                //var applicationUser = new ApplicationUser()
                //{
                //    UserName = model.Username,
                //    Email = model.Email,
                //    FullName = model.Name
                //};


                //context.Login.Add(loginModel);
                //var result = _userManager.CreateAsync(applicationUser, model.Password);
                await context.SaveChangesAsync();
                return Ok(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TenantModel model)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                context.Tenants.Remove(context.Tenants.Find(id));
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost, DisableRequestSizeLimit]
        public  IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("All the files are successfully uploaded");
                
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

       
    }
}