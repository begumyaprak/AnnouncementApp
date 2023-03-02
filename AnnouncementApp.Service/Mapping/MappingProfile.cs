using AnnouncementApp.Data.Models;
using AnnouncementApp.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        
        {
            CreateMap<AnnouncementDto, Announcement>()
            .ReverseMap();


            CreateMap<LikeDto, Like>()
            .ReverseMap();


            CreateMap<CommentDto, Comment>()
            .ReverseMap();
        }
    }
}
