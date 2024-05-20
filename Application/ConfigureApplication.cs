using Application.Mapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public class ConfigureApplication
    {
        public static void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new JobMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}