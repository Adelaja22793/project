﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSSL_SIWES.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegempController : Controller
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RegempController(SiwesData.ApplicationDbContext context, UserManager<IdentityUser> userManager)
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
  

        // GET api/<controller>/5
        [HttpGet("{rcno}")]
        public async Task<ActionResult<List<string>>> GetRcNo(string rcno)
        {
         //   var result = "";

            List<string> result = new List<string>();
            try
            {
                // get email 

                // var user = _context.StudentSetUps.FirstOrDefault(m => m.MatricNumber == matricno.Trim());


                var identityUser = await _userManager.FindByNameAsync(rcno.Trim());

           

                if (identityUser != null)
                {
                    result.Insert(0, "exist");
                }
                else
                {
                    //   var user = _context.StudentSetUps.Where(m => m.Email == email.Trim()).ToList();

                    var user = _context.EmployerSuperSetups.FirstOrDefault(m => m.Code == rcno.Trim());
                    // check if email has beeen registered

                    if (user != null)
                    {
                        result.Insert(0, user.Name.Trim());
                        result.Insert(1, user.Email.Trim());
                     
                    }
                    else
                    {
                        result.Insert(0, "notexist");
                    }
                }



            }
            catch
            {
                result.Insert(0, "syserr");
            }
            return result;

        }

        [HttpGet("{staffid}")]
        public async Task<ActionResult<List<string>>> Getstaffid(string staffid)
        {
            //   var result = "";

            List<string> result = new List<string>();
            try
            {
                // get email 

                // var user = _context.StudentSetUps.FirstOrDefault(m => m.MatricNumber == matricno.Trim());

                var staffidinfo = await _context.ItfStaff.FirstOrDefaultAsync(m => m.StaffId == staffid.Trim());
              //  var identityUser = await _userManager.FindByNameAsync(rcno.Trim());



                if (staffidinfo == null)
                {
                    result.Insert(0, "notexist");
                }
                else
                {
                    //   var user = _context.StudentSetUps.Where(m => m.Email == email.Trim()).ToList();

               
                    if (staffidinfo != null)
                    {
                        result.Insert(0, staffidinfo.Surname.ToString().Trim() + " " + staffidinfo.OtherNames.ToString().Trim());
                        result.Insert(1, staffidinfo.Email.ToString());

                    }
                    else
                    {
                        result.Insert(0, "notexist");
                    }
                }



            }
            catch
            {
                result.Insert(0, "syserr");
            }
            return result;

        }

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
