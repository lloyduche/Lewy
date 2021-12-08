using AutoMapper;
using Lewy.Core;
using Lewy.Core.DTOs;
using Lewy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LewyApi.Helpers
{
    public class AutoMappersProfiles: Profile
    {

        public AutoMappersProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest =>
                        dest.PhotoUrl, opt =>
                                opt.MapFrom(src =>
                                           src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest =>
                            dest.Age, opt =>
                                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
        }
        
    }
}
