using AutoMapper;
using Elipgo.ShoeStock.Api.Dtos.Responses;
using Elipgo.ShoeStock.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Store, StoreDto>();
            CreateMap<Article, ArticleDto>().ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name));
        }
    }
}
