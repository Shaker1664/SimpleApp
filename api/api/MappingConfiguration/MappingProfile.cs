using api.Entities;
using api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.MappingConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUser, User>();
            CreateMap<User, UserIndex>();
            CreateMap<Product, ProductDetails>();
            CreateMap<Product, ProductIndex>();
        }
    }
}
