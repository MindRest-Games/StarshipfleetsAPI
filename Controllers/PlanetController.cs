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
        public IHttpActionResult GetPlanetTypeDetailCall(int PlanetTypeID)
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


        [Route("GetGalaxy/{GalaxyID}")]
        [HttpGet]
        [ResponseType(typeof(PlanetTypeDetail))]
        public IHttpActionResult GetGalaxy(int GalaxyID)
        {
            try
            {
                return Ok(PlanetDAL.GetGalaxy(GalaxyID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetSector/{GalaxyID}/{SectorID}")]
        [HttpGet]
        [ResponseType(typeof(PlanetTypeDetail))]
        public IHttpActionResult GetSector(int GalaxyID, string SectorID)
        {
            try
            {
                return Ok(PlanetDAL.GetGalaxy(GalaxyID, SectorID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("GetPlanet/{PlanetID}")]
        [HttpGet]
        [ResponseType(typeof(PlanetTypeDetail))]
        public IHttpActionResult GetPlanet(int PlanetID)
        {
            try
            {
                return Ok(PlanetDAL.GetPlanet(PlanetID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}