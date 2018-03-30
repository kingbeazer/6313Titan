using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using _6313Titan.Models;
using _6313Titan.DTOs;

namespace _6313Titan.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Case, CaseDTO>();
            CreateMap<CaseDTO, Case>();
        }
    }
}