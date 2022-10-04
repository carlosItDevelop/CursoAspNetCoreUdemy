using AutoMapper;
using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Mvc.ServiceApp.ViewModels;

namespace Cooperchip.ITDeveloper.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            CreateMap<Triagem, TriagemViewModel>().ReverseMap();
        }
    }
}
