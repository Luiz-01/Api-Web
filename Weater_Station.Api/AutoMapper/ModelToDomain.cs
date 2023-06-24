using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_Station.Api.Models;
using Weather_Station.Domain.Entities;

namespace Weather_Station.Api.AutoMapper
{
    public class ModelToDomain : Profile
    {
        public ModelToDomain()
        {
            ConfigureMappings();
        }

        public void ConfigureMappings()
        {
            CreateMap<UsarioModel, tb_usu_usuario>().ReverseMap();
        }
    }
}
