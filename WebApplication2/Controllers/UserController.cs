﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
   
    public class UserController : BaseController<User,string>
    {
        public UserController(RequestScope scopeContext,IUserService service)
            :base(scopeContext,service)
        {

        }

        [AllowAnonymous]
        public override Task<ActionResult> Get(string id)
        {
            return base.Get(id);
        }
    }
}
