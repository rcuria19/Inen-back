using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPC.APIBusiness.DBContext.Interface;
using UPC.APIBusiness.DBEntity.Model;


namespace UPC.APIBusiness.API.Controllers
{
    [Produces("application/json")]
    [Route("api/historialmedico")]
    [ApiController]
    public class HistorialMedico : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IHistorialMedicoRepository _HistorialMedico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HistorialMedicoRepository"></param>
        public HistorialMedico(IHistorialMedicoRepository HistorialMedicoRepository)
        {
            _HistorialMedico = HistorialMedicoRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="historalMedico"></param>
        /// <returns></returns>
        [Produces("application/json")]
        //[AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityHistorialMedico historalMedico)
        {
            var ret = _HistorialMedico.Insert(historalMedico);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        //[Authorize]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetHistorial()
        {
            var ret = _HistorialMedico.GetHistorial();
            return Json(ret);
        }

    }
}
