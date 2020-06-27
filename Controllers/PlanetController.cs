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
                return Ok(PlanetDAL.GetGalaxySystems(GalaxyID));
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


        [Route("GetSystem/{GalaxyID}/{SectorID}/{System}")]
        [HttpGet]
        [ResponseType(typeof(PlanetTypeDetail))]
        public IHttpActionResult GetSystem(int GalaxyID, string SectorID, int System)
        {
            try
            {
                return Ok(PlanetDAL.GetGalaxy(GalaxyID, SectorID, System));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("GetPlanet/{PlanetID}/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(PlanetDetail))]
        public IHttpActionResult GetPlanet(int PlanetID, int UserID)
        {
            try
            {
                return Ok(PlanetDAL.GetPlanet(PlanetID, UserID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("UpdatePlanetPop")]
        [HttpPost]
        [ResponseType(typeof(PlanetStats))]
        public IHttpActionResult UpdatePlanetPop([FromBody]PlanetDetail planetDetail)
        {
            try
            {
                return Ok(PlanetDAL.UpdatePlanetPop(planetDetail));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("UpdatePlanetHarvest")]
        [HttpPost]
        [ResponseType(typeof(PlanetStats))]
        public IHttpActionResult UpdatePlanetHarvest([FromBody]PlanetDetail planetDetail)
        {
            try
            {
                return Ok(PlanetBLL.UpdatePlanetHarvest(planetDetail));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("ColonizePlanet")]
        [HttpPost]
        [ResponseType(typeof(PlanetDetail))]
        public IHttpActionResult ColonizePlanet([FromBody]PlanetDetail planetDetail)
        {
            try
            {
                return Ok(PlanetDAL.ColonizePlanet(planetDetail));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetBuildingTypes/{PlanetID}")]
        [HttpGet]
        [ResponseType(typeof(List<PlanetBuildings>))]
        public IHttpActionResult GetBuildingTypes(int PlanetID)
        {
            try
            {
                return Ok(PlanetDAL.GetBuildingTypes(PlanetID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("AddBuildingQueue")]
        [HttpPost]
        [ResponseType(typeof(PlanetDetail))]
        public IHttpActionResult AddBuildingQueue([FromBody]BuildingQue buildingQue)
        {
            try
            {
                return Ok(PlanetBLL.AddBuildingQueue(buildingQue));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetBuildingQueue/{PlanetID}/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(AllbuildQues))]
        public IHttpActionResult GetBuildingQueue(int PlanetID, int UserID)
        {
            try
            {
                return Ok(PlanetBLL.GetBuildingQueue(PlanetID, UserID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetPlanetStats/{PlanetID}")]
        [HttpGet]
        [ResponseType(typeof(BuildingQue))]
        public IHttpActionResult BuildingQueue(int PlanetID)
        {
            try
            {
                return Ok(PlanetDAL.GetPlanetStats(PlanetID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}