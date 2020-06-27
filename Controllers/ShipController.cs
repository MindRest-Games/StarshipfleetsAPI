using StarshipfleetsAPI.Models.Ships;
using StarshipfleetsAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using StarshipfleetsAPI.Models.Planets;
using StarshipfleetsAPI.BLL;

namespace StarshipfleetsAPI.Controllers 
{
    [RoutePrefix("Ships")]
    public class ShipController : ApiController
    {
        [Route("GetShipHulls")]
        [HttpGet]
        [ResponseType(typeof(List<ShipHulls>))]
        public IHttpActionResult GetShipHulls()
        {
            try
            {
                return Ok(ShipDAL.GetShipHulls()); ;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetShipPods")]
        [HttpGet]
        [ResponseType(typeof(List<ShipPods>))]
        public IHttpActionResult GetShipPods()
        {
            try
            {
                return Ok(ShipDAL.GetShipPods()); ;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetShipDesignDetails/{ShipDesignID}")]
        [HttpGet]
        [ResponseType(typeof(List<ShipDesignDetails>))]
        public IHttpActionResult GetShipDesignDetails(int ShipDesignID)
        {
            try
            {
                return Ok(ShipDAL.GetShipDesignDetails(ShipDesignID)); ;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("RemoveShipDesigns/{UserID}/{ShipDesignID}")]
        [HttpGet]
        [ResponseType(typeof(List<UserDesigns>))]
        public IHttpActionResult RemoveShipDesigns(int UserID, int ShipDesignID)
        {
            try
            {
                return Ok(ShipDAL.RemoveShipDesigns(UserID, ShipDesignID)); ;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetShipDesignbyUser/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(List<UserDesigns>))]
        public IHttpActionResult GetShipDesignbyUser(int UserID)
        {
            try
            {
                return Ok(ShipDAL.GetShipDesignbyUser(UserID)); ;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("AddShipDesigns")]
        [HttpPost]
        [ResponseType(typeof(List<UserDesigns>))]
        public IHttpActionResult AddShipDesigns([FromBody]UserDesigns design)
        {
            try
            {
                return Ok(ShipDAL.AddShipDesigns(design));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("AddShipDesignPods")]
        [HttpPost]
        [ResponseType(typeof(ShipDesignDetails))]
        public IHttpActionResult AddShipDesignPods([FromBody]List<AddShipPods> Pods)
        {
            try
            {
                return Ok(ShipDAL.AddShipDesignPods(Pods));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("AddShipQueue")]
        [HttpPost]
        [ResponseType(typeof(UserDesigns))]
        public IHttpActionResult AddShipQueue([FromBody]BuildingQue buildingQue)
        {
            try
            {
                return Ok(ShipBLL.AddShipQueue(buildingQue));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetUserFleets/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(UserDesigns))]
        public IHttpActionResult GetUserFleets(int UserID)
        {
            try
            {
                return Ok(ShipDAL.GetUserFleets(UserID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("GetSystemFleets/{System}")]
        [HttpGet]
        [ResponseType(typeof(UserDesigns))]
        public IHttpActionResult GetSystemFleets(string System)
        {
            try
            {
                return Ok(ShipDAL.GetUserFleets(null,null,null,System).FindAll(x => x.Status == 0));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("GetPlanetFleets/{UserID}/{PlanetID}")]
        [HttpGet]
        [ResponseType(typeof(List<Fleet>))]
        public IHttpActionResult GetPlanetFleets(int UserID, int PlanetID)
        {
            try
            {
                return Ok(ShipDAL.GetPlanetFleets(UserID, PlanetID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("MoveFleet/{UserID}/{FleetID}/{PlanetID}")]
        [HttpGet]
        [ResponseType(typeof(List<Fleet>))]
        public IHttpActionResult MoveFleet(int UserID, int FleetID, int PlanetID)
        {
            try
            {
                return Ok(ShipBLL.MoveFleet(UserID, FleetID, PlanetID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("FleetMoveComplete/{UserID}")]
        [HttpGet]
        [ResponseType(typeof(List<Fleet>))]
        public IHttpActionResult FleetMoveComplete(int UserID)
        {
            try
            {
                return Ok(ShipBLL.FleetMoveComplete(UserID));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }        
    }
}