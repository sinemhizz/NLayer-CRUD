using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();  //product<->productDto etkileşimi olabilir ya da reversemap yani tam tersi olabilir.
            CreateMap<Category,CategoryDto>().ReverseMap(); 
            CreateMap<ProductFeature,ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();   //geri dönüşe ihtiyaç olmadığı için reversemap yok
            CreateMap<Product,ProductWithCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>();
        
        }
    }
}
