using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopCine.Application.Features.Users.Commands;
using TopCine.Domain.Features.Users;
using TopCine.WebApi.ModelViews;

namespace TopCine.WebApi.Mappings.Users
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserAuthenticateModelView>();
            CreateMap<UserRegisterCommand, User>();
            CreateMap<User, UserModelView>();
        }
    }
}
