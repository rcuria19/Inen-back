using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>

    [Produces("application/json")]
    [Route("api/Ecografia")]
    public class EcografiaController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IEcografiaRepository _EcografiaRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="EcografiaRepository"></param>
        public EcografiaController(IEcografiaRepository EcografiaRepository)
        {
            _EcografiaRepository = EcografiaRepository;
        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetEcografia")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetEcografia")]
        public ActionResult Get()
        {
            var ret = _EcografiaRepository.GetEcografia();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ecografiaI"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insertar")]
        public ActionResult Insert(EntityEcografia ecografiaI)
        {
            var ret = _EcografiaRepository.Insert(ecografiaI);
            return Json(ret);
        }


    }
}
