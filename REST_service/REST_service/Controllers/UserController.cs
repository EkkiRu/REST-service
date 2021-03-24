using NHibernate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_service.Date;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST_service
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ISession session;

        public UserController(ISession session)
        {
            this.session = session;
        }
        
        static List<Person> ListPerson = new List<Person>();

        [HttpGet]
        public ActionResult GetTest(string text)
        {
            if (text == null)
            {
                return Ok(JsonConvert.SerializeObject(ListPerson));
            }
            else
            {
                return Ok(text.Split(new char[] { ' ' }));
            }
        }
        [HttpPost]
        public ActionResult<Person> Post(Person incominguser)
        {
            try
            {
                var user = session.Query<Person>().FirstOrDefault(x => x.IIN == incominguser.IIN);
                if (user != null)
                {
                    return Ok("Duplicate");
                }
                else
                {
                    ListPerson.Add(incominguser);
                    session.Save(incominguser);
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

