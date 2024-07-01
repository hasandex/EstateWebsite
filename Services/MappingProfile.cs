
namespace EstateWebsite.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateHomeVM, Home>()
                .ForMember(src => src.Cover, opt => opt.Ignore())
                .ForMember(src => src.UserId, opt => opt.Ignore());

            CreateMap<UpdateHomeVM, Home>()
                .ForMember(src => src.Cover, opt => opt.Ignore())
                .ForMember(src => src.UserId, opt => opt.Ignore());
            CreateMap<Home, UpdateHomeVM>()
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover));
        }
    }
}
