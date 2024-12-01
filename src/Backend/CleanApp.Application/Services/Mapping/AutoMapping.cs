using AutoMapper;
using CleanApp.Communication.Requests;
using CleanApp.Domain.Entities;

namespace CleanApp.Application.Services.Mapping;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestUserCreateJson, Domain.Entities.User>()
            .ForMember(dest => dest.Password, options => options.Ignore());

    }
}
