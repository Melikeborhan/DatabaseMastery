using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.BrandDtos;
using DatabseMastery.TransportMongoDb.Dtos.SliderDtos;
using DatabseMastery.TransportMongoDb.Entities;

namespace DatabseMastery.TransportMongoDb.Mapping
{
    public class GeneralMapping: Profile //AutoMapper'ın Profile sınıfı, mapping konfigürasyonlarını tanımlamak için kullanılır.
    {
        public GeneralMapping()
        {
            CreateMap<Slider,ResultSliderDto>().ReverseMap();
            CreateMap<Slider,CreateSliderDto>().ReverseMap();
            CreateMap<Slider,UpdateSliderDto>().ReverseMap();
            CreateMap<Slider,GetSliderByIdDto>().ReverseMap();


            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetBrandByIdDto>().ReverseMap();

        }


    }
}
