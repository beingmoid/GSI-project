using System;
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

	public class LoginController : BaseController
	{
		private readonly ILoginService _loginService;
		public LoginController(RequestScope scopeContext, ILoginService loginService)
			: base(scopeContext, loginService)
		{
			_loginService = loginService;
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Post([FromBody] LoginInfo loginInfo)
		{
			return new JsonResult((await _loginService.Authenticate(loginInfo.Login, loginInfo.Password)));
			//return new JsonResult(new { isSucess = true, msg = "done" });
		}
	}
}
