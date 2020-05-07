using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StarshipfleetsAPI.DAL;
using StarshipfleetsAPI.Models.User;

namespace StarshipfleetsAPI.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        [Route("UserLoginCall")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult UserLoginCall([FromBody]User user)
        {
            try
            {
                return Ok(UserDAL.UserLogin(user.UserEmail, user.Password));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("CreateLoginCall")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult CreateLoginCall([FromBody]User user)
        {
            try
            {
                return Ok(UserDAL.CreateLogin(user.UserEmail, user.Password));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}