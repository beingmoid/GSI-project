using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
   
    public class GameStateController : ControllerBase
    {
        public GameStateController(RequestScope scopeContext,)
        {

        }
        public Task<ActionResult> Post([FromBody]object state)
        {

            return new JsonResult("");
        }
    }
}
