using Application.DTOs;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class JobMapper : Profile
    {
        public JobMapper()
        {
            CreateMap<Job, JobDTO>().ReverseMap();
        }
    }
}
