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

        CreateMap<WxUser, WxUserDto>();
        CreateMap<WxUserDto, WxUser>();

        CreateMap<Activity, ActivityDto>();
        CreateMap<ActivityDto, Activity>();

        CreateMap<Activity, CreateUpdateActivityDto>();
        CreateMap<CreateUpdateActivityDto, Activity>();

        CreateMap<ActivityAppendix, CreateUpdateAppendixDto>();
        CreateMap<CreateUpdateAppendixDto, ActivityAppendix>();

        CreateMap<ActivityUserDto, ActivityUser>();
        CreateMap<ActivityUser, ActivityUserDto>();

        CreateMap<ActivityAppendix, ActivityAppendixDto>();
        CreateMap<ActivityAppendixDto, ActivityAppendix>();
    }
}
