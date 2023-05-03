using AutoMapper;
using polyclinic.Dto;
using polyclinic.Models;

namespace polyclinic.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Medic, MedicDto>()
                .ForMember(d => d.Photo, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsPrimary).ImageUrl));
            CreateMap<Polyclinic, PolyclinicDto>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(d => d.Photo, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsPrimary).ImageUrl));
            CreateMap<Specialization, SpecializationDto>()
                .ForMember(d => d.MedicName, opt => opt.MapFrom(src => src.Medic.FullName))
                .ForMember(d => d.Photo, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsPrimary).ImageUrl));
        }
    }
}