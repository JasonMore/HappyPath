using AutoMapper;
using HappyPath.Service.Models;
using HappyPath.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Maps
{
    public class PersonViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Person, PersonViewModel>();
            
            CreateMap<PersonViewModel, Person>();
        }
    }
}
