using AutoMapper;
using DatabseMastery.TransportMongoDb.Dtos.AboutDtos;
using DatabseMastery.TransportMongoDb.Dtos.BrandDtos;
using DatabseMastery.TransportMongoDb.Dtos.GetInTouchDtos;
using DatabseMastery.TransportMongoDb.Dtos.OfferDtos;
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


             CreateMap<Offer,ResultOfferDto>().ReverseMap();
            CreateMap<Offer, CreateOfferDto>().ReverseMap();
            CreateMap<Offer, UpdateOfferDto>().ReverseMap();
            CreateMap<Offer, GetOfferByIdDto>().ReverseMap();
            
            
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutByIdDto>().ReverseMap();


             CreateMap<GetInTouchSection, ResultGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouchSection, CreateGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouchSection, UpdateGetInTouchDto>().ReverseMap();
            CreateMap<GetInTouchSection, GetGetInTouchByIdDto>().ReverseMap();

        }


    }
}
