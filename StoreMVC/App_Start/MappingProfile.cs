using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StoreMVC.Dtos;
using StoreMVC.Models;

namespace StoreMVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
        }
    }
}