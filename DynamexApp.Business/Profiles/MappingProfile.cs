using AutoMapper;
using DynamexApp.Business.DTOs.BrandDto;
using DynamexApp.Business.DTOs.CountryDTO;
using DynamexApp.Business.DTOs.LanguageDTO;
using DynamexApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LanguagePostDTO, Language>();
            CreateMap<Language, LanguageGetDTO>();
            CreateMap<CountryPostDTO, Country>();
            CreateMap<Country, CountryGetDto>();
            CreateMap<CountryEditDTO, Country>();
            CreateMap<BrandPostDto, Brand>();
            CreateMap<Brand, BrandGetDTO>();
            CreateMap<Brand, BrandListItemDto>();
        }
    }
}
