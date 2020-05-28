using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StarshipfleetsAPI.BLL;
using StarshipfleetsAPI.DAL;
using StarshipfleetsAPI.Models.Planets;
using StarshipfleetsAPI.Models.Research;

namespace StarshipfleetsAPI.Controllers
{
    [RoutePrefix("Research")]
    public class ResearchController : ApiController
    {

        [Route("GetResearchTypes/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(List<Technology>))]
        public IHttpActionResult GetResearchTypes(int UserID)
        {
            try
            {
                return Ok(ResearchDAL.GetResearchTypes(UserID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("AddResearchQueue")]
        [HttpPost]
        [ResponseType(typeof(PlanetDetail))]
        public IHttpActionResult AddResearchQueue([FromBody]BuildingQue buildingQue)
        {
            try
            {
                return Ok(ResearchBLL.AddResearchQueue(buildingQue));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}