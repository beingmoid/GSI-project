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
using Microsoft.AspNetCore.Hosting;
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
        public PlayerController(RequestScope scopeContext,IPlayerService service, IHostingEnvironment environment,
             IFileProvider fileProvider)
            :base(scopeContext,service)
        {
            _env = environment;
            _fileProvider = fileProvider;
            playerService = service;
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
        public async Task<ActionResult> GetConfig(string Id)
        {

            //string[] arr = streams.Split('\n');
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i].Contains("token"))
            //    {
            //        string[] split = arr[i].Split('"');
            //        string temp = "";
            //        for (int j = 0; j < split.Length; j++)
            //        {
            //            if (split[j]=="token")
            //            {
            //                split[j] += " " +'"'+ user.token+'"';
            //                temp = split[j].ToString();
            //                break;
            //            }

            //        }
            //        arr[i] = temp;
            //        break;
            //    }
            //}
            //               var test = @"

            //           \u0022CS: GO Service Integration 0.1\u0022A
            //           {
            //               \u0022uri\u0022 \u0022 http://localhost:62443/api/Values \u0022
            //               \u0022timeout\u0022 \u00225.0\u0022
            //\u0022buffer\u0022  \u0022 0.0\u0022
            //\u0022throttle\u0022 \u0022 0.01\u0022
            //\u0022heartbeat\u0022 \u0022 0.01\u0022
            //\u0022auth\u0022
            //{
            //                   \u0022token\u0022  \u0022 " + user.token + @" \u0022

            //}
            //\u0022data\u0022
            //{
            //                   \u0022provider\u0022                  \u0022 1\u0022

            //   \u0022map\u0022                       

            //   \u0022round\u0022                     

            //   \u0022player_id\u0022                \u0022 1\u0022

            //   \u0022player_state\u0022              \u0022 1\u0022

            //   \u0022player_weapons\u0022            \u0022 1\u0022

            //   \u0022player_match_stats\u0022       \u0022 1\u0022

            //   \u0022allplayers_id\u0022             \u0022 1\u0022

            //   \u0022allplayers_state\u0022          \u0022 1\u0022

            //   \u0022allplayers_match_stats\u0022    \u0022 1\u0022
            //}
            //           }
            //                   ";

            //var bytes = Encoding.ASCII.GetBytes(arr.ToString());
            //var 
            var user = await this.Service.GetOne(x => x.Id == Id);
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

        [HttpGet("FilterList")]
        public async Task<ActionResult> FilterList(string searchValue) => new JsonResult((await playerService.FilterList(searchValue)));
    }
}
