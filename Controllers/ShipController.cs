using StarshipfleetsAPI.Models.Ships;
using StarshipfleetsAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

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
    }
}