using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;

namespace WebApplication1.Configration
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserViewModel>().ReverseMap();
            CreateMap<Posts, PostViewModel>().ReverseMap();
        }


    }
}
