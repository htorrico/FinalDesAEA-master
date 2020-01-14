using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using System.Threading;
using System.Web.Http;
using Common.HttpHelpers;
using Domain.Models;
using Models.Request;
using Services.Implentations;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private UserService UserService = new UserService();

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(Login_Request login)
        {

            bool isUserValid = false;
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            EResponseBase<User> eResponse = UserService.Login(login.Username, login.Password);

            if (eResponse.Code==200)
                isUserValid = true;
            //TODO: This code is only for demo - extract method in new class & validate correctly in your application !!
            //var isUserValid = (login.Username == "user" && login.Password == "123456");

            if (isUserValid)
            {             
                var token = TokenGenerator.GenerateTokenJwt(eResponse.Object.UserName, eResponse.Object.Role);
                return Ok(token);
            }


            //if (isUserValid)
            //{
            //    var rolename = "Developer";
            //    var token = TokenGenerator.GenerateTokenJwt(login.Username, rolename);
            //    return Ok(token);
            //}

            ////TODO: This code is only for demo - extract method in new class & validate correctly in your application !!
            //var isTesterValid = (login.Username == "test" && login.Password == "123456");
            //if (isTesterValid)
            //{
            //    var rolename = "Tester";
            //    var token = TokenGenerator.GenerateTokenJwt(login.Username, rolename);
            //    return Ok(token);
            //}

            ////TODO: This code is only for demo - extract method in new class & validate correctly in your application !!
            //var isAdminValid = (login.Username == "admin" && login.Password == "123456");
            //if (isAdminValid)
            //{
            //    var rolename = "Administrator";
            //    var token = TokenGenerator.GenerateTokenJwt(login.Username, rolename);
            //    return Ok(token);
            //}

            // Unauthorized access 
            return Unauthorized();
        }
    }
}