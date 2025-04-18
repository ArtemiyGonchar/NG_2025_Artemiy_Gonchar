using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using StoreManagmentBL.Enums;
using StoreManagmentBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentBL.Profiles
{
    public class StoreManagmentMappingProfile : Profile
    {
        public StoreManagmentMappingProfile()
        {
            CreateMap<Store, StoreDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Location, opt => opt.Ignore());

            CreateMap<Pet, PetDto>();

            CreateMap<ContractType, ContractTypeBL>().ReverseMap();
            CreateMap<Vendor, VendorDto>().ReverseMap();
        }
    }
}
