using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StarshipfleetsAPI.DAL;
using StarshipfleetsAPI.Models.Planets;

namespace StarshipfleetsAPI.Controllers
{
    [RoutePrefix("Planet")]
    public class PlanetController : ApiController
    {
        [Route("GetPlanetTypeDetailCall/{PlanetTypeID}")]
        [HttpGet]
        [ResponseType(typeof(PlanetTypeDetail))]
        public IHttpActionResult Get(int PlanetTypeID)
        {
            try
            {
                return Ok(PlanetDAL.GetPlanetTypeDetail(PlanetTypeID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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