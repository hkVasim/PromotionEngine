using AutoMapper;
using Promotion.Model;
using PromotionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductForCreateDTO, Product>();
        }
    }
}
