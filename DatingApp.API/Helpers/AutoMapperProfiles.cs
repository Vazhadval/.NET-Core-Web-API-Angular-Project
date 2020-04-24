using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(destinationMember => destinationMember.PhotoUrl, IMappingOperationOptions =>
                     IMappingOperationOptions.MapFrom(sourceMember => sourceMember.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(destinationMember => destinationMember.Age, IMappingOperationOptions =>
                     IMappingOperationOptions.MapFrom(sourceMember => sourceMember.DateOfBirth.CalculateAge()));


            CreateMap<User, UserForDetailsDto>()
                .ForMember(destinationMember => destinationMember.PhotoUrl, IMappingOperationOptions =>
                     IMappingOperationOptions.MapFrom(sourceMember => sourceMember.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(destinationMember => destinationMember.Age, IMappingOperationOptions =>
                     IMappingOperationOptions.MapFrom(sourceMember => sourceMember.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotosForDetailsDto>();
        }
    }
}