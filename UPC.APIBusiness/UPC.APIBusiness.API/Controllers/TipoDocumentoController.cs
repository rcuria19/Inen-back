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

namespace API
{
    [Produces("application/json")]
    [Route("api/TipoDocumento")]
    public class TipoDocumentoController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly ITipoDocumentoRepository _TipoDocumentoRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="TipoDocumento"></param>
        public TipoDocumentoController(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _TipoDocumentoRepository = tipoDocumentoRepository;

        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListTipoDocumento")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListTipoDocumento")]
        public ActionResult Get()
        {
            var ret = _TipoDocumentoRepository.GetTipoDocumentos();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }


    }
}
