using System;
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
    public class RegSchSuperController : Controller
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;

        public RegSchSuperController(SiwesData.ApplicationDbContext context, UserManager<AppUserTab> userManager)
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



        [HttpGet("{instSupEmail}")]
        public async Task<ActionResult<List<string>>> Getsuperid(string instSupEmail, int instid, string offtype)
        {
            //   var result = "";

            List<string> result = new List<string>();
            try
            {


                var staffidinfo = await _context.InstitutionOfficers.FirstOrDefaultAsync(m => m.Email == instSupEmail.Trim()
                && m.OfficerType == "2");

                if (staffidinfo == null)
                {
                    result.Insert(0, "notexist");
                }
                else
                {
                    //   var user = _context.StudentSetUps.Where(m => m.Email == email.Trim()).ToList();

                    #region  check if the account has been registered 
                    var user = _userManager.FindByEmailAsync(instSupEmail.Trim());
                    if (user != null)
                    {
                        result.Insert(0, "alreg");
                    }
                    #endregion

                    else if (staffidinfo != null)
                    {
                        result.Insert(0, staffidinfo.IntOfficerName.ToString().Trim());
                        result.Insert(1, staffidinfo.Email.ToString());

                    }
                    else
                    {
                        result.Insert(0, "notexist");
                    }
                }



            }
            catch (Exception ex)
            {
                result.Insert(0, ex.Message + ex.StackTrace);
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
