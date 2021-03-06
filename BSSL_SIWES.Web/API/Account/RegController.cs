﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegController : Controller
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;

        public RegController(SiwesData.ApplicationDbContext context, UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{email}")]
        public async Task<ActionResult<string>> GetCheckMatric(string email)
        {
            var result = "";
            try
            {
                // get email 

                // var user = _context.StudentSetUps.FirstOrDefault(m => m.MatricNumber == matricno.Trim());


                var AppUserTab = await _userManager.FindByEmailAsync(email.Trim());

                if (AppUserTab != null)
                {
                    result ="exist";
                }
                else
                {
                 //   var user = _context.StudentSetUps.Where(m => m.Email == email.Trim()).ToList();

                    var user =  _context.StudentSetUps.FirstOrDefault(m => m.Email.Trim() == email.Trim());
                    // check if email has beeen registered

                    if (user != null)
                    {
                        result = user.Surname + " " + user.OtherNames;
                    }
                    else
                    {
                        result = "notexist";
                    }
                }
              


            }
            catch
            {
                result = "syserr";
            }
            return result;

        }

        // GET a

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
