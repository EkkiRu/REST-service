using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using REST_service.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_service
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ApplicationContext database;
        public UserController(ApplicationContext context)
        {
            database = context;
        }

        static List<User> ListUser = new List<User>();

        [HttpGet]
        public ActionResult GetTest(string text)
        {
            if (text == null)
            {
                return Ok(JsonConvert.SerializeObject(ListUser));
            }
            else
            {
                return Ok(text.Split(new char[] { ' ' }));
            }
        }
        [HttpPost]
        public async Task<ActionResult<User>> Post(User incominguser)
        {
            try
            {
                var user = database.Users.FirstOrDefault(x => x.IIN == incominguser.IIN);
                if (user != null)
                {
                    return Ok("Duplicate");
                }
                else
                {
                    ListUser.Add(incominguser);
                    database.Users.Add(incominguser);
                    database.SaveChanges();
                    return Ok("Save");
                }
            }
            catch
            {
                return Ok("Error");
            }
        }
    }
}

