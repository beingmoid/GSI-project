using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL.Service.Services;
using CSGSI;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
   
    public class GameStateController : BaseController
    {
        public GameStateController(RequestScope scopeContext, IGameStateService service)
            :base(scopeContext,service)
        {

        }
        List<GameState> li = new List<GameState>();

        [HttpPost("State")]
        public ActionResult Post([FromBody] string gameState)
        {
            var GameState = new GameState(gameState);
            li.Add(GameState);
            return Ok();
        }
        [HttpGet]
        public ActionResult Get() => new JsonResult(li);
    }
}
