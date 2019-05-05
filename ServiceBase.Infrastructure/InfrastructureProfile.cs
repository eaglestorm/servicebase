using AutoMapper;
using ServiceBase.Core.Model.Context;
using ServiceBase.Infrastructure.Records;

namespace ServiceBase.Infrastructure
{
    public class InfrastructureProfile: Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<ExampleRecord, ExampleModel>();
        }
    }
}