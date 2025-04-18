using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using PetStoreBL.Enums;
using PetStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreBL.Profiles
{
    public class PetStoreMappingProfile : Profile
    {
        public PetStoreMappingProfile()
        {
            CreateMap<Pet, PetStoreDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Breed, opt => opt.MapFrom(src => src.Breed))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.StoreId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PetTypes, PetTypesBL>().ReverseMap();
        }
    }
}
