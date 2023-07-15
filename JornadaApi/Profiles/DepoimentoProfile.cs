using AutoMapper;
using JornadaApi.Data.Dtos;
using JornadaApi.Models;

namespace JornadaApi.Profiles
{
    public class DepoimentoProfile : Profile
    {
        public DepoimentoProfile() 
        {
            CreateMap<CreateDepoimentoDto, Depoimento>();
            CreateMap<UpdateDepoimentoDto, Depoimento>();
            CreateMap<Depoimento, UpdateDepoimentoDto>();
        }
    }
}
