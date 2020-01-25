using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
   
    public class PlayerController : BaseController<User,string>
    {
        public PlayerController(RequestScope scopeContext,IPlayerService service)
            :base(scopeContext,service)
        {

        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] Player entity) 
        {
            entity.RoleId = 2;
            DAL.Entities.User u = new User()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password
            };
            List<DAL.Entities.User> li = new List<User>();
            li.Add(u);
           return new JsonResult((await  this.Service.Insert(li)));
        }
    }
}
