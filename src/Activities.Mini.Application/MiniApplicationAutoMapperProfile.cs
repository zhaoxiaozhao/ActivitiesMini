using Activities.Mini.WxActivities;
using AutoMapper;

namespace Activities.Mini;

public class MiniApplicationAutoMapperProfile : Profile
{
    public MiniApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<WxUser, WxUserRegisterDto>();
        CreateMap<WxUserRegisterDto, WxUser>();
        CreateMap<Activity, CreateUpdateActivityDto>();
        CreateMap<CreateUpdateActivityDto, Activity>();
        CreateMap<ActivityUserDto, ActivityUser>();
        CreateMap<ActivityUser, ActivityUserDto>();
        CreateMap<ActivityAppendix, ActivityAppendixDto>();
        CreateMap<ActivityAppendixDto, ActivityAppendix>();
    }
}
