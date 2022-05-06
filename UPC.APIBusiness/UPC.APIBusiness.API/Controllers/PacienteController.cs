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
    [Route("api/Paciente")]
    public class PacienteController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IPacienteRepository _PacienteRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Paciente"></param>
        public PacienteController(IPacienteRepository PacienteRepository)
        {
            _PacienteRepository = PacienteRepository;
        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetPacientes")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetPacientes")]
        public ActionResult Get()
        {
            var ret = _PacienteRepository.GetPacientes();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insertar")]
        public ActionResult Insert(EntityPaciente paciente)
        {
            var ret = _PacienteRepository.Insert(paciente);
            return Json(ret);
        }


    }
}
