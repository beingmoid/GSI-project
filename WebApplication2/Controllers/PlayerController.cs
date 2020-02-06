using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Service;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace WebApplication2.Controllers
{
   
    public class PlayerController : BaseController<User,string>
    {
        private IHostingEnvironment _env;
        private IFileProvider _fileProvider;
        private readonly IPlayerService playerService;
        private IHttpContextAccessor _httpContextAccessor;
        public PlayerController(RequestScope scopeContext,IPlayerService service, IHostingEnvironment environment,
             IFileProvider fileProvider,
             IHttpContextAccessor httpContextAccessor)
            :base(scopeContext,service)
        {
            _env = environment;
            _fileProvider = fileProvider;
            playerService = service;
            _httpContextAccessor = httpContextAccessor;
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
        [HttpGet("GetConfig")]
        public async Task<ActionResult> GetConfig()
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "UserId")?.Value;
            var user = await this.Service.GetOne(x => x.Id == UserId);
            if (user != null)
            {

                var test = System.IO.File.ReadAllText(_env.ContentRootPath + @"\\AppData\\gamestate_integration_testv1" + ".txt");
                System.IO.File.WriteAllText(_env.ContentRootPath + "\\AppData\\" + user.token + ".cfg", test.Replace("{token_here}", user.token.ToString()));
                //string name = 

                test = System.IO.File.ReadAllText(_env.ContentRootPath + @"\\AppData\\gamestate_integration_testv1" + ".txt");
                string path = _env.ContentRootPath + "\\AppData\\" + user.token + ".cfg";
              //  IFileProvider provider = new PhysicalFileProvider("\\AppData\\" + user.token);
               IFileInfo fileInfo = _fileProvider.GetFileInfo("\\AppData\\" + user.token+ ".cfg");
                var readStream = fileInfo.CreateReadStream();
                //return File(path, "text/plain", "config.cfg");
                using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(test)))
                {
                    mem.Position = 0;
                    using (var sr = new StreamReader(mem))
                    {
                        return File(readStream, "text/plain", "gamestate_integration_test.cfg");
                    }
                   
                } 
                //var stream = System.IO.File.OpenRead(path);
                //return new FileStreamResult(stream, "application/octet-stream");
            }
            else
            {
                throw new ServiceException("User not found");
            }
        }

        
      
        [HttpGet("GetConfigInText")]
        public async Task<ActionResult> GetConfigText()
        {
         
            var UserId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "UserId")?.Value;
            var user = await this.Service.GetOne(x => x.Id == UserId);
            var test = System.IO.File.ReadAllText(_env.ContentRootPath + @"\\AppData\\gamestate_integration_testv1" + ".txt");
            System.IO.File.WriteAllText(_env.ContentRootPath + "\\AppData\\" + user.token + ".cfg", test.Replace("{token_here}", user.token.ToString()));
            test = System.IO.File.ReadAllText(_env.ContentRootPath + "\\AppData\\" + user.token + ".cfg");
            return new JsonResult(_env.ContentRootPath + "\\AppData\\" + user.token + ".cfg");
        }

        [HttpGet("FilterList")]
        public async Task<ActionResult> FilterList(string searchValue) => new JsonResult((await playerService.FilterList(searchValue)));
    }
}
