using AutoMapper;
using Repository.Configurations;

public class AutoMapperConfiguration
{
    public static void Configure()
    {
        Mapper.Initialize(x =>
        {
            x.AddProfile<MyMappings>();
        });
    }
}
