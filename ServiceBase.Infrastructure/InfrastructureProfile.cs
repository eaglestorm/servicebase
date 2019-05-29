using AutoMapper;
using CleanDdd.Common.Model.Identity;
using ServiceBase.Core.Model.Context;
using ServiceBase.Infrastructure.Records;

namespace ServiceBase.Infrastructure
{
    public class InfrastructureProfile: Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<ExampleRecord, ExampleModel>();
            CreateMap<long, LongIdentity>().ConstructUsing(x=> new LongIdentity(x));
        }
    }
}