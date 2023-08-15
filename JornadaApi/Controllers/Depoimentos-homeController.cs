using AutoMapper;
using JornadaApi.Data;
using JornadaApi.Images;
using Microsoft.AspNetCore.Mvc;

namespace JornadaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Depoimentos_homeController : ControllerBase
    {
        private DepoimentoContext _depomentoContext;
        private Img _img;
        private Mapper _mapper;

        public Depoimentos_homeController(DepoimentoContext context, Mapper mapper)
        {
            _depomentoContext = context;
            _mapper = mapper;
        }
    }
}
