using BCS_Exam.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCS_Exam.Controllers
{
    [Route("api/NPS/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET api/<CustomersController>
        [HttpGet]
        public ActionResult Get(string parkCode, string arriving)
        {
            List<Customer> customerList = null;
            if (string.IsNullOrEmpty(parkCode) || string.IsNullOrEmpty(arriving))
                goto BadRequest;
            using (var context = new BCSContext())
            {
                IEnumerable<Customer> customer = from t in context.Talktoguests
                                                 join st in context.SpokenToGuests on t.ResId equals st.ResId into lst
                                                 from sub_st in lst.DefaultIfEmpty()
                                                 where t.ParkCode == parkCode && t.Arrived == arriving
                                                 //remove spoken guests
                                                 && string.IsNullOrEmpty(sub_st.ResId)
                                                 select new Customer
                                                 {
                                                     ReservationId = t.ResId,
                                                     GuestName = t.GuestName,
                                                     GuestMobile = t.GuestMobile,
                                                     AreaName = t.AreaName,
                                                     Arrived = t.Arrived,
                                                     Category = t.Category,
                                                     Depart = t.Depart,
                                                     Nights = t.NightsThisRes,
                                                     PreviousNPCComment = t.PrevNpsComment,
                                                     PreviousNPS = string.IsNullOrEmpty(t.PrevNps) ? null : t.PrevNps
                                                 };
                customerList = customer.ToList();
            }
            BadRequest:
            if (customerList == null ||
                customerList.Count == 0)
                return BadRequest("You must filter the contents of the talktoguests table by finding only records matching parkCode and arrived");
            return Ok(new JsonResult(customerList));
        }
    }
}
