using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_Station.Api.Models;
using Weather_Station.Domain.Entities;

namespace Weather_Station.Api.AutoMapper
{
    public class DomainToModel : Profile
    {
        public DomainToModel()
        {
            ConfigureMappings();
        }

        public void ConfigureMappings()
        {
            CreateMap<tb_usu_usuario, UsarioModel>().ReverseMap();
        }
    }
}
