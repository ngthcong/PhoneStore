using AutoMapper;
using PhoneStore.Data;

using PhoneStore.Models;
using PhoneStore.Models.FormModel.User;
using PhoneStore.Models.ViewModel;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProtNameViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, CartItemViewModel>();
            CreateMap<ProSpecification, SpecViewModel>();
            CreateMap<ProVariant, VariantViewModel>();
            CreateMap<ProType, TypeViewModel>();
            CreateMap<ProBrand, BrandViewModel>();
            CreateMap<Account, UserViewModel>();
            CreateMap<SignupModel, Account>();
            CreateMap<VarImages, ImageViewModel>()
                .ForMember(des => des.Index, act => act.MapFrom(src => src.Index))
                .ForMember(des => des.Image, act => act.MapFrom(src => src.ImgPath));
            CreateMap<AddressCity, CityViewModel>();         
            CreateMap<AddressDistrict, DistrictViewModel>();   
            CreateMap<AddressWard, WardViewModel>();
            CreateMap<ProVariant, VariantViewModel>();
            
        }
    }
}
