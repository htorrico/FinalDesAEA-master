using Common.HttpHelpers;
using Domain.Models;
using Services.Implentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
   // [Authorize]
    public class UserController : ApiController
    {
        private UserService UserService = new UserService();

        // GET: api/User
        [HttpGet]
        public JsonResult<EResponseBase<User>> Get()
        {
            return Json(UserService.GetList());
        }

        // GET: api/User/5
        [HttpGet]
        public JsonResult<EResponseBase<User>> Get(int id)
        {
            return Json(UserService.Get(id));
        }

        // POST: api/User
        [HttpPost]
        public JsonResult<EResponseBase<User>> Post(User User)
        {
            return Json(UserService.Add(User));
        }

        // PUT: api/User/5
        [HttpPut]
        public JsonResult<EResponseBase<User>> Put(User User)
        {
            return Json(UserService.Update(User));
        }

        // DELETE: api/User/5
        [HttpDelete]
        public JsonResult<EResponseBase<User>> Delete(int id)
        {
            return Json(UserService.Delete(id));
        }
    }
}
