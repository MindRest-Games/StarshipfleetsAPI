using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StarshipfleetsAPI.DAL;
using StarshipfleetsAPI.Models.Planets;
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

        [Route("GetPlanetList/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(List<PlanetDetail>))]
        public IHttpActionResult GetPlanet(int UserID)
        {
            try
            {
                return Ok(UserDAL.GetPlanetList(UserID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetFirstPlanet/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(List<PlanetDetail>))]
        public IHttpActionResult GetFirstPlanet(int UserID)
        {
            try
            {
                return Ok(UserDAL.GetFirstPlanet(UserID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}