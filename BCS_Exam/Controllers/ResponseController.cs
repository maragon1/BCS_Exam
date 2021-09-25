using BCS_Exam.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCS_Exam.Controllers
{
    [Route("api/NPS/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {

        // POST api/<ResponseController>
        [HttpPost]
        public async Task<ActionResult> Post(string ResId, string UserEmail)
        {
            if (string.IsNullOrEmpty(ResId) || string.IsNullOrEmpty(UserEmail))
            {
                return BadRequest("A new record must be inserted into the spokenToGuests table with these details.");
            }
            using (var context = new BCSContext())
            {
                context.SpokenToGuests.Add(new SpokenToGuests() { ResId = ResId, UserEmail = UserEmail });
                await context.SaveChangesAsync();
            }
            return Ok(null);
        }
    }
}
