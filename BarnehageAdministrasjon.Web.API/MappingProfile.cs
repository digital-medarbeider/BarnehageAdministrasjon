using AutoMapper;
using BarnehageAdministrasjon.Models;
using BarnehageAdministrasjon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarnehageAdministrasjon.Web.API
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Application, ApplicationViewModel>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<Municipality, MunicipalityViewModel>();
            CreateMap<ApplicationKindergartenCoverage, ApplicationKindergartenCoverageViewModel>();
            CreateMap<ApplicationSpecRequirement, ApplicationSpecRequirementViewModel>();
            CreateMap<SpecialRequirement, SpecialRequirementViewModel>();
            CreateMap<WeekDay, WeekDayViewModel>();
        }
    }
}
