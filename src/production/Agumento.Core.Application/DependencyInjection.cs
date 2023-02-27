using Agumento.Core.Application.AutoMapperProfile;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agumento.Core.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(ScheduleInterviewMapperProfile));
            services.AddAutoMapper(typeof(OpenPositionMapperProfile));
            services.AddAutoMapper(typeof(OpenPositionReportMapperProfile));
        }
    }
}
