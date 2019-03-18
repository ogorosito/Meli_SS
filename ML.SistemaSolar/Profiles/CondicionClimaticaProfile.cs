using AutoMapper;
using ML.SistemaSolar.DTOs;
using ML.SistemaSolar.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Profiles
{
    public class CondicionClimaticaProfile : Profile
    {
        private const string LLUVIA = "Lluvia";
        private const string SEQUIA = "Sequia";
        private const string CONDICIONES_OPTIMAS = "Condiciones Óptimas de Temperatura";
        private const string SIN_CONDICIONES = "";


        public CondicionClimaticaProfile()
        {
            CreateMap<CondicionClimatica, ClimaResponse>()
                .ForMember(d => d.Clima, o => o.MapFrom(s => 
                s.EsPeriodoDeLluvia ? LLUVIA : 
                s.EsPeriodoDeSequia ? SEQUIA : 
                s.HayCondicionesOptimasDeTemperatura ? CONDICIONES_OPTIMAS : SIN_CONDICIONES));
        }
    }
}
