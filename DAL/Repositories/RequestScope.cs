using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public class RequestScope
	{
		public RequestScope(IServiceProvider serviceProvider, ILogger logger, IMapper mapper, string userId)
		{
			this.ServiceProvider = serviceProvider;
			this.UserId = userId;
			//this.TenantId = tenantId;
			this.Mapper = mapper;
			this.Logger = logger;
		}

		public IServiceProvider ServiceProvider { get; }
		public string UserId { get; }
		//public int? TenantId { get; }
		public IMapper Mapper { get; }
		public ILogger Logger { get; }
	}

	public class RequestScope<Context> : RequestScope
		where Context : EfContext
	{
		public RequestScope(IServiceProvider serviceProvider, Context context, ILogger logger, IMapper mapper, string userId)
			: base(serviceProvider, logger, mapper, userId)
		{
			this.DbContext = context;
		}

		public Context DbContext { get; }
	}
}
