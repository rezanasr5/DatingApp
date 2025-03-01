using API.DTO;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUsers, MembersDto>()
            .ForMember(m=>m.Age,o=>o.MapFrom(u=>u.DateOfBirth.CalculateAge()))
            .ForMember(m => m.PhotoUrl, 
                o=> o.MapFrom(u=>u.Photos.FirstOrDefault(x=>x.IsMain)!.Url));
        
        CreateMap<Photo, PhotoDto>();
    }
}