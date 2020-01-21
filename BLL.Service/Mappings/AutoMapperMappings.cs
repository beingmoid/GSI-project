﻿using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.Service.Mappings
{
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {

			this.CreateMap<Role>();
			this.CreateMap<RoleRight>();
			this.CreateMap<User>();
			this.CreateMap<Team>();

		}

    }
	public static class ExtensionMethods
	{
		public static IMappingExpression<TEntity, TEntity> CreateMap<TEntity>(this Profile profile)
			where TEntity : IBaseEntity
		{
			var map = profile.CreateMap<TEntity, TEntity>()
				.ForMember(o => o.TenantId, o => o.Ignore())
				.ForMember(o => o.CreateTime, o => o.Ignore())
				.ForMember(o => o.CreateUserId, o => o.Ignore())
				.ForMember(o => o.EditTime, o => o.Ignore())
				.ForMember(o => o.EditUserId, o => o.Ignore())
				.ForMember(o => o.IsDeleted, o => o.Ignore())
				.ForMember(o => o.IsNew, o => o.Ignore())
				.ForMember(o => o.Timestamp, o => o.Ignore());

			var isIdAutoGenerated = (Attribute.GetCustomAttribute(typeof(TEntity).GetProperty("Id"), typeof(DatabaseGeneratedAttribute)) as DatabaseGeneratedAttribute)?
				.DatabaseGeneratedOption != DatabaseGeneratedOption.None;

			if (isIdAutoGenerated)
			{
				map.ForMember("Id", o => o.Ignore());
			}

			return map;
		}
	}
}
