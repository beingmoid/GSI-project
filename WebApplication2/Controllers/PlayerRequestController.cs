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
   
    public class PlayerRequestController : BaseController<PlayerRequest,int>
    {
        public PlayerRequestController(RequestScope scopeContext,IPlayerRequestService service)
            :base(scopeContext,service)
        {

        }
    }
}
