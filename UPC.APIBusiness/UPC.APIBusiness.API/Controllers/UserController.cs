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
using UPC.APIBusiness.DBEntity.Model;
using UPC.E31A.APIBusiness.API.Security;

namespace UPC.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListUser")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListUser")]
        public ActionResult Get()
        {
            var ret = _UserRepository.GetUsers();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLogin login)
        {
            var ret = _UserRepository.Login(login);

            if (ret.isSuccess)
            {
                var loginresponse = ret.data as EntityLoginResponse;
                var usrid = loginresponse.idusuario.ToString();
                var usrdni = loginresponse.documentoidentidad;

                var token = JsonConvert.DeserializeObject<AccessToken>(
                        await new Authentication().GenerateToken(usrdni, usrid)
                    ).access_token;

                loginresponse.token = token;
                ret.data = loginresponse;
            }

            return Json(ret);
        }
    }
}