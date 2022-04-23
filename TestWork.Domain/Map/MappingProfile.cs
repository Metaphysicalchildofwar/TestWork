using AutoMapper;
using TestWork.Dto.Base;
using TestWork.Dto.DesignObjects;

namespace TestWork.Domain.Map
{
    /// <summary>
    /// Конфигуратор моделей
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectEntity, DesignObjectWithoutIdDto>()
                .ReverseMap();

            CreateMap<ProjectEntity, BaseModelDto>()
                .ReverseMap();

            CreateMap<DesignObjectEntity, DesignObjectDto>()
                .ForMember(x => x.Project, opt => opt.MapFrom(s => s.Project))
                .ReverseMap();
        }
    }
}
