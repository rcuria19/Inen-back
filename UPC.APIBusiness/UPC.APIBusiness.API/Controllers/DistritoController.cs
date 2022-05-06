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
    [Produces("application/json")]
    [Route("api/Distrito")]
    public class DistritoController : Controller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IDistritoRepository _DistritoRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Distrito"></param>
        public DistritoController(IDistritoRepository distritoRepository)
        {
            _DistritoRepository = distritoRepository;

        }


        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListDistritos")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListDistritos")]
        public ActionResult Get()
        {
            var ret = _DistritoRepository.GetDistritos();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }


    }
}
