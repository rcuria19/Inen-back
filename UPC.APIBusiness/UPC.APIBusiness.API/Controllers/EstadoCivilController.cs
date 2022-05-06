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
    [Route("api/EstadoCivil")]
    public class EstadoCivilController : Controller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IEstadoCivilRepository _EstadoCivilRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="EstadoCivil"></param>
        public EstadoCivilController(IEstadoCivilRepository estadoCivilRepository)
        {
            _EstadoCivilRepository = estadoCivilRepository;
        }


        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListEstadoCivil")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListEstadoCivil")]
        public ActionResult Get()
        {
            var ret = _EstadoCivilRepository.GetEstadoCivil();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

    }
}
