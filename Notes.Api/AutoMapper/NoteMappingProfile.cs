using Notes.Api.Model;
using Notes.Api.Repository.Entities;
using AutoMapper;
namespace Notes.Api.AutoMapper
{
    public class NoteMappingProfile:Profile
    {
        public NoteMappingProfile()
        {
            CreateMap<NoteModel, Note>()
                //.ForMember(dest => dest.ModifiedBy, act => act.MapFrom(src => src.ModifiedBy)) 
                .ReverseMap();
        }
    }
}
