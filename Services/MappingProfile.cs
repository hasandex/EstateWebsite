
namespace EstateWebsite.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEstateVM, Estate>()
                .ForMember(src => src.Cover, opt => opt.Ignore())
                .ForMember(src => src.UserId, opt => opt.Ignore());

            CreateMap<UpdateEstateVM, Estate>()
                .ForMember(src => src.Cover, opt => opt.Ignore())
                .ForMember(src => src.UserId, opt => opt.Ignore());
            CreateMap<Estate, UpdateEstateVM>()
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover));
        }
    }
}
